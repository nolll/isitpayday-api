using System;
using Core.Classes;

namespace Core.Services
{
    public interface IPayDayService
    {
        int GetSelectedPayDay();
        bool IsPayDay(DateTime utcTime, int payDay);
        bool IsPayDay(UserSettings userSettings);
    }
}