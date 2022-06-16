using System;
using System.Collections.Generic;
using System.Linq;

namespace GeradorNumerosLoteria
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroInicial, numeroFinal, quantidadeNumerosPorJogo, quantidadeJogos;
            SolicitarNumeros(out numeroInicial, out numeroFinal, out quantidadeNumerosPorJogo, out quantidadeJogos);
            Processar(numeroInicial, numeroFinal, quantidadeNumerosPorJogo, quantidadeJogos);
        }

        private static void SolicitarNumeros(out int numeroInicial, out int numeroFinal, out int quantidadeNumerosPorJogo, out int quantidadeJogos)
        {
            Console.Write("Entre com o número inicial: ");
            numeroInicial = int.Parse(Console.ReadLine());
            Console.Write("Entre com o número final: ");
            numeroFinal = int.Parse(Console.ReadLine());
            Console.Write("Informe a quantidade de números por jogo: ");
            quantidadeNumerosPorJogo = int.Parse(Console.ReadLine());
            Console.Write("Informe a quantidade de jogos: ");
            quantidadeJogos = int.Parse(Console.ReadLine());
        }

        private static void Processar(int numeroInicial, int numeroFinal, int quantidadeNumerosPorJogo, int quantidadeJogos)
        {
            for (int i = 1; i <= quantidadeJogos; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Jogo número {i}:");
                GerarNumeroRandomico(numeroInicial, numeroFinal, quantidadeNumerosPorJogo);
            }

            Console.WriteLine("Aperte qualquer tecla para sair...");
            Console.ReadKey();
        }
        private static void GerarNumeroRandomico(int numeroInicial, int numeroFinal, int quantidadeNumerosPorJogo)
        {
            var rnd = new Random();
            List<int> numerosGerados = new List<int>();

            int numeroGerado;

            for (int i = 0; i < quantidadeNumerosPorJogo; i++)
            {
                numeroGerado = rnd.Next(numeroInicial, numeroFinal + 1);

                while (numerosGerados.Where(x => x == numeroGerado).FirstOrDefault() == numeroGerado)
                {
                    numeroGerado = rnd.Next(numeroInicial, numeroFinal + 1);
                }

                numerosGerados.Add(numeroGerado);
            }

            numerosGerados.Sort();
            numerosGerados.ForEach(x => Console.WriteLine($"Número Gerado: {x}"));

        }
    }
}
