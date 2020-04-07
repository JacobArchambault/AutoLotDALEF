namespace AutoLotConsoleApp.EF
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using AutoLotDAL.Interception;
    using System.Data.Entity.Core.Objects;
    using System;

    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public AutoLotEntities() : base("name=AutoLotConnection")
        {
            // Interceptor code
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;

            //DbInterception.Add(new ConsoleWriterInterceptor());
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);
        }
        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
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
        { }
        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        { }
    }
}
