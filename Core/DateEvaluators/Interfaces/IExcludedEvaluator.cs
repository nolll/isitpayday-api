using System;

namespace Core.DateEvaluators
{
    public interface IExcludedEvaluator
    {
        bool IsExcluded(DateTime userTime);
    }
}