namespace BookingReservationConsoleApp.Interface;
public interface IHotelSelector
{
    Hotel? SelectHotel(List<Hotel> hotels);
}