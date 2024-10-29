//using Newtonsoft.Json;

//namespace BookingReservationConsoleApp.Domain;

//public class Reservation
//{
//    public DateTime StartDate { get; set; } = default!;
//    public DateTime EndDate { get; set; } = default!;
//    public int NumberOfDays { get; set; }
//    public Hotel Hotel { get; set; } = default!;
//    public Room Room { get; set; } = default!;

//    public static List<Reservation> LoadReservations(string filePath, List<Hotel> hotels)
//    {
//        var jsonData = File.ReadAllText(filePath);
//        var reservations = JsonConvert.DeserializeObject<List<Reservation>>(jsonData) ?? new List<Reservation>();

//        foreach (var reservation in reservations)
//        {
//            reservation.Hotel = hotels.FirstOrDefault(h => h.Name.Equals(reservation.Hotel.Name, StringComparison.OrdinalIgnoreCase));
//            reservation.Room = reservation.Hotel?.Rooms.FirstOrDefault(r => r.RoomType.Equals(reservation.Room.RoomType, StringComparison.OrdinalIgnoreCase));

//            if (reservation.Hotel != null)
//            {
//                reservation.Hotel.Reservations.Add(reservation);
//            }
//        }
//        return reservations;
//    }
//}
