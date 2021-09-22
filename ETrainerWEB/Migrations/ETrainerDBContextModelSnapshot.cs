﻿// <auto-generated />
using E_Trainer_WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Trainer_WEB.Migrations
{
    [DbContext(typeof(ETrainerDBContext))]
    partial class ETrainerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("E_Trainer_WEB.Models.Dish", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("caloricityPerGram")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<float>("portionWeight")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.Exercise", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("properties")
                        .HasColumnType("text");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.Property<int>("workoutId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.HasIndex("workoutId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.ExerciseSchema", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("properties")
                        .HasColumnType("text");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.ToTable("ExerciseSchemas");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.ExerciseType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("properties")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.Ingredient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("caloricityPerGram")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<float>("portionWeight")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.Meal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.Workout", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.Exercise", b =>
                {
                    b.HasOne("E_Trainer_WEB.Models.ExerciseType", null)
                        .WithMany("Exercises")
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Trainer_WEB.Models.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("workoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.ExerciseSchema", b =>
                {
                    b.HasOne("E_Trainer_WEB.Models.ExerciseType", null)
                        .WithMany("ExerciseSchemas")
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.ExerciseType", b =>
                {
                    b.Navigation("Exercises");

                    b.Navigation("ExerciseSchemas");
                });

            modelBuilder.Entity("E_Trainer_WEB.Models.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
