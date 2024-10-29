using BookingReservationConsoleApp.Tests.Services;

public class ReservationDateGetterServiceTests
{
    [Fact]
    public void GetReservationDates_ValidDates_ReturnsCorrectDates()
    {
        var inputSequence = new Queue<string>(new[]
        {
            "2024-10-10", // Start date
            "2024-10-12"  // End date
        });
        Func<string> mockInput = () => inputSequence.Dequeue();

        var dateGetter = new ReservationGetterTestService(mockInput);

        var (startDate, endDate) = dateGetter.GetReservationDates();

        Assert.Equal(new DateTime(2024, 10, 10), startDate);
        Assert.Equal(new DateTime(2024, 10, 12), endDate);
    }

    [Fact]
    public void GetReservationDates_EndDateBeforeStartDate_RePromptForEndDate()
    {
        var inputSequence = new Queue<string>(new[]
        {
            "2024-10-10",
            "2024-10-08",
            "2024-10-15"
        });
        Func<string> mockInput = () => inputSequence.Dequeue();

        var dateGetter = new ReservationGetterTestService(mockInput);

        var (startDate, endDate) = dateGetter.GetReservationDates();

        Assert.Equal(new DateTime(2024, 10, 10), startDate);
        Assert.Equal(new DateTime(2024, 10, 15), endDate);
    }

    [Fact]
    public void GetReservationDates_EmptyInput_ReturnsMinValueDates()
    {
        var inputSequence = new Queue<string>(new[]
        {
            ""
        });
        Func<string> mockInput = () => inputSequence.Dequeue();

        var dateGetter = new ReservationGetterTestService(mockInput);

        var (startDate, endDate) = dateGetter.GetReservationDates();

        Assert.Equal(DateTime.MinValue, startDate);
        Assert.Equal(DateTime.MinValue, endDate);
    }
}
