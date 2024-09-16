using System.ComponentModel;

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

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = string.Empty;
            
            while (string.IsNullOrEmpty(placa))
            {
                Console.Write("Placa: ");
                placa = Console.ReadLine().ToUpper();
            }
            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.Write("Placa: ");
            string placa = Console.ReadLine().ToUpper();


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,                
                int horas = ObterHorasEstacionado();

                // TODO: Realizar o seguinte cálculo
                decimal valorTotal = horas * precoPorHora + precoInicial;

                // TODO: Remover a placa digitada da lista de veículos
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
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        // Método que obtém o numéro de horas com tratamento de erro.
        private int ObterHorasEstacionado()
        {
            int horas = 0;
            do
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                
                if (int.TryParse(Console.ReadLine(), out horas) && horas >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Digite um valor númerico posítivo.");
                }

            } while (true);

            return horas;
        }
    }
}
