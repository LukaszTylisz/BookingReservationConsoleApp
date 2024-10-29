using BookingReservationConsoleApp.Domain;

public class Reservation
{
    public DateTime StartDate { get; set; } = default!;
    public DateTime EndDate { get; set; } = default!;
    public int NumberOfDays { get; set; }
    public Hotel Hotel { get; set; } = default!;
    public Room Room { get; set; } = default!;
}