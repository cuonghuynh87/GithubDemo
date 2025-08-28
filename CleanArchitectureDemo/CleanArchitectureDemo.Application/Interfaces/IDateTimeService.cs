namespace CleanArchitectureDemo.Application.Interfaces.Repositories;

public interface IDateTimeService
{
    DateTime NowUtc { get; }
}