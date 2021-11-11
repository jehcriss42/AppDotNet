using DIO.Series.Classes;
using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
	static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
	static void Main()
        {
			string selecionafilmeOuSerie = SelecionarFilmeOuSerie();
			var flmeouSerie = "";

			while (flmeouSerie == "")
			{
				switch (selecionafilmeOuSerie)
				{
					case "1":
						flmeouSerie = "Filme";
						break;

					case "2":
						flmeouSerie = "Serie";
						break;
					default:
						Console.WriteLine("Opção Inválida");
						break;
				}

				if (flmeouSerie != "")
					break;

				selecionafilmeOuSerie = SelecionarFilmeOuSerie();

			}

			string opcaoUsuario = GerenciarFilmesOuSeries();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listar(flmeouSerie);
						break;
					case "2":
						Inserir(flmeouSerie);
						break;
					case "3":
						Atualizar(flmeouSerie);
						break;
					case "4":
						Excluir(flmeouSerie);
						break;
					case "5":
						Visualizar(flmeouSerie);
						break;
					case "C":
						Console.Clear();
						break;
					default:
						Console.WriteLine("Opção Inválida");
						break;
				}

				opcaoUsuario = GerenciarFilmesOuSeries();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        #region metodos
        private static void Excluir(string filmeOuSerie)
		{
			Console.Write($"Digite o id correspondente - {filmeOuSerie}: ");
			int indice = int.Parse(Console.ReadLine());

			if (filmeOuSerie == "Filme")
				repositorioFilme.Exclui(indice);
			else if (filmeOuSerie == "Serie")
				repositorioSerie.Exclui(indice);
		}
	    
        private static void Visualizar(string filmeOuSerie)
		{
			Console.Write($"Digite o id correspondente - {filmeOuSerie}: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			if (filmeOuSerie == "Filme")
            		{
				Filme item = repositorioFilme.RetornaPorId(indiceSerie);
				Console.WriteLine(item);
			}

			if (filmeOuSerie == "Serie")
            		{
				Serie item = repositorioSerie.RetornaPorId(indiceSerie);
				Console.WriteLine(item);
			}
		}
	    
		private static void Atualizar(string filmeOuSerie)
		{
			Console.Write($"Digite o id correspondente - {filmeOuSerie}: ");
			int indice = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			if (filmeOuSerie == "Serie")
			{
				Console.Write("Digite a quantidade de temporada da Série: ");
				int qtdeTemporada = int.Parse(Console.ReadLine());

				Serie atualizaSerie = new Serie(id: indice,
								genero: (Genero)entradaGenero,
								titulo: entradaTitulo,
								ano: entradaAno,
								descricao: entradaDescricao,
								qtdeTemporada: qtdeTemporada);

				repositorioSerie.Atualiza(indice, atualizaSerie);
			}

			if (filmeOuSerie == "Filme")
			{
				Console.Write("Digite a duracao do Filme: ");
				int duracaoMinutos  = int.Parse(Console.ReadLine());

				Filme atualizafilme = new Filme(id: indice,
								genero: (Genero)entradaGenero,
								titulo: entradaTitulo,
								ano: entradaAno,
								descricao: entradaDescricao,
								duracaoMinutos: duracaoMinutos);

				repositorioFilme.Atualiza(indice, atualizafilme);
			}
		}
	    
        private static void Listar(string filmeOuSerie)
		{
			Console.WriteLine($"Listar {filmeOuSerie}");

             		if (filmeOuSerie == "Serie")
            		{
				List<Serie> series = repositorioSerie.Lista();

				if (series.Count == 0)
				{
					Console.WriteLine("Nenhuma série cadastrada.");
					return;
				}
				foreach (var serie in series)
					Console.WriteLine(serie);
			}
			 else if (filmeOuSerie == "Filme")
            		{
				List<Filme> filmes = repositorioFilme.Lista();

				if (filmes.Count == 0)
				{
					Console.WriteLine("Nenhum filme cadastrado.");
					return;
				}

				foreach(var filme in filmes)
					Console.WriteLine(filme);
			}
		}
	    
		private static void Inserir(string filmeOuSerie)
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write(Environment.NewLine + "Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			if (filmeOuSerie == "Serie")
			{
				Console.Write("Digite a quantidade de temporada da Série: ");
				int qtdeTemporada = int.Parse(Console.ReadLine());

				Serie InsereSerie = new Serie(id: repositorioSerie.ProximoId(),
								genero: (Genero)entradaGenero,
								titulo: entradaTitulo,
								ano: entradaAno,
								descricao: entradaDescricao,
								qtdeTemporada: qtdeTemporada);

				repositorioSerie.Insere(InsereSerie);
			}

			else if (filmeOuSerie == "Filme")
			{
				Console.Write("Digite a duracao do Filme: ");
				int duracaoMinutos = int.Parse(Console.ReadLine());

				Filme inserefilme = new Filme(id: repositorioFilme.ProximoId(),
								genero: (Genero)entradaGenero,
								titulo: entradaTitulo,
								ano: entradaAno,
								descricao: entradaDescricao,
								duracaoMinutos: duracaoMinutos);

				repositorioFilme.Insere(inserefilme);
			}
		}
		#endregion

		private static string GerenciarFilmesOuSeries()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar");
			Console.WriteLine("2- Inserir");
			Console.WriteLine("3- Atualizar");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	    
		private static string SelecionarFilmeOuSerie()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Filme");
			Console.WriteLine("2- Serie");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();

			Console.WriteLine();
			return opcaoUsuario;
		}

	}
}
