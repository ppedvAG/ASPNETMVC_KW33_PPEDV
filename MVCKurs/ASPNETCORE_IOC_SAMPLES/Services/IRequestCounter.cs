namespace ASPNETCORE_IOC_SAMPLES.Services
{
    public interface IRequestCounter
    {
        int Counter { get; set; }

        void IncrementCounter();
    }
}
