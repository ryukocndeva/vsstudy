using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Messaging;

namespace SendConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessageToQueue(@".\Private$\TestQueue");
        }


        private static void SendMessageToQueue(string queueName)
        {
            MessageQueue msMq = null;
            if (!MessageQueue.Exists(queueName))
            {
                msMq = MessageQueue.Create(queueName);
            }
            else
            {
                msMq = new MessageQueue(queueName);
            }

            int i = 0;

            try
            {
                for (i = 0; i < 100; i++)
                {
                    Person p = new Person()
                    {
                        FirstName = "John",
                        LastName = "Doe " + (++i).ToString()
                    };
                    msMq.Send(p);
                }
            }
            catch (MessageQueueException ee)
            {
                Console.Write(ee.ToString());
            }
            catch (Exception eee)
            {
                Console.Write(eee.ToString());
            }
            finally
            {
                msMq.Close();
            }
            Console.WriteLine("Message sent...");
        }

    }

    public class Person
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
