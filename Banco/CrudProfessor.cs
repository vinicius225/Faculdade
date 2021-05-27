using Faculdade.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Faculdade.Banco
{
    public class CrudProfessor : CRUD<Professor>
    {
        Conexao conexao = new Conexao();
        public void adicionar(Professor obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "insert into professor values (null,@nome)";
            con.Parameters.AddWithValue("@nome", obj.nome);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }

        public void atualizar(Professor obj)
        {
            throw new NotImplementedException();
        }

        public List<Professor> Consultar()
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select codigo,nome from professor ";
            List<Professor> resultado = new List<Professor>(); 
            var Ler = con.ExecuteReader();
            while (Ler.Read()){
                Professor professor = new Professor();
               professor.codigo = Ler.GetInt32(0);
               professor.nome = Ler.GetString(1);
                resultado.Add(professor);
            }
            return (resultado);
        }

        public Professor consultarID(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select * from professor where codigo =@codigo";
            con.Parameters.AddWithValue("@codigo", id);
            var Ler = con.ExecuteReader();
            Professor professor = new Professor();
            if (Ler.Read())
            {
                professor.codigo = Ler.GetInt32(0); 
                professor.nome = Ler.GetString(1);

            }
            return (professor);
        }

        public void excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}