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
    }
}
