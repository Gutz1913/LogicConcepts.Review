using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: TAYLOR MODIFIED EXERCISE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var n = ConsoleExtension.GetInt("Number of terms: ");
        var x = ConsoleExtension.GetDouble("X value........: ");
        var taylor = TaylorModified(x, n);
        Console.WriteLine($"f({x}) = {taylor:N5} ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Do you want to continue? ¿[Y]es, [No]?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine(":::::: GAME OVER ::::::");

double TaylorModified(double x, int n)
{
    double sum = 0;
    int sign = 1;
    for (int i = 0; i < n; i++)
    {
        sum += Math.Pow(x, i) / MyMath.Factorial(i) * sign;
        sign *= -1;
    }
    return sum;
}

