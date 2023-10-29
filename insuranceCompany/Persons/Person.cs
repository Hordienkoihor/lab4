

namespace insuranceCompany.Persons;

public abstract class  Person
{
    private DateTime _birthDate;
    private long _passportNumber;
    public string FirstName { get; private set; } 
    public string LastName { get; private set; }

    public long PassportNumber
    {
        get => _passportNumber;
        private set
        {
            int count = value.ToString().Length;
            if (count == 8)
            {
                _passportNumber = value;
            }
        }
    }
//
    public DateTime BirthDate
    {
        get => _birthDate;
        private set
        {   int age = DateTime.Now.Date.Year - value.Year;
            if (age >= 18)
            {
                _birthDate = value;
                
            }
        }
    }

    protected Person(string firstName, string lastName, long passportNumber, DateTime birthDate)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.PassportNumber = passportNumber;
        this.BirthDate = birthDate;

    }

    protected Person(string firstName, string lastName, DateTime birthDate)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.PassportNumber = 0;
        this.BirthDate = birthDate;
    }
    
    protected Person(string firstName, string lastName, long passportNumber)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.PassportNumber =  passportNumber;
        this.BirthDate = DateTime.MinValue;
    }
}