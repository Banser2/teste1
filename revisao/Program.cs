using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {

                    case "1":
                        //todo: adcionar aluno e nota
                        Console.WriteLine("Informe o Nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a Sua Nota: ");
                       if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                       {
                           aluno.nota = nota;
                       }else{
                           throw new ArgumentException("Valor  da nota  deve ser Decimal! ");
                       }
                       alunos[indiceAluno] = aluno;
                       indiceAluno ++;
                        break;

                    case "2":
                        //todo: lista aluno
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"AlUNO: {a.Nome} - NOTA: {a.nota}");
                            }
                            
                        }
                        break;

                    case "3":
                        //todo: calcular media geral e conceito
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].nota;
                                nrAlunos++;
                            }
                        }
                            var mediaGeral = notaTotal / nrAlunos;
                            Conceito conceitoGeral;

                           if (mediaGeral < 2)
                            {
                               conceitoGeral = Conceito.E;
                            }
                            else if (mediaGeral < 4)
                            {
                                conceitoGeral = Conceito.D;
                            }

                             else if (mediaGeral < 6)
                            {
                                conceitoGeral = Conceito.C;
                            }

                             else if (mediaGeral < 8)
                            {
                                conceitoGeral = Conceito.B;
                            }

                             else{

                                conceitoGeral = Conceito.A;

                             }


                            Console.WriteLine($"Media Geral: {mediaGeral} - CONCEITO: {conceitoGeral}");
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }              

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
// menu
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a Opção Desejada:");
            Console.WriteLine("1- Inserir Novo Aluno");
            Console.WriteLine("2- Listar Aluno:");
            Console.WriteLine("3- Calcular Media Geral:");
            Console.WriteLine("X- Sair:");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
