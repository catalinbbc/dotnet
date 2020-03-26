using System;

namespace iClockEx
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }
}
