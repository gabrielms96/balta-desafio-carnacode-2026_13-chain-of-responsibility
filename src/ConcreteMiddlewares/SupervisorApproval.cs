using DesignPatternChallengeChainOfResponsability.Handler;

namespace DesignPatternChallengeChainOfResponsability.ConcreteMiddlewares
{
    public class SupervisorApproval : ExpenseApprovalSystem
    {
        public SupervisorApproval(ExpenseApprovalSystem next) : base(next) { }

        public override void ProcessExpense(ExpenseRequest request)
        {
            if (request.Amount <= 100)
            {

                Console.WriteLine("[Supervisor] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
                {
                    Console.WriteLine($"✅ [Supervisor] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("Supervisor", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Supervisor] Despesa REJEITADA - Documentação inválida");
                }
            }
            else
            {
                Next.ProcessExpense(request);
            }
        }

    }
}

