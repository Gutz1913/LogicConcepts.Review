using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: MULTIPLAE OF ANOTHER ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var number1 = ConsoleExtension.GetInt("Enter the first number..: ");
		var number2 = ConsoleExtension.GetInt("Enter the second number.: ");
		if (number1 % number2 == 0)
		{
			Console.WriteLine($"{number1} is a multiple of {number2}");
		}
		else
		{
			Console.WriteLine($"{number1} is not a multiple of {number2}");
        }
    }
	catch (Exception ex)
	{

		Console.WriteLine($"Error: {ex.Message}");
	}

    do
    {
		answer = ConsoleExtension.GetValidOptions("¿Do you want to continue? ¿[Y]es, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");
