using Application.Interfaces;
using System;

namespace Application.Services
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
