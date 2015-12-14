using System.Globalization;
using System.Web.Mvc;

namespace Web
{
    public class CustomSelectListItem : SelectListItem
    {
        public CustomSelectListItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public CustomSelectListItem(string text, int value)
            : this(text, value.ToString(CultureInfo.InvariantCulture))
        {
        }
    }
}