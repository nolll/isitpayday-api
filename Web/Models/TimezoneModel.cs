using JetBrains.Annotations;

namespace Web.Models
{
    public class TimezoneModel
    {
        [UsedImplicitly]
        public string Id { get; }

        public TimezoneModel(string id)
        {
            Id = id;
        }
    }
}