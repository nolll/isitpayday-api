using System;

namespace Core.Services
{
    public interface IPayDayService
    {
        int GetSelectedPayDay();
        bool IsPayDay(DateTime dateTime, int payDay);
    }
}