namespace CrudProduto.Models
{
	public class Usuario : EntidadeDominio
	{
		public string nome { get; set; }
		public string senha1 { get; set; }
		public string senha2 { get; set; }

		public Usuario()
		{

		}

		public Usuario(string nome, string senha1, string senha2)
		{
			this.nome = nome;
			this.senha1 = senha1;
			this.senha2 = senha2;
		}
	}
}
