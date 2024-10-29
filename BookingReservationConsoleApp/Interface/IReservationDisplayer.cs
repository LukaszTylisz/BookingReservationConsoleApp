using BookingReservationConsoleApp.Domain;

namespace BookingReservationConsoleApp.Interface;
public interface IReservationDisplayer
{
    void DisplayExistingReservations(Room selectedRoom, Hotel selectedHotel);
}