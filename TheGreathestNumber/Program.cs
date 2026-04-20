using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DEL NÚMERO MAYOR :::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var number1 = ConsoleExtension.GetInt("Enter first number: ");
		var number2 = ConsoleExtension.GetInt("Enter second number: ");
		var number3 = ConsoleExtension.GetInt("Enter third number: ");

		if (number1 > number2 && number1 > number3)
		{
			Console.WriteLine($"The greathest number is: {number1}");
		}
		else if (number2 > number1 && number2 > number3)
		{
			Console.WriteLine($"The greathest number is: {number2}");
		}
		else if (number3 > number1 && number3 > number2)
		{
			Console.WriteLine($"The greathest number is: {number3}");
		}
		else 
		{
			Console.WriteLine("The numbers are equal or a single larger number cannot be determined.");
		}

    }
	catch (Exception ex)
	{

		Console.WriteLine(ex.Message);
	}

	do
	{
		answer = ConsoleExtension.GetValidOptions("¿Do you want to continue? ¿[Y]es, [N]o?: ", options);
	} while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");
