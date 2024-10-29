using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Service;
public class ReservationDateGetterService : IReservationDateGetter
{
    public (DateTime, DateTime) GetReservationDates()
    {
        const string dateFormat = "yyyy-MM-dd";
        const string exitMessage = "Press Enter to exit";

        var startDate = GetDate($"Enter start date ({dateFormat}) {exitMessage}: ");
        if (startDate == null) return (DateTime.MinValue, DateTime.MinValue);

        var endDate = GetDate($"Enter end date ({dateFormat}) {exitMessage}: ");
        if (endDate == null) return (DateTime.MinValue, DateTime.MinValue);

        while (endDate < startDate)
        {
            Console.WriteLine("Error: End date cannot be earlier than start date.");
            endDate = GetDate($"Enter end date ({dateFormat}) {exitMessage}: ");
            if (endDate == null) return (DateTime.MinValue, DateTime.MinValue);
        }

        return (startDate.Value, endDate.Value);
    }
    private static DateTime? GetDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return null;

            if (DateTime.TryParseExact(input, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime result))
                return result;

            Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd.");
        }
    }
}