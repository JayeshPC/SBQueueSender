using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace SBQueueSender
{
    class Program
    {
        static String ConnectionString = "Endpoint=sb://myazrservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2w55AchgtlvXF6N62OcA56Fv6v7/nYSSar7H5zHKpdg=";
        static string QueuePath = "sbque";
        static void Main(string[] args)
        {
            //Service Bus Queue Sender
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);
            for (int i = 0; i < 10; i++)
            {
                var message = new BrokeredMessage("Sender's Message ==> " + i);


                //      message.SessionId = “test”;


                queueClient.Send(message);
                Console.Write("\nSent Message : = " + i);
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
            queueClient.Close();

        }
    }
}
