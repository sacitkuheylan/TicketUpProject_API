using System;
using TicketUpProject_API.Service.Contract;

namespace TicketUpProject_API.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}