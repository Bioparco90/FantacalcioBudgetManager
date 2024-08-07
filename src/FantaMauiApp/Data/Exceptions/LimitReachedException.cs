﻿namespace FantaMauiApp.Data.Exceptions
{
    [Serializable]
    internal class LimitReachedException : Exception
    {
        public LimitReachedException()
        {
        }

        public LimitReachedException(string? message) : base(message)
        {
        }

        public LimitReachedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}