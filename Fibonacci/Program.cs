using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: FIBONACCI EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var n = ConsoleExtension.GetInt("How many terms do you want (2 minimum): ");
		double a = 0;
		double b = 1;

		Console.Write($"{a:N0}\t{b:N0}\t");

		for (int i = 2; i < n; i++)
		{
			double c = a + b;
			Console.Write($"{c:N0}\t");
			a = b;
			b = c;
		}
		Console.WriteLine();
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