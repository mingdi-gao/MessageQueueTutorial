using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace MsmqTriggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var myMessageQ = new MessageQueue(@".\Private$\MQTriggerTest");
                var mt = new MessageQueueTransaction();
                mt.Begin();
                var message = new Message
                {
                    Formatter = new ActiveXMessageFormatter(),
                    Body = @"Msmq触发器测试消息!",
                    Label = "test123"
                };
                myMessageQ.Send(message, mt);
                mt.Commit();
                myMessageQ.Close();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
