namespace BookingReservationConsoleApp.Domain;

public class Room
{
    public string RoomType { get; set; } = default!;
    public Hotel Hotel { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    public bool IsAvailable(DateTime startDate, DateTime endDate)
    {
        return Reservations.All(reservation =>
            reservation.StartDate >= endDate || reservation.EndDate <= startDate);
    }
}