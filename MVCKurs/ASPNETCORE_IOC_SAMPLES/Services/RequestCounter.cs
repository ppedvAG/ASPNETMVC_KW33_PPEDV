namespace ASPNETCORE_IOC_SAMPLES.Services
{
    public class RequestCounter : IRequestCounter
    {
        public int Counter { get; set; }

        public void IncrementCounter()
        {
            Counter++;
        }
    }
}
