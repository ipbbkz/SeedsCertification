﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using СертификацияСемян.Данные;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    [DbContext(typeof(КонтекстБдПриложения))]
    [Migration("20231017080712_Удаление")]
    partial class Удаление
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "Администратор",
                            Name = "Администратор",
                            NormalizedName = "АДМИНИСТРАТОР"
                        },
                        new
                        {
                            Id = "Инспектор",
                            Name = "Инспектор",
                            NormalizedName = "ИНСПЕКТОР"
                        },
                        new
                        {
                            Id = "СтаршийИнспектор",
                            Name = "СтаршийИнспектор",
                            NormalizedName = "СТАРШИЙИНСПЕКТОР"
                        },
                        new
                        {
                            Id = "Лаборатория",
                            Name = "Лаборатория",
                            NormalizedName = "ЛАБОРАТОРИЯ"
                        },
                        new
                        {
                            Id = "РуководительСертификационнойСлужбы",
                            Name = "РуководительСертификационнойСлужбы",
                            NormalizedName = "РУКОВОДИТЕЛЬСЕРТИФИКАЦИОННОЙСЛУЖБЫ"
                        },
                        new
                        {
                            Id = "Фермер",
                            Name = "Фермер",
                            NormalizedName = "ФЕРМЕР"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("СертификацияСемян.Данные.Анализ", b =>
                {
                    b.Property<int>("Ид")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ид"));

                    b.Property<DateTime>("ДатаОбновления")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаСоздания")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ДатаУдаления")
                        .HasColumnType("datetime2");

                    b.Property<int>("ИнспекцияИд")
                        .HasColumnType("int");

                    b.Property<int>("Статус")
                        .HasColumnType("int");

                    b.Property<int>("ТипАнализа")
                        .HasColumnType("int");

                    b.HasKey("Ид");

                    b.ToTable("Анализы");
                });

            modelBuilder.Entity("СертификацияСемян.Данные.ЗаписьИнспекции", b =>
                {
                    b.Property<int>("Ид")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ид"));

                    b.Property<int?>("Безтиповые")
                        .HasColumnType("int");

                    b.Property<int?>("ВиральныеБолезни")
                        .HasColumnType("int");

                    b.Property<int>("ИнспекцияИд")
                        .HasColumnType("int");

                    b.Property<int?>("Карантин")
                        .HasColumnType("int");

                    b.Property<int>("КоличествоРастенийВСерии")
                        .HasColumnType("int");

                    b.Property<int>("НомерСерии")
                        .HasColumnType("int");

                    b.Property<int?>("Ризоктония")
                        .HasColumnType("int");

                    b.Property<int?>("Черноножка")
                        .HasColumnType("int");

                    b.HasKey("Ид");

                    b.ToTable("ЗаписиИнспекций");
                });

            modelBuilder.Entity("СертификацияСемян.Данные.Заявка", b =>
                {
                    b.Property<int>("Ид")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ид"));

                    b.Property<bool>("Активно")
                        .HasColumnType("bit");

                    b.Property<string>("Гербициды")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ДатаОбновления")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаПосадки")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаСбора")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаСоздания")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ДатаУдаления")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ЗаключениеОНематодах")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ИзоляцияПолей")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Инсектициды")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("КлассСемянИд")
                        .HasColumnType("int");

                    b.Property<string>("КоординатыУчастка")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("НаваниеСортаСемян")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ПлощадьПосадки")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ПрогнозируемоеКоличествоУрожая")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Протравители")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("РазмерКлубня")
                        .HasColumnType("int");

                    b.Property<string>("РасстояниеВРяду")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("РасстояниеМеждуРядами")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("СвидетельствоПроисхожденияСемян")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Севооборот2ГодаНазад")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Севооборот3ГодаНазад")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("СевооборотПрошлогоГода")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Статус")
                        .HasColumnType("int");

                    b.Property<int>("ТипЗаявки")
                        .HasColumnType("int");

                    b.Property<string>("Удобрения")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("УчастокИд")
                        .HasColumnType("int");

                    b.Property<string>("ФормаУчастка")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Фунгициды")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ид");

                    b.ToTable("Заявки");
                });

            modelBuilder.Entity("СертификацияСемян.Данные.Инспекция", b =>
                {
                    b.Property<int>("Ид")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ид"));

                    b.Property<DateTime>("ДатаОбновления")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаСоздания")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ДатаУдаления")
                        .HasColumnType("datetime2");

                    b.Property<string>("ДругиеИнспектора")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ЗаявкаИд")
                        .HasColumnType("int");

                    b.Property<string>("ИмяВедущегоИнспектора")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ОбщиеУсловияПоля")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ПланируемаяДата")
                        .HasColumnType("datetime2");

                    b.Property<string>("ПричинаОтказа")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Статус")
                        .HasColumnType("int");

                    b.Property<int>("ТипИнспекции")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ФактическаяДата")
                        .HasColumnType("datetime2");

                    b.Property<string>("ФизиологическаяСтадия")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ЦелевойНачальныйПорог")
                        .HasColumnType("int");

                    b.HasKey("Ид");

                    b.ToTable("Инспекции");
                });

            modelBuilder.Entity("СертификацияСемян.Данные.ПроизводительСемян", b =>
                {
                    b.Property<int>("Ид")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ид"));

                    b.Property<bool>("Активно")
                        .HasColumnType("bit");

                    b.Property<string>("БинИлиИин")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ДатаОбновления")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаСоздания")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ДатаУдаления")
                        .HasColumnType("datetime2");

                    b.Property<string>("ИдВладельца")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("КонтактноеЛицо")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("НаваниеКомпании")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("НомерТелефонаКонтактногоЛица")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ФормаХозяйствования")
                        .HasColumnType("int");

                    b.Property<string>("ЭлектроннаяПочтаКонтактногоЛица")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ЮридическийАдрес")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ид");

                    b.ToTable("ПроизводителиСемян");
                });

            modelBuilder.Entity("СертификацияСемян.Данные.УчастокПоля", b =>
                {
                    b.Property<int>("Ид")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ид"));

                    b.Property<string>("АдресУчастка")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Активно")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ДатаОбновления")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаСоздания")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ДатаУдаления")
                        .HasColumnType("datetime2");

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ПравоустанавливающиеДокументы")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Ид");

                    b.ToTable("УчасткиПолей");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
