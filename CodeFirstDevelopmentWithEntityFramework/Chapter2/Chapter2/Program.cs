using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();
                var person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe"
                };

                context.People.Add(person);
                context.SaveChanges();
            }
        }

        public class Person
        {
            public int PersonId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Context : DbContext
        {
            public Context(): base("name=chapter2")
            {

            }
            public DbSet<Person> People { get; set; }    
        }
    }
}
