
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var db = new Context();
                //db.ChangeDatabase(initialCatalog: Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                //    + "\\sdn.mdf", configConnectionStringName: "OrderDbConnectionString");
                db.ChangeDatabase("e:\\sdn.mdf", configConnectionStringName: "OrderDbConnectionString");

                db.Orders.Add(new Data.Entity.Order(){Accepted=true,SalMahRoz=13990102});
                db.SaveChanges();


                Console.WriteLine(db.Orders.Count());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message.ToString());
                Console.ReadKey();
            }
        }
    }
}
