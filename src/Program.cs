using DesignPatternChallengeChainOfResponsability.ConcreteMiddlewares;

namespace DesignPatternChallengeChainOfResponsability
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<ExpenseRequest> listExpenseRequest = new List<ExpenseRequest>();

            listExpenseRequest.Add(new ExpenseRequest("João Silva", 50.00m, "Material de escritório", "TI"));
            listExpenseRequest.Add(new ExpenseRequest("Maria Santos", 350.00m, "Curso de capacitação", "RH"));
            listExpenseRequest.Add(new ExpenseRequest("Pedro Oliveira", 2500.00m, "Notebook", "TI"));
            listExpenseRequest.Add(new ExpenseRequest("Ana Costa", 15000.00m, "Servidor para datacenter", "TI"));

            foreach (var expenseRequest in listExpenseRequest)
            {
                var chain = new SupervisorApproval(
                            new ManagerApproval(
                                new DirectorRequest(
                                    new CeoRequest(null))));
                chain.ProcessExpense(expenseRequest);
            }
        }
    }
}