namespace Helper;

public class CalculatorHelper
{
    public static string GetInput(string message = "")
    {
        Console.Write(message);
        return Console.ReadLine();
    }
    public static void Clear()
    {
        Console.ReadKey();
        Console.Clear();
    }
}
