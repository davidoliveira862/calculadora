using System;

class Calculadora
{
    static void Main()
    {
        Console.WriteLine("Digite a expressão (ex: 10 + 5 * 2 - 3)");
        Console.WriteLine("Operadores: + - * /");
        Console.WriteLine("Digite 'sair' para encerrar.\n");

        while (true)
        {
            Console.Write("Expressão: ");
            string entrada = Console.ReadLine()?.Trim();

            if (entrada?.ToLower() == "sair") break;

            try
            {
                string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double resultado = double.Parse(partes[0]);

                for (int i = 1; i < partes.Length - 1; i += 2)
                {
                    string op = partes[i];
                    double proximo = double.Parse(partes[i + 1]);

                    resultado = op switch
                    {
                        "+" => resultado + proximo,
                        "-" => resultado - proximo,
                        "*" => resultado * proximo,
                        "/" => proximo == 0 ? throw new DivideByZeroException() : resultado / proximo,
                        _   => throw new InvalidOperationException($"Operador inválido: {op}")
                    };
                }

                Console.WriteLine($"Resultado: {resultado}\n");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Erro: divisão por zero.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}\n");
            }
        }
    }
}