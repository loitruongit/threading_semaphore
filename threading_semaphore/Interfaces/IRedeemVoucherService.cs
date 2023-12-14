using threading_semaphore.Models.Requests;
using threading_semaphore.Models.Responses;

namespace threading_semaphore.Interfaces
{
    public interface IRedeemVoucherService
    {
        Task<AppResponse<RedeemVoucherResponse>> RedeemVoucherAsync(RedeemVoucherRequest request);
    }
}
