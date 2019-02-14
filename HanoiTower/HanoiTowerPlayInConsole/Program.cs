using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanoiTowerPlayInConsole
{
    class Program
    {
        static List<int> t1 = new List<int>();
        static List<int> t2 = new List<int>();
        static List<int> t3 = new List<int>();
        static int movimentos = 0, quantidadeDiscos;
        static double movimentosPossiveis;

        static void Main()
        {
            Jogo();
        }

        static void Jogo()
        {
            Console.Write("Informe a quantidade de discos: ");
            quantidadeDiscos = Convert.ToInt32(Console.ReadLine());
            if (quantidadeDiscos >= 64)
            {
                Console.WriteLine("Deseja que o mundo acabe? Escolha outra quantidade de discos.");
                Jogo();
            }
            else
            {
                movimentosPossiveis = Math.Pow(2, quantidadeDiscos) - 1;
                Console.WriteLine("");
                for (int i = quantidadeDiscos; i >= 1; i--)
                {
                    t1.Add(i);
                }
                while (!ChecarFinal())
                {
                    var destino = t3;
                    var origem = t1;
                    MostrarTorres();
                    Console.WriteLine("");
                    Console.Write("Informe o disco que quer movimentar: ");
                    var input = Console.ReadLine();
                    int disco;
                    if (int.TryParse(input, out disco))
                    {
                        Console.Write("Informe a torre de destino: ");
                        string resposta = Console.ReadLine().ToUpper();
                        switch (resposta)
                        {
                            case "A": destino = t1; break;
                            case "B": destino = t2; break;
                            case "C": destino = t3; break;
                            default: NaoMover(); continue;

                        }
                    }
                    else
                    {
                        NaoMover();
                        continue;
                    }

                    if (t1.Contains(disco)) origem = t1;
                    else if (t2.Contains(disco)) origem = t2;
                    else if (t3.Contains(disco)) origem = t3;

                    Mover(disco, ref origem, ref destino);
                }
            }

            Console.WriteLine("Fim de jogo! {0} movimentos realizados!", movimentos);
            Console.Write("{0}", movimentos <= movimentosPossiveis ? "Parabéns!" : "Você falhou!");
            Console.ReadKey();
        }

        static void NaoMover()
        {
            Console.WriteLine("Informação inválida!");
            Console.ReadKey();
            Console.Clear();
        }

        static void MostrarTorres()
        {
            Console.WriteLine("Movimentos realizados: " + movimentos);
            Console.Write("Discos na torre A: ");
            for (int i = 0; i < t1.Count; i++)
                Console.Write(t1[i] + " ");
            Console.WriteLine("");
            Console.Write("Discos na torre B: ");
            for (int i = 0; i < t2.Count; i++)
                Console.Write(t2[i] + " ");
            Console.WriteLine("");
            Console.Write("Discos na torre C: ");
            for (int i = 0; i < t3.Count; i++)
                Console.Write(t3[i] + " ");
        }

        static bool ChecarMovimento(int disco, List<int> origem, List<int> destino)
        {
            if (destino.Count == 0 && disco == origem[origem.Count - 1] && disco >= 1 && disco <= quantidadeDiscos)
                return true;
            else if (destino.Count > 0 && disco == origem[origem.Count - 1] && disco < destino[destino.Count - 1] &&
                disco >= 1 && disco <= quantidadeDiscos)
                return true;

            return false;
        }


        static void Mover(int disco, ref List<int> origem, ref List<int> destino)
        {
            if (ChecarMovimento(disco, origem, destino))
            {
                destino.Add(disco);
                origem.Remove(disco);
                movimentos++;
            }
            else
            {
                Console.WriteLine("Movimento inválido!");
                Console.ReadKey();
            }
            Console.Clear();
        }

        static bool ChecarFinal()
        {
            if (t3.Count == quantidadeDiscos)
                return true;

            return false;
        }
    }
}
