using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Classes
{
    public class Filme : EntidadeBase
    {
		private int duracaoMinutos { get; set; }

		public Filme(int id, Genero genero, string titulo, string descricao, int ano, int duracaoMinutos)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.duracaoMinutos = duracaoMinutos;
			this.Excluido = false;
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "id: " + this.Id + Environment.NewLine;
			retorno += "Gênero: " + this.Genero + Environment.NewLine;
			retorno += "Titulo: " + this.Titulo + Environment.NewLine;
			retorno += "Descrição: " + this.Descricao + Environment.NewLine;
			retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
			retorno += "Duracao em Minutos" + this.duracaoMinutos + Environment.NewLine;
			retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

		public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}

		public bool retornaExcluido()
		{
			return this.Excluido;
		}

		public void Excluir()
		{
			this.Excluido = true;
		}
	}
}
