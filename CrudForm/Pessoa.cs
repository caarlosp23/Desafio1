using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudForm
{
    class Pessoa
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public string mensagem = "";


        private string nome;
        private string telefone;
        private string cidade;
        private string rg;
        private string cpf;

        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Cpf { get => cpf; set => cpf = value; }

        public void gravarPessoa()
        {
            cmd.CommandText = "insert into Pessoa(nome,telefone,cidade,rg,cpf) values (@nome,@telefone,@cidade,@rg,@cpf)";
            //parametros
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@cidade", cidade);
            cmd.Parameters.AddWithValue("@rg", rg);
            cmd.Parameters.AddWithValue("@cpf", cpf);
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