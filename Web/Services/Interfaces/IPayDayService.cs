using System;

namespace Web.Services
{
    public interface IPayDayService
    {
        bool IsPayDay();
        bool IsPayDay(DateTime dateTime);
        int GetPayDay();
    }
}