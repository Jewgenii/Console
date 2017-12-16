namespace console
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ClassRoom> ClassRoom { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudGroup> StudGroup { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ClassRoom>()
                .HasMany(e => e.Schedule)
                .WithOptional(e => e.ClassRoom)
                .HasForeignKey(e => e.idClassRoom);

            modelBuilder.Entity<Student>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudGroup)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.idStudent);

            modelBuilder.Entity<StudGroup>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<StudGroup>()
                .HasMany(e => e.Schedule)
                .WithOptional(e => e.StudGroup)
                .HasForeignKey(e => e.idStudGroup);

            modelBuilder.Entity<Subjects>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Subjects>()
                .HasMany(e => e.Schedule)
                .WithOptional(e => e.Subjects)
                .HasForeignKey(e => e.idSubjects);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Schedule)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.idTeacher);
        }
    }
}
