using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Veiculo carro = null;
            int opcao;

            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=================================");
                Console.WriteLine("       SISTEMA DE GESTÃO");
                Console.WriteLine("          DE FROTA");
                Console.WriteLine("=================================");
                Console.ResetColor();

                Console.WriteLine("1 - Registar veículo");
                Console.WriteLine("2 - Consultar dados");
                Console.WriteLine("3 - Abastecer veículo");
                Console.WriteLine("4 - Realizar viagem");
                Console.WriteLine("5 - Consultar autonomia");
                Console.WriteLine("6 - Verificar combustível");
                Console.WriteLine("7 - Consultar estado do veículo");
                Console.WriteLine("8 - Consultar total de gastos");
                Console.WriteLine("0 - Sair");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEscolha uma opção: ");
                Console.ResetColor();

                int.TryParse(Console.ReadLine(), out opcao);

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        Console.Write("Matrícula: ");
                        string matricula = Console.ReadLine();

                        Console.Write("Capacidade do depósito: ");

                        if (int.TryParse(Console.ReadLine(), out int capacidade))
                        {
                            try
                            {
                                carro = new Veiculo(matricula, capacidade);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Veículo registado com sucesso!");
                                Console.ResetColor();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Capacidade inválida!");
                        }
                        break;

                    case 2:
                        if (carro != null)
                            carro.MostrarDados();
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 3:
                        if (carro != null)
                        {
                            Console.Write("Litros: ");
                            bool litrosOk = double.TryParse(
                                Console.ReadLine(), out double litros);

                            Console.Write("Preço por litro: ");
                            bool precoOk = double.TryParse(
                                Console.ReadLine(), out double preco);

                            if (litrosOk && precoOk)
                                carro.Abastecer(litros, preco);
                            else
                                Console.WriteLine("Valores inválidos!");
                        }
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 4:
                        if (carro != null)
                        {
                            Console.Write("Distância em km: ");

                            if (int.TryParse(Console.ReadLine(), out int km))
                                carro.RealizarViagem(km);
                            else
                                Console.WriteLine("Distância inválida!");
                        }
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 5:
                        if (carro != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Autonomia: " +
                                carro.CalcularAutonomia().ToString("F2") + " km");
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 6:
                        if (carro != null)
                            carro.VerificarCombustivel();
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 7:
                        if (carro != null)
                            carro.MostrarEstado();
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 8:
                        if (carro != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Total gasto: " +
                                carro.TotalGasto.ToString("F2") + " €");
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine("Registe primeiro um veículo!");
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Obrigado por utilizar o sistema!");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 0);
        }
    }
}