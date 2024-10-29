using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class HotelSelectorService : IHotelSelector
{
    public Hotel? SelectHotel(List<Hotel> hotels)
    {
        Hotel? selectedHotel = null;
        while (selectedHotel == null)
        {
            Console.WriteLine("Available Hotels:");
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"- {hotel.Name}");
            }

            Console.WriteLine("Enter hotel name (or press Enter to exit):");
            string hotelName = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(hotelName))
            {
                return null; // Exit program
            }

            selectedHotel = hotels.FirstOrDefault(h => h.Name.Equals(hotelName, StringComparison.OrdinalIgnoreCase));

            if (selectedHotel == null)
            {
                Console.WriteLine("Hotel not found. Please enter a valid hotel name.");
            }
        }
        return selectedHotel;
    }
}