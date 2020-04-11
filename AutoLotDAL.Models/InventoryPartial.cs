using AutoLotDAL.Models.MetaData;
using System.ComponentModel.DataAnnotations;
namespace AutoLotDAL.Models
{
    [MetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{PetName ?? "** No Name **"} is a {Color} {Make} with ID {Id}.";
        }
    }
}
