using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Device> Devices {  get; set; } 
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<DeviceSchedule> DeviceSchedules { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<ScheduleTimeSlot> ScheduleTimeSlots { get; set; }
    public DbSet<DeviceDailyAvailability> DeviceDailyAvailability { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Media>(entity =>
        {
            // Content - Media: One-to-Many
            entity.HasOne(m => m.Content)
            .WithMany(c => c.Media)
            .HasForeignKey(m => m.ContentId)
            .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Device>(entity =>
        {
            //Device - User : One-to-One
            entity.HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Device>(d => d.UserId);
            // Device - DeviceType: One-to-Many
            entity.HasOne(d => d.DeviceType)
            .WithMany(dt => dt.Devices)
            .HasForeignKey(d => d.DeviceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

            // Device - Location: One-to-Many
            entity.HasOne(d => d.Location)
            .WithMany(l => l.Devices)
            .HasForeignKey(d => d.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<DeviceSchedule>(entity =>
        {
            // Device - DeviceSchedule: One-to-Many
            entity.HasOne(ds => ds.Device)
            .WithMany(d => d.DeviceSchedules)
            .HasForeignKey(ds => ds.DeviceID)
            .OnDelete(DeleteBehavior.Cascade);

            // Schedule - DeviceSchedule: One-to-Many
            entity.HasOne(ds => ds.Schedule)
            .WithMany(s => s.DeviceSchedules)
            .HasForeignKey(ds => ds.ScheduleID)
            .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Schedule>(entity =>
        {
            // Schedule - Content: One-to-One
            entity.HasOne(s => s.Content)
            .WithMany(c => c.Schedules)
            .HasForeignKey(s => s.ContentID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ScheduleTimeSlot>(entity =>
        {
            // Schedule - ScheduleTimeSlot : One-to-Many
            entity.HasOne(ds => ds.Schedule)
            .WithMany(d => d.ScheduleSlots)
            .HasForeignKey(ds => ds.ScheduleID)
            .OnDelete(DeleteBehavior.Cascade);

            // TimeSlot - ScheduleTimeSlot: One-to-Many
            entity.HasOne(ds => ds.TimeSlot)
            .WithMany(s => s.ScheduleSlots)
            .HasForeignKey(ds => ds.ScheduleID)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DeviceDailyAvailability>(entity =>
        {
            entity.HasKey(d => new { d.DeviceID, d.DateTime });
            // Device - DeviceDailyAvailability : One-to-Many
            entity.HasOne(da => da.Device)
                  .WithMany(d => d.DeviceDailyAvailabilities)
                  .HasForeignKey(da => da.DeviceID)
                  .OnDelete(DeleteBehavior.Cascade); // Xóa theo chuỗi
        });
    }

}
