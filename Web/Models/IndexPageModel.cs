namespace Web.Models
{
    public class IndexPageModel
    {
        public IndexPageModel(
            string payDayString)
        {
            PayDayString = payDayString;
        }

        public string PayDayString { get; private set; }
    }
}