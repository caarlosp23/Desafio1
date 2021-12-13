using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudForm
{
    class Aluno : Pessoa
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public string mensagem = "";

        private string Matricula;
        private string curso;
        private string codigoCurso;

        public string Matricula1 { get => Matricula; set => Matricula = value; }
        public string Curso { get => curso; set => curso = value; }
        public string CodigoCurso { get => codigoCurso; set => codigoCurso = value; }


        public void gravarAluno()
        {
            cmd.CommandText = "insert into aluno(matricula,nomealuno,CodigoDoCurso) values (@matricula,@nomealuno,@CodigoDoCurso)";
            //parametros
            cmd.Parameters.AddWithValue("@matricula", Matricula1);
            cmd.Parameters.AddWithValue("@nomealuno", Nome);
            cmd.Parameters.AddWithValue("@CodigoDoCurso", codigoCurso);
            try
            {
                //conectar com o banco - conexao
                cmd.Connection = conexao.conectar();
                //executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.desconectar();
                //mostrar msg de erro ou sucesso
                this.mensagem = "Cadastrado com sucesso!";
                cmd.Parameters.Clear();

            }
            catch (SqlException e)
            {
                this.mensagem = "Erro na conexão no banco de dados!";
            }
        }

        public void gravarCurso()
        {
            cmd.CommandText = "insert into curso(codigocurso,nomecurso) values (@codigocurso,@nomecurso)";


            //parametros
            cmd.Parameters.AddWithValue("@codigocurso", CodigoCurso);
            cmd.Parameters.AddWithValue("@nomecurso", Curso);
            try
            {
                //conectar com o banco - conexao
                cmd.Connection = conexao.conectar();
                //executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.desconectar();
                //mostrar msg de erro ou sucesso
                this.mensagem = "Cadastrado com sucesso!";
                cmd.Parameters.Clear();
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro na conexão no banco de dados!";
            }
            // executar comando que escreveu
            // desconectar bd

            //mostrar msg sucesso ou erro

        }
    }
}