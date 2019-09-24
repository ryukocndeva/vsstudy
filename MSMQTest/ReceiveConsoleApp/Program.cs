using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Messaging;

namespace ReceiveConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiveMessageFromQueue(@".\Private$\TestQueue");
        }

        private static void ReceiveMessageFromQueue(string queueName)
        {
            MessageQueue msMq = new MessageQueue(queueName);

            try
            {
                msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(Person)});
                var message = (Person)msMq.Receive().Body;
                Console.WriteLine("FirstName: " + message.FirstName + ", LastName: " + message.LastName);

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
            Console.WriteLine("Message received...");

        }
    }


    public class Person
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
