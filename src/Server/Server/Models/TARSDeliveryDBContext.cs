using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.Models
{
    public partial class TARSDeliveryDBContext : DbContext
    {
        public TARSDeliveryDBContext()
        {
        }

        public TARSDeliveryDBContext(DbContextOptions<TARSDeliveryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<MoneyOrder> MoneyOrders { get; set; } = null!;
        public virtual DbSet<MoneyScope> MoneyScopes { get; set; } = null!;
        public virtual DbSet<MoneyService> MoneyServices { get; set; } = null!;
        public virtual DbSet<OfficeBranch> OfficeBranches { get; set; } = null!;
        public virtual DbSet<ParcelOrder> ParcelOrders { get; set; } = null!;
        public virtual DbSet<ParcelService> ParcelServices { get; set; } = null!;
        public virtual DbSet<ParcelType> ParcelTypes { get; set; } = null!;
        public virtual DbSet<Pincode> Pincodes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ServicePrice> ServicePrices { get; set; } = null!;
        public virtual DbSet<TrackHistory> TrackHistories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WeightScope> WeightScopes { get; set; } = null!;
        public virtual DbSet<ZoneType> ZoneTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5S9FPLG;Initial Catalog=TARSDeliveryDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(10)
                    .HasColumnName("area_name");
            });

            modelBuilder.Entity<MoneyOrder>(entity =>
            {
                entity.ToTable("money_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note");

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(50)
                    .HasColumnName("receiver_address");

                entity.Property(e => e.ReceiverName)
                    .HasMaxLength(50)
                    .HasColumnName("receiver_name");

                entity.Property(e => e.ReceiverNationalIdentityNumber)
                    .HasMaxLength(50)
                    .HasColumnName("receiver_national_identity_number");

                entity.Property(e => e.ReceiverPhone)
                    .HasMaxLength(20)
                    .HasColumnName("receiver_phone");

                entity.Property(e => e.ReceiverPincode)
                    .HasMaxLength(10)
                    .HasColumnName("receiver_pincode");

                entity.Property(e => e.SenderAddress)
                    .HasMaxLength(50)
                    .HasColumnName("sender_address");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(50)
                    .HasColumnName("sender_name");

                entity.Property(e => e.SenderNationalIdentityNumber)
                    .HasMaxLength(50)
                    .HasColumnName("sender_national_identity_number");

                entity.Property(e => e.SenderPhone)
                    .HasMaxLength(20)
                    .HasColumnName("sender_phone");

                entity.Property(e => e.SenderPincode)
                    .HasMaxLength(10)
                    .HasColumnName("sender_pincode");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TransferDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("transfer_date");

                entity.Property(e => e.TransferFee).HasColumnName("transfer_fee");

                entity.Property(e => e.TransferStatus)
                    .HasMaxLength(10)
                    .HasColumnName("transfer_status");

                entity.Property(e => e.TransferValue).HasColumnName("transfer_value");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ReceiverPincodeNavigation)
                    .WithMany(p => p.MoneyOrderReceiverPincodeNavigations)
                    .HasForeignKey(d => d.ReceiverPincode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money_order_receiver_pincode");

                entity.HasOne(d => d.SenderPincodeNavigation)
                    .WithMany(p => p.MoneyOrderSenderPincodeNavigations)
                    .HasForeignKey(d => d.SenderPincode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money_order_sender_pincode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MoneyOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money_order_user_id");
            });

            modelBuilder.Entity<MoneyScope>(entity =>
            {
                entity.ToTable("money_scope");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.MaxValue).HasColumnName("max_value");

                entity.Property(e => e.MinValue).HasColumnName("min_value");
            });

            modelBuilder.Entity<MoneyService>(entity =>
            {
                entity.ToTable("money_service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.MoneyScopeId).HasColumnName("money_scope_id");

                entity.Property(e => e.ZoneTypeId).HasColumnName("zone_type_id");

                entity.HasOne(d => d.MoneyScope)
                    .WithMany(p => p.MoneyServices)
                    .HasForeignKey(d => d.MoneyScopeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money_service_money_scope");

                entity.HasOne(d => d.ZoneType)
                    .WithMany(p => p.MoneyServices)
                    .HasForeignKey(d => d.ZoneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money_service_zone_type");
            });

            modelBuilder.Entity<OfficeBranch>(entity =>
            {
                entity.ToTable("office_branch");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .HasColumnName("branch_name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasColumnName("city_name");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(50)
                    .HasColumnName("district_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .HasColumnName("pincode");

                entity.HasOne(d => d.PincodeNavigation)
                    .WithMany(p => p.OfficeBranches)
                    .HasForeignKey(d => d.Pincode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_office_branch_pincode");
            });

            modelBuilder.Entity<ParcelOrder>(entity =>
            {
                entity.ToTable("parcel_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(50)
                    .HasColumnName("delivery_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note");

                entity.Property(e => e.OrderDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(10)
                    .HasColumnName("order_status");

                entity.Property(e => e.ParcelHeight).HasColumnName("parcel_height");

                entity.Property(e => e.ParcelLenght).HasColumnName("parcel_lenght");

                entity.Property(e => e.ParcelTypeId).HasColumnName("parcel_type_id");

                entity.Property(e => e.ParcelWeight).HasColumnName("parcel_weight");

                entity.Property(e => e.ParcelWidth).HasColumnName("parcel_width");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(10)
                    .HasColumnName("payment_method");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(10)
                    .HasColumnName("payment_mode");

                entity.Property(e => e.ReceiverAddress)
                    .HasMaxLength(10)
                    .HasColumnName("receiver_address");

                entity.Property(e => e.ReceiverEmail)
                    .HasMaxLength(50)
                    .HasColumnName("receiver_email");

                entity.Property(e => e.ReceiverName)
                    .HasMaxLength(50)
                    .HasColumnName("receiver_name");

                entity.Property(e => e.ReceiverPhone)
                    .HasMaxLength(50)
                    .HasColumnName("receiver_phone");

                entity.Property(e => e.ReceiverPincode)
                    .HasMaxLength(10)
                    .HasColumnName("receiver_pincode");

                entity.Property(e => e.SenderAddress)
                    .HasMaxLength(50)
                    .HasColumnName("sender_address");

                entity.Property(e => e.SenderEmail)
                    .HasMaxLength(50)
                    .HasColumnName("sender_email");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(50)
                    .HasColumnName("sender_name");

                entity.Property(e => e.SenderPhone)
                    .HasMaxLength(20)
                    .HasColumnName("sender_phone");

                entity.Property(e => e.SenderPincode)
                    .HasMaxLength(10)
                    .HasColumnName("sender_pincode");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.TotalCharge).HasColumnName("total_charge");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VppValue).HasColumnName("vpp_value");

                entity.HasOne(d => d.ParcelType)
                    .WithMany(p => p.ParcelOrders)
                    .HasForeignKey(d => d.ParcelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parcel_order_parcel_type");

                entity.HasOne(d => d.ReceiverPincodeNavigation)
                    .WithMany(p => p.ParcelOrderReceiverPincodeNavigations)
                    .HasForeignKey(d => d.ReceiverPincode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parcel_order_parcel_receiver_pincode");

                entity.HasOne(d => d.SenderPincodeNavigation)
                    .WithMany(p => p.ParcelOrderSenderPincodeNavigations)
                    .HasForeignKey(d => d.SenderPincode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parcel_order_parcel_sender_pincode");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ParcelOrders)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parcel_order_service_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ParcelOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parcel_order_user_id");
            });

            modelBuilder.Entity<ParcelService>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK_service");

                entity.ToTable("parcel_service");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServiceDescription)
                    .HasMaxLength(200)
                    .HasColumnName("service_description");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .HasColumnName("service_name");

                entity.Property(e => e.ServiceStatus)
                    .HasMaxLength(10)
                    .HasColumnName("service_status");

                entity.Property(e => e.TimeConsuming).HasColumnName("time_consuming");
            });

            modelBuilder.Entity<ParcelType>(entity =>
            {
                entity.ToTable("parcel_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OverDimensionRate).HasColumnName("over_dimension_rate");

                entity.Property(e => e.ParcelMaxHeight).HasColumnName("parcel_max_height");

                entity.Property(e => e.ParcelMaxLength).HasColumnName("parcel_max_length");

                entity.Property(e => e.ParcelMaxWeight).HasColumnName("parcel_max_weight");

                entity.Property(e => e.ParcelMaxWidth).HasColumnName("parcel_max_width");

                entity.Property(e => e.ParcelName)
                    .HasMaxLength(10)
                    .HasColumnName("parcel_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pincode>(entity =>
            {
                entity.HasKey(e => e.Pincode1)
                    .HasName("PK_zipcode");

                entity.ToTable("pincode");

                entity.Property(e => e.Pincode1)
                    .HasMaxLength(10)
                    .HasColumnName("pincode");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasColumnName("city_name");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Pincodes)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pincode_area");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<ServicePrice>(entity =>
            {
                entity.ToTable("service_price");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ParselType).HasColumnName("parsel_type");

                entity.Property(e => e.ScopeWeightId).HasColumnName("scope_weight_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServicePrice1).HasColumnName("service_price");

                entity.Property(e => e.ZoneTypeId).HasColumnName("zone_type_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ServicePrice)
                    .HasForeignKey<ServicePrice>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_price_service_id");

                entity.HasOne(d => d.ParselTypeNavigation)
                    .WithMany(p => p.ServicePrices)
                    .HasForeignKey(d => d.ParselType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_price_parcel_type");

                entity.HasOne(d => d.ScopeWeight)
                    .WithMany(p => p.ServicePrices)
                    .HasForeignKey(d => d.ScopeWeightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_price_scope_weight");

                entity.HasOne(d => d.ZoneType)
                    .WithMany(p => p.ServicePrices)
                    .HasForeignKey(d => d.ZoneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_price_zone_type");
            });

            modelBuilder.Entity<TrackHistory>(entity =>
            {
                entity.HasKey(e => e.TrackId);

                entity.ToTable("track_history");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FromLocation)
                    .HasMaxLength(50)
                    .HasColumnName("from_location");

                entity.Property(e => e.NewLocation)
                    .HasMaxLength(50)
                    .HasColumnName("new_location");

                entity.Property(e => e.NewStatus)
                    .HasMaxLength(50)
                    .HasColumnName("new_status");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.UpdateTime)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("update_time");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrackHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_track_history_employee_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TrackHistories)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_track_history_order_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressCity)
                    .HasMaxLength(50)
                    .HasColumnName("address_city");

                entity.Property(e => e.AddressDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("address_district");

                entity.Property(e => e.AddressStreet)
                    .HasMaxLength(50)
                    .HasColumnName("address_street");

                entity.Property(e => e.AddressWard)
                    .HasMaxLength(50)
                    .HasColumnName("address_ward");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_user_role");
            });

            modelBuilder.Entity<WeightScope>(entity =>
            {
                entity.ToTable("weight_scope");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.MaxWeight).HasColumnName("max_weight");

                entity.Property(e => e.MinWeight).HasColumnName("min_weight");
            });

            modelBuilder.Entity<ZoneType>(entity =>
            {
                entity.ToTable("zone_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ZoneDescription)
                    .HasMaxLength(50)
                    .HasColumnName("zone_description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
