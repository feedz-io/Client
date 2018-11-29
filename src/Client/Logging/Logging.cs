namespace Feedz.Client
{
    public interface IFeedzLogger
    {
        void Info(string message);
        void Error(string message);
    }
}