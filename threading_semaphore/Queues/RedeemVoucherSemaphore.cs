using threading_semaphore.Interfaces;

namespace threading_semaphore.Queues
{
    public class RedeemVoucherSemaphore : IRedeemVoucherSemaphore
    {
        private static RedeemVoucherSemaphore _instance = null;
        private static readonly object _padlock = new object();
        private readonly Dictionary<string, Semaphore> _semaphores;
        private static readonly int maxCount = 1;

        public RedeemVoucherSemaphore()
        {
            _semaphores = new Dictionary<string, Semaphore>();
        }

        public static RedeemVoucherSemaphore Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RedeemVoucherSemaphore();
                        }
                    }
                }
                return _instance;
            }
        }

        public Semaphore GetSemaphore(string voucherId)
        {
            Semaphore semaphore;
            bool semaphoreCreated = false;

            lock (_semaphores)
            {
                if (!_semaphores.TryGetValue(voucherId, out semaphore))
                {
                    semaphore = new Semaphore(maxCount, maxCount);
                    _semaphores.Add(voucherId, semaphore);
                    semaphoreCreated = true;
                }
            }

            if (!semaphoreCreated)
            {
                //Console.WriteLine("User waiting for redeem voucher {0}.", voucherId);
            }

            semaphore.WaitOne();

            return semaphore;
        }
    }
}
