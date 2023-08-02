using Microsoft.EntityFrameworkCore;
using Request_Course.Models;

namespace Request_Course.Data
{
    public class ReqContexts:DbContext
    {
        public ReqContexts(DbContextOptions<ReqContexts> dbContextOptions):base(dbContextOptions)
        {

        }

        public virtual DbSet<T_Doreh_Darkhasti> T_Doreh_Darkhasti { get; set; }
        public virtual DbSet<T_Fasl_Doreh> T_Fasl_Doreh { get; set; }
        public virtual DbSet<T_Fasl_Doreh_Pishnahadi> T_Fasl_Doreh_Pishnahadi { get; set; }
        public virtual DbSet<T_L_DaragehElmi> T_L_DaragehElmi { get; set; }
        public virtual DbSet<T_L_FildAsli> T_L_FildAsli { get; set; }
        public virtual DbSet<T_L_MaghtaeTahsili> T_L_MaghtaeTahsili { get; set; }
        public virtual DbSet<T_L_MediaAmozeshi> T_L_MediaAmozeshi { get; set; }
        public virtual DbSet<T_L_ModateDoreh> T_L_ModateDoreh { get; set; }
        public virtual DbSet<T_L_MokhatabanDoreh> T_L_MokhatabanDoreh { get; set; }
        public virtual DbSet<T_L_OnvanAsli> T_L_OnvanAsli { get; set; }
        public virtual DbSet<T_L_OnvanDoreh> T_L_OnvanDoreh { get; set; }
        public virtual DbSet<T_L_Ostan> T_L_Ostan { get; set; }
        public virtual DbSet<T_L_RaveshAmozeshi> T_L_RaveshAmozeshi { get; set; }
        public virtual DbSet<T_L_ReshtehTahsili> T_L_ReshtehTahsili { get; set; }
        public virtual DbSet<T_L_Sathe_Sherkat> T_L_Sathe_Sherkat { get; set; }
        public virtual DbSet<T_L_SatheKeyfi_Modares> T_L_SatheKeyfi_Modares { get; set; }
        public virtual DbSet<T_L_Semat> T_L_Semat { get; set; }
        public virtual DbSet<T_L_Vaziyat_Doreh> T_L_Vaziyat_Doreh { get; set; }
        public virtual DbSet<T_MarahelDoreh> T_MarahelDoreh { get; set; }
        public virtual DbSet<T_Modaresan> T_Modaresan { get; set; }
        public virtual DbSet<T_Modaresan_Fild_Amozeshi> T_Modaresan_Fild_Amozeshi { get; set; }
        public virtual DbSet<T_Mokhatebin> T_Mokhatebin { get; set; }
        public virtual DbSet<T_Nazarsanji> T_Nazarsanji { get; set; }
        public virtual DbSet<T_Pishnahad_Modares_Doreh> T_Pishnahad_Modares_Doreh { get; set; }
        public virtual DbSet<T_Activation> T_Activation { get; set; }
        public virtual DbSet<T_Admin> T_Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Activation>()
                .Property(e => e.code)
                .IsFixedLength();

            modelBuilder.Entity<T_Doreh_Darkhasti>()
                .Property(e => e.Nomreh_Modares)
                .HasPrecision(3, 2);

            modelBuilder.Entity<T_Doreh_Darkhasti>()
                .HasMany(e => e.T_Fasl_Doreh_Pishnahadi)
                .WithOne(e => e.T_Doreh_Darkhasti)
                .HasForeignKey(e => e.T_Doreh_Darkhasti_ID);

            modelBuilder.Entity<T_Doreh_Darkhasti>()
                .HasMany(e => e.T_MarahelDoreh)
                .WithOne(e => e.T_Doreh_Darkhasti)
                .HasForeignKey(e => e.T_Doreh_Darkhasti_ID);

            modelBuilder.Entity<T_Doreh_Darkhasti>()
                .HasMany(e => e.T_Nazarsanji)
                .WithOne(e => e.T_Doreh_Darkhasti)
                .HasForeignKey(e => e.T_Doreh_Darkhasti_ID);

            modelBuilder.Entity<T_Doreh_Darkhasti>()
                .HasMany(e => e.T_Pishnahad_Modares_Doreh)
                .WithOne(e => e.T_Doreh_Darkhasti)
                .HasForeignKey(e => e.T_Doreh_Darkhasti_ID);

            modelBuilder.Entity<T_L_DaragehElmi>()
                .HasMany(e => e.T_Modaresan)
                .WithOne(e => e.T_L_DaragehElmi)
                .HasForeignKey(e => e.T_L_DaragehElmi_ID);

            modelBuilder.Entity<T_L_FildAsli>()
                .HasMany(e => e.T_Modaresan_Fild_Amozeshi)
                .WithOne(e => e.T_L_FildAsli)
                .HasForeignKey(e => e.T_L_FildAsli_ID);

            modelBuilder.Entity<T_L_MaghtaeTahsili>()
                .HasMany(e => e.T_Modaresan)
                .WithOne(e => e.T_L_MaghtaeTahsili)
                .HasForeignKey(e => e.T_L_MaghtaeTahsili_ID);

            modelBuilder.Entity<T_L_MediaAmozeshi>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_MediaAmozeshi)
                .HasForeignKey(e => e.T_L_MediaAmozeshi_ID);

