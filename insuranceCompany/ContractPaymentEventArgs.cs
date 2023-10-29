using insuranceCompany.Persons;

namespace insuranceCompany;

public class ContractPaymentEventArgs: EventArgs
{//
    public Client Client { get; }
    public Contract Contract { get; }

    public ContractPaymentEventArgs(Client client, Contract contract)
    {
        Client = client;
        Contract = contract;
    }
}