namespace CrudProduto.Models
{
	public class AcessorioBasico : EntidadeDominio
	{
		public  string nome{ get; set; }
		public string descricao { get; set; }
		public int quantidade { get; set; }
		public LinhaPrdouto linhaPrdouto { get; set; }

		public AcessorioBasico()
		{

		}

		public AcessorioBasico(string nome, string descricao, int quantidade, LinhaPrdouto linhaPrdouto)
		{
			this.nome = nome;
			this.descricao = descricao;
			this.quantidade = quantidade;
			this.linhaPrdouto = linhaPrdouto;
		}
	}
}
