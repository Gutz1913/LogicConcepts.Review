using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::::::: SORT NUMBERS EXERCISE ::::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var number1 = ConsoleExtension.GetInt("Enter first number: ");
        var number2 = ConsoleExtension.GetInt("Enter second number: ");
        var number3 = ConsoleExtension.GetInt("Enter third number: ");

        if (number1 == number2 || number1 == number3 || number2 == number3)
        {
            Console.WriteLine("The numbers must be different from each other. Try again.");
            continue;
        }

        if (number1 > number2 && number1 > number3)
        {
            if (number2 > number3)
            {
                Console.WriteLine($"The largest is {number1}, the middle one is {number2}, the smallest is {number3}");
            }
            else
            {
                Console.WriteLine($"The largest is {number1}, the middle one is {number3}, the smallest is {number2} ");
            }
        }
        else if (number2 > number1 && number2 > number3)
        {
            if (number1 > number3)
            {
                Console.WriteLine($"The largest is {number2}, the middle one is {number1}, the smallest is {number3}");
            }
            else
            {
                Console.WriteLine($"The largest is {number2}, the middle one is {number3}, the smallest is {number1}");
            }
        }
        else
        {
            if (number1 > number2)
            {
                Console.WriteLine($"The largest is {number3}, the middle one is {number1}, the smallest is {number2}");
            }
            else
            {
                Console.WriteLine($"The largest is {number3}, the middle one is {number2}, the smallest is {number1}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("Do you want to continue? ¿[Y]es, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");
