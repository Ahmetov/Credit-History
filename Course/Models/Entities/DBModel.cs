namespace Course
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Адрес> Адрес { get; set; }
        public virtual DbSet<Банк> Банк { get; set; }
        public virtual DbSet<Заёмщик> Заёмщик { get; set; }
        public virtual DbSet<Кредитная_История> Кредитная_История { get; set; }
        public virtual DbSet<Кредитный_Договор> Кредитный_Договор { get; set; }

        public void setQuanity(int id)
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@borrowerId", id);
            var phones = Database.ExecuteSqlCommand("customProc @borrowerId", param);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Заёмщик>()
                .Property(e => e.Средняя_ЗП)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Кредитный_Договор>()
                .Property(e => e.Сумма_Кредита)
                .HasPrecision(19, 4);
        }

       
    }
}
