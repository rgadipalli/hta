using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HTA.Models;

namespace HTA.Migrations
{
    [DbContext(typeof(HTAContext))]
    [Migration("20170516211902_DateFormat")]
    partial class DateFormat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("tbl_devotee","dbo");
                });
        }
    }
}
