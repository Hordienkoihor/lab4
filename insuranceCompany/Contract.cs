using System.Runtime.CompilerServices;
using System.Timers;
using insuranceCompany.Persons;
using Timer = System.Timers.Timer;

namespace insuranceCompany;

public record Contract(Client Client, InsurancyAgent Agent, string InsuredItem, double InsuredItemWorth, long Number, InsuranceCompany Company)
{   
    public Client Client { get; private set; } = Client;
    public InsurancyAgent Agent { get; private set; } = Agent;
    public double PayRate { get; private set; } = (InsuredItemWorth * 5) / 100;
    public string InsuredItem { get; private set; } = InsuredItem;
    public double InsuredItemWorth { get; private set; } = InsuredItemWorth;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public long Number { get; private set; } = Number;
    public DateTime NextPaymentDue { get; set; }
    private InsuranceCompany _company { get; set; } = Company;

    internal Timer paymentTimer;//
    
    public event EventHandler<ContractPaymentEventArgs> ContractPaymentDue;
    public void OnPaymentTimerElapsed(object sender, ElapsedEventArgs e)
    {
        DateTime currentTime = DateTime.Now;
        foreach (var contract in Company.Contracts)
        {
            if (contract.NextPaymentDue <= currentTime)
            {
                ContractPaymentDue?.Invoke(this, new ContractPaymentEventArgs(contract.Client, contract));
            }
        }
    }
    
    
    /// <summary>
    /// initialazing payment
    /// </summary>
    public void InitializePaymentTimer()
    {
        paymentTimer = new Timer( 1000); 
        paymentTimer.Elapsed += OnPaymentTimerElapsed;
        paymentTimer.AutoReset = true;
        paymentTimer.Enabled = true;
    }
    
}