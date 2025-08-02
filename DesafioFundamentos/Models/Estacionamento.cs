using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public static bool ChecandoPlacaValida(string placa)
        {
            Regex regexold = new Regex("[A-Za-z]+-[0-9]+", RegexOptions.IgnoreCase);
            Regex regexnew = new Regex("^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$", RegexOptions.IgnoreCase);
            // You can use regex.IsMatch(placa) here if you want to validate the plate
            return regexold.IsMatch(placa) || regexnew.IsMatch(placa);
        }

        public void AdicionarVeiculo()
        {


            bool placaValida;
            string car;

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            do
            {

                 car = Console.ReadLine().ToUpper();
                 placaValida = ChecandoPlacaValida(car);

                if (!placaValida)
                {
                    Console.WriteLine("Formato de placa inválido. Por favor, tente novamente.");
                }

            } while (!placaValida);




            veiculos.Add(car);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");



                decimal horas = decimal.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;


                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string car in veiculos)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
