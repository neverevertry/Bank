using System;

namespace Common.TimeProvider
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
