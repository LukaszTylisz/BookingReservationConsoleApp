using BookingReservationConsoleApp.Domain;

public class Hotel
{
    public string Name { get; set; } = default!;
    public decimal PricePerDay { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<Room> Rooms { get; set; } = new List<Room>();

    public int CountAvailableRooms(string roomType, DateTime startDate, DateTime endDate)
    {
        var reservedCount = Reservations.Count(reservation =>
            reservation.Room.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase) &&
            reservation.StartDate < endDate &&
            reservation.EndDate > startDate);

        var totalCount = Rooms.Count(room => room.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase));
        return totalCount - reservedCount;
    }
}