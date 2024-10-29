using BookingReservationConsoleApp.Domain;

namespace BookingReservationConsoleApp.Interface;
public interface IRoomSelector
{
    Room? SelectRoom(Hotel selectedHotel);
}
