using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: EXERCISE WITH EVEN AND ODD NUMBERS ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var number = ConsoleExtension.GetInt("Enter a number: ");
        if (number % 2 == 0)
        {
            Console.WriteLine($"The number: {number}, is Odd.");
        }
        else
        {
            Console.WriteLine($"The number: {number}, is Even.");
        }
    }
    catch (Exception ex)
    {

        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("Do you want to continue? ¿[Y]es, [N]o?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");
