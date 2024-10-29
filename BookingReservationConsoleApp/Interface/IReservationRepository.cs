namespace BookingReservationConsoleApp.Interface;
public interface IReservationRepository
{
    List<Reservation> LoadReservations(string filePath, List<Hotel> hotels);
}
