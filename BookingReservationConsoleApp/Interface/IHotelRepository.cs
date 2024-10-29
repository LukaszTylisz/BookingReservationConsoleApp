namespace BookingReservationConsoleApp.Interface;
public interface IHotelRepository
{
    List<Hotel> LoadHotels(string filePath);
}