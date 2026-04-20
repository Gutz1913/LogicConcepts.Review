using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: SHIPPING EXERCISE ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::");
do
{
	try
	{
		var weight = ConsoleExtension.GetFloat("Weight of the merchandise: ");
		var value = ConsoleExtension.GetDecimal("Value of the merchandise: ");
		string isMonday;
        do
        {
			isMonday = ConsoleExtension.GetValidOptions("¿Is Monday? ¿[Y]es, [N]o?: ", options)!;
        }
        while (!options.Any(x => x.Equals(isMonday, StringComparison.CurrentCultureIgnoreCase)));

		var payMethods = new List<string> { "m", "c" };
		string payMethod;
        do
        {
            payMethod = ConsoleExtension.GetValidOptions("Pay method [M]oney, [C]ard: ", payMethods)!; 
        } while (!payMethods.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));

		var fare = CalculateFare(weight);
		var discount = CalculateDiscount(fare, value);
		decimal promotion = 0;
		if (discount == 0)
		{
			promotion = CalculatePromotion(fare, isMonday, payMethod, value);
		}

		Console.WriteLine($"Fare: {fare,20:C2}");
		Console.WriteLine($"Discount: {discount,20:C2}");
		Console.WriteLine($"Promotion: {promotion,20:C2}");
		Console.WriteLine($"Value to pay: {fare - discount - promotion,20:C2}");
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

decimal CalculatePromotion(decimal fare, string isMonday, string payMethod, decimal value)
{
	if (isMonday.ToLower() == "y" && payMethod.ToLower() == "c")
	{
		return fare * 0.5M;
	}

	if (payMethod.ToLower() == "m" && value > 1000000M)
	{
		return fare * 0.4M;
	}
	return 0;
}

decimal CalculateDiscount(decimal fare, decimal value)
{
	if (value >= 300000M && value <= 600000M)
	{
		return fare * 0.1M;
	}
    if (value > 600000M && value <= 1000000M)
    {
        return fare * 0.2M;
    }
	if (value > 1000000M)
	{
		return fare * 0.3M;
	}
	return 0;
}

decimal CalculateFare(float weight)
{
    if (weight < 100)
	{
		return 20000M;
    }
	if (weight >= 100 && weight <= 150)
	{
		return 25000M;
	}
	if (weight > 150 && weight <= 200)
	{
		return 30000M;
	}
	int aditional = ((int)weight - 200) / 10;
	return 35000M + aditional * 2000;
}

