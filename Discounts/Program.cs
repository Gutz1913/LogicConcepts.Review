using Shared;
using System.IO.Pipes;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: DISCOUNTS EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var desks = ConsoleExtension.GetInt("Desks number.......:");
		var valueToPay = CalculateValue(desks);
	}
	catch (Exception ex)
	{

		Console.WriteLine(ex.Message);
	}

    do
    {
		answer = ConsoleExtension.GetValidOptions("¿Do you want to continue? ¿[Y]es, [No]?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");

decimal CalculateValue(int desks)
{
    float discount;
	if (desks < 5)
	{
		discount = 0.1f;
	}
	else if (desks >= 5 && desks < 10)
	{
		discount = 0.2f;
	}
	else
	{
		discount = 0.4f;
	}
	return desks * 650000M * (decimal)(1 - discount);
}

