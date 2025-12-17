using Controller;
using Models;

Estacionamento estacionamento = new Estacionamento();

int escolha = 0;
int fim = 0;

while (true)
{
    Console.WriteLine("Digite uma opção numérica conforme abaixo");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Retirar veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar consulta");
    escolha = int.Parse(Console.ReadLine());
    switch (escolha)
    {
        case 1:
            Console.WriteLine("Cadastramento de veículos");
            Console.WriteLine("Insira a placa do veículo");
            string placa = Console.ReadLine();
            Console.WriteLine("Insira uma data");
            Console.WriteLine("O ano:");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine("O mês: ");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("O dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("A hora atual da entrada: ");
            int hora = int.Parse(Console.ReadLine()); //em uma aplicação real, isto seria um DateTime.Now()
            DateTime data = new DateTime(ano, mes, dia, hora, 0, 0);
            Veiculo v = new Veiculo{Placa = placa};
            estacionamento.CadastrarVeiculo(v, data);
            break;
        case 2:
            Console.WriteLine("Insira a placa do veículo que deseja retirar");
            placa = Console.ReadLine();
            Console.WriteLine("Insira uma data");
            Console.WriteLine("O ano:");
            ano = int.Parse(Console.ReadLine());
            Console.WriteLine("O mês: ");
            mes = int.Parse(Console.ReadLine());
            Console.WriteLine("O dia: ");
            dia = int.Parse(Console.ReadLine());
            Console.WriteLine("A hora atual da retirada: ");
            hora = int.Parse(Console.ReadLine()); //em uma aplicação real, isto seria um DateTime.Now()
            data = new DateTime(ano, mes, dia, hora, 0, 0);
            estacionamento.RetirarVeiculo(placa, data);
            break;
        case 3:
            estacionamento.Veiculos.ForEach( v =>
            {
                Console.WriteLine("---");
                Console.WriteLine("Veículo");
                Console.WriteLine($"Placa: {v.Placa}");
                Console.WriteLine("---");
            });
            break;
        case 4:
            Console.WriteLine("Encerrando aplicação");
            fim = 1;
            break;
        default:
            Console.WriteLine("Insira valores válidos. Revise as informações");
            break;
    }
    if(fim == 1)
    {
        break;
    }
}