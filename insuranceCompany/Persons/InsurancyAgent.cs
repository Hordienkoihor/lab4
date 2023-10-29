namespace insuranceCompany.Persons;

public class InsurancyAgent: Person
{
    public InsurancyAgent(string firstName, string lastName, long passportNumber, DateTime birthDate, double salery) : base(firstName, lastName, passportNumber, birthDate)
    {
        Salery = salery;
    }

    public InsurancyAgent(string firstName, string lastName, DateTime birthDate, double salery) : base(firstName, lastName, birthDate)
    {
        Salery = salery;
    }
/// <summary>
/// /
/// </summary>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="passportNumber"></param>
/// <param name="salery"></param>
    public InsurancyAgent(string firstName, string lastName, long passportNumber, double salery) : base(firstName, lastName, passportNumber)
    {
        Salery = salery;
    }

    public double Salery { get; private set; }
    // public double DealsCount { get; private set; }
    
}