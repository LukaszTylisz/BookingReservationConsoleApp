//namespace BookingReservationConsoleApp.Domain;

//public class Room
//{
//    public string RoomType { get; set; } = default!;
//    public Hotel Hotel { get; set; } = default!;

//    public bool IsAvailable(DateTime startDate, DateTime endDate)
//    {
//        return !Hotel.Reservations.Any(r =>
//            (startDate < r.EndDate && endDate > r.StartDate));
//    }
//}