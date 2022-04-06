using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadTask
{
    class Program
    {
        private static DummyRequestHandler RequestHandler =
                                new DummyRequestHandler();
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение запущено");
            Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");

            string command = "";

            while ((command = Console.ReadLine()) != "/exit")
            {
                Request(command);

                Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
            }
            Console.WriteLine("Приложение устало");
        }

        private static void HandleRequest(string guid, string str, string[] strArr)
        {
            try
            {
                var response = RequestHandler.HandleRequest(str, strArr);
                Console.WriteLine($"Сообщение с идентификатором {guid} " +
                                  $"получило ответ - {response}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Сообщение с идентификатором {guid} " +
                                  $"упало с ошибкой: {e.Message}");
            }
        }

        private static void Request(string str)
        {
            Console.WriteLine($"Будет послано сообщение {str}");

            string message = "";
            List<string> listOfArg = new List<string>();
            while (message != "/end")
            {
                Console.WriteLine("Введите агрументы сообщения. Для окончания добавления аргументов введите /end");
                message = Console.ReadLine();
                listOfArg.Add(message);
            }
            var identifity = Guid.NewGuid().ToString("D");

            Console.WriteLine($"Было отправлено сообщение \"{str}\". " +
                              $"Присвоен идентификатор {identifity}");

            ThreadPool.QueueUserWorkItem(_ => HandleRequest(identifity, str, listOfArg.ToArray()));
        }
    }
}