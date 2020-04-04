using AutoLotConsoleApp.EF;
using System.Data.Entity;

namespace AutoLotDAL.EF
{
    class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            base.Seed(context);
        }
    }
}
