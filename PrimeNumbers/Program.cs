using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: PRIME NUMBERS EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var n = ConsoleExtension.GetInt("how many prime numbers do you want?: ");
		var primes = GetPrimes(n);
		foreach (var prime in primes)
		{
			Console.Write($"{prime,10:NO}");
		}
		Console.WriteLine();
		Console.WriteLine($"The sum is..................: {primes.Sum(),10:N0}");
		Console.WriteLine($"The average is..............: {primes.Average(),10:N2}");
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

List<int> GetPrimes(int n)
{
	var primes = new List<int>();
	var num = 2;
	while (primes.Count < n)
	{
		if (MyMath.IsPrime(num))
		{
			primes.Add(num);
		}
		num++;
	}
	return primes;
}


