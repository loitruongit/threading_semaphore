using threading_semaphore.Queues;

namespace threading_semaphore.Interfaces
{
    public interface IRedeemVoucherSemaphore
    {
        static RedeemVoucherSemaphore Instance;

        public Semaphore GetSemaphore(string voucherId);
    }
}
