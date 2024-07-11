namespace FantaMauiApp.Data.Exceptions
{
    [Serializable]
    internal class PlayerExistsException : Exception
    {
        public PlayerExistsException()
        {
        }

        public PlayerExistsException(string? message) : base(message)
        {
        }

        public PlayerExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}