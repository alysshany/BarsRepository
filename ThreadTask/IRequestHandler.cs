namespace ThreadTask
{
    public interface IRequestHandler
    {
        string HandleRequest(string message, string[] arguments);
    }
}