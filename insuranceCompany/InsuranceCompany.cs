using System.Timers;
using insuranceCompany.Persons;

using Timer = System.Timers.Timer;

namespace insuranceCompany;

public class InsuranceCompany
{       
        public string Name { get;  set; }
        
        private List<Client?> clients = new List<Client>();

        public List<Client?> Clients
        {
                get { return clients; }
        }
        private List<InsurancyAgent?> agents = new List<InsurancyAgent>();

        public List<InsurancyAgent?> Agents
        {
                get { return agents; }
        }
        private List<Contract?> contracts = new List<Contract>();

        public List<Contract?> Contracts
        {
                get { return contracts; }
        }
        
        

        private Timer paymentTimer;
        public InsuranceCompany() : this("Company")
        {
                
        }

        public InsuranceCompany(string name)
        {
                Name = name;
        }
        //
        public InsuranceCompany(string name, InsurancyAgent agent)
        {
                Name = name;
                Agents.Add(agent);
        }
        /// <summary>
        /// add agent to the Agent list
        /// </summary>
        /// <param name="agent"></param>
        public void addAgent(InsurancyAgent agent)
        {
                if (agent != null)
                {
                        Agents.Add(agent);
                        Console.WriteLine($"Agent {agent.FirstName} added!");
                }
                else
                {
                        Console.WriteLine("Agent cannot be null.");
                }
        }
        /// <summary>
        /// add contract to the Contracts list
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public bool addContract(Contract contract)
        {
                if (Contracts.Any(c => c.Number == contract.Number))
                { 
                        return false;
                }

                Contracts.Add(contract);
                Clients.Add(contract.Client);
                contract.InitializePaymentTimer();
                contract.NextPaymentDue = DateTime.Now.AddMilliseconds(contract.paymentTimer.Interval); 
                
                contract.ContractPaymentDue += HandleContractPaymentDue;
                Console.WriteLine($"contract {contract.Number} added!");
                return true;

        }
        /// <summary>
        /// delete contract by its number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool deleteContract(long number)
        {       
                return(Contracts.Remove(Contracts.Find(x => x.Number == number)));
                
        }
        /// <summary>
        /// Find contract by field number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>
        /// returns contract or null
        /// </returns>
        public Contract findByNumberContract(long number)
        {
                if (Contracts.Any(x => x.Number == number))
                {
                        return Contracts.Find(x => x.Number == number);
                }
                else
                {
                        return null; 
                }
        }
        
        public InsurancyAgent findByPassNumAgent(long number)
        {
                if (Agents.Any(x => x.PassportNumber == number))
                {
                        return Agents.Find(x => x.PassportNumber == number);
                }
                else
                {
                        return null; 
                }
        }
        
        
        
        
        /// <summary>
        /// eventhandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleContractPaymentDue(object sender, ContractPaymentEventArgs e)
        {
                double paymentAmount = e.Contract.PayRate; 

                
                e.Contract.Client.MakePayment(paymentAmount); 

                
                e.Contract.NextPaymentDue = e.Contract.NextPaymentDue.AddMonths(1);        
        }


        bool removeContract(long number)
        {
                findByNumberContract(number).ContractPaymentDue -= HandleContractPaymentDue;
                return Contracts.Remove(findByNumberContract(number));
        }
        

        

        
}       