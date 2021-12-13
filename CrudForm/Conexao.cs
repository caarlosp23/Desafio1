using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudForm
{
    class Conexao
    {
        SqlConnection con = new SqlConnection();
        
        //construtor
        public Conexao()
        {
            con.ConnectionString = "Data Source=localhost; Initial Catalog=BancoDesafio; User ID=usuario; password=senha;language=Portuguese";
        }
        //metodo conectar 
        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            } 
            return con;
        }
        //metodo desconectar
        public void  desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return;
        }

        public DataTable executarConsultaGenerica(string sql)
        {
            try
            {
                conectar();

                SqlCommand command = new SqlCommand(sql, con);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                adapter.Fill(dt);//adaptar preenche o datatable com os dados do command

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                desconectar();
            }
        }
    }
}
