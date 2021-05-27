using MySqlConnector;
using System;


namespace WebApplication1.Models
{
    public class Conexao
    {
        private string caminho = "server=localhost;uid=root;pwd=root;database=faculdade;";
        private MySqlConnection conector;

        public Conexao()
        {
            conector = new MySqlConnection(caminho);
        }
        public MySqlConnection Conectar()
        {
            conector.Open();
            return conector;
        }
        public MySqlConnection Desconecta()
        {
            conector.Close();
            return conector;
        }

    }

    }
    
