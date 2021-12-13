using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudForm
{
    class Cadastro
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public string mensagem = "";


        public Cadastro(string nome, string telefone, string cidade, string RG, string CPF)
        {   
        //comando sql - insert, update, delete -- sql command
        cmd.CommandText= "insert into Pessoa(nome,telefone,cidade,rg,cpf) values (@nome,@telefone,@cidade,@RG,@CPF)";
        //parametros
        cmd.Parameters.AddWithValue("@nome",nome);
        cmd.Parameters.AddWithValue("@telefone", telefone);
        cmd.Parameters.AddWithValue("@cidade", cidade);
        cmd.Parameters.AddWithValue("@rg", RG);
        cmd.Parameters.AddWithValue("@cpf", CPF);
        
            //conectar com o bd -- conexao 
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