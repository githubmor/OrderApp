namespace Data
{

    using Data.Entity;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.SqlClient;

    public class Context : DbContext
    {
        public Context()
            : base("name=OrderDbConnectionString")
        {
            base.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        public virtual DbSet<Bazres> Bazress { get; set; }
        public virtual DbSet<Destenation> Customers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Pallet> Pallets { get; set; }
        public virtual DbSet<Baste> Bastes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Khodro> Khodros { get; set; }
        public virtual DbSet<AmarTolidKhodro> AmarTolidKhodros { get; set; }
        public virtual DbSet<KhodroProductRelation> KhodroProductRelation { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmarTolidKhodro>()
               .HasKey(vf => new { vf.SalMah, vf.KhodroId })
               .HasRequired(et => et.Khodro)
               .WithMany(eo => eo.Tolids);

            modelBuilder.Entity<Khodro>()
                .HasMany(p => p.Tolids)
                .WithRequired(p => p.Khodro)
                .HasForeignKey(p => p.KhodroId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bazres>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Bazre)
                .HasForeignKey(e => e.Bazres_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .HasOptional(p => p.Destenation)
                .WithMany()
                .HasForeignKey(o => o.Customer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .HasOptional(p => p.Driver)
                .WithMany()
                .HasForeignKey(o => o.Driver_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Destenation>()
                 .HasMany(p => p.OrderDetails)
                 .WithOptional(p => p.Destenation)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                 .HasMany(p => p.OrderDetails)
                 .WithOptional(p => p.Driver)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Description)
                .IsUnicode(true);

            modelBuilder.Entity<Pallet>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Pallet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Baste>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Baste);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhodroProductRelation>()
                .HasRequired(p => p.Khodro)
                .WithMany(o => o.ProductsRelation)
                .HasForeignKey(p => p.KhodroId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<KhodroProductRelation>()
                .HasRequired(p => p.Product)
                .WithMany(o => o.KhodrosRelation)
                .HasForeignKey(p => p.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
              .HasMany(e => e.Khodros)
              .WithRequired(e => e.Sazandeh)
              .HasForeignKey(h => h.CustomerId)
              .WillCascadeOnDelete(false);
        }
    }

    public static class ConnectionTools
    {
        // all params are optional
        public static void ChangeDatabase(
            this DbContext source,
            string initialCatalog = "",
            string dataSource = "",
            string userId = "",
            string password = "",
            bool integratedSecuity = true,
            string configConnectionStringName = "")
        /* this would be used if the
        *  connectionString name varied from 
        *  the base EF class name */
        {
            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder
                    (ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (entityCnxStringBuilder.ProviderConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                // set the integrated security status
                sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                // set log item if required
            }
        }
    }
}