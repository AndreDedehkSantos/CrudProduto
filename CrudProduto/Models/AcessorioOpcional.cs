namespace CrudProduto.Models
{
	public class AcessorioOpcional : EntidadeDominio
	{
		public string nome { get; set; }
		public string descricao { get; set; }
		public int quantidade { get; set; }
		public Produto produto { get; set; }

		public AcessorioOpcional()
		{

		}

		public AcessorioOpcional(string nome, string descricao, int quantidade, Produto produto)
		{
			this.nome = nome;
			this.descricao = descricao;
			this.quantidade = quantidade;
			this.produto = produto;
		}
	}
}
