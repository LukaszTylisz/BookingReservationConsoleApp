using BookingReservationConsoleApp.Domain;
using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class RoomSelectorService : IRoomSelector
{
    public Room? SelectRoom(Hotel selectedHotel)
    {
        Room? selectedRoom = null;
        while (selectedRoom == null)
        {
            Console.WriteLine($"Available Room Types in {selectedHotel.Name}:");
            foreach (var room in selectedHotel.Rooms)
            {
                Console.WriteLine($"- {room.RoomType}");
            }

            Console.WriteLine("Enter room type (or press Enter to exit):");
            string roomType = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(roomType))
            {
                return null; // Exit program
            }

            selectedRoom = selectedHotel.Rooms.FirstOrDefault(r => r.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase));

            if (selectedRoom == null)
            {
                Console.WriteLine("Room type not available in the selected hotel. Please enter a valid room type.");
            }
        }
        return selectedRoom;
    }
}