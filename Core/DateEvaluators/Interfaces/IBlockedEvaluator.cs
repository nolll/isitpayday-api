using System;

namespace Core.DateEvaluators
{
    public interface IBlockedEvaluator
    {
        bool IsBlocked(DateTime userTime);
    }
}