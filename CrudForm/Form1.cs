using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            Cadastro cad = new Cadastro(txtNome.Text,txtTele.Text, txtCidade.Text, txtRG.Text, txtCPF.Text);
            MessageBox.Show(cad.mensagem);
            
        }

        private void btnLerArquivo_Click(object sender, EventArgs e)
        {
            Arquivo arq = new Arquivo();
            arq.lerArquivo();
            MessageBox.Show("Quantidade pessoas cadastradas: " + arq.pessoas.ToString());
            MessageBox.Show("Quantidade alunos cadastrados: "+arq.alunos.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao bd = new Conexao();

            string sql = "select cpf,nome,Matricula,NomeCurso from Pessoa inner join Aluno on Pessoa.Nome = Aluno.NomeAluno inner join Curso on curso.CodigoCurso = Aluno.codigodocurso order by Pessoa.Nome asc";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexao bd = new Conexao();

            string sql = "select * from pessoa";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexao bd = new Conexao();

            string sql = "select * from curso";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }
    }
}
