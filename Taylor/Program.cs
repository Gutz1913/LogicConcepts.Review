using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::");
Console.WriteLine(":::::: TAYLOR EXERCISE ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::");
do
{
    try
    {
        var n = ConsoleExtension.GetInt("Number of terms: ");
        var x = ConsoleExtension.GetDouble("X value........: ");
        var taylor = Taylor(x, n);
        Console.WriteLine($"f({x}) = {taylor:N5}");
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

double Taylor(double x, int n)
{
    double sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += Math.Pow(x, i) / MyMath.Factorial(i);
    }
    return sum;
}


