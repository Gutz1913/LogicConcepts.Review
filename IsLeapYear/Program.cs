using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: LEAP YEAR EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::");
do
{
	var currentYear = DateTime.Now.Year;
	var message = string.Empty;
	var year = 0;
	try
	{
		year = ConsoleExtension.GetInt("Ingresa el año: ");
		if (year == currentYear)
		{
			message = "es";
		}
		else if (year > currentYear)
		{
			message = "va a ser";
		}
		else
		{
			message = "fue";
        }

		var isLeapYear = DateUtilities.IsLeapYear(year);
		Console.WriteLine($"El año {year}, {(isLeapYear ? "SI" : "NO")} {message} bisiesto");
	}
	catch (Exception ex)
	{

		Console.WriteLine($"Lo que ingresaste no es un año valido.");
	}

    do
    {
		answer = ConsoleExtension.GetValidOptions("¿Do you want to continue? ¿[Y]es, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");