            modelBuilder.Entity<T_L_ModateDoreh>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_ModateDoreh)
                .HasForeignKey(e => e.T_L_ModateDoreh_ID);

            modelBuilder.Entity<T_L_MokhatabanDoreh>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_MokhatabanDoreh)
                .HasForeignKey(e => e.T_L_MokhatabanDoreh_ID);

            modelBuilder.Entity<T_L_OnvanAsli>()
                .HasMany(e => e.T_Fasl_Doreh)
                .WithOne(e => e.T_L_OnvanAsli)
                .HasForeignKey(e => e.T_L_OnvanAsli_ID);

            modelBuilder.Entity<T_L_OnvanDoreh>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_OnvanDoreh)
                .HasForeignKey(e => e.T_L_OnvanDoreh_ID);

            modelBuilder.Entity<T_L_OnvanDoreh>()
                .HasMany(e => e.T_Fasl_Doreh)
                .WithOne(e => e.T_L_OnvanDoreh)
                .HasForeignKey(e => e.T_L_OnvanDoreh_ID);

            modelBuilder.Entity<T_L_OnvanDoreh>()
                .HasMany(e => e.T_Modaresan_Fild_Amozeshi)
                .WithOne(e => e.T_L_OnvanDoreh)
                .HasForeignKey(e => e.T_L_OnvanDoreh_ID);

            modelBuilder.Entity<T_L_Ostan>()
                .HasMany(e => e.T_Mokhatebin)
                .WithOne(e => e.T_L_Ostan)
                .HasForeignKey(e => e.T_L_Ostan_ID);

            modelBuilder.Entity<T_L_RaveshAmozeshi>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_RaveshAmozeshi)
                .HasForeignKey(e => e.T_L_RaveshAmozeshi_ID);

            modelBuilder.Entity<T_L_ReshtehTahsili>()
                .HasMany(e => e.T_Modaresan)
                .WithOne(e => e.T_L_ReshtehTahsili)
                .HasForeignKey(e => e.T_L_ReshtehTahsili_ID);

            modelBuilder.Entity<T_L_Sathe_Sherkat>()
                .HasMany(e => e.T_Mokhatebin)
                .WithOne(e => e.T_L_Sathe_Sherkat)
                .HasForeignKey(e => e.T_L_Sathe_Sherkat_ID);

            modelBuilder.Entity<T_L_SatheKeyfi_Modares>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_SatheKeyfi_Modares)
                .HasForeignKey(e => e.T_L_SatheKeyfi_Modares_ID);

            modelBuilder.Entity<T_L_Semat>()
                .HasMany(e => e.T_Mokhatebin)
                .WithOne(e => e.T_L_Semat)
                .HasForeignKey(e => e.T_L_Semat_ID);

            modelBuilder.Entity<T_L_Vaziyat_Doreh>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_L_Vaziyat_Doreh)
                .HasForeignKey(e => e.T_L_Vaziyat_Doreh_ID);

            modelBuilder.Entity<T_L_Vaziyat_Doreh>()
                .HasMany(e => e.T_MarahelDoreh)
                .WithOne(e => e.T_L_Vaziyat_Doreh)
                .HasForeignKey(e => e.T_L_Vaziyat_Doreh_ID);

            modelBuilder.Entity<T_Modaresan>()
                .Property(e => e.Nomreh_Keyfi)
                .HasPrecision(2, 2);

            modelBuilder.Entity<T_Modaresan>()
                .Property(e => e.Avg_Nomreh_Tadris)
                .HasPrecision(3, 2);

            modelBuilder.Entity<T_Modaresan>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_Modaresan)
                .HasForeignKey(e => e.T_Modaresan_ID);

            modelBuilder.Entity<T_Modaresan>()
                .HasMany(e => e.T_Modaresan_Fild_Amozeshi)
                .WithOne(e => e.T_Modaresan)
                .HasForeignKey(e => e.T_Modaresan_ID);

            modelBuilder.Entity<T_Modaresan>()
                .HasMany(e => e.T_Pishnahad_Modares_Doreh1)
                .WithOne(e => e.T_Modaresan1)
                .HasForeignKey(e => e.T_Modaresan_ID1);

            modelBuilder.Entity<T_Mokhatebin>()
                .HasMany(e => e.T_Doreh_Darkhasti)
                .WithOne(e => e.T_Mokhatebin)
                .HasForeignKey(e => e.T_Mokhatebin_ID);

            modelBuilder.Entity<T_Modaresan>()
                .HasMany(e => e.T_Pishnahad_Modares_Doreh2)
                .WithOne(e => e.T_Modaresan2)
                .HasForeignKey(e => e.T_Modaresan_ID2);

            modelBuilder.Entity<T_Modaresan>()
                .HasMany(e => e.T_Pishnahad_Modares_Doreh3)
                .WithOne(e => e.T_Modaresan3)
                .HasForeignKey(e => e.T_Modaresan_ID3);

            modelBuilder.Entity<T_Nazarsanji>()
                .Property(e => e.Avg_Num)
                .HasPrecision(3, 2);

            modelBuilder.Entity<T_Modaresan>()
                .HasMany(e => e.T_Activation)
                .WithOne(e => e.T_Modaresan)
                .HasForeignKey(e => e.T_Modaresan_ID);

            modelBuilder.Entity<T_Mokhatebin>()
               .HasMany(e => e.T_Activation)
               .WithOne(e => e.T_Mokhatebin)
               .HasForeignKey(e => e.T_Mokhatebin_ID);

        }

    }
}
