import { Component, OnInit } from '@angular/core';
import { Produto } from "../modelo/produto";
import { ProdutoServico } from '../servicos/produto/produto.servico';

@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})
export class ProdutoComponent implements OnInit {
  public produto: Produto;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public mensagem: string;

  constructor(private produtoServico: ProdutoServico) {

  }

  ngOnInit(): void {
    this.produto = new Produto();
  }

  public cadastrar() {
    this.ativar_spinner = true;
    this.produtoServico.cadastrar(this.produto)
      .subscribe(
        produtoJson => {
          console.log(produtoJson);
          this.ativar_spinner = false;
        },
        e => {
          console.log(e.error);
          this.ativar_spinner = false;
          this.mensagem = e.error;
        }
      );
  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.ativar_spinner = true;
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {
          this.produto.nomeArquivo = nomeArquivo;
          console.log(nomeArquivo);
          alert(nomeArquivo);
          this.ativar_spinner = false;
        },
        e => {
          this.ativar_spinner = false;
          this.mensagem = e.error;
          console.log('Mensagem: [' + this.mensagem + ']');
        }
      );
  }
}
