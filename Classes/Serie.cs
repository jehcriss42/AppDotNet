using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
		private int qtdeTemporada { get; set; }

		public Serie(int id, Genero genero, string titulo, string descricao, int ano, int qtdeTemporada)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.qtdeTemporada = qtdeTemporada;
			this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
			retorno += "Id: " + this.Id + Environment.NewLine;
			retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
			retorno += "Quantidade de Temporada" + this.qtdeTemporada + Environment.NewLine;
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