using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Message to be sent");
            Console.WriteLine("High priority messages should start with 'HP:')");
            string MessageToBeSend = Console.ReadLine();

            // Get or Create Queue
            MessageQueue myQueue;
            if (MessageQueue.Exists(@".\private$\TestQueue"))
            {
                myQueue = new MessageQueue(@".\private$\TestQueue");
            }
            else
            {
                myQueue = MessageQueue.Create(@".\private$\TestQueue");
            }

            // Create Message
            Message myMessage = new Message();

            // Set Formatter for Message
            myMessage.Formatter = new BinaryMessageFormatter();
            myMessage.Body = MessageToBeSend;
            myMessage.Label = "App1Message";

            if (MessageToBeSend.StartsWith("HP:"))
            {
                myMessage.Priority = MessagePriority.Highest;
            }
            else
            {
                myMessage.Priority = MessagePriority.Normal;
            }

            myQueue.Send(myMessage);
            Console.WriteLine("Thanks for sending message");
            Console.ReadKey();
           

        }
    }
}
