using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class HotelService(IHotelRepository hotelRepository)
{
    private readonly IHotelRepository _hotelRepository = hotelRepository;

    public List<Hotel> GetHotels(string filePath)
    {
        return _hotelRepository.LoadHotels(filePath);
    }
}