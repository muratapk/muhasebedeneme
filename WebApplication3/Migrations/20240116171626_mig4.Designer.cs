﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Data;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240116171626_mig4")]
    partial class mig4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<int>("Maliyet_Id1")
                        .HasColumnType("int");

                    b.Property<int>("Personel_Id")
                        .HasColumnType("int");

                    b.Property<int>("Personel_Id1")
                        .HasColumnType("int");

                    b.HasKey("Hesap_Id");

                    b.HasIndex("Maliyet_Id1");

                    b.HasIndex("Personel_Id1");

                    b.ToTable("Hesaps");
                });

            modelBuilder.Entity("WebApplication3.Models.ilcesi", b =>
                {
                    b.Property<int>("ilce_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ilce_Id"), 1L, 1);

                    b.Property<int?>("il_Id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ilce_Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ilisil_Id")
                        .HasColumnType("int");

                    b.HasKey("ilce_Id");

                    b.HasIndex("ilisil_Id");

                    b.ToTable("ilcesis");
                });

            modelBuilder.Entity("WebApplication3.Models.ili", b =>
                {
                    b.Property<int>("il_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("il_Id"), 1L, 1);

                    b.Property<string>("il_Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("il_Id");

                    b.ToTable("ilis");
                });

            modelBuilder.Entity("WebApplication3.Models.Maliyet", b =>
                {
                    b.Property<int>("Maliyet_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Maliyet_Id"), 1L, 1);

                    b.Property<int>("Okul_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Okul_Id1")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("idari_pay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("iscilik")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("isin_Adedi")
                        .HasColumnType("int");

                    b.Property<string>("isin_Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("kar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("malzeme")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ogrenci")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ogretmen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pesin_Gelir")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("shcek")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Maliyet_Id");

                    b.HasIndex("Okul_Id1");

                    b.ToTable("Maliyets");
                });

            modelBuilder.Entity("WebApplication3.Models.Okul", b =>
                {
                    b.Property<int>("Okul_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Okul_Id"), 1L, 1);

                    b.Property<string>("OkulAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VergiNo")
                        .HasColumnType("int");

                    b.Property<int>("ilce_Id")
                        .HasColumnType("int");

                    b.HasKey("Okul_Id");

                    b.ToTable("Okuls");
                });

            modelBuilder.Entity("WebApplication3.Models.Personel", b =>
                {
                    b.Property<int>("Personel_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Personel_Id"), 1L, 1);

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Brans_Id")
                        .HasColumnType("int");

                    b.Property<int>("Brans_Id1")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TcNo")
                        .HasColumnType("int");

                    b.HasKey("Personel_Id");

                    b.HasIndex("Brans_Id1");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("WebApplication3.Models.Hesap", b =>
                {
                    b.HasOne("WebApplication3.Models.Maliyet", "Maliyet")
                        .WithMany("Hesaps")
                        .HasForeignKey("Maliyet_Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication3.Models.Personel", "Personel")
                        .WithMany("Hesap")
                        .HasForeignKey("Personel_Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maliyet");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("WebApplication3.Models.ilcesi", b =>
                {
                    b.HasOne("WebApplication3.Models.ili", "ilis")
                        .WithMany("ilcesis")
                        .HasForeignKey("ilisil_Id");

                    b.Navigation("ilis");
                });

            modelBuilder.Entity("WebApplication3.Models.Maliyet", b =>
                {
                    b.HasOne("WebApplication3.Models.Okul", "Okul")
                        .WithMany("Maliyets")
                        .HasForeignKey("Okul_Id1");

                    b.Navigation("Okul");
                });

            modelBuilder.Entity("WebApplication3.Models.Personel", b =>
                {
                    b.HasOne("WebApplication3.Models.Brans", "Brans")
                        .WithMany("Personels")
                        .HasForeignKey("Brans_Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brans");
                });

            modelBuilder.Entity("WebApplication3.Models.Brans", b =>
                {
                    b.Navigation("Personels");
                });

            modelBuilder.Entity("WebApplication3.Models.ili", b =>
                {
                    b.Navigation("ilcesis");
                });

            modelBuilder.Entity("WebApplication3.Models.Maliyet", b =>
                {
                    b.Navigation("Hesaps");
                });

            modelBuilder.Entity("WebApplication3.Models.Okul", b =>
                {
                    b.Navigation("Maliyets");
                });

            modelBuilder.Entity("WebApplication3.Models.Personel", b =>
                {
                    b.Navigation("Hesap");
                });
#pragma warning restore 612, 618
        }
    }
}