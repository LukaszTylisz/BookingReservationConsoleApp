using BookingReservationConsoleApp.Interface;
using BookingReservationConsoleApp.Service;

namespace BookingReservationConsoleApp;
public class App : IApp
{
    private readonly HotelService _hotelService;
    private readonly ReservationService _reservationService;
    private readonly IHotelSelector _hotelSelector;
    private readonly IRoomSelector _roomSelector;
    private readonly IReservationDisplayer _reservationDisplayer;
    private readonly IReservationDateGetter _reservationDateGetter;
    private readonly IReservationMaker _reservationMaker;
    public App(HotelService hotelService, ReservationService reservationService, IHotelSelector hotelSelector, IRoomSelector roomSelector,
        IReservationDisplayer reservationDisplayer, IReservationDateGetter reservationDateGetter, IReservationMaker reservationMaker)
    {
        _hotelService=hotelService;
        _reservationService=reservationService;
        _hotelSelector=hotelSelector;
        _roomSelector=roomSelector;
        _reservationDisplayer=reservationDisplayer;
        _reservationDateGetter=reservationDateGetter;
        _reservationMaker=reservationMaker;
    }

    public void Run()
    {
        var hotels = _hotelService.GetHotels("hotels.json");
        var reservations = _reservationService.GetReservations("reservations.json", hotels);

        bool closeApp = false;

        while (!closeApp)
        {
            var selectedHotel = _hotelSelector.SelectHotel(hotels);
            if (selectedHotel == null) return;

            var selectedRoom = _roomSelector.SelectRoom(selectedHotel);
            if (selectedRoom == null) return;

            _reservationDisplayer.DisplayExistingReservations(selectedRoom, selectedHotel);

            var (startDate, endDate) = _reservationDateGetter.GetReservationDates();
            if (startDate == DateTime.MinValue || endDate == DateTime.MinValue) return;

            int availableCount = selectedHotel.CountAvailableRooms(selectedRoom.RoomType, startDate, endDate);
            Console.WriteLine($"Available {selectedRoom.RoomType} rooms from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}: {availableCount}");

            if (availableCount <= 0)
            {
                Console.WriteLine("Room is not available for the selected dates.");
            }
            else
            {
                if (_reservationMaker.MakeReservation(selectedRoom, startDate, endDate))
                {
                    Console.WriteLine("Reservation made successfully!");
                }
            }

            Console.WriteLine("\nSee You next time, press any key to exit");
            Console.ReadKey();
            break;
        }
    }
}
