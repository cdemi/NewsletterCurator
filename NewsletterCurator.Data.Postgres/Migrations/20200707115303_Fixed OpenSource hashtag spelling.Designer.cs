﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsletterCurator.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NewsletterCurator.Data.Postgres.Migrations
{
    [DbContext(typeof(NewsletterCuratorContext))]
    [Migration("20200707115303_Fixed OpenSource hashtag spelling")]
    partial class FixedOpenSourcehashtagspelling
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NewsletterCurator.Data.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashTags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Priority")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = new Guid("01f3205e-578b-4568-9d86-7c15fceb6a4f"),
                            Color = "#004D40",
                            HashTags = "Data",
                            Name = "Data",
                            Priority = 3.5f
                        },
                        new
                        {
                            ID = new Guid("01f3205e-578b-4568-3d87-5c15fceb6a4f"),
                            Color = "#e91e63",
                            HashTags = "BigData",
                            Name = "Big Data",
                            Priority = 3.6f
                        },
                        new
                        {
                            ID = new Guid("bbf3205e-578b-4568-9d86-7c15fceb6a4f"),
                            Color = "#673ab7",
                            HashTags = "DevOps",
                            Name = "DevOps",
                            Priority = 3f
                        },
                        new
                        {
                            ID = new Guid("219acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                            Color = "#F50057",
                            HashTags = "UX,UserExperience",
                            Name = "User Experience",
                            Priority = 2.5f
                        },
                        new
                        {
                            ID = new Guid("3f9acf3f-bf48-455d-9a3f-f660cd3a13b3"),
                            Color = "#3f51b5",
                            HashTags = "FrontEnd",
                            Name = "Front End",
                            Priority = 2f
                        },
                        new
                        {
                            ID = new Guid("67e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#388f5b",
                            HashTags = "Robotics",
                            Name = "Robotics",
                            Priority = 6.9f
                        },
                        new
                        {
                            ID = new Guid("57e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#2196f3",
                            HashTags = "AI,ArtificialIntelligence",
                            Name = "Artificial Intelligence",
                            Priority = 7f
                        },
                        new
                        {
                            ID = new Guid("21e0baf7-4b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#6f8b60",
                            HashTags = "Blockchain,Crypto,Cryptocurrency",
                            Name = "Blockchain and Cryptocurrencies",
                            Priority = 9.5f
                        },
                        new
                        {
                            ID = new Guid("32e0baf7-4b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#bc4dd1",
                            HashTags = "QuantumComputing,Quantum",
                            Name = "Quantum Computing",
                            Priority = 9.5f
                        },
                        new
                        {
                            ID = new Guid("12e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#03a9f4",
                            HashTags = "Space",
                            Name = "Space",
                            Priority = 10f
                        },
                        new
                        {
                            ID = new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#00bcd4",
                            HashTags = "Security,InfoSec",
                            Name = "Security",
                            Priority = 5f
                        },
                        new
                        {
                            ID = new Guid("30e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#b65050",
                            HashTags = "Privacy",
                            Name = "Privacy",
                            Priority = 5.1f
                        },
                        new
                        {
                            ID = new Guid("b3e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#009688",
                            HashTags = "Hardware",
                            Name = "Hardware",
                            Priority = 5.5f
                        },
                        new
                        {
                            ID = new Guid("a1e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            Color = "#4caf50",
                            HashTags = "QA,QualityAssurance",
                            Name = "Quality Assurance",
                            Priority = 5.8f
                        },
                        new
                        {
                            ID = new Guid("91e0baf7-3c82-4866-b9ae-5a2e77ad88fa"),
                            Color = "#57106e",
                            HashTags = "Business",
                            Name = "Business",
                            Priority = 5.85f
                        },
                        new
                        {
                            ID = new Guid("12e0baf7-3b82-4866-b9ae-5a2e77ad88fb"),
                            Color = "#683864",
                            HashTags = "Product,ProductOwnership,ProductManagement",
                            Name = "Product",
                            Priority = 5.9f
                        },
                        new
                        {
                            ID = new Guid("84754987-6f3f-4b5e-a79d-a61b13a61647"),
                            Color = "#8bc34a",
                            HashTags = "eSports",
                            Name = "eSports",
                            Priority = 8.5f
                        },
                        new
                        {
                            ID = new Guid("44754987-6f3f-4b5e-a79d-a61b13a61647"),
                            Color = "#ca9a07",
                            HashTags = "Gambling,SportsBetting,Casino",
                            Name = "Gambling",
                            Priority = 9f
                        },
                        new
                        {
                            ID = new Guid("33754987-6f3f-4b5e-a79d-a61b13a61647"),
                            Color = "#1abaa4",
                            HashTags = "Gaming",
                            Name = "Gaming",
                            Priority = 8.9f
                        },
                        new
                        {
                            ID = new Guid("497ff497-33d2-434c-a1db-5a722d94078f"),
                            Color = "#ff9800",
                            HashTags = "Tech",
                            Name = "General Tech",
                            Priority = 8f
                        },
                        new
                        {
                            ID = new Guid("527ff497-33d2-724c-a1db-5a722d94078f"),
                            Color = "#0336ff",
                            HashTags = "Cloud",
                            Name = "Cloud",
                            Priority = 3.4f
                        },
                        new
                        {
                            ID = new Guid("127ff497-11d2-724c-a1db-5a722d94078f"),
                            Color = "#2c90d7",
                            HashTags = "Kubernetes,k8s",
                            Name = "Kubernetes",
                            Priority = 3.45f
                        },
                        new
                        {
                            ID = new Guid("127ff497-33d2-734c-a1db-5a722a94078f"),
                            Color = "#77b53f",
                            HashTags = "Serverless",
                            Name = "Serverless",
                            Priority = 3.6f
                        },
                        new
                        {
                            ID = new Guid("527ff497-33d2-434c-a1db-5a722d94078f"),
                            Color = "#ff5722",
                            HashTags = "Infrastructure,sysadmin",
                            Name = "Infrastructure",
                            Priority = 4f
                        },
                        new
                        {
                            ID = new Guid("622fa497-32d2-434c-a1db-5a722d94012f"),
                            Color = "#6e179b",
                            HashTags = "IoT,InternetOfThings",
                            Name = "Internet of Things",
                            Priority = 4.5f
                        },
                        new
                        {
                            ID = new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                            Color = "#607d8b",
                            HashTags = "SoftwareDevelopment,Software,Dev,Programming",
                            Name = "Software Development",
                            Priority = 0f
                        },
                        new
                        {
                            ID = new Guid("217f4497-33d2-434c-a1db-5a422d98078f"),
                            Color = "#67ca0c",
                            HashTags = "Architecture,SoftwareArchitecture,EnterpriseArchitecture",
                            Name = "Architecture",
                            Priority = 0.1f
                        },
                        new
                        {
                            ID = new Guid("847bf497-33a2-424c-a1db-5a722d94078a"),
                            Color = "#88b224",
                            HashTags = "OpenSource,OSS,FOSS",
                            Name = "Open Source",
                            Priority = 5.7f
                        },
                        new
                        {
                            ID = new Guid("847ff497-33a2-424c-a1db-5a722d94078f"),
                            Color = "#795548",
                            HashTags = "Design",
                            Name = "Design",
                            Priority = 6f
                        },
                        new
                        {
                            ID = new Guid("927af497-33a2-424c-a1db-5a722d92078a"),
                            Color = "#a74141",
                            HashTags = "Healthcare,Medical",
                            Name = "Healthcare",
                            Priority = 89f
                        },
                        new
                        {
                            ID = new Guid("123ff497-33a2-424c-a1db-5a722d940456"),
                            Color = "#1dae0b",
                            HashTags = "Politics",
                            Name = "Politics",
                            Priority = 89.5f
                        },
                        new
                        {
                            ID = new Guid("927ff497-33a2-424c-a1db-5a722d94078f"),
                            Color = "#ef0078",
                            HashTags = "Random",
                            Name = "Random",
                            Priority = 90f
                        },
                        new
                        {
                            ID = new Guid("917ff497-33a2-424c-a1db-5a722d94078f"),
                            Color = "#ef0078",
                            HashTags = "Humor,Funny",
                            Name = "Humor",
                            Priority = 100f
                        },
                        new
                        {
                            ID = new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                            Color = "#2C8693",
                            HashTags = "dotNet",
                            Name = ".NET",
                            Priority = 1f
                        });
                });

            modelBuilder.Entity("NewsletterCurator.Data.Newsitem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FaviconURL")
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<bool>("IsAlreadySent")
                        .HasColumnType("boolean");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasAlternateKey("URL");

                    b.HasIndex("CategoryID");

                    b.ToTable("Newsitems");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d68f05e8-94f8-4e99-9b03-08d6329b2519"),
                            CategoryID = new Guid("e17226a6-bed1-44f5-863f-3970bb634fce"),
                            DateTime = new DateTimeOffset(new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            IsAlreadySent = false,
                            Summary = "For the past couple of years, Microsoft has been developing two forms of the SignalR – the original ASP.NET SignalR library and the newer ASP.NET Core SignalR.  This fall will see the last major update to the legacy ASP.NET SignalR library.",
                            Title = "ASP.NET SignalR 2.4 to Add Azure Support",
                            URL = "https://www.infoq.com/news/2018/10/aspnet-signalr"
                        },
                        new
                        {
                            ID = new Guid("0a8a1ca1-29e9-473e-1b07-08d632b276cb"),
                            CategoryID = new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            DateTime = new DateTimeOffset(new DateTime(2018, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            ImageURL = "https://regmedia.co.uk/2018/01/23/mr_freeze.jpg",
                            IsAlreadySent = false,
                            Summary = "Hardware hackers bring cold boot attacks out of the deep freeze",
                            Title = "You'll never guess what you can do once you steal a laptop, reflash the BIOS, and reboot it",
                            URL = "https://www.theregister.co.uk/2018/09/14/cold_boot_attack_reloaded/"
                        },
                        new
                        {
                            ID = new Guid("d501a11e-26a3-423b-1b06-08d632b276cb"),
                            CategoryID = new Guid("40e0baf7-3b80-4866-b9ae-3a2e77ad88fb"),
                            DateTime = new DateTimeOffset(new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            ImageURL = "https://cdn.wccftech.com/wp-content/uploads/2018/09/apple-a12-bionic-header-wccftech.com_-740x418.jpg",
                            IsAlreadySent = false,
                            Summary = "Apple's A12 and S4 processor upgrade boot-level security. Take a look here for all of the changes and more.",
                            Title = "4 New Security Features For Apple A12 And S4 That Weren't Mentioned Onstage",
                            URL = "https://wccftech.com/4-new-security-features-for-apple-a12-and-s4-that-werent-mentioned-onstage/"
                        },
                        new
                        {
                            ID = new Guid("6df0545e-0b4b-4162-f391-08d632ced619"),
                            CategoryID = new Guid("317ff497-33d2-434c-a1db-5a722d94078f"),
                            DateTime = new DateTimeOffset(new DateTime(2018, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            ImageURL = "https://www.confluent.io/wp-content/uploads/Event-Driven-2.0-–-Data-as-a-Service.png",
                            IsAlreadySent = false,
                            Summary = "Streaming systems have led to far richer approaches than the event-driven architectures of old. In the future, data will be as automated and self-service as infrastructure is today, in the form of data as a service.",
                            Title = "Event Driven 2.0: Data as a Service | Confluent",
                            URL = "https://www.confluent.io/blog/event-driven-2-0-data-service"
                        });
                });

            modelBuilder.Entity("NewsletterCurator.Data.Subscriber", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DateSubscribed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateUnsubscribed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateValidated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Subscribers");

                    b.HasData(
                        new
                        {
                            ID = new Guid("ff6f302b-8266-4d45-978a-9e8456b593c4"),
                            DateSubscribed = new DateTimeOffset(new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            DateUnsubscribed = new DateTimeOffset(new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            DateValidated = new DateTimeOffset(new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "test@test.test"
                        },
                        new
                        {
                            ID = new Guid("f16f302b-8266-4d45-978a-9e8456b593c4"),
                            DateSubscribed = new DateTimeOffset(new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            DateValidated = new DateTimeOffset(new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            Email = "test2@test.test"
                        });
                });

            modelBuilder.Entity("NewsletterCurator.Data.Newsitem", b =>
                {
                    b.HasOne("NewsletterCurator.Data.Category", "Category")
                        .WithMany("Newsitems")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
