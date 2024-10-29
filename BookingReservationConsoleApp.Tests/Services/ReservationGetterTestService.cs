using BookingReservationConsoleApp.Interface;

namespace BookingReservationConsoleApp.Tests.Services
{
    public class ReservationGetterTestService : IReservationDateGetter
    {
        private readonly Func<string> _getInput;

        public ReservationGetterTestService(Func<string> getInput = null)
        {
            _getInput = getInput ?? Console.ReadLine;
        }

        public (DateTime, DateTime) GetReservationDates()
        {
            DateTime startDate;
            DateTime endDate;

            // Prompt for the start date
            while (true)
            {
                Console.Write("Enter start date (yyyy-MM-dd) (or press Enter to exit): ");
                var startDateInput = _getInput();
                if (string.IsNullOrWhiteSpace(startDateInput)) return (DateTime.MinValue, DateTime.MinValue);

                if (DateTime.TryParse(startDateInput, out startDate))
                    break;

                Console.WriteLine("Invalid date format. Please enter the start date in the format yyyy-MM-dd.");
            }

            // Prompt for the end date and validate it against the start date
            while (true)
            {
                Console.Write("Enter end date (yyyy-MM-dd) (or press Enter to exit): ");
                var endDateInput = _getInput();
                if (string.IsNullOrWhiteSpace(endDateInput)) return (DateTime.MinValue, DateTime.MinValue);

                if (!DateTime.TryParse(endDateInput, out endDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the end date in the format yyyy-MM-dd.");
                    continue;
                }

                if (endDate >= startDate)
                    break;

                Console.WriteLine("Error: End date cannot be earlier than start date. Please re-enter the end date.");
            }

            return (startDate, endDate);
        }
    }
}