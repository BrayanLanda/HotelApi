// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using HotelApi.Data;
// using HotelApi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace HotelApi.Seeders
// {
//     public class DataSeeder
//     {
//         private readonly DataContext _context;

//         public DataSeeder(DataContext context)
//         {
//             _context = context;
//         }

//         public async Task SeedAsync()
//         {
//             // Seed RoomTypes
//             if (!_context.RoomTypes.Any())
//             {
//                 var roomTypes = new List<RoomType>
//             {
//                 new RoomType { Name = "Simple Room", Description = "A cozy basic room with a single bed, ideal for solo travelers." },
//                 new RoomType { Name = "Double Room", Description = "Offers flexibility with two single beds or a double bed, perfect for couples or friends." },
//                 new RoomType { Name = "Suite", Description = "Spacious and luxurious, with a king-size bed and a separate living area, ideal for those seeking comfort and exclusivity." },
//                 new RoomType { Name = "Family Room", Description = "Designed for families, with extra space and multiple beds for a comfortable stay." }
//             };

//                 await _context.RoomTypes.AddRangeAsync(roomTypes);
//                 await _context.SaveChangesAsync();
//             }

//             // Seed Rooms
//             if (!_context.Rooms.Any())
//             {
//                 var roomTypes = await _context.RoomTypes.ToListAsync();
//                 var rooms = new List<Room>();
//                 int roomNumber = 1;

//                 // Create 10 rooms per floor for 5 floors
//                 for (int floor = 1; floor <= 5; floor++)
//                 {
//                     foreach (var roomType in roomTypes)
//                     {
//                         for (int i = 0; i < 10; i++)
//                         {
//                             rooms.Add(new Room
//                             {
//                                 RoomTypeId = roomType.Id,
//                                 PricePerNight = roomType.Name switch
//                                 {
//                                     "Simple Room" => 50,
//                                     "Double Room" => 80,
//                                     "Suite" => 150,
//                                     "Family Room" => 200,
//                                     _ => throw new Exception("Unknown room type")
//                                 },
//                                 Availability = true, // All rooms are available at start
//                                 MaxOccupancy = roomType.Name switch
//                                 {
//                                     "Simple Room" => 1,
//                                     "Double Room" => 2,
//                                     "Suite" => 2,
//                                     "Family Room" => 4,
//                                     _ => throw new Exception("Unknown room type")
//                                 }
//                             });
//                         }
//                     }
//                 }

//                 await _context.Rooms.AddRangeAsync(rooms);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }