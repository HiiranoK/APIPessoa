using Dapper;
using MySqlConnector;

namespace APIPessoa.Repository
{
    public class PessoaRepository
    {
        public List<Pessoa> SelecionarPessoas() {

            // o comando que quero
            string query = "SELECT * FROM Pessoa";

            //variável de conexão
            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);        

            return conn.Query<Pessoa>(query).ToList();
        }

        public List<Pessoa> SelecionarPessoa(string nome)
        {
            string query = $"select * from Pessoa where nome='{nome}'";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            return conn.Query<Pessoa>(query).ToList();
        }

        public void InserirPessoa(Pessoa pessoa) 
        {
            string query = "insert into Pessoa(nome,dataNascimento,quantidadeFilhos,idade) " +
                $"values('{pessoa.Nome}','{pessoa.DataNascimento.ToString("yyyy,MM,dd")}',{pessoa.filhos})";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            conn.ExecuteScalar(query);
            
        }

        public void DeletarPessoa(string Nome)
        {
            string query = $"DELETE FROM Pessoa WHERE nome = '{Nome}'";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            conn.Execute(query);

        }

        public void AlterarPessoa(string nome, Pessoa pessoa)
        {
            string query = $"UPDATE Pessoa SET nome = '{pessoa.Nome}', dataNascimento ='{pessoa.DataNascimento.ToString("yyyy,MM,dd")}', quantidadeFilhos={pessoa.filhos} WHERE nome='{nome}'";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            conn.Execute(query);

        }
    }
}
