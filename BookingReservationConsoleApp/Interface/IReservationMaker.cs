using BookingReservationConsoleApp.Domain;

namespace BookingReservationConsoleApp.Interface;
public interface IReservationMaker
{
    bool MakeReservation(Room selectedRoom, DateTime startDate, DateTime endDate);
}