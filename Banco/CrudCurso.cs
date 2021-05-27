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

        public void atualizarProfessor(Professor obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "update professor set nome = @nome where codigo = @codigo";
            con.Parameters.AddWithValue("@codigo", obj.codigo);
            con.Parameters.AddWithValue("@nome", obj.nome);
            con.ExecuteNonQuery();
            conexao.Desconecta();
        }
        public List<Curso> Consultar()
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select codigo,nome from curso ";
            List<Curso> resultado = new List<Curso>();
            var Ler = con.ExecuteReader();
            while (Ler.Read())
            {
                Curso curso = new Curso();
                curso.codigo = Ler.GetInt32(0);
                curso.nome = Ler.GetString(1);
                resultado.Add(curso);
                
            }
            conexao.Desconecta();
            return (resultado);
        }

        public Professor ConsultarProfessorId(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select codigo,nome from professor where codigo = @codigo ";
            con.Parameters.AddWithValue("@codigo", id);
            Professor professor = new Professor(); 
            var Ler = con.ExecuteReader();
            if (Ler.Read()){
               professor.codigo = Ler.GetInt32(0);
               professor.nome = Ler.GetString(1);
               conexao.Desconecta();
            }
            return (professor);
        }
        public List<Professor> ConsultarProfessor()
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "select codigo,nome from professor ";
            List<Professor> resultado = new List<Professor>();
            var Ler = con.ExecuteReader();
            while (Ler.Read())
            {
                Professor professor = new Professor();
                professor.codigo = Ler.GetInt32(0);
                professor.nome = Ler.GetString(1);
                resultado.Add(professor);
                

            }
            conexao.Desconecta();
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
                conexao.Desconecta();

            }
            return (curso);
        }

        public void excluir(int id)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "delete from ";
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
            conexao.Desconecta();
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
                conexao.Desconecta();
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
            conexao.Desconecta();
            return (resultado);
            
        }

        public void atualizar(Curso obj)
        {
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "update curso set nome = @nome where codigo = @codigo";
            con.Parameters.AddWithValue("@codigo", obj.codigo);
            con.Parameters.AddWithValue("@nome", obj.nome);
            var Ler = con.ExecuteNonQuery();
            conexao.Desconecta();
           
        }
        public void CadastroDisciplina (int id, Disciplina obj )
        {
            int codigoDisciplina = 0;
            MySqlCommand con = conexao.Conectar().CreateCommand();
            con.CommandText = "insert into disciplina values(null,@nome)";
            con.Parameters.AddWithValue("@nome", obj.nomeDisciplina);
            con.ExecuteNonQuery();
            con.CommandText = "select * from disciplina order by codigo desc";
            var Ler = con.ExecuteReader();

            if (Ler.Read())
            {
                codigoDisciplina = Ler.GetInt32(0);
                conexao.Desconecta();
            }
            MySqlCommand con2 = conexao.Conectar().CreateCommand();
            con2.CommandText = "insert into cursodisciplina values(null,@idCurso,@iddisciplina)";
            con2.Parameters.AddWithValue("@idCurso", id);
            con2.Parameters.AddWithValue("iddisciplina", codigoDisciplina);
            con2.ExecuteNonQuery();
            conexao.Desconecta();

            MySqlCommand con3 = conexao.Conectar().CreateCommand();
            con3.CommandText = "insert into disciplinaprofessor values (null,@codigodisciplina,@codigoprofessor, @horario)";
            con3.Parameters.AddWithValue("@codigodisciplina", codigoDisciplina);
            con3.Parameters.AddWithValue("@codigoprofessor", obj.codigoProfessor);
            con3.Parameters.AddWithValue("@horario", obj.horarioAula);
            con3.ExecuteNonQuery();
            conexao.Desconecta();
            }

        }
    }
