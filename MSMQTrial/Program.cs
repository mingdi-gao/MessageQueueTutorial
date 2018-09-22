using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            string queuePath = @".\private$\myQueue";
            // QueueManager.Createqueue(queuePath);

            // Student stu = new Student() { Name = "StephenGao", Age = 18 };
            // QueueManager.SendMessage<Student>(stu, queuePath);

            // Student stu = QueueManager.ReceiveMessageByPeek<Student>(queuePath);
            // Console.WriteLine(stu.Name);
            // Console.WriteLine(stu.Age);

            // Student stu = QueueManager.ReceiveMessage<Student>(queuePath);
            // Console.WriteLine(stu.Name);

            QueueManager.Deletequeue(queuePath);
            QueueManager.Createqueue(queuePath);
            MessageQueueTransaction tran = new MessageQueueTransaction();
            tran.Begin();
            try
            {
                Student stu;
                for (int i= 0; i < 4; i++)
                {
                    stu = new Student() { Name = "Stephen" + i, Age = i };
                    QueueManager.SendMessage<Student>(stu, queuePath, tran);
                    if (i == 3)
                    {
                        throw new Exception();
                    }
                }
                tran.Commit();
            }

            catch
            {
                tran.Abort();
            }
            Console.ReadKey();
        }

    }
        
}
