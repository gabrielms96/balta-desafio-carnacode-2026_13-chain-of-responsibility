using DesignPatternChallengeChainOfResponsability.Handler;

namespace DesignPatternChallengeChainOfResponsability.ConcreteMiddlewares
{
    public class DirectorRequest : ExpenseApprovalSystem
    {
        public DirectorRequest(ExpenseApprovalSystem next) : base(next) { }

        public override void ProcessExpense(ExpenseRequest request)
        {
            if (request.Amount <= 5000)
            {
                // Diretor pode aprovar
                Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Gerente] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Diretor] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) &&
                    CheckPolicy(request) && CheckStrategicAlignment(request))
                {
                    Console.WriteLine($"✅ [Diretor] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("Diretor", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Diretor] Despesa REJEITADA");
                }
            }
            else
            {
                Next.ProcessExpense(request);
            }
        }
    }
}
