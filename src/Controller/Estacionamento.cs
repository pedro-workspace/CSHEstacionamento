using Models;

namespace Controller;
public class Estacionamento
{
    public List<Veiculo> Veiculos {get;set;} //Lista de veículos meramente representativa
    List<Retirada> Retiradas {get;set;}
    List<Entrada> Entradas {get;set;}

    private List<Veiculo> BuscarVeiculoPorPlaca(string placa)
    {
        List<Veiculo> encontrados = Veiculos.FindAll(
            delegate (Veiculo v)
            {
                return v.Placa == placa;
            });
        if(encontrados.Count == 1)
        {
            Console.WriteLine("Veículo encontrado");
            return encontrados;
        }
        else if(encontrados.Count > 1)
        {
            Console.WriteLine("Erro, mais de um veículo com a mesma placa");
            return encontrados;
        }
        else
        {
            Console.WriteLine("Veículo não encontrado");
            return encontrados;
        }
    }

//Calcula o preço do estacionamento em reais
    private double CalcularPreço(int horasEstacionado)
    {
        double total = 5 + (2 * horasEstacionado);
        return total;
    }

    public void CadastrarVeiculo(Veiculo v, DateTime data)
    {
        Veiculos.Append(v);
        Entrada entrada = new Entrada
        {
            Placa = v.Placa,
            Data = data
        };
        Entradas.Append(entrada);
        Console.WriteLine($"Veículo {v.Placa}, cadastrado com sucesso!");
    }

    public void RetirarVeiculo(string placa, DateTime dataRetirada)
    {
        Entrada entrada = BuscarEntradaPorPlaca(placa);
        List<Veiculo> veiculos = BuscarVeiculoPorPlaca(entrada.Placa);
        if(veiculos.Count == 1)
        {
            TimeSpan diferenca = dataRetirada.Subtract(entrada.Data);
            int horasEstacionado = (int)Math.Floor(diferenca.TotalHours);
            Retirada retirada = new Retirada{
                Valor = CalcularPreço(horasEstacionado),
                Placa = entrada.Placa,
                Data = dataRetirada
                };
            //Entrada a ser removida
            Retiradas.Append(retirada);
            Entradas.Remove(entrada);
            Veiculos.Remove(veiculos.ElementAt(0));
        }
        else
        {
            Console.WriteLine("Erro. Não foi possível retirar o veículo, verifique suas informações");
        }
    }

    private Entrada BuscarEntradaPorPlaca(string placa)
    {
        List<Entrada> entrada = Entradas.FindAll(
            delegate(Entrada e)
            {
                return e.Placa == placa;
            }
        );
        return entrada.ElementAt(0) ?? throw new Exception("Entrada não encontrada");
    }
}