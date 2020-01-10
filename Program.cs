using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
namespace ProjetoCap6
{
    class Program
    {
        public static List<Aluno> Alunos = new List<Aluno>();
        CultureInfo MyCult = new CultureInfo("pt-BR", false);
        static void Main(string[] args)
        {
            MainMenu();
        }
        static void MainMenu()
        {
            int flag = -1;
            while (flag != 0)
            {
                Console.WriteLine("- Menu Principal -");
                Console.Write("[1] Adicionar\n[2] Pesquisar\n[3] Exibir\n[4] Deletar\n[5] Atualizar\n[0] Sair\nSua opção: ");
                flag = int.Parse(Console.ReadLine());
                switch (flag)
                {
                    case 1:
                        Adicionar(); break;
                    case 2:
                        Pesquisar(); break;
                    case 3:
                        Exibir(); break;
                    case 4:
                        Deletar(); break;
                    case 5:
                        Atualizar();break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção incorreta."); break;
                }
            }
        }
        static void Adicionar()
        {
            Console.Write("Digite a matrícula do aluno: ");
            string matr = Console.ReadLine();
            if (Alunos.Exists(x => x.Matr == matr))
            {
                Console.Write("Matrícula já existente.");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o sexo do aluno (M/F): ");
            char sexo = char.Parse(Console.ReadLine());
            Alunos.Add(new Aluno(matr, nome, sexo));
            Console.Clear();
        }
        static void Pesquisar()
        {
            Console.Write("Digite a matrícula para pesquisa: ");
            string matr = Console.ReadLine();
            if (Alunos.Exists(x => x.Matr == matr))
            {
                Aluno aluno = Alunos.Find(x => x.Matr == matr);
                Console.WriteLine("Aluno de matrícula {0} encontrado, com dados a seguir: ", aluno.Matr);
                Console.WriteLine(aluno);
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
            Console.ReadKey(true);
            Console.Clear();
        }
        static void Exibir()
        {
            Console.Clear();
            Console.WriteLine("[1] Alunos aprovados\n[2] Alunos reprovados\n[3] Todos os alunos\n");
            Console.Write("Sua opção: ");
            int flag = int.Parse(Console.ReadLine());
            if (flag == 1)
            {
                List<Aluno> Aprovados = new List<Aluno>();
                Aprovados = Alunos.FindAll(x => x.Media > 7);
                Console.WriteLine("Alunos aprovados: ");
                foreach (Aluno aluno in Aprovados)
                {
                    Console.WriteLine(aluno);
                }
            }
            else if (flag == 2)
            {
                List<Aluno> Reprovados = new List<Aluno>();
                Reprovados = Alunos.FindAll(x => x.Media < 7);
                Console.WriteLine("Alunos reprovados: ");
                foreach (Aluno aluno in Reprovados)
                {
                    Console.WriteLine(aluno);
                }
            }
            else if (flag == 3)
            {
                Console.WriteLine("Todos os alunos: ");
                foreach (Aluno aluno in Alunos)
                {
                    Console.WriteLine(aluno);
                }
            }
            Console.Write("\nPressione qualquer tecla para voltar.");
            Console.ReadKey(true);
            Console.Clear();
        }
        static void Deletar()
        {
            Console.Write("Digite a matrícula para deletar: ");
            string matr = Console.ReadLine();
            if (Alunos.Exists(x => x.Matr == matr))
            {
                int i = Alunos.FindIndex(x => x.Matr == matr);
                Console.Write("Aluno encontrado, tem certeza que deseja deletar? (Y para continuar, qualquer outra tecla abortará a operação.): ");
                char flag = char.Parse(Console.ReadLine());
                if (flag == 'y' || flag == 'Y')
                {
                    Alunos.RemoveAt(i);
                    Aluno.DeletarMatricula(i);
                    Console.WriteLine("Aluno deletado.");
                }
            }
            else
            {
                Console.WriteLine("Aluno não encontrado.");
            }
            Console.ReadKey(true);
            Console.Clear();
        }
        static void Atualizar()
        {
            Console.Write("Digite a matrícula a qual deseja atualizar: ");
            string matr = Console.ReadLine();
            if (Alunos.Exists(x => x.Matr == matr))
            {
                Console.WriteLine("Aluno encontrado.");
                Aluno aluno = Alunos.FirstOrDefault(x => x.Matr == matr);
                int i = Alunos.FindIndex(x => x.Matr == matr);
                Console.WriteLine("Dados atuais do aluno: ");
                Console.WriteLine(aluno);
                Alunos.RemoveAt(i);
                Console.WriteLine();
                Console.WriteLine("-- Digite os novos dados a seguir --");
                Console.WriteLine("Digite a matrícula do aluno: ");
                matr = Console.ReadLine();
                if (Alunos.Exists(x => x.Matr == matr))
                {
                    Console.Write("Matrícula já existente.");
                    Console.ReadKey(true);
                    Console.Clear();
                    Alunos.Insert(i, aluno);
                    return;
                }
                Console.Write("Digite o nome do aluno: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o sexo do aluno (M/F): ");
                char sexo = char.Parse(Console.ReadLine());
                Aluno.DeletarMatricula(i);
                Alunos.Insert(i, new Aluno(matr, nome, sexo));
                Console.WriteLine("Aluno atualizado com sucesso. Pressione qualquer tecla para voltar.");
            }
            else
            {
                Console.WriteLine("Matrícula não encontrada.");
            }
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}