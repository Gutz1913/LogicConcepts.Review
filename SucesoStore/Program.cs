using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: SUCESO STORE EXERCISE ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		Console.WriteLine("*** INPUT DATA ***");
		var CC = ConsoleExtension.GetDecimal("Purchase cost ($)....................................................: ");

		var tpOptions = new List<string> { "p", "n" };
		var TP = string.Empty;
        do
        {
			TP = ConsoleExtension.GetValidOptions("Product type [P]erishable, [N]on-perishable: ", tpOptions);
        } while (!tpOptions.Any(x => x.Equals(TP, StringComparison.CurrentCultureIgnoreCase)));

		var tcOptions = new List<string> { "c", "e" };
		var TC = string.Empty;
        do
        {
			TC = ConsoleExtension.GetValidOptions("Conservation type [C]old, [E]nvironment: ", tcOptions);
        } while (!tcOptions.Any(x => x.Equals(TC, StringComparison.CurrentCultureIgnoreCase)));

		var PC = ConsoleExtension.GetInt("Conservation period (days).........................................: ");
		var PA = ConsoleExtension.GetInt("Storage period (days)..............................................: ");
		var VOL = ConsoleExtension.GetInt("Volume (liters)....................................................:");

		var maOptions = new List<string> { "n", "c", "e", "g" };
		var MA = string.Empty;
        do
        {
			MA = ConsoleExtension.GetValidOptions("Storage medium [N]evera, [C]ongelador, [E]estanteria, [G]uacal: ", maOptions);
        } while (!maOptions.Any(x => x.Equals(MA, StringComparison.CurrentCulture)));

		Console.WriteLine("*** CALCULATIONS ***");
		var CA = GetStorageCost(CC, TC, PC, TP, VOL, PA);
		var PDP = GetProductDepreciation(PA);
		var CE = GetExhibitionCost(TP, TC, MA, CA);
		var VR_P = GetProductValue(CC, CA, CE, PDP);
		var VR_V = GetSaleValue(VR_P, TP);
		Console.WriteLine($"Storage costs...............................................: {CA,20:C2}");
		Console.WriteLine($"Depreciation percentage.....................................: {PDP,20:P2}");
		Console.WriteLine($"Exhibition costs............................................: {CE,20:C2}");
		Console.WriteLine($"Product value...............................................: {VR_P,20:C2}");
		Console.WriteLine($"Sale value..................................................: {VR_V,20:C2}");
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

decimal GetStorageCost(decimal CC, string? TC, int PC, string? TP, int VOL, int PA)
{
	if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
	{
		if (TC!.Equals("c", StringComparison.CurrentCultureIgnoreCase))
		{
			if (PC < 10)
			{
				return CC * 0.05M;
			}
			return CC * 0.1M;
		}

		if (PA < 20)
		{
			return CC * 0.03M;
		}

		if (PA > 20)
		{
			return CC * 0.1M;
		}
		return CC * 0.05M;
	}

	if (VOL >= 50)
	{
		return CC * 0.1M;
	}
	return CC * 0.2M;
}

float GetProductDepreciation(int PA)
{
	if (PA < 30)
	{
		return 0.95f;
	}
	return 0.85f;
}

decimal GetExhibitionCost(string? TP, string? TC, string? MA, decimal CA)
{
	if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
	{
		if (TC!.Equals("c", StringComparison.CurrentCultureIgnoreCase))
		{
			if (MA!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
			{
				return CA * 2;
			}
			if (MA!.Equals("c", StringComparison.CurrentCultureIgnoreCase))
			{
				return CA;
			}
		}
	}
	if (MA!.Equals("e", StringComparison.CurrentCultureIgnoreCase))
	{
		return CA * 0.05M;
	}
    if (MA!.Equals("g", StringComparison.CurrentCultureIgnoreCase))
    {
        return CA * 0.7M;
    }
	return 0;
}

decimal GetProductValue(decimal CC, decimal CA, decimal CE, float PDP)
{
	return (CC + CA + CE) * (decimal)PDP;
}

decimal GetSaleValue(decimal VR_P, string? TP)
{
	if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
	{
		return VR_P * 1.4M;
	}
	return VR_P * 1.2M;
}