internal class Program
{
    private static void Main(string[] args)
    {
        IHealthInsurance policy = new BasicHealthInsurance();
        policy = new AccidentalAddOn(policy);
        policy = new CriticalIllness(policy);

        Console.WriteLine(policy.GetPrem());
    }
}