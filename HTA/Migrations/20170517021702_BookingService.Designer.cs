using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HTA.Models;

namespace HTA.Migrations
{
    [DbContext(typeof(HTAContext))]
    [Migration("20170517021702_BookingService")]
    partial class BookingService
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HTA.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime?>("ApprovedDate");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int?>("DevoteeId");

                    b.Property<int?>("DevoteeMemID");

                    b.Property<bool?>("IsActive");

                    b.Property<bool?>("IsApproved");

                    b.Property<bool?>("IsPaid");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("LastModifiedBy");

                    b.Property<int?>("ReceiptId");

                    b.HasKey("BookingID");

                    b.HasIndex("DevoteeId");

                    b.ToTable("tbl_booking");
                });

            modelBuilder.Entity("HTA.Models.BookingItem", b =>
                {
                    b.Property<int>("BookingItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BookingID");

                    b.Property<int?>("NoUnits");

                    b.Property<int?>("PriestAlloted");

                    b.Property<int?>("PriestI");

                    b.Property<int?>("PriestII");

                    b.Property<int?>("PriestIII");

                    b.Property<DateTime>("ServiceDate");

                    b.Property<int?>("ServiceTimeID");

                    b.Property<decimal>("Service_Fee")
                        .HasColumnType("money");

                    b.Property<int?>("Service_ID");

                    b.HasKey("BookingItemId");

                    b.HasIndex("BookingID");

                    b.HasIndex("Service_ID");

                    b.ToTable("tbl_bookingitem");
                });

            modelBuilder.Entity("HTA.Models.Devotee", b =>
                {
                    b.Property<int>("Devotee_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address_1");

                    b.Property<string>("Address_2");

                    b.Property<string>("Cell_Phone");

                    b.Property<string>("City");

                    b.Property<string>("Company_Name");

                    b.Property<DateTime?>("DOB");

                    b.Property<DateTime?>("Date_Created");

                    b.Property<string>("Fax");

                    b.Property<string>("First_Name");

                    b.Property<int?>("Gothram_ID");

                    b.Property<string>("Home_Phone");

                    b.Property<bool?>("Is_Active");

                    b.Property<bool?>("Is_Company");

                    b.Property<bool?>("Is_Emailing");

                    b.Property<bool?>("Is_Mailing");

                    b.Property<bool?>("Is_ProfileComplete");

                    b.Property<DateTime?>("Last_LoggedIn");

                    b.Property<DateTime?>("Last_Modified");

                    b.Property<string>("Last_Name");

                    b.Property<string>("LoginEmail");

                    b.Property<int?>("MemberType_ID");

                    b.Property<string>("Middle_Name");

                    b.Property<string>("Password");

                    b.Property<string>("Sex");

                    b.Property<int?>("Star_ID");

                    b.Property<int?>("StateID");

                    b.Property<bool?>("TemporaryPassord");

                    b.Property<DateTime?>("Wedding_Date");

                    b.Property<string>("Who_Modified");

                    b.Property<string>("Work_Phone");

                    b.Property<string>("Work_Phone_Ext");

                    b.Property<string>("Zip");

                    b.HasKey("Devotee_ID");

                    b.ToTable("tbl_devotee");
                });

            modelBuilder.Entity("HTA.Models.Service", b =>
                {
                    b.Property<int>("Service_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommitteeType_ID");

                    b.Property<DateTime>("Date_Created");

                    b.Property<bool?>("EmailReceipt");

                    b.Property<string>("EmailSubject");

                    b.Property<double>("Fee")
                        .HasColumnType("money");

                    b.Property<bool?>("Is_Active");

                    b.Property<bool?>("Is_IT_Exempt");

                    b.Property<bool?>("Is_Outside");

                    b.Property<bool?>("Is_Priest");

                    b.Property<bool?>("Is_Quick");

                    b.Property<bool?>("Is_Web_Avail");

                    b.Property<DateTime>("Last_Modified");

                    b.Property<string>("Notes");

                    b.Property<int?>("ServiceGroup_ID");

                    b.Property<string>("Service_Desc");

                    b.Property<string>("ToEmailAddress");

                    b.Property<string>("Who_Modified");

                    b.HasKey("Service_ID");

                    b.HasIndex("ServiceGroup_ID");

                    b.ToTable("tbl_service");
                });

            modelBuilder.Entity("HTA.Models.ServiceGroup", b =>
                {
                    b.Property<int>("ServiceGroup_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date_Created");

                    b.Property<bool?>("Is_Active");

                    b.Property<DateTime>("Last_Modified");

                    b.Property<string>("ServiceGroup_Name");

                    b.Property<string>("Who_Modified");

                    b.HasKey("ServiceGroup_ID");

                    b.ToTable("tbl_servicegroup","dbo");
                });

            modelBuilder.Entity("HTA.Models.Booking", b =>
                {
                    b.HasOne("HTA.Models.Devotee", "Devotee")
                        .WithMany()
                        .HasForeignKey("DevoteeId");
                });

            modelBuilder.Entity("HTA.Models.BookingItem", b =>
                {
                    b.HasOne("HTA.Models.Booking", "Booking")
                        .WithMany("BookingItem")
                        .HasForeignKey("BookingID");

                    b.HasOne("HTA.Models.Service", "Service")
                        .WithMany("BookingItem")
                        .HasForeignKey("Service_ID");
                });

            modelBuilder.Entity("HTA.Models.Service", b =>
                {
                    b.HasOne("HTA.Models.ServiceGroup", "serviceGroup")
                        .WithMany("Services")
                        .HasForeignKey("ServiceGroup_ID");
                });
        }
    }
}
