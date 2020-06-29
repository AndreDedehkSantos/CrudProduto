namespace CrudProduto.Models
{
	public class FichaTecnica
	{
		public string descricao { get; set; }
		public string componenteBasico { get; set; }
		public string componentePrimario { get; set; }
		public string componenteSecundario { get; set; }
		public string categoria { get; set; }
		public string subCategoria { get; set; }
		public Produto produto { get; set; }

		public FichaTecnica()
		{

		}

		public FichaTecnica(string descricao, string componenteBasico, string componentePrimario, string componenteSecundario, string categoria, string subCategoria, Produto produto)
		{
			this.descricao = descricao;
			this.componenteBasico = componenteBasico;
			this.componentePrimario = componentePrimario;
			this.componenteSecundario = componenteSecundario;
			this.categoria = categoria;
			this.subCategoria = subCategoria;
			this.produto = produto;
		}
	}

}
