using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Triggmine.Report.Scheduler.Models;

namespace Triggmine.Report.Scheduler.Data.Context
{
    public partial class AuthorizationContext : DbContext
    {
        public AuthorizationContext()
        {
        }

        public AuthorizationContext(DbContextOptions<AuthorizationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=52.208.138.95;Database=Authorization;Username=dev_dbo;Password=dev_dbo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("dblink");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer", "tma");

                entity.HasIndex(e => e.ApiKey)
                    .HasName("customer_api_key_key")
                    .IsUnique();

                entity.HasIndex(e => e.AuthId);

                entity.HasIndex(e => e.Email);

                entity.HasIndex(e => e.Id);

                entity.HasIndex(e => e.UserName);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('tma.customer_id_seq'::regclass)");

                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasColumnName("api_key")
                    .HasMaxLength(32);

                entity.Property(e => e.AssetId).HasMaxLength(128);

                entity.Property(e => e.AuthId)
                    .IsRequired()
                    .HasColumnName("auth_id")
                    .HasMaxLength(128);

                entity.Property(e => e.BillingLimit).HasColumnName("billing_limit");

                entity.Property(e => e.CmsName)
                    .HasColumnName("cms_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerUid)
                    .HasColumnName("customerUid")
                    .HasMaxLength(128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(256);

                entity.Property(e => e.EspApiKey)
                    .HasColumnName("esp_api_key")
                    .HasMaxLength(256);

                entity.Property(e => e.EspEmailFrom)
                    .HasColumnName("esp_email_from")
                    .HasMaxLength(256);

                entity.Property(e => e.EspNameFrom)
                    .HasColumnName("esp_name_from")
                    .HasMaxLength(256);

                entity.Property(e => e.EspProvider)
                    .HasColumnName("esp_provider")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.IndustryUid).HasColumnName("industry_uid");

                entity.Property(e => e.IsAiEnabled).HasColumnName("is_ai_enabled");

                entity.Property(e => e.IsFbIntegrated).HasColumnName("is_fb_integrated");

                entity.Property(e => e.IsLocked).HasColumnName("is_locked");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(3);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastSingInDate).HasColumnName("lastSingInDate");

                entity.Property(e => e.LogoUrl)
                    .HasColumnName("logo_url")
                    .HasMaxLength(256);

                entity.Property(e => e.NeedNotification)
                    .IsRequired()
                    .HasColumnName("need_notification")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(25);

                entity.Property(e => e.Position).HasMaxLength(64);

                entity.Property(e => e.RegisterSource)
                    .HasColumnName("register_source")
                    .HasMaxLength(200);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ShopAlias)
                    .HasColumnName("shop_alias")
                    .HasMaxLength(256);

                entity.Property(e => e.ShopCurrency)
                    .HasColumnName("shop_currency")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("'USD'::character varying");

                entity.Property(e => e.ShopUrl)
                    .HasColumnName("shop_url")
                    .HasMaxLength(200);

                entity.Property(e => e.SourceId).HasMaxLength(128);

                entity.Property(e => e.SupportEmail)
                    .HasColumnName("support_email")
                    .HasMaxLength(256);

                entity.Property(e => e.TemplateColor)
                    .HasColumnName("template_color")
                    .HasMaxLength(64);

                entity.Property(e => e.TimeZone)
                    .HasColumnName("time_zone")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(128);
            });

            modelBuilder.HasSequence("customer_id_seq");

            modelBuilder.HasSequence("mail_limit_configuration_id_seq");
        }
    }
}
