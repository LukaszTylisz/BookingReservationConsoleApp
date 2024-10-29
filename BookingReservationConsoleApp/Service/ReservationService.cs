using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class ReservationService(IReservationRepository reservationRepository)
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;

    public List<Reservation> GetReservations(string filePath, List<Hotel> hotels)
    {
        return _reservationRepository.LoadReservations(filePath, hotels);
    }
}