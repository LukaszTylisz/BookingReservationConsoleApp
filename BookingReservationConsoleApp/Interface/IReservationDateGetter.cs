namespace BookingReservationConsoleApp.Interface;
public interface IReservationDateGetter
{
    (DateTime startDate, DateTime endDate) GetReservationDates();
}
