using Shared;
using System.IO.Pipes;

var answer = string.Empty;
var options = new List<string> { "y", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
Console.WriteLine(":::::: SIMPLE PAYROLL EXERCISE ::::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
do
{
	try
	{
		var name = ConsoleExtension.GetString("Enter name: ");
		var workHours = ConsoleExtension.GetInt("Enter number of worked hours: ");
		var hourValue = ConsoleExtension.GetDecimal("Enter hour value: ");
		var minimumSalary = ConsoleExtension.GetDecimal("Enter minimum salary: ");

		var salary = workHours * hourValue;
        if(salary < minimumSalary)
        {
            Console.WriteLine($"Name....................................: {name}");
            Console.WriteLine($"Salary..................................: {minimumSalary,20:C2}");
        }
        else
        {
            Console.WriteLine($"Name....................................: {name}");
            Console.WriteLine($"Salary..................................: {salary,20:C2}");
        }
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