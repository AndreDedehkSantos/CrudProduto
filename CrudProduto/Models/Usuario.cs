namespace CrudProduto.Models
{
	public class Usuario
	{
		public string nome { get; set; }
		public string senha { get; set; }

		public Usuario()
		{

		}

		public Usuario(string nome, string senha)
		{
			this.nome = nome;
			this.senha = senha;
		}
	}
}
