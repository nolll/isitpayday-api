using System;

namespace Web.Services
{
    public interface IPayDayService
    {
        int GetSelectedPayDay();
        bool IsPayDay(DateTime dateTime, int payDay);
    }
}