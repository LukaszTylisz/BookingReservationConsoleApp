using BookingReservationConsoleApp.Domain;
using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class ReservationMakerService : IReservationMaker
{
    public bool MakeReservation(Room selectedRoom, DateTime startDate, DateTime endDate)
    {
        if (selectedRoom.Hotel == null)
        {
            Console.WriteLine("Error: The selected room does not belong to any hotel.");
            return false;
        }

        if (endDate < startDate)
        {
            Console.WriteLine("Error: End date cannot be earlier than start date.");
            return false;
        }

        var reservation = new Reservation
        {
            StartDate = startDate,
            EndDate = endDate,
            NumberOfDays = (endDate - startDate).Days,
            Room = selectedRoom,
            Hotel = selectedRoom.Hotel
        };

        selectedRoom.Reservations.Add(reservation);
        reservation.Hotel.Reservations.Add(reservation);
        return true;
    }
}
