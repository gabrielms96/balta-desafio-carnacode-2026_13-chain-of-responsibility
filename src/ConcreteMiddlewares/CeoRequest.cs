using DesignPatternChallengeChainOfResponsability.Handler;

namespace DesignPatternChallengeChainOfResponsability.ConcreteMiddlewares
{
    public class CeoRequest : ExpenseApprovalSystem
    {
        public CeoRequest(ExpenseApprovalSystem next) : base(next)
        {
        }

        public override void ProcessExpense(ExpenseRequest request)
        {
            Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
            Console.WriteLine("[Gerente] Valor acima do meu limite, encaminhando...");
            Console.WriteLine("[Diretor] Valor acima do meu limite, encaminhando...");
            Console.WriteLine("[CEO] Analisando pedido...");

            if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) &&
                CheckPolicy(request) && CheckStrategicAlignment(request) && CheckBoardApproval(request))
            {
                Console.WriteLine($"✅ [CEO] Despesa de R$ {request.Amount:N2} APROVADA");
                RegisterApproval("CEO", request);
            }
            else
            {
                Console.WriteLine($"❌ [CEO] Despesa REJEITADA");
            }
        }
    }
}
