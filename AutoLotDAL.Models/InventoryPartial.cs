using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDal.Models
{
    public partial class Inventory : EntityBase
    {
        [NotMapped]
        public string MakeColor => $"{Make} ({Color})";
        public override string ToString()
        {
            return $"{PetName ?? "** No Name **"} is a {Color} {Make} with ID {Id}.";
        }

    }
}
