using Faculdade.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Faculdade.Banco
{
    public class CrudAluno : CRUD<Aluno>
    {
        Conexao conexao = new Conexao();
        public void adicionar(Aluno obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "insert into aluno  values (null, @codigo_curso, @nome, @email, @sexo, @endereco, @complemento, @cep, @cidade, @estado, @telefone)"; ;
            con.Parameters.AddWithValue("@codigo_curso", obj.codigoCurso);
            con.Parameters.AddWithValue("@nome",obj.nome);
            con.Parameters.AddWithValue("@email",obj.email);
            con.Parameters.AddWithValue("@sexo", obj.sexo);
            con.Parameters.AddWithValue("@endereco", obj.endereco);
            con.Parameters.AddWithValue("@complemento", obj.complemento);
            con.Parameters.AddWithValue("@cep", obj.cep);
            con.Parameters.AddWithValue("@cidade",obj.cidade);
            con.Parameters.AddWithValue("@estado", obj.estado);
            con.Parameters.AddWithValue("@telefone", obj.telefone);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }


        public void atualizar(Aluno obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "update aluno set nome = @nome, email = @email, telefone=@telefone, endereco=@endereco, sexo =@sexo," +
                " complemento =@complemento, cep=@cep, cidade=@cidade, estado =@estado, codigo_curso=@codigo_curso  where codigo=@codigo";
            con.Parameters.AddWithValue("@codigo_curso", obj.codigoCurso);
            con.Parameters.AddWithValue("@nome", obj.nome);
            con.Parameters.AddWithValue("@email", obj.email);
            con.Parameters.AddWithValue("@sexo", obj.sexo);
            con.Parameters.AddWithValue("@endereco", obj.endereco);
            con.Parameters.AddWithValue("@complemento", obj.complemento);
            con.Parameters.AddWithValue("@cep", obj.cep);
            con.Parameters.AddWithValue("@cidade", obj.cidade);
            con.Parameters.AddWithValue("@estado", obj.estado);
            con.Parameters.AddWithValue("@telefone", obj.telefone);
            con.Parameters.AddWithValue("@codigo", obj.codigo);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }
        public void atualizarNota(Aluno obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "update nota set nota = @nota where codigo_aluno =@aluno and codigo_disciplina=@disciplina";
            con.Parameters.AddWithValue("@aluno", obj.codigo);
            con.Parameters.AddWithValue("@nota", obj.nota);
            con.Parameters.AddWithValue("@disciplina", obj.codigoDisciplina);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }

        public List<Aluno> Consultar()
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select   aluno.nome, email,curso.nome, aluno.codigo  from aluno  inner join curso on curso.codigo = aluno.codigo_curso order by aluno.nome";
            var Leitor = con.ExecuteReader();
            List<Aluno> relatorio = new List<Aluno>();
            while (Leitor.Read())
            {
                Aluno s = new Aluno();
                
                s.nome = Leitor.GetString(0);
                s.email = Leitor.GetString(1);
                s.cidade = Leitor.GetString(2);
                s.codigo = Leitor.GetInt32(3);
                relatorio.Add(s);
            }
            return relatorio;

        }

        public Aluno consultarID(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select codigo, codigo_curso, nome, email, sexo,endereco, case when complemento is null then" +
                "  '--' else complemento end," +
                " cep, cidade, estado, telefone from aluno where codigo = @codigo ";
            con.Parameters.AddWithValue("@codigo", id);
            var Ler =con.ExecuteReader();
            Aluno aluno = new Aluno();
            if (Ler.Read())
            {
                aluno.codigo = Ler.GetInt32(0);
                aluno.codigoCurso = Ler.GetInt32(1);
                aluno.nome = Ler.GetString(2);
                aluno.email = Ler.GetString(3);
                aluno.sexo = Ler.GetString(4);
                aluno.endereco = Ler.GetString(5);
                aluno.complemento = Convert.ToString( Ler.GetString(6));
                aluno.cep = Ler.GetString(7);
                aluno.cidade = Ler.GetString(8);
                aluno.estado = Ler.GetString(9);
                aluno.telefone = Ler.GetString(10);
            }
            return (aluno);
        }

        public void excluir(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "delete from aluno where codigo = @codigo";
            con.Parameters.AddWithValue("@codigo", id);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }
        public List<Nota> nota()
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select case when aluno.nome is null then  '--' else aluno.nome  end ," +
        " case when disciplina.nome is null then  '--' else disciplina.nome end," +
        " convert(case when nota.nota is null then  '--' else nota.nota end,decimal)," +
        " case when nota.semestre is null then  '--' else nota.semestre end," +
        " case when nota.ano is null then  '--' else nota.ano end from nota" +
        " left join aluno on aluno.codigo = nota.codigo_aluno" +
        " left join disciplina on disciplina.codigo = nota.codigo_disciplina";
            var Ler = con.ExecuteReader();
            List<Nota> notas = new List<Nota>();
            while(Ler.Read()){
                Nota n = new Nota();
                n.nomeAluno = Ler.GetString(0);
                n.disciplina = Ler.GetString(1);
                n.nota =Ler.GetDouble(2);
                n.semestre =int.Parse( Ler.GetString (3));
                n.ano = int.Parse( Ler.GetString (4));
                notas.Add(n);
            }
            return notas;
        }
        public List<Nota> notaId(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select case when aluno.nome is null then  '--' else aluno.nome  end ," +
        " case when disciplina.nome is null then  '--' else disciplina.nome end," +
        " convert(case when nota.nota is null then  '--' else nota.nota end,decimal)," +
        " case when nota.semestre is null then  '--' else nota.semestre end," +
        " case when nota.ano is null then  '--' else nota.ano end,  aluno.codigo , nota.codigo_disciplina from nota" +
        " left join aluno on aluno.codigo = nota.codigo_aluno" +
        " left join disciplina on disciplina.codigo = nota.codigo_disciplina where aluno.codigo =@codigo ";
            con.Parameters.AddWithValue("@codigo", id);
            var Ler = con.ExecuteReader();
            List<Nota> notas = new List<Nota>();
            while (Ler.Read())
            {
                Nota n = new Nota();
                n.nomeAluno = Ler.GetString(0);
                n.disciplina = Ler.GetString(1);
                n.nota = Ler.GetDouble(2);
                n.semestre = int.Parse(Ler.GetString(3));
                n.ano = int.Parse(Ler.GetString(4));
                n.codigoAluno = Ler.GetInt32(5);
                n.codigoDisciplina = Ler.GetInt32(6);
                notas.Add(n);
            }
            return notas;
        }
    }
}