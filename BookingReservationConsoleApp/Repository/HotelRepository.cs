using BookingReservationConsoleApp.Interface;
using Newtonsoft.Json;

namespace BookingReservationConsoleApp.Repository;
public class HotelRepository : IHotelRepository
{
    public List<Hotel> LoadHotels(string filePath)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        var usersJsonPath = Path.Combine(baseDirectory, "Json", "hotels.json");

        if (!File.Exists(filePath))
            throw new FileNotFoundException("The hotels file was not found.", filePath);

        var jsonData = File.ReadAllText(filePath);
        var hotels = JsonConvert.DeserializeObject<List<Hotel>>(jsonData) ?? new List<Hotel>();

        foreach (var hotel in hotels)
        {
            foreach (var room in hotel.Rooms)
            {
                room.Hotel = hotel;
            }
        }

        return hotels;
    }
}
