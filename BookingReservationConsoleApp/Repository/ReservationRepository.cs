using BookingReservationConsoleApp.Interface;
using Newtonsoft.Json;

namespace BookingReservationConsoleApp.Repository;
public class ReservationRepository : IReservationRepository
{
    public List<Reservation> LoadReservations(string filePath, List<Hotel> hotels)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        var usersJsonPath = Path.Combine(baseDirectory, "Json", "reservations.json");

        if (!File.Exists(filePath))
            throw new FileNotFoundException("The reservations file was not found.", filePath);

        var jsonData = File.ReadAllText(filePath);
        var reservations = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

        foreach (var reservation in reservations)
        {
            reservation.Hotel = hotels.FirstOrDefault(h => h.Name.Equals(reservation.Hotel.Name, StringComparison.OrdinalIgnoreCase));
            reservation.Room = reservation.Hotel?.Rooms.FirstOrDefault(r => r.RoomType.Equals(reservation.Room.RoomType, StringComparison.OrdinalIgnoreCase));

            if (reservation.Room != null)
            {
                reservation.Room.Hotel = reservation.Hotel;
            }

            if (reservation.Hotel != null && reservation.Room != null)
            {
                reservation.Hotel.Reservations.Add(reservation);
                reservation.Room.Reservations.Add(reservation);
            }
        }
        return reservations;
    }
}