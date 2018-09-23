using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Latest message");

            MessageQueue myQueue;
            myQueue = new MessageQueue(@".\private$\testQueue");

            Message myMessage = myQueue.Receive();
            myMessage.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(myMessage.Body.ToString());
            Console.ReadKey();
        }
    }
}
