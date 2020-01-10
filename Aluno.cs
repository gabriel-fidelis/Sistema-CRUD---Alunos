using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace ProjetoCap6
{
    class Aluno
    {
        CultureInfo MyCult = new CultureInfo("pt-BR", false);
        private string _matr;
        private string _nome;
        private char _sexo;
        private double[] _av = new double[3];
        public double Media { get; private set; }
        private static List<string> matriculas = new List<string>();
        public Aluno(string matr, string nome, char sexo)
        {
            Matr = matr;
            Nome = nome;
            Sexo = sexo;
            DefinirNotas();
        }
        public string Matr
        {
            get { return _matr; }
            private set
            {
                if (value.Length != 10 || matriculas.Exists(x => x == value))
                {
                    Console.WriteLine("Matrícula inválida");
                    Console.WriteLine("Digite a matrícula novamente: ");
                    string matr = Console.ReadLine();
                    Matr = matr;
                }
                else
                {
                    _matr = value;
                    matriculas.Add(value);
                }
            }
        }
        public string Nome
        {
            get { return _nome; }
            private set
            {
                if (value != null)
                {
                    _nome = value;
                }
                else
                {
                    Console.WriteLine("Nome incorreto.");
                    Console.Write("Digite o nome novamente: ");
                    string name = Console.ReadLine();
                    Nome = name;
                }
            }
        }
        public char Sexo
        {
            get { return _sexo; }
            private set
            {
                if (value == 'm' || value == 'M' || value == 'f' || value == 'F')
                {
                    _sexo = value;
                }
                else
                {
                    Console.WriteLine("Sexo inválido.");
                    Console.Write("Digite o sexo novamente: ");
                    char sexo = char.Parse(Console.ReadLine());
                }
            }
        }
        public double[] Avx
        {
            get { return _av; }
            private set
            {
                for (int i = 0; i < Avx.Length; i++)
                {
                    if (value[i] < 0 || value[i] > 10)
                    {
                        Console.Write("AV{0} inválida. Digite um valor entre 0 e 10: ", i + 1);
                        double avplaceholder = double.Parse(Console.ReadLine(), MyCult);
                        _av[i] = SetAv(avplaceholder, i);
                    }
                    else
                    {
                        _av[i] = value[i];
                    }
                }
            }
        }
        private double SetAv(double placeholder, int i)
        {
            if (placeholder >= 0 && placeholder <= 10)
            {
                return placeholder;
            }
            else
            {
                Console.Write("AV{0} inválida. Digite um valor entre 0 e 10: ", i + 1);
                double avplaceholder = double.Parse(Console.ReadLine(), MyCult);
                return SetAv(avplaceholder, i);
            }
        }
        private void DefinirNotas()
        {
            Console.Write("Digite a AV1 do aluno: ");
            double av1 = double.Parse(Console.ReadLine(), MyCult);
            Console.Write("Digite a AV2 do aluno: ");
            double av2 = double.Parse(Console.ReadLine(), MyCult);
            Console.Write("Digite a AV3 do aluno: ");
            double av3 = double.Parse(Console.ReadLine(), MyCult);
            double[] avs = new double[] { av1, av2, av3 };
            Avx = avs;
            DefinirMedia(Avx);
        }
        public static void DeletarMatricula(int i)
        {
            matriculas.RemoveAt(i);
        }

        private void DefinirMedia(double[] avs)
        {
            if (avs[0] > avs[2] && avs[1] > avs[2])
            {
                Media = (avs[0] + avs[1]) / 2;
            }
            else if (avs[0] > avs[1] && avs[2] > avs[1])
            {
                Media = (avs[0] + avs[2]) / 2;
            }
            else
            {
                Media = (avs[1] + avs[2]) / 2;
            }
        }

        public override string ToString()
        {
            return "Matrícula: " + Matr + "\n" +
                   "Nome: " + Nome + "\n" +
                   "Sexo: " + Sexo + "\n" +
                   "AV1: " + Avx[0].ToString("F2", MyCult) + "\n" +
                   "AV2: " + Avx[1].ToString("F2", MyCult) + "\n" +
                   "AV3: " + Avx[2].ToString("F2", MyCult) + "\n" +
                   "Media: " + Media.ToString("F2", MyCult) + "\n";
        }
    }
}