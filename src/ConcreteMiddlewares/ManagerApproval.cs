using DesignPatternChallengeChainOfResponsability.Handler;

namespace DesignPatternChallengeChainOfResponsability.ConcreteMiddlewares
{
    public class ManagerApproval : ExpenseApprovalSystem
    {
        public ManagerApproval(ExpenseApprovalSystem next) : base(next)
        {
        }

        public override void ProcessExpense(ExpenseRequest request)
        {
            if (request.Amount <= 500)
            {
                // Gerente pode aprovar
                Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Gerente] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) &&
                    CheckPolicy(request))
                {
                    Console.WriteLine($"✅ [Gerente] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("Gerente", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Gerente] Despesa REJEITADA");
                }
            }
            else
            {
                Next.ProcessExpense(request);
            }
        }
    }
}
