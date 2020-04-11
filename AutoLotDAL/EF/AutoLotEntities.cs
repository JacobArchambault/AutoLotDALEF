namespace AutoLotDAL.EF
{
    using AutoLotDAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;

    public partial class AutoLotEntities : DbContext
    {
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public AutoLotEntities() : base("name=AutoLotConnection")
        {
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);
        }
        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            // Sender is of type ObjectContext. 
            // Can get current and original values, 
            // and cancel/modify the save operation as desired.
            if (!(sender is ObjectContext context)) return;
            foreach (ObjectStateEntry item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added))
            {
                // Do something important here
                if ((item.Entity as Inventory) != null)
                {
                    var entity = (Inventory)item.Entity;
                    if (entity.Color == "Red")
                    {
                        item.RejectPropertyChanges(nameof(entity.Color));
                    }
                }
            }

        }
        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        { }
    }
}
