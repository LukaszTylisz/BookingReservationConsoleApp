using BookingReservationConsoleApp.Domain;
using BookingReservationConsoleApp.Service;

public class ReservationMakerServiceTests
{
    [Fact]
    public void MakeReservation_ValidRoom_AddsReservation()
    {
        var hotel = new Hotel { Name = "Test Hotel" };
        var room = new Room { RoomType = "Suite", Hotel = hotel };

        var reservationMaker = new ReservationMakerService();
        var result = reservationMaker.MakeReservation(room, new DateTime(2024, 10, 10), new DateTime(2024, 10, 12));

        Assert.True(result);
        Assert.Single(room.Reservations);
        Assert.Equal(new DateTime(2024, 10, 10), room.Reservations[0].StartDate);
        Assert.Equal(new DateTime(2024, 10, 12), room.Reservations[0].EndDate);
    }

    [Fact]
    public void MakeReservation_NullHotel_ReturnsFalse()
    {
        var room = new Room { RoomType = "Suite", Hotel = null };

        var reservationMaker = new ReservationMakerService();
        var result = reservationMaker.MakeReservation(room, new DateTime(2024, 10, 10), new DateTime(2024, 10, 12));

        Assert.False(result);
        Assert.Empty(room.Reservations);
    }

    [Fact]
    public void MakeReservation_EndDateBeforeStartDate_ReturnsFalse()
    {
        var hotel = new Hotel { Name = "Test Hotel" };
        var room = new Room { RoomType = "Suite", Hotel = hotel };

        var reservationMaker = new ReservationMakerService();
        var result = reservationMaker.MakeReservation(room, new DateTime(2024, 10, 12), new DateTime(2024, 10, 10));

        Assert.False(result);
        Assert.Empty(room.Reservations);
    }
}