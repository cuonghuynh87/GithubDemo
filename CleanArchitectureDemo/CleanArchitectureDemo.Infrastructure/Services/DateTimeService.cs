using CleanArchitectureDemo.Application.Interfaces.Repositories;

namespace CleanArchitectureDemo.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}