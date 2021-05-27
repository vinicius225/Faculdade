using Faculdade.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Faculdade.Banco
{
    public class CrudCurso : CRUD<Curso>
    {
        Conexao conexao = new Conexao();
        public void adicionar(Curso obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "insert into curso values (null,@nome)";
            con.Parameters.AddWithValue("@nome", obj.nome);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }

        public void atualizar(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "updsate professor set nome = @nome where codigo = @codigo";
            con.Parameters.AddWithValue("@codigo", id);
            con.ExecuteNonQuery();
        }

        public List<Curso> Consultar()
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select codigo,nome from curso ";
            List<Curso> resultado = new List<Curso>(); 
            var Ler = con.ExecuteReader();
            while (Ler.Read()){
                Curso curso = new Curso();
               curso.codigo = Ler.GetInt32(0);
               curso.nome = Ler.GetString(1);
                resultado.Add(curso);
            }
            return (resultado);
        }

        public Curso consultarID(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select * from curso where codigo =@codigo";
            con.Parameters.AddWithValue("@codigo", id);
            var Ler = con.ExecuteReader();
            Curso curso = new Curso();
            if (Ler.Read())
            {
                curso.codigo = Ler.GetInt32(0); 
                curso.nome = Ler.GetString(1);

            }
            return (curso);
        }

        public void excluir(int id)
        {
            throw new NotImplementedException();
        }
        public List<Disciplina> Disciplina(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select case when curso.nome is null then  '--' else curso.nome  end ,"+
" case when disciplina.nome is null then  '--' else disciplina.nome end,"+
" case when disciplinaprofessor.horario is null then  '--' else disciplinaprofessor.horario end,"+
" case when professor.nome is null then  '--' else professor.nome end"+
" from curso left join cursodisciplina on curso.codigo = cursodisciplina.codigo_curso"+
" left join disciplinaprofessor on codigo_disciplinaprofessor = disciplinaprofessor.codigo"+
" left join disciplina on disciplinaprofessor.codigo_disciplina = disciplina.codigo"+
" left join professor on disciplinaprofessor.codigo_professor = professor.codigo where curso.codigo = @codigo";
;
            List<Disciplina> resultado = new List<Disciplina>();
            con.Parameters.AddWithValue("@codigo", id);
            var Ler = con.ExecuteReader();
            while (Ler.Read())
            {
                Disciplina disciplina = new Disciplina();         
                disciplina.nomeCurso = Ler.GetString(0);
                disciplina.nomeDisciplina = Ler.GetString(1);
                disciplina.horarioAula = Ler.GetString(2);
                disciplina.nomeProfessor = Ler.GetString(3);
                resultado.Add(disciplina);
            }
            return (resultado);
        }
        public List<Disciplina> DisciplinaIdCurso(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select case when curso.nome is null then  '--' else curso.nome  end ," +
" case when disciplina.nome is null then  '--' else disciplina.nome end," +
" case when disciplinaprofessor.horario is null then  '--' else disciplinaprofessor.horario end," +
" case when professor.nome is null then  '--' else professor.nome end" +
" from curso left join cursodisciplina on curso.codigo = cursodisciplina.codigo_curso" +
" left join disciplinaprofessor on codigo_disciplinaprofessor = disciplinaprofessor.codigo" +
" left join disciplina on disciplinaprofessor.codigo_disciplina = disciplina.codigo" +
" left join professor on disciplinaprofessor.codigo_professor = professor.codigo where curso.codigo =@codigo";
            ;
            con.Parameters.AddWithValue("@codigo", id);
            List<Disciplina> resultado = new List<Disciplina>();
            var Ler = con.ExecuteReader();
            while (Ler.Read())
            {
                Disciplina disciplina = new Disciplina();
                disciplina.nomeCurso = Ler.GetString(0);
                disciplina.nomeDisciplina = Ler.GetString(1);
                disciplina.horarioAula = Ler.GetString(2);
                disciplina.nomeProfessor = Ler.GetString(3);
                resultado.Add(disciplina);
            }
            return (resultado);
        }
        public List<Disciplina> DisciplinaIdProfessor(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select case when curso.nome is null then  '--' else curso.nome  end ," +
" case when disciplina.nome is null then  '--' else disciplina.nome end," +
" case when disciplinaprofessor.horario is null then  '--' else disciplinaprofessor.horario end," +
" case when professor.nome is null then  '--' else professor.nome end" +
" from curso left join cursodisciplina on curso.codigo = cursodisciplina.codigo_curso" +
" left join disciplinaprofessor on codigo_disciplinaprofessor = disciplinaprofessor.codigo" +
" left join disciplina on disciplinaprofessor.codigo_disciplina = disciplina.codigo" +
" left join professor on disciplinaprofessor.codigo_professor = professor.codigo where curso.codigo =@codigo";
            ;
            con.Parameters.AddWithValue("@codigo", id);
            List<Disciplina> resultado = new List<Disciplina>();
            var Ler = con.ExecuteReader();
            while (Ler.Read())
            {
                Disciplina disciplina = new Disciplina();
                disciplina.nomeCurso = Ler.GetString(0);
                disciplina.nomeDisciplina = Ler.GetString(1);
                disciplina.horarioAula = Ler.GetString(2);
                disciplina.nomeProfessor = Ler.GetString(3);
                resultado.Add(disciplina);
            }
            return (resultado);
        }


    }
}