using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

// Obtém o preço inicial e o preço por hora do usuário 
decimal precoInicial = ObterPreco("Digite o preço inicial: ");
decimal precoPorHora = ObterPreco("Digite o preço por hora: ");


// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");

// Método que obtém um preço numérico com tratamento de erro 
decimal ObterPreco(string mensagem)
{
    decimal preco;
    while (true)
    {
        Console.Write(mensagem);
        if (decimal.TryParse(Console.ReadLine(), out preco) && preco > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Digite um valor numérico posítivo.");
        }
    }
    return preco;
}