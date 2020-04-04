using AutoLotConsoleApp.EF;
using AutoLotDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MyDataInitializer());

            Console.WriteLine("***** Fun with ADO.NET EF Code First *****\n");

            using (var context = new AutoLotEntities())
            {
                foreach (Inventory c in context.Inventory)
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadLine();
        }
    }
}
