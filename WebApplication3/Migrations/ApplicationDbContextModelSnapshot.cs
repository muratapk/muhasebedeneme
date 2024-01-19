﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Data;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication3.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OkulId")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.HasIndex("OkulId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("WebApplication3.Models.Brans", b =>
                {
                    b.Property<int>("Brans_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Brans_Id"), 1L, 1);

                    b.Property<string>("Brans_Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Brans_Id");

                    b.ToTable("Brans");
                });

            modelBuilder.Entity("WebApplication3.Models.Hesap", b =>
                {
                    b.Property<int>("Hesap_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hesap_Id"), 1L, 1);

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("Maliyet_Id")
                        .HasColumnType("int");

                    b.Property<int>("Personel_Id")
                        .HasColumnType("int");

                    b.HasKey("Hesap_Id");

                    b.HasIndex("Maliyet_Id");

                    b.HasIndex("Personel_Id");

                    b.ToTable("Hesaps");
                });

            modelBuilder.Entity("WebApplication3.Models.Maliyet", b =>
                {
                    b.Property<int>("MaliyetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaliyetId"), 1L, 1);

                    b.Property<decimal>("Idari_pay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Iscilik")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Isin_Adedi")
                        .HasColumnType("int");

                    b.Property<string>("Isin_Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Kar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Malzeme")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ogrenci")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ogretmen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OkulId")
                        .HasColumnType("int");

                    b.Property<decimal>("Pesin_Gelir")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Shcek")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tutari")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaliyetId");

                    b.HasIndex("OkulId");

                    b.ToTable("Maliyets");
                });

            modelBuilder.Entity("WebApplication3.Models.Mil", b =>
                {
                    b.Property<int>("MilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MilId"), 1L, 1);

                    b.Property<string>("MilAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MilId");

                    b.ToTable("Mils");
                });

            modelBuilder.Entity("WebApplication3.Models.Milce", b =>
                {
                    b.Property<int>("MilceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MilceId"), 1L, 1);

                    b.Property<int>("MilId")
                        .HasColumnType("int");

                    b.Property<string>("MilceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MilceId");

                    b.HasIndex("MilId");

                    b.ToTable("Milces");
                });

            modelBuilder.Entity("WebApplication3.Models.Okul", b =>
                {
                    b.Property<int>("OkulId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OkulId"), 1L, 1);

                    b.Property<int?>("MilceId")
                        .HasColumnType("int");

                    b.Property<string>("OkulAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VergiNo")
                        .HasColumnType("int");

                    b.HasKey("OkulId");

                    b.HasIndex("MilceId");

                    b.ToTable("Okuls");
                });

            modelBuilder.Entity("WebApplication3.Models.Personel", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelId"), 1L, 1);

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TcNo")
                        .HasColumnType("int");

                    b.HasKey("PersonelId");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("WebApplication3.Models.Admin", b =>
                {
                    b.HasOne("WebApplication3.Models.Okul", "Okul")
                        .WithMany("Admins")
                        .HasForeignKey("OkulId");

                    b.Navigation("Okul");
                });

            modelBuilder.Entity("WebApplication3.Models.Hesap", b =>
                {
                    b.HasOne("WebApplication3.Models.Maliyet", "Maliyet")
                        .WithMany("Hesaps")
                        .HasForeignKey("Maliyet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication3.Models.Personel", "Personel")
                        .WithMany()
                        .HasForeignKey("Personel_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maliyet");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("WebApplication3.Models.Maliyet", b =>
                {
                    b.HasOne("WebApplication3.Models.Okul", "Okul")
                        .WithMany("Maliyets")
                        .HasForeignKey("OkulId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Okul");
                });

            modelBuilder.Entity("WebApplication3.Models.Milce", b =>
                {
                    b.HasOne("WebApplication3.Models.Mil", "Mil")
                        .WithMany("Milces")
                        .HasForeignKey("MilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mil");
                });

            modelBuilder.Entity("WebApplication3.Models.Okul", b =>
                {
                    b.HasOne("WebApplication3.Models.Milce", "Milce")
                        .WithMany()
                        .HasForeignKey("MilceId");

                    b.Navigation("Milce");
                });

            modelBuilder.Entity("WebApplication3.Models.Maliyet", b =>
                {
                    b.Navigation("Hesaps");
                });

            modelBuilder.Entity("WebApplication3.Models.Mil", b =>
                {
                    b.Navigation("Milces");
                });

            modelBuilder.Entity("WebApplication3.Models.Okul", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Maliyets");
                });
#pragma warning restore 612, 618
        }
    }
}
