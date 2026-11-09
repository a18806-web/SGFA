using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFA
{
    internal class Veiculo
    {
        private int _quilometragem;
        private double _nivelCombustivel;

        public string Matricula { get; set; }
        public int CapacidadeDeposito { get; set; }
        public double TotalGasto { get; private set; }

        public int Quilometragem
        {
            get { return _quilometragem; }
            set
            {
                if (value < _quilometragem || value < 0)
                    throw new Exception("Quilometragem inválida!");

                _quilometragem = value;
            }
        }

        public double NivelCombustivel
        {
            get { return _nivelCombustivel; }
            set
            {
                if (value < 0 || value > CapacidadeDeposito)
                    throw new Exception("Combustível inválido!");

                _nivelCombustivel = value;
            }
        }

        public Veiculo(string matricula, int capacidade)
        {
            if (string.IsNullOrWhiteSpace(matricula) || capacidade <= 0)
                throw new Exception("Dados inválidos!");

            Matricula = matricula.ToUpper();
            CapacidadeDeposito = capacidade;
            _quilometragem = 0;
            _nivelCombustivel = capacidade;
            TotalGasto = 0;
        }

        // Abastecer veículo
        public void Abastecer(double litros, double preco)
        {
            if (litros <= 0 || preco <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valores inválidos!");
                Console.ResetColor();
                return;
            }

            double espaco = CapacidadeDeposito - NivelCombustivel;
            double abastecido = Math.Min(litros, espaco);

            if (abastecido == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("O depósito já está cheio!");
                Console.ResetColor();
                return;
            }

            NivelCombustivel += abastecido;
            TotalGasto += abastecido * preco;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Abastecimento realizado!");
            Console.WriteLine("Litros: " + abastecido.ToString("F2"));
            Console.WriteLine("Custo: " + (abastecido * preco).ToString("F2") + " €");
            Console.ResetColor();

            if (abastecido < litros)
                Console.WriteLine("Aviso: Abastecimento limitado à capacidade do depósito.");
        }

        // Realizar viagem
        public bool RealizarViagem(int km)
        {
            if (km <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Distância inválida!");
                Console.ResetColor();
                return false;
            }

            double consumo = km * 0.07;

            if (NivelCombustivel < consumo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Combustível insuficiente!");
                Console.ResetColor();
                return false;
            }

            Quilometragem += km;
            NivelCombustivel -= consumo;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Viagem realizada com sucesso!");
            Console.WriteLine("Distância: " + km + " km");
            Console.WriteLine("Combustível consumido: " + consumo.ToString("F2") + " L");
            Console.ResetColor();

            VerificarCombustivel();

            return true;
        }

        // Calcular autonomia
        public double CalcularAutonomia()
        {
            return NivelCombustivel / 0.07;
        }

        // Alerta aos 10%
        public void VerificarCombustivel()
        {
            if (NivelCombustivel <= CapacidadeDeposito * 0.10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n!!! ALERTA !!!");
                Console.WriteLine("Combustível abaixo de 10%!");
                Console.WriteLine("Abasteça o veículo imediatamente!");
                Console.ResetColor();
            }
        }

        // Consultar dados
        public void MostrarDados()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\n===== DADOS DO VEÍCULO =====");
            Console.WriteLine("Matrícula: " + Matricula);
            Console.WriteLine("Quilometragem: " + Quilometragem + " km");
            Console.WriteLine("Capacidade: " + CapacidadeDeposito + " L");
            Console.WriteLine("Combustível: " + NivelCombustivel.ToString("F2") + " L");
            Console.WriteLine("Autonomia: " + CalcularAutonomia().ToString("F2") + " km");
            Console.WriteLine("Total gasto: " + TotalGasto.ToString("F2") + " €");

            Console.ResetColor();

            VerificarCombustivel();
        }

        // Estado do veículo
        public void MostrarEstado()
        {
            Console.WriteLine("\n===== ESTADO DO VEÍCULO =====");

            if (NivelCombustivel <= CapacidadeDeposito * 0.10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Estado: Combustível crítico!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Estado: Operacional");
                Console.ResetColor();
            }
        }
    }
}
    