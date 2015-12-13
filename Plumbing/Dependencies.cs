using Core.Storage;

namespace Plumbing
{
    public class Dependencies
    {
        public IStorage Storage { get; }

        public Dependencies(IStorage storage)
        {
            Storage = storage;
        }
    }
}