﻿using AutoLotConsoleApp.EF;
using AutoLotDAL.EF;
using AutoLotDAL.Repos;
using System;
using System.Data.Entity;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            //Database.SetInitializer(new MyDataInitializer());

            Console.WriteLine("***** Fun with ADO.NET EF Code First *****\n");
            Console.WriteLine("***** Using a Repository *****\n");
            using (var repo = new InventoryRepo())
            {
                foreach (Inventory c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadLine();
        }
        private static void AddNewRecord(Inventory car)
        {
            // Add record to the Inventory table of the AutoLot database.
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }
        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                // Grab the car, change it, save.
                var carToUpdate = repo.GetOne(carId);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Blue";
                repo.Save(carToUpdate);
            }
        }
        private static void RemoveRecordByCar(Inventory carToDelete)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carToDelete);
            }
        }
        private static void RemoveRecordById(int carId, byte[] timeStamp)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carId, timeStamp);
            }
        }
    }
}
