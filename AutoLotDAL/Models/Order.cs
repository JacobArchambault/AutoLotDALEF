using AutoLotDAL.Models.Base;

namespace AutoLotConsoleApp.EF
{
    public partial class Order : EntityBase
    {
        public int CustId { get; set; }

        public int CarId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
