using threading_semaphore.Common.Enums;
using threading_semaphore.Interfaces;
using threading_semaphore.Models.Requests;
using threading_semaphore.Models.Responses;

namespace threading_semaphore.Services
{
    public class RedeemVoucherService : IRedeemVoucherService
    {
        public Dictionary<string, VoucherCodeEnum> dicVoucherCode = new Dictionary<string, VoucherCodeEnum>
        {
            {"CODE01", VoucherCodeEnum.AVAILABLE},
            {"CODE02", VoucherCodeEnum.AVAILABLE}
        };

        private readonly IRedeemVoucherSemaphore _redeemVoucherSemaphore;
        public RedeemVoucherService(IRedeemVoucherSemaphore redeemVoucherSemaphore)
        {
            _redeemVoucherSemaphore = redeemVoucherSemaphore;
        }

        public async Task<AppResponse<RedeemVoucherResponse>> RedeemVoucherAsync(RedeemVoucherRequest request)
        {
            Semaphore semaphore = _redeemVoucherSemaphore.GetSemaphore(request.VoucherId);
            try
            {
                var voucherInfo = dicVoucherCode.FirstOrDefault(x => x.Value == VoucherCodeEnum.AVAILABLE);
                if (!string.IsNullOrEmpty(voucherInfo.Key))
                {
                    Console.WriteLine($"Voucher redeemed successfully: {voucherInfo.Key}");
                    dicVoucherCode[voucherInfo.Key] = VoucherCodeEnum.REDEEMED;
                }
                else
                {
                    Console.WriteLine("Voucher sold out!");
                    return AppResponse<RedeemVoucherResponse>.Error("Voucher sold out!");
                }

                var result = new RedeemVoucherResponse
                {
                    UserId = request.UserId,
                    VoucherCode = voucherInfo.Key,
                };

                return AppResponse<RedeemVoucherResponse>.Success(result);
            }
            catch (Exception ex)
            {

                return AppResponse<RedeemVoucherResponse>.Error(ex.Message);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
