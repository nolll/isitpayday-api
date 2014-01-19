using System;

namespace Web.DateEvaluators
{
    public interface IExcludedEvaluator
    {
        bool IsExcluded(DateTime dateTime);
    }
}