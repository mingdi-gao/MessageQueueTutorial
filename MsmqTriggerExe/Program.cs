using System;
using System.Collections.Generic;

using System.IO;

namespace MsmqTriggerExe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter(File.Open(@"d:\msmq.txt", FileMode.Append)))
            {
                for (int i = 0; i < args.Length; i++)
                {
                    writer.WriteLine("{0} - {1}", i, args[i]);
                }
                writer.WriteLine("gg");

                writer.Flush();
            }
        }
    }
}
