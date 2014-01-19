using System;

namespace Web.DateEvaluators
{
    public interface IBlockedEvaluator
    {
        bool IsBlocked(DateTime dateTime);
    }
}