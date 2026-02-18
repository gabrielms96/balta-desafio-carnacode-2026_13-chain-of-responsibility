
using DesignPatternChallengeChainOfResponsability.ConcreteMiddlewares;

namespace DesignPatternChallengeChainOfResponsability.Handler
{
    public abstract class ExpenseApprovalSystem
    {
        protected ExpenseApprovalSystem Next;

        public ExpenseApprovalSystem(ExpenseApprovalSystem next)
        {
            Next = next;
        }

        public abstract void ProcessExpense(ExpenseRequest report);

        public virtual bool ValidateReceipt(ExpenseRequest request)
        {
            Console.WriteLine("  → Validando nota fiscal...");
            return true; // Simulação
        }

        public virtual bool CheckBudget(string department, decimal amount)
        {
            Console.WriteLine($"  → Verificando orçamento do departamento {department}...");
            return true; // Simulação
        }

        public virtual void RegisterApproval(string approver, ExpenseRequest request)
        {
            Console.WriteLine($"  → Registrando aprovação por {approver}...");
        }

        public virtual bool CheckPolicy(ExpenseRequest request)
        {
            Console.WriteLine("  → Verificando conformidade com política...");
            return true; // Simulação
        }
        public virtual bool CheckStrategicAlignment(ExpenseRequest request)
        {
            Console.WriteLine("  → Verificando alinhamento estratégico...");
            return true; // Simulação
        }

        public virtual bool CheckBoardApproval(ExpenseRequest request)
        {
            Console.WriteLine("  → Verificando aprovação do conselho...");
            return true; // Simulação
        }
    }
}
