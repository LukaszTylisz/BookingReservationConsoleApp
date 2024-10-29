//using Newtonsoft.Json;

//namespace BookingReservationConsoleApp.Domain;

//public class Hotel
//{
//    public string Name { get; set; } = default!;
//    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
//    public List<Room> Rooms { get; set; } = default!;

//    public Hotel(string name, decimal pricePerDay)
//    {
//        Name = name;
//    }

//    public bool IsRoomAvailable(string roomType, DateTime startDate, DateTime endDate)
//    {
//        return Rooms.Any(room =>
//            room.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase) &&
//            Reservations.All(reservation =>
//                reservation.Room != room ||
//                reservation.StartDate >= endDate ||
//                reservation.EndDate <= startDate
//            )
//        );
//    }

//    public static List<Hotel> LoadHotels(string filePath)
//    {
//        var jsonData = File.ReadAllText(filePath);
//        return JsonConvert.DeserializeObject<List<Hotel>>(jsonData) ?? new List<Hotel>();
//    }
//}
