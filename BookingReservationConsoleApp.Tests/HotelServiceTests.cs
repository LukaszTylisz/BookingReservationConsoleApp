using BookingReservationConsoleApp.Interface;
using BookingReservationConsoleApp.Service;
using Moq;

namespace BookingReservationConsoleApp.Tests;
public class HotelServiceTests
{
    [Fact]
    public void GetHotels_ValidFilePath_ReturnsHotels()
    {
        var mockHotelRepository = new Mock<IHotelRepository>();
        var expectedHotels = new List<Hotel> { new Hotel { Name = "Test Hotel" } };

        mockHotelRepository
            .Setup(repo => repo.LoadHotels(It.IsAny<string>()))
            .Returns(expectedHotels);

        var hotelService = new HotelService(mockHotelRepository.Object);

        var hotels = hotelService.GetHotels("dummyPath.json");

        Assert.Single(hotels);
        Assert.Equal("Test Hotel", hotels[0].Name);
    }
}
