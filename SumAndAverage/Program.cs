using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: SUM AND AVERAGE EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var n = ConsoleExtension.GetInt("How many numbers do you want?: ");
		int sum = 0;
		for (int i = 1; i <= n; i++)
		{
			Console.Write($"{i}\t");
			sum += i;
		}
		var average = sum / n;
		Console.WriteLine();
		Console.WriteLine($"The sum is: {sum,10:N0}");
		Console.WriteLine($"The average is: {average,10:N0}");
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
