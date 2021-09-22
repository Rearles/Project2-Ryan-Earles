using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project2_TCG.Models.Entities
{
    public partial class cardgameContext : DbContext
    {
        public cardgameContext()
        {
        }

        public cardgameContext(DbContextOptions<cardgameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Rarity> Rarities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersCard> UsersCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.Color)
                    .HasConstraintName("FK__Card__Color__60A75C0F");

                entity.HasOne(d => d.RarityNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.Rarity)
                    .HasConstraintName("FK__Card__Rarity__6477ECF3");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Color1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Color");
            });

            modelBuilder.Entity<Rarity>(entity =>
            {
                entity.ToTable("Rarity");

                entity.Property(e => e.Rarity1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Rarity");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersCard>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardId).HasColumnName("cardId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.UsersCards)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersCard__cardI__7E37BEF6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersCards)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersCard__userI__7D439ABD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
