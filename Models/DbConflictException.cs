public class DbConflictException : Exception
{
    public DbConflictException(string message) : base(message) {}
}