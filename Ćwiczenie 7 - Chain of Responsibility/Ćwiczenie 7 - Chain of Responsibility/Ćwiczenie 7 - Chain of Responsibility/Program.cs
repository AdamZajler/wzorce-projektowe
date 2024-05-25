using System;

namespace Ćwiczenie_7___Chain_of_Responsibility
{
    interface IHandler
    {
        void HandleTicketRequest(int code, string message);
    }


    class ConcreateTechnicalIssueHandler : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleTicketRequest(int code, string message)
        {
            if (code == 1)
            {
                Console.WriteLine("Obsługa wiadomości '{0}' przez pomoc techniczną\n", message);
            }
            else
            {
                successor.HandleTicketRequest(code, message);
            }
        }
    }

    class ConcreateBillingHandler : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleTicketRequest(int code, string message)
        {
            if (code == 2)
            {
                Console.WriteLine("Obsługa wiadomości '{0}' przez pomoc dział pomocy rozliczeniowej\n", message);
            }
            else
            {
                successor.HandleTicketRequest(code, message);
            }
        }
    }

    class ConcreateGeneralReportsHandler : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleTicketRequest(int code, string message)
        {
            Console.WriteLine("Obsługa wiadomości '{0}' przez ogólną pomoc raportów\n", message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var TechnicalHandler = new ConcreateTechnicalIssueHandler();
            var BillingHandler = new ConcreateBillingHandler();
            var GeneralHandler = new ConcreateGeneralReportsHandler();

            TechnicalHandler.SetSuccessor(BillingHandler);
            BillingHandler.SetSuccessor(GeneralHandler);

            var requests = new int[] { 1, 2, 3 };

            foreach(int request in requests)
            {
                Console.WriteLine("Obsługuje request: {0}", request);
                TechnicalHandler.HandleTicketRequest(request, "Problem XYZ");
            }

            Console.ReadKey();
        }
    }
}
