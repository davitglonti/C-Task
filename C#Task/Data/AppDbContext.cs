using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

public class AppDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<TeacherPupil> TeacherPupils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeacherPupil>()
            .HasKey(tp => new { tp.TeacherID, tp.PupilID });

        modelBuilder.Entity<TeacherPupil>()
            .HasOne(tp => tp.Teacher)
            .WithMany(t => t.TeacherPupils)
            .HasForeignKey(tp => tp.TeacherID);

        modelBuilder.Entity<TeacherPupil>()
            .HasOne(tp => tp.Pupil)
            .WithMany(p => p.TeacherPupils)
            .HasForeignKey(tp => tp.PupilID);
    }
}
