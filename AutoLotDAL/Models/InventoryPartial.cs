﻿namespace AutoLotConsoleApp.EF
{
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{PetName ?? "** No Name **"} is a {Color} {Make} with ID {CarId}.";
        }
    }
}
