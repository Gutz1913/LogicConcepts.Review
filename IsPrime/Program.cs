using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: PRIME NUMBERS EXERCISE :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var n = ConsoleExtension.GetInt("Enter a number: ");
		var isPrime = MyMath.IsPrime(n);
		Console.WriteLine($"The number: {n}, {(isPrime ? "Is" : " Is not")} a prime number");
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
