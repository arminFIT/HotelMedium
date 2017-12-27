using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace HotelMedium.Web.Models
{
    public partial class HotelContext : DbContext
    {
            
        public HotelContext(DbContextOptions options):base(options)
        {
        }
        public virtual DbSet<AccessCodes> AccessCodes { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EventHalls> EventHalls { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventTypes> EventTypes { get; set; }
        public virtual DbSet<ExtraFeatures> ExtraFeatures { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<ReservationOffers> ReservationOffers { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<ReservationServices> ReservationServices { get; set; }
        public virtual DbSet<ReservationServicesExtraFeatures> ReservationServicesExtraFeatures { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<RoomTypeGallery> RoomTypeGallery { get; set; }
        public virtual DbSet<RoomTypes> RoomTypes { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesExtraFeatures> ServicesExtraFeatures { get; set; }
        public virtual DbSet<TourLocations> TourLocations { get; set; }
        public virtual DbSet<Tours> Tours { get; set; }
        public virtual DbSet<ToursClients> ToursClients { get; set; }
        public virtual DbSet<TourTypes> TourTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("fit-server1"));


#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\;Database=Nova;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessCodes>(entity =>
            {
                entity.HasKey(e => e.AccessCodeId);

                entity.Property(e => e.AccessCodeId)
                    .HasColumnName("AccessCodeID")
                    .HasColumnType("nchar(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.AccessCodes)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccessCodes_ReservationID");
            });

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasKey(e => e.BillId);

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateIssued).HasColumnType("datetime");

                entity.Property(e => e.IssuedOn)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bills_Clients");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Bills");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Bills");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreditCardCsc).HasColumnName("CreditCardCSC");

                entity.Property(e => e.CreditCardNumber)
                    .IsRequired()
                    .HasMaxLength(19);

                entity.Property(e => e.DateCardExpiration).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_CityID");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventHalls>(entity =>
            {
                entity.HasKey(e => e.EventHallId);

                entity.Property(e => e.EventHallId).HasColumnName("EventHallID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventHallId).HasColumnName("EventHallID");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.EventHall)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventHallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_EventHallID");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_EventTypeID");
            });

            modelBuilder.Entity<EventTypes>(entity =>
            {
                entity.HasKey(e => e.EventTypeId);

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ExtraFeatures>(entity =>
            {
                entity.HasKey(e => e.ExtraFeatureId);

                entity.Property(e => e.ExtraFeatureId).HasColumnName("ExtraFeatureID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Offers>(entity =>
            {
                entity.HasKey(e => e.OfferId);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ReservationOffers>(entity =>
            {
                entity.HasKey(e => e.ReservationOfferId);

                entity.Property(e => e.ReservationOfferId).HasColumnName("ReservationOfferID");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.ReservationOffers)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationOffers_OfferID");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationOffers)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationOffers_ReservationID");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateReserved).HasColumnType("datetime");

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Reservations");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Reservations");
            });

            modelBuilder.Entity<ReservationServices>(entity =>
            {
                entity.HasKey(e => e.ReservationServiceId);

                entity.Property(e => e.ReservationServiceId).HasColumnName("ReservationServiceID");

                entity.Property(e => e.DateReserved).HasColumnType("datetime");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationServices)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationServices_ReservationID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ReservationServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationServices_ServiceID");
            });

            modelBuilder.Entity<ReservationServicesExtraFeatures>(entity =>
            {
                entity.HasKey(e => new { e.ExtraFeatureId, e.ReservationServiceId });

                entity.Property(e => e.ExtraFeatureId).HasColumnName("ExtraFeatureID");

                entity.Property(e => e.ReservationServiceId).HasColumnName("ReservationServiceID");

                entity.HasOne(d => d.ExtraFeature)
                    .WithMany(p => p.ReservationServicesExtraFeatures)
                    .HasForeignKey(d => d.ExtraFeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationServicesExtraFeatures_ExtraFeatureID");

                entity.HasOne(d => d.ReservationService)
                    .WithMany(p => p.ReservationServicesExtraFeatures)
                    .HasForeignKey(d => d.ReservationServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationServicesExtraFeatures_ReservationServiceID");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomTypes_Rooms");
            });

            modelBuilder.Entity<RoomTypeGallery>(entity =>
            {
                entity.Property(e => e.RoomTypeGalleryId).HasColumnName("RoomTypeGalleryID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.RoomTypeGallery)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomTypes_RoomTypeGallery");
            });

            modelBuilder.Entity<RoomTypes>(entity =>
            {
                entity.HasKey(e => e.RoomTypeId);

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Salaries>(entity =>
            {
                entity.HasKey(e => e.SalaryId);

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Salaries_EmployeeID");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServicesExtraFeatures>(entity =>
            {
                entity.HasKey(e => new { e.ExtraFeatureId, e.ServiceId });

                entity.Property(e => e.ExtraFeatureId).HasColumnName("ExtraFeatureID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.ExtraFeature)
                    .WithMany(p => p.ServicesExtraFeatures)
                    .HasForeignKey(d => d.ExtraFeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesExtraFeatures_ExtraFeatureID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicesExtraFeatures)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicesExtraFeatures_ServiceID");
            });

            modelBuilder.Entity<TourLocations>(entity =>
            {
                entity.HasKey(e => e.TourLocationId);

                entity.Property(e => e.TourLocationId).HasColumnName("TourLocationID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tours>(entity =>
            {
                entity.HasKey(e => e.TourId);

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TourLocationId).HasColumnName("TourLocationID");

                entity.Property(e => e.TourTypeId).HasColumnName("TourTypeID");

                entity.HasOne(d => d.TourLocation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.TourLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tours_TourLocationID");

                entity.HasOne(d => d.TourType)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.TourTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tours_TourTypeID");
            });

            modelBuilder.Entity<ToursClients>(entity =>
            {
                entity.HasKey(e => e.TourClientId);

                entity.Property(e => e.TourClientId).HasColumnName("TourClientID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ToursClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToursClients_ClientID");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.ToursClients)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToursClients_TourID");
            });

            modelBuilder.Entity<TourTypes>(entity =>
            {
                entity.HasKey(e => e.TourTypeId);

                entity.Property(e => e.TourTypeId).HasColumnName("TourTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
