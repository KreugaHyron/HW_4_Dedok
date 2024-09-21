using HW_4_Dedok;
internal class Program
{
    private static void Main(string[] args)
    {
        //1
        Console.WriteLine("Task_1: ");
        string[] testCases = {
            "{}[]",     
            "(())",     
            "[{}]",     
            "[}",       
            "[[{}]]",   
            "[[{]}]"    
        };
        foreach (var test in testCases)
        {
            Console.WriteLine($"'{test}' is valid: {test.AreBracketsValid()}");
        }
        Console.WriteLine();
        //2
        Console.WriteLine("Task_2: ");
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int[] evenNumbers = numbers.Filter(n => n % 2 == 0);
        Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));

        int[] oddNumbers = numbers.Filter(n => n % 2 != 0);
        Console.WriteLine("Непарні числа: " + string.Join(", ", oddNumbers));
        Console.WriteLine();
        //3
        Console.WriteLine("Task_3: ");
        var card = new CreditCard("1234-5678-9012-3456", "Іван Іванов", new DateTime(2025, 12, 31), "1234", 1000m);
        card.OnDeposit += amount => Console.WriteLine($"Поповнено: {amount} грн.");
        card.OnWithdraw += amount => Console.WriteLine($"Витрачено: {amount} грн.");
        card.OnStartUsingCredit += () => Console.WriteLine("Розпочато використання кредитних коштів.");
        card.OnLimitReached += () => Console.WriteLine("Досягнуто кредитного ліміту!");
        card.OnPinChanged += () => Console.WriteLine("PIN було змінено.");

        card.Deposit(500);
        try
        {
            card.Withdraw(600);  
            card.Withdraw(500);  
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        card.ChangePin("4321");
        Console.WriteLine();
        //4
        Console.WriteLine("Task_4: ");
        DailyTemperature[] temperatures = new DailyTemperature[]
        {
            new DailyTemperature(30.5m, 15.0m), 
            new DailyTemperature(28.0m, 10.0m), 
            new DailyTemperature(35.0m, 20.0m), 
            new DailyTemperature(25.0m, 5.0m),  
            new DailyTemperature(40.0m, 30.0m)  
        };
        int maxDifferenceDayIndex = 0;
        decimal maxDifference = temperatures[0].TemperatureDifference;

        for (int i = 1; i < temperatures.Length; i++)
        {
            decimal difference = temperatures[i].TemperatureDifference;
            if (difference > maxDifference)
            {
                maxDifference = difference;
                maxDifferenceDayIndex = i;
            }
        }

        Console.WriteLine($"День з максимальною різницею температур: День {maxDifferenceDayIndex + 1}");
        Console.WriteLine($"Максимальна різниця: {maxDifference}°C");
    }
}