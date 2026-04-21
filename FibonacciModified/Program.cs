using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: FIBONACCI MODIFIED EXERCISE :::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var n = ConsoleExtension.GetInt("How many terms do you want (3 minimum): ");
		double a = 0;
		double b = 1;
		double c = 2;

		Console.Write($"{a,20:N0}{b,20:N0}{c,20:N0}");

		for (int i = 3; i < n; i++)
		{
			double d = a + b + c;
			Console.Write($"{d,20:N0}");
			a = b;
			b = c;
			c = d;
        }
		Console.WriteLine();
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error {ex.Message}");		
	}

    do
    {
		answer = ConsoleExtension.GetValidOptions("¿Do you want to continue? ¿[Y]es, [No]?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");