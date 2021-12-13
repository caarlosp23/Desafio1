using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudForm
{
    class Arquivo
    {

        public string nome, mensagem;
        StreamReader sr;
        public int pessoas = 0;
        public int alunos = 0;

        public void lerArquivo()
        {
            string linha;
            sr = new StreamReader(@"C:\desafio\desafio1.txt");
            Pessoa pessoa = new Pessoa() ;
            Aluno aluno = new Aluno();
            linha = sr.ReadLine();

            while (linha != null)
            {
                string[] dados = linha.Split('-');
                if (dados[0] == "Z")
                {
                    pessoa.Nome = dados[1];
                    pessoa.Telefone = dados[2];
                    pessoa.Cidade = dados[3];
                    pessoa.Rg = dados[4];
                    pessoa.Cpf = dados[5];
                    pessoa.gravarPessoa();
                    pessoas++;
                } else if (dados[0] == "Y")
                {
                    aluno.Matricula1 = dados[1];//tabela aluno
                    aluno.Nome = pessoa.Nome;//tabela aluno
                    aluno.CodigoCurso = dados[2]; //tabela curso
                    aluno.Curso = dados[3]; //tabela curso
                    aluno.gravarAluno();
                    aluno.gravarCurso();
                    alunos++;

                }
                    linha = sr.ReadLine();
                
            }

            
            sr.Close();
        }
    }
}
