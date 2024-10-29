using BookingReservationConsoleApp.Domain;
using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class ReservationDisplayerService : IReservationDisplayer
{
    public void DisplayExistingReservations(Room selectedRoom, Hotel selectedHotel)
    {
        var existingReservations = selectedHotel
            .Reservations
            .Where(res => res.Room.RoomType.Equals(selectedRoom.RoomType, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (existingReservations.Count > 0)
        {
            Console.WriteLine($"Existing Reservations for {selectedRoom.RoomType} in {selectedHotel.Name}:");
            foreach (var reservation in existingReservations)
            {
                Console.WriteLine($"- From: {reservation.StartDate:yyyy-MM-dd} To: {reservation.EndDate:yyyy-MM-dd}");
            }
        }
        else
        {
            Console.WriteLine($"No existing reservations for {selectedRoom.RoomType} in {selectedHotel.Name}.");
        }
    }
}