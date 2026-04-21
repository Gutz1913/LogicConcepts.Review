using Shared;
using System.IO.Pipes;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: QUADRATIC EQUATIONS EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var a = ConsoleExtension.GetDouble("Enter the value of 'a': ");
		var b = ConsoleExtension.GetDouble("Enter the value of 'b': ");
		var c = ConsoleExtension.GetDouble("Enter the value of 'c': ");
		var solution = QuadraticEquation(a, b, c);
		Console.WriteLine($"X1 = {solution.X1:N5}");
		Console.WriteLine($"X2 = {solution.X2:N5}");
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

QuadraticEquationSolution QuadraticEquation(double a, double b, double c)
{
	return new QuadraticEquationSolution
	{
		X1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
		X2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a)
	};
}

public class QuadraticEquationSolution
{
	public double X1 { get; set; }
	public double X2 { get; set; }
}


