﻿// <auto-generated />
using composure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace composure.Migrations
{
    [DbContext(typeof(ComposureContext))]
    partial class ComposureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("composure.Models.NewApp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Class");

                    b.Property<string>("Name");

                    b.Property<string>("Spec");

                    b.Property<int>("itemLevel");

                    b.HasKey("ID");

                    b.ToTable("NewApp");
                });
#pragma warning restore 612, 618
        }
    }
}
