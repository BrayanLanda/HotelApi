using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Seeders
{
    public class DataSeeder
    {
        private readonly DataContext _context;

        public DataSeeder(DataContext context)
        {
            _context = context;
        }

        // public async Task SeedAsync()
        // {
        //     var guests = new List<Guest>
        //     {
        //         new Guest
        //         {
        //             FirstName = "John",
        //             LastName = "Doe",
        //             Email = "john.doe@example.com",
        //             IdentificationNumber = "123456789",
        //             PhoneNumber = "123-456-7890",
        //             Birthdate = new DateTime(1990, 1, 1)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Jane",
        //             LastName = "Smith",
        //             Email = "jane.smith@example.com",
        //             IdentificationNumber = "987654321",
        //             PhoneNumber = "098-765-4321",
        //             Birthdate = new DateTime(1992, 2, 2)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Alice",
        //             LastName = "Johnson",
        //             Email = "alice.johnson@example.com",
        //             IdentificationNumber = "123123123",
        //             PhoneNumber = "321-654-9870",
        //             Birthdate = new DateTime(1985, 3, 3)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Bob",
        //             LastName = "Brown",
        //             Email = "bob.brown@example.com",
        //             IdentificationNumber = "456456456",
        //             PhoneNumber = "654-321-0987",
        //             Birthdate = new DateTime(1980, 4, 4)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Charlie",
        //             LastName = "Davis",
        //             Email = "charlie.davis@example.com",
        //             IdentificationNumber = "789789789",
        //             PhoneNumber = "987-654-3210",
        //             Birthdate = new DateTime(1995, 5, 5)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Emily",
        //             LastName = "Wilson",
        //             Email = "emily.wilson@example.com",
        //             IdentificationNumber = "321321321",
        //             PhoneNumber = "432-109-8765",
        //             Birthdate = new DateTime(1993, 6, 6)
        //         },
        //         new Guest
        //         {
        //             FirstName = "David",
        //             LastName = "Garcia",
        //             Email = "david.garcia@example.com",
        //             IdentificationNumber = "654654654",
        //             PhoneNumber = "210-987-6543",
        //             Birthdate = new DateTime(1988, 7, 7)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Sophia",
        //             LastName = "Martinez",
        //             Email = "sophia.martinez@example.com",
        //             IdentificationNumber = "111222333",
        //             PhoneNumber = "543-210-9876",
        //             Birthdate = new DateTime(1991, 8, 8)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Michael",
        //             LastName = "Lopez",
        //             Email = "michael.lopez@example.com",
        //             IdentificationNumber = "222333444",
        //             PhoneNumber = "678-901-2345",
        //             Birthdate = new DateTime(1987, 9, 9)
        //         },
        //         new Guest
        //         {
        //             FirstName = "Isabella",
        //             LastName = "Hernandez",
        //             Email = "isabella.hernandez@example.com",
        //             IdentificationNumber = "333444555",
        //             PhoneNumber = "789-012-3456",
        //             Birthdate = new DateTime(1994, 10, 10)
        //         }
        //     };

        //     await _context.Guests.AddRangeAsync(guests);
        //     await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
        // }
    }
}


// Seed RoomTypes
// if (!_context.RoomTypes.Any())
// {
//     var roomTypes = new List<RoomType>
// {
//     new RoomType { Name = "Simple Room", Description = "A cozy basic room with a single bed, ideal for solo travelers." },
//     new RoomType { Name = "Double Room", Description = "Offers flexibility with two single beds or a double bed, perfect for couples or friends." },
//     new RoomType { Name = "Suite", Description = "Spacious and luxurious, with a king-size bed and a separate living area, ideal for those seeking comfort and exclusivity." },
//     new RoomType { Name = "Family Room", Description = "Designed for families, with extra space and multiple beds for a comfortable stay." }
// };

//     await _context.RoomTypes.AddRangeAsync(roomTypes);
//     await _context.SaveChangesAsync();
// }

// // Seed Rooms
// if (!_context.Rooms.Any())
// {
//     var roomTypes = await _context.RoomTypes.ToListAsync();
//     var rooms = new List<Room>();
//     int roomNumber = 1;

//     // Create 10 rooms per floor for 5 floors
//     for (int floor = 1; floor <= 5; floor++)
//     {
//         foreach (var roomType in roomTypes)
//         {
//             for (int i = 0; i < 10; i++)
//             {
//                 rooms.Add(new Room
//                 {
//                     RoomTypeId = roomType.Id,
//                     PricePerNight = roomType.Name switch
//                     {
//                         "Simple Room" => 50,
//                         "Double Room" => 80,
//                         "Suite" => 150,
//                         "Family Room" => 200,
//                         _ => throw new Exception("Unknown room type")
//                     },
//                     Availability = true, // All rooms are available at start
//                     MaxOccupancy = roomType.Name switch
//                     {
//                         "Simple Room" => 1,
//                         "Double Room" => 2,
//                         "Suite" => 2,
//                         "Family Room" => 4,
//                         _ => throw new Exception("Unknown room type")
//                     }
//                 });
//             }
//         }
//     }

//     await _context.Rooms.AddRangeAsync(rooms);
//     await _context.SaveChangesAsync();
// }