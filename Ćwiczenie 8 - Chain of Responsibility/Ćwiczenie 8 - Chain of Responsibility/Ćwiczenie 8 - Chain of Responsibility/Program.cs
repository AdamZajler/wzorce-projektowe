using System;

namespace Ćwiczenie_8___Chain_of_Responsibility
{
    interface IHandler
    {
        void HandleErrorLogRequest(string code);
    }


    class ConcreateInfoHandler : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleErrorLogRequest(string code)
        {
            if (code == "INFO")
            {
                Console.WriteLine("Obsługa błędu typu INFO\n");
            }
            else
            {
                successor.HandleErrorLogRequest(code);
            }
        }
    }

    class ConcreateWarningHandler : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleErrorLogRequest(string code)
        {
            if (code == "WARNING")
            {
                Console.WriteLine("Obsługa błędu typu WARNING\n");
            }
            else
            {
                successor.HandleErrorLogRequest(code);
            }
        }
    }

    class ConcreateErrorHandler : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        public void HandleErrorLogRequest(string code)
        {
            Console.WriteLine("Obsługa błędu typu INFO\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var InfoHandler = new ConcreateInfoHandler();
            var WarningHandler = new ConcreateWarningHandler();
            var ErrorHandler = new ConcreateErrorHandler();

            InfoHandler.SetSuccessor(WarningHandler);
            WarningHandler.SetSuccessor(ErrorHandler);

            var errors = new string[] { "INFO", "WARNING", "ERROR" };

            foreach (string error in errors)
            {
                Console.WriteLine("TYP BŁĘDU: {0}", error);
                InfoHandler.HandleErrorLogRequest(error);
            }

            Console.ReadKey();
        }
    }
}
