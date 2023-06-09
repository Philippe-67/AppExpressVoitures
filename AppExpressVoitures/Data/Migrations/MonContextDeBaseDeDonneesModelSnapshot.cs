﻿// <auto-generated />
using System;
using AppExpressVoitures.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppExpressVoitures.Data.Migrations
{
    [DbContext(typeof(MonContextDeBaseDeDonnees))]
    partial class MonContextDeBaseDeDonneesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppExpressVoitures.Models.Reparations", b =>
                {
                    b.Property<int>("ReparationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReparationId"), 1L, 1);

                    b.Property<DateTime?>("DateDelivrance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePriseEnCharge")
                        .HasColumnType("datetime2");

                    b.Property<int>("VinId")
                        .HasColumnType("int");

                    b.Property<int?>("VoitureVinID")
                        .HasColumnType("int");

                    b.HasKey("ReparationId");

                    b.HasIndex("VoitureVinID");

                    b.ToTable("Reparations");
                });

            modelBuilder.Entity("AppExpressVoitures.Models.Voitures", b =>
                {
                    b.Property<int>("VinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VinID"), 1L, 1);

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateVente")
                        .HasColumnType("datetime2");

                    b.Property<string>("Finition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrixAchat")
                        .HasColumnType("real");

                    b.Property<float>("PrixVente")
                        .HasColumnType("real");

                    b.Property<bool>("VoitureDisponible")
                        .HasColumnType("bit");

                    b.HasKey("VinID");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("AppExpressVoitures.Models.Reparations", b =>
                {
                    b.HasOne("AppExpressVoitures.Models.Voitures", "Voiture")
                        .WithMany("Reparations")
                        .HasForeignKey("VoitureVinID");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("AppExpressVoitures.Models.Voitures", b =>
                {
                    b.Navigation("Reparations");
                });
#pragma warning restore 612, 618
        }
    }
}
