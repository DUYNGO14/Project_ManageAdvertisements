using Domain.Entities;
using System.Drawing;

namespace Infrastructure.Seeder.DataSeed;

public static class LocationData
{
    public static readonly List<Location> Locations = new List<Location>
    {
        new Location { Floor = 1, Department = "Khu vực Cổng chính", Description = "Tầng 1 - Khu vực Cổng chính" },
        new Location { Floor = 1, Department = "Khu vực Thời trang - phụ kiện", Description = "Tầng 1 - Khu vực Thời trang - phụ kiện" },
        new Location { Floor = 1, Department = "Khu vực Đồ ăn & nước uống", Description = "Tầng 1 - Khu vực Đồ ăn & nước uống" },
        new Location { Floor = 1, Department = "Khu vực Tủ đồ thông minh E-Locker", Description = "Tầng 1 - Khu vực Tủ đồ thông minh E-Locker" },
        new Location { Floor = 1, Department = "Khu vực thang máy", Description = "Tầng 1 - Khu vực thang máy" },
        new Location { Floor = 1, Department = "Khu vực thang cuốn", Description = "Tầng 1 - Khu vực thang cuốn" },
        new Location { Floor = 2, Department = "Khu vực Thời trang - phụ kiện", Description = "Tầng 2 - Khu vực Thời trang - phụ kiện" },
        new Location { Floor = 2, Department = "Khu vực thang máy", Description = "Tầng 2 - Khu vực thang máy" },
        new Location { Floor = 2, Department = "Khu vực thang cuốn", Description = "Tầng 2 - Khu vực thang cuốn" },
        new Location { Floor = 3, Department = "Khu vực Đồ ăn & nước uống", Description = "Tầng 3 - Khu vực Đồ ăn & nước uống" },
        new Location { Floor = 3, Department = "Khu vực vui chơi giải trí", Description = "Tầng 3 - Khu vực vui chơi giải trí" },
        new Location { Floor = 3, Department = "Khu vực cửa hàng chuyên dụng", Description = "Tầng 3 - Khu vực cửa hàng chuyên dụng" },
        new Location { Floor = 3, Department = "Khu vực thang máy", Description = "Tầng 3 - Khu vực thang máy" },
        new Location { Floor = 3, Department = "Khu vực thang cuốn", Description = "Tầng 3 - Khu vực thang cuốn" },
        new Location { Floor = 4, Department = "Khu vực thời trang - phụ kiện", Description = "Tầng 4 - Khu vực thời trang - phụ kiện" },
        new Location { Floor = 4, Department = "Khu vực cửa hàng chuyên dụng", Description = "Tầng 4 - Khu vực cửa hàng chuyên dụng" },
        new Location { Floor = 4, Department = "Khu vực thang máy", Description = "Tầng 4 - Khu vực thang máy" },
        new Location { Floor = 4, Department = "Khu vực thang cuốn", Description = "Tầng 4 - Khu vực thang cuốn" }
    };
}

public static class DeviceTypeData
{
    public static readonly List<DeviceType> deviceTypes = new List<DeviceType>
    {
        new DeviceType {  Name="Vertical LCD",Resolution="1080x1920",Size="21 inches" },
        new DeviceType {  Name="Digital Poster",Resolution="1920x1080",Size="32 inches" },
        new DeviceType {  Name="LED",Resolution="1920x1080",Size="300 inches" }
    };
}

public static class TimeSlotData
{
    public static readonly List<TimeSlot> TimeSlots = new List<TimeSlot>
    {
        new TimeSlot
        {

            StartTime = TimeSpan.FromHours(11).Add(TimeSpan.FromMinutes(30)), // 11:00 AM
            EndTime = TimeSpan.FromHours(13).Add(TimeSpan.FromMinutes(30)), // 1:00 PM
            IsPeak = true,
        },
        new TimeSlot
        {

            StartTime = TimeSpan.FromHours(19), // 7:00 PM
            EndTime = TimeSpan.FromHours(21), // 9:00 PM
            IsPeak = true ,// Giờ cao điểm
        },
        new TimeSlot
        {
            StartTime = TimeSpan.FromHours(8), // 5:00 PM
            EndTime = TimeSpan.FromHours(22), // 9:00 PM
            IsPeak = false, // Giờ cao điểm
        },
    };
}

public static class DeviceData
{
    public static readonly List<Device> Devices = new List<Device>
    {

    new Device
    {
        DeviceName = "DP-F4.1",
        LocationId = 15,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F4.2",
        LocationId = 16,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F4.1",
        LocationId = 17,
        DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F4.2",
        LocationId = 18,
        DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F3.1",
        LocationId = 11,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F3.2",
        LocationId = 12,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F3.1",
        LocationId = 13,
        DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F3.2",
        LocationId = 14,
        DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },

    new Device
    {
        DeviceName = "LED-F1",
        LocationId = 1,
        DeviceTypeId = 3,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LED-F2",
        LocationId = 7,
         DeviceTypeId = 3,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LED-F3",
        LocationId = 10,
        DeviceTypeId = 3,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F1.1",
        LocationId = 2,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F1.2",
        LocationId = 2,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F1.3",
        LocationId = 3,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F1.4",
        LocationId = 4,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F1.1",
        LocationId = 5,
        DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F1.2",
        LocationId = 6,
         DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },

    new Device
    {
        DeviceName = "DP-F2.1",
        LocationId = 7,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },

    new Device
    {
        DeviceName = "DP-F2.2",
        LocationId =7,
         DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },

    new Device
    {
        DeviceName = "DP-F2.3",
        LocationId =7,
         DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F2.4",
        LocationId =7,
         DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "LCD-F2.1",
        LocationId =9,
        DeviceTypeId = 1,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    new Device
    {
        DeviceName = "DP-F2.5",
        LocationId =10,
        DeviceTypeId = 2,
        Status = "Active",
        CreatedAt = DateTime.UtcNow
    },
    };
}