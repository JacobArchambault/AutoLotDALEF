namespace AutoLotConsoleApp.EF
{
    using AutoLotDAL.Models.Base;
    using System.ComponentModel.DataAnnotations;

    public partial class CreditRisk : EntityBase
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}
