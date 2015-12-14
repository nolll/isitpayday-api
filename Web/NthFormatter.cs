using System.Globalization;

namespace Web
{
    public class NthFormatter
    {
        private readonly string _n;

        public NthFormatter(int n)
        {
            _n = n.ToString(CultureInfo.InvariantCulture);
        }

        public string Format()
        {
            if (FormatsAsFirst)
                return $"{_n}st";
            if (FormatsAsSecond)
                return $"{_n}nd";
            if (FormatsAsThird)
                return $"{_n}rd";
            return $"{_n}th";
        }

        private bool FormatsAsFirst => _n.EndsWith("1") && !_n.EndsWith("11");
        private bool FormatsAsSecond => _n.EndsWith("2") && !_n.EndsWith("12");
        private bool FormatsAsThird => _n.EndsWith("3") && !_n.EndsWith("13");
    }
}