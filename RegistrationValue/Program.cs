using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: REGISTRATION VALUE EXERCISE ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var credits = ConsoleExtension.GetInt("Credits number.....: ");
        var creditValue = ConsoleExtension.GetDecimal("Value per credit...: ");
        var stratum = ConsoleExtension.GetInt("Student stratum....:");

        var registrationValue = CalculateRegistrationValue(credits, creditValue, stratum);
        var subsidy = CalculateSubsidy(stratum);

        Console.WriteLine($"Registration value: {registrationValue,20:C2}");
        Console.WriteLine($"Subsidy value: {subsidy,20:C2}");
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

decimal CalculateSubsidy(int stratum)
{
    if (stratum == 1)
    {
        return 200000M;
    }
    if (stratum == 2)
    {
        return 100000M;
    }
    return 0;
}

decimal CalculateRegistrationValue(int credits, decimal creditValue, int stratum)
{
    decimal value;
    if (credits <= 20)
    {
        value = credits * creditValue;
    }
    else
    {
        value = (20 * creditValue) + ((credits - 20) * creditValue * 2M);
    }

    if (stratum == 1)
    {
        return value * 0.2M;
    }
    if (stratum == 2)
    {
        return value * 0.5M;
    }
    if (stratum == 3)
    {
        return value * 0.7M;
    }
    return value;
}

