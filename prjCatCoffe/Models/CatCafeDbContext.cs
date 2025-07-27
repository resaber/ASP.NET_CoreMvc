using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjCatCoffe.Models;

public partial class CatCafeDbContext : DbContext
{
    public CatCafeDbContext()
    {
    }

    public CatCafeDbContext(DbContextOptions<CatCafeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cafe> Cafes { get; set; }

    public virtual DbSet<CafeAmbiencePhoto> CafeAmbiencePhotos { get; set; }

    public virtual DbSet<CafeAmbiencePhotoType> CafeAmbiencePhotoTypes { get; set; }

    public virtual DbSet<CafeCat> CafeCats { get; set; }

    public virtual DbSet<CafeCatPhoto> CafeCatPhotos { get; set; }

    public virtual DbSet<CafeMeal> CafeMeals { get; set; }

    public virtual DbSet<CafeMealPhoto> CafeMealPhotos { get; set; }

    public virtual DbSet<CafeMealType> CafeMealTypes { get; set; }

    public virtual DbSet<Caterer> Caterers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<OpeningHour> OpeningHours { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CatCafeDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Bookings__31384C298E14A4B6");

            entity.Property(e => e.ReservationId)
                .ValueGeneratedNever()
                .HasColumnName("reservation_id");
            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Note)
                .HasMaxLength(300)
                .HasColumnName("note");
            entity.Property(e => e.PeopleCount).HasColumnName("people_count");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cafe).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CafeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Cafes");

            entity.HasOne(d => d.Member).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Members");
        });

        modelBuilder.Entity<Cafe>(entity =>
        {
            entity.HasKey(e => e.CafeId).HasName("PK__Cafes__FDF117B20ED2EE08");

            entity.ToTable(tb => tb.HasTrigger("trg_Cafes_Update"));

            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.CaterId).HasColumnName("cater_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cater).WithMany(p => p.Caves)
                .HasForeignKey(d => d.CaterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cafes_Caterers");
        });

        modelBuilder.Entity<CafeAmbiencePhoto>(entity =>
        {
            entity.HasKey(e => e.CafePhotoId).HasName("PK__Cafe_Amb__29FBD0795608FEBE");

            entity.ToTable("Cafe_AmbiencePhotos", tb => tb.HasTrigger("trg_CafeAmbiencePhotos_Update"));

            entity.Property(e => e.CafePhotoId).HasColumnName("cafe_photo_id");
            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cafe).WithMany(p => p.CafeAmbiencePhotos)
                .HasForeignKey(d => d.CafeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AmbiencePhotos_Cafes");

            entity.HasOne(d => d.Type).WithMany(p => p.CafeAmbiencePhotos)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AmbiencePhotos_Types");
        });

        modelBuilder.Entity<CafeAmbiencePhotoType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Cafe_Amb__2C00059897FAF0E5");

            entity.ToTable("Cafe_AmbiencePhotoTypes");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CafeCat>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Cat_Phot__DD5DDDBDB61C5739");

            entity.ToTable("Cafe_Cats");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cafe).WithMany(p => p.CafeCats)
                .HasForeignKey(d => d.CafeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cafe_Cats_Cafes");
        });

        modelBuilder.Entity<CafeCatPhoto>(entity =>
        {
            entity.HasKey(e => e.CatPhotoId).HasName("PK__Cafe_Cat__16ED8BC850095355");

            entity.ToTable("Cafe_Cat_Photos");

            entity.Property(e => e.CatPhotoId).HasColumnName("cat_photo_id");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cat).WithMany(p => p.CafeCatPhotos)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cafe_Cat_Photos_Cafe_Cats");
        });

        modelBuilder.Entity<CafeMeal>(entity =>
        {
            entity.HasKey(e => e.MealId).HasName("PK__Cafe_Mea__2910B00F7F6DBD43");

            entity.ToTable("Cafe_Meals");

            entity.Property(e => e.MealId).HasColumnName("meal_id");
            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MealName)
                .HasMaxLength(50)
                .HasColumnName("meal_name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cafe).WithMany(p => p.CafeMeals)
                .HasForeignKey(d => d.CafeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cafe_Meals_Cafes");

            entity.HasOne(d => d.Type).WithMany(p => p.CafeMeals)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cafe_Meals_Cafe_MealTypes");
        });

        modelBuilder.Entity<CafeMealPhoto>(entity =>
        {
            entity.HasKey(e => e.MealPhotoId).HasName("PK__Cafe_Mea__4A82FCC0E845E170");

            entity.ToTable("Cafe_Meal_Photos");

            entity.Property(e => e.MealPhotoId).HasColumnName("meal_photo_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.MealId).HasColumnName("meal_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Meal).WithMany(p => p.CafeMealPhotos)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cafe_MealPhotos_Meals");
        });

        modelBuilder.Entity<CafeMealType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Cafe_Mea__2C000598A3923D7F");

            entity.ToTable("Cafe_MealTypes");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Caterer>(entity =>
        {
            entity.HasKey(e => e.CatererId).HasName("PK__Caterers__BFFD0FA70AD37F6F");

            entity.Property(e => e.CatererId).HasColumnName("caterer_id");
            entity.Property(e => e.ApplyReason)
                .HasMaxLength(500)
                .HasColumnName("apply_reason");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IntroText).HasColumnName("intro_text");
            entity.Property(e => e.LegalName)
                .HasMaxLength(50)
                .HasColumnName("legal_name");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Member).WithMany(p => p.Caterers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caterers_Members");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__B29B853412CAD912");

            entity.ToTable(tb => tb.HasTrigger("trg_Members_Update"));

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .HasColumnName("account");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsCaterer).HasColumnName("is_caterer");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OpeningHour>(entity =>
        {
            entity.HasKey(e => e.OpenTimeId).HasName("PK__OpeningH__BE372F470535DC0A");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TRG_Update_OpeningHours_Timestamp");
                    tb.HasTrigger("trg_OpeningHours_Update");
                });

            entity.Property(e => e.OpenTimeId).HasColumnName("open_time_id");
            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.CloseTime)
                .HasPrecision(0)
                .HasColumnName("close_time");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DayType)
                .HasMaxLength(20)
                .HasColumnName("day_type");
            entity.Property(e => e.OpenTime)
                .HasPrecision(0)
                .HasColumnName("open_time");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cafe).WithMany(p => p.OpeningHours)
                .HasForeignKey(d => d.CafeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OpeningHours_Cafes");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__46596229179724AF");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.CafeId).HasColumnName("cafe_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasDefaultValue("Cash")
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("payment_status");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Cafe).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CafeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Cafes");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Members");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_Orders_Bookings");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__3764B6BCA49565AE");

            entity.Property(e => e.OrderItemId)
                .ValueGeneratedNever()
                .HasColumnName("order_item_id");
            entity.Property(e => e.MealId).HasColumnName("meal_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubTotal).HasColumnName("sub_total");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

            entity.HasOne(d => d.Meal).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_CafeMeals");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
