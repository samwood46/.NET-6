
try
{
    DivideMultipleNumbers((5, 2), (16, 1), (38, 0), (56, 9), (98, 15));

}
catch (DivisionResultException ex)
{
    Console.WriteLine($"DivisionResultException has been thrown: {ex.Message}");
    throw;
}

catch (DivideByZeroException ex)
{


    Console.WriteLine($"DivideByZeroException has been thrown: {ex.Message}");
}
static void DivideMultipleNumbers(params (int number, int divisor)[] numbers)
{
    double[] result;
    try
    {
        result = numbers.Select(s => Math.Round((double)(s.number / s.divisor), MidpointRounding.ToZero)).ToArray(); //goes through and rounds down each ans ie 2.5 = 2

        Console.WriteLine($"Division operation has been completed successfully: {string.Join(",", result)}");

    }

    // Inner exception is basically checking if theres more details so more context can be gicven as to what went wrong
    catch (Exception ex) when (ex is DivideByZeroException && ex.InnerException != null) // inner exception is null so it goews to the finally block
    {
        Console.WriteLine($"Exception has been thrown: {ex.Message}");
        throw; // throws original exception that was caught
    }

    // finally block must be hit no matter what
    finally
    {
        new DivisionResultException();

    }

}
class DivisionResultException : DivideByZeroException
{  }
