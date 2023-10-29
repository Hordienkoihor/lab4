using insuranceCompany.Persons;

namespace insuranceCompany;

public class Program
{
    public static void Main()
    {
        InsuranceCompany test = new InsuranceCompany("testova");
        test.addAgent(new InsurancyAgent("Petro", "Olecsiyovich", DateTime.Now,  2000));
        Client client = new Client("Petro", "Olecsiyovich", DateTime.Now, 20000);
        InsurancyAgent agent = test.Agents.Find(x => x.FirstName == "Petro");
        Contract testContract = new Contract(client,agent , "korova", 3642838, 1, test);
        if (testContract != null)
        {
            test.addContract(testContract);
        }
        System.Threading.Thread.Sleep(10000);
    }
}