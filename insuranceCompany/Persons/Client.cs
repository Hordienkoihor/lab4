namespace insuranceCompany.Persons;

public class Client: Person 
{
    public Client(string firstName, string lastName, long passportNumber, DateTime birthDate, double yearlyIncome) : base(firstName, lastName, passportNumber, birthDate)
    {
        YearlyIncome = yearlyIncome;
    }

    public Client(string firstName, string lastName, DateTime birthDate, double yearlyIncome) : base(firstName, lastName, birthDate)
    {
        YearlyIncome = yearlyIncome;
    }
//
    public Client(string firstName, string lastName, long passportNumber, double yearlyIncome) : base(firstName, lastName, passportNumber)
    {
        YearlyIncome = yearlyIncome;
    }

    public double YearlyIncome { get; private set; }

    /// <summary>
    /// Making payment method 
    /// </summary>
    /// <param name="paymentAmount"></param>
    public void MakePayment(double paymentAmount)
    {
        Console.WriteLine($"payment done!! {paymentAmount} грошей ");
    }
}