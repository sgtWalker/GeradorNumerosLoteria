using System;
using System.Collections.Generic;
using System.Linq;

namespace GeradorNumerosLoteria
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroInicial, numeroFinal, quantidadeRodadas;
            SolicitarNumeros(out numeroInicial, out numeroFinal, out quantidadeRodadas);
            GerarNumeroRandomico(numeroInicial, numeroFinal, quantidadeRodadas);
        }

        private static void SolicitarNumeros(out int numeroInicial, out int numeroFinal, out int quantidadeRodadas)
        {
            Console.Write("Entre com o número inicial: ");
            numeroInicial = int.Parse(Console.ReadLine());
            Console.Write("Entre com o número final: ");
            numeroFinal = int.Parse(Console.ReadLine());
            Console.Write("Informe a quantidade de rodadas: ");
            quantidadeRodadas = int.Parse(Console.ReadLine());
        }

        private static void GerarNumeroRandomico(int numeroInicial, int numeroFinal, int quantidadeRodadas)
        {
            var rnd = new Random();
            List<int> numerosGerados = new List<int>();

            int numeroGerado;

            for (int i = 0; i < quantidadeRodadas; i++)
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
