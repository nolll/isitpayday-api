using System;

namespace Core.Services
{
    public interface IPayDayService
    {
        bool IsPayDay(DateTime utcTime, int payDay);
        bool IsPayDay();
    }
}