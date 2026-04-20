
using Shared;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: TRANSPORTATION COMPANY EXERCISE ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.WriteLine("*** INPUT DATA ***");
        var routeOptions = new List<string> { "1", "2", "3", "4"};
        var route = string.Empty;
        do
        {
            route = ConsoleExtension.GetValidOptions("Route [1][2][3][4]...............................: ", routeOptions);
        }
        while (!routeOptions.Any(x => x == route));
        var trips = ConsoleExtension.GetInt("Number of trips..........................................: ");
        var passengers = ConsoleExtension.GetInt("Total number of passengers..........................: ");
        var packages10 = ConsoleExtension.GetInt("Number of parcels weighing less than 10Kg...........: ");
        var packages10_20 = ConsoleExtension.GetInt("Number of parcels between 10Kg and less than 20Kg: ");
        var packages20 = ConsoleExtension.GetInt("Number of parcels over 20Kg.........................: ");
        Console.WriteLine();
        var incomePassengers = GetIncomePassengers(route, passengers, trips);
        var incomePackages = GetIncomePackages(route, packages10, packages10_20, packages20);
        var incomes = incomePassengers + incomePackages;
        var valueHelper = GetValueHelper(incomes);
        var valueSure = GetValueSure(incomes);
        var fuelValue = GetFuelValue(route, trips, passengers, packages10, packages10_20, packages20);
        var deductions = valueHelper + valueSure + fuelValue;
        var totalToPay = incomes - deductions;
        Console.WriteLine("*** CALCULATIONS ***");
        Console.WriteLine($"Passenger Revenue..........................: {incomePassengers,20:C2} ");
        Console.WriteLine($"Income from Parcels........................: {incomePackages,20:C2} ");
        Console.WriteLine($"                                             -------------------- ");
        Console.WriteLine($"TOTAL INCOME...............................: {incomes,20:C2} ");
        Console.WriteLine($"Assistant Payment..........................: {valueHelper,20:C2} ");
        Console.WriteLine($"Sure Payment...............................: {valueSure,20:C2} ");
        Console.WriteLine($"Fuel Payment...............................: {fuelValue,20:C2} ");
        Console.WriteLine($"                                             -------------------- ");
        Console.WriteLine($"TOTAL DEDUCTIONS...........................: {deductions,20:C2} ");
        Console.WriteLine($"                                             ==================== ");
        Console.WriteLine($"TOTAL AMOUNT DUE...........................: {totalToPay,20:C2} ");
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

decimal GetFuelValue(string? route, int trips, int passengers, int packages10, int packages10_20, int packages20)
{
    float kms;
    switch (route)
    {
        case "1":
            kms = 150 * trips;
            break;
        case "2":
            kms = 167 * trips;
            break;
        case "3":
            kms = 184 * trips;
            break;
        default:
            kms = 203 * trips;
            break;
    }

    var gallons = kms / 39;
    var value = (decimal)gallons * 8860;
    var weight = passengers * 60 + packages10 * 10 + packages10_20 * 15 + packages20 * 20;
    if (weight < 5000) return value;
    if (weight <= 10000) return value * 1.1M;
    return value * 1.25M;
}

decimal GetValueSure(decimal incomes)
{
    if (incomes < 1000000) return incomes * 0.05M;
    if (incomes <= 2000000) return incomes * 0.08M;
    if (incomes < 4000000) return incomes * 0.08M;
    return incomes * 0.13M;
}

decimal GetValueHelper(decimal incomes)
{
    if (incomes < 1000000) return incomes * 0.03M;
    if (incomes <= 2000000) return incomes * 0.04M;
    if (incomes < 4000000) return incomes * 0.06M;
    return incomes * 0.9M;    
}

decimal GetIncomePackages(string? route, int packages10, int packages10_20, int packages20)
{
    decimal value = 0;
    switch (route)
    {
        case "1":
        case "2":
            if (packages10 < 50) value += packages10 * 100M;
            else if (packages10 <= 100) value += packages10 * 120M;
            else if (packages10 <= 130) value += packages10 * 150M;
            else value += packages10 * 160M;

            var packagesGreater10 = packages10_20 + packages20;
            if (packagesGreater10 <= 50) value += packagesGreater10 * 120M;
            else if (packagesGreater10 <= 100) value += packagesGreater10 * 140M;
            else if (packagesGreater10 <= 130) value += packagesGreater10 * 160M;
            else value += packagesGreater10 * 180M;
            return value;

        default:
            if (packages10 <= 50) value += packages10 * 130M;
            else if (packages10 <= 100) value += packages10 * 160M;
            else if (packages10 <= 130) value += packages10 * 175M;
            else value += packages10 * 200M;

            if (packages10_20 <= 50) value += packages10_20 * 140M;
            else if (packages10_20 <= 100) value += packages10_20 * 180M;
            else if (packages10_20 <= 130) value += packages10_20 * 200M;
            else value += packages10_20 * 300M;
            return value;
    }
}

decimal GetIncomePassengers(string? route, int passengers, int trips)
{
    decimal value = 0;
    switch (route)
    {
        case "1":
            value = 500000M * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.05M; 
            if (passengers <= 150) return value * 1.06M; 
            if (passengers <= 200) return value * 1.07M;
            return value * 1.07M + (passengers - 200) * 50M;
            
        case "2":
            value = 600000M * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.07M;
            if (passengers <= 150) return value * 1.08M;
            if (passengers <= 200) return value * 1.09M;
            return value * 1.09M + (passengers - 200) * 60M;

        case "3":
            value = 800000M * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.10M;
            if (passengers <= 150) return value * 1.13M;
            if (passengers <= 200) return value * 1.15M;
            return value * 1.15M + (passengers - 200) * 100M;
         
        default:
            value = 1000000M * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.125M;
            if (passengers <= 150) return value * 1.15M;
            if (passengers <= 200) return value * 1.7M;
            return value * 1.17M + (passengers - 200) * 150M;
    }
}



