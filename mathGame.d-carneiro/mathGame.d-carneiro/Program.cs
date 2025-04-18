using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

// math game app - c# academy

class Program
{
    private static readonly List<string> historico = new List<string>();

    static void Main()
    {
        Console.WriteLine("Welcome to the math game");

        bool continuar = true;
        while (continuar)
        {
            Questionario();
            Console.WriteLine("Do you wish to make another operation? (y/any key)");
            string simOuNao = Console.ReadLine()?.ToLower();
            if (simOuNao != "y")
            {
                Console.WriteLine("Thank you for your participation!");
                continuar = false;
            }

        }

    }

    static void Questionario()
    {
        string escolha;
        while (true)
        {
            Console.WriteLine("Chose an operation:");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Subtract");
            Console.WriteLine("3 - Multiply");
            Console.WriteLine("4 - Divide");
            Console.WriteLine("5 - Show history");
            escolha = Console.ReadLine();
            if (escolha == "1" || escolha == "2" || escolha == "3" || escolha == "4" || escolha == "5")
                break;
            else
                Console.WriteLine("Invalid option, try again");
        }
        if (escolha == "5")
        {
            MostrarResultado();
            return;
        }
        int num1 = LerNumero("First number: ");

        if (escolha == "4" && (num1 < 0 || num1 > 100))
        {
            Console.WriteLine("The dividend must be between 0 and 100");
            return;
        }
            int num2 = LerNumero("Second number: ");

        if (escolha == "4" && num2 == 0)
        {
            Console.WriteLine("It's not possible to divide by 0");
            return;
        }

        if (escolha == "4" && ( num1 % num2 != 0))
        {
            Console.WriteLine("The result is not an integer");
            return;
        }


        Operacoes(num1, num2, escolha);

    }
    static void Operacoes(int a, int b, string c)
    {
        string resultado = "";
        switch (c)
        {
            case "1":
                int somaa = a + b;
                resultado = $"{a} + {b} = {somaa}";
                Console.WriteLine($"Your result is: {somaa}");
                break;
            case "2":
                int subt = a - b;
                resultado = $"{a} - {b} = {subt}";
                Console.WriteLine($"Your result is: {subt}");
                break;
            case "3":
                int multi = a * b;
                resultado = $"{a} * {b} = {multi}";
                Console.WriteLine($"Your result is: {multi}");
                break;
            case "4":
                int divi = a / b;
                resultado = $"{a} / {b} = {divi}";
                Console.WriteLine($"Your result is: {divi}");
                break;
            default:
                Console.WriteLine("Invalid option");
                break;


        }
        historico.Add(resultado);

    }

    static void MostrarResultado()
    {
        Console.WriteLine("Operations history:");
        if (historico.Count == 0)
        {
            Console.WriteLine("No operations made yet!");
        }
        else
        {
            foreach (var entrada in historico)
            {
                Console.WriteLine(entrada);
            }
        }
    }

    static int LerNumero(string message)
    {
        Console.WriteLine(message);
        string input = Console.ReadLine();
        int numero;
        while (!int.TryParse(input, out numero))
        {
            Console.WriteLine("Please insert an integer");
            input = Console.ReadLine();
        }

        return numero;
    }

}
