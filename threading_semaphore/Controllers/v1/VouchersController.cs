using Microsoft.AspNetCore.Mvc;
using threading_semaphore.Interfaces;
using threading_semaphore.Models.Requests;
using threading_semaphore.Models.Responses;

namespace threading_semaphore.Controllers.v1
{
    [ApiVersion("1.0")]
    public class VouchersController : ApiControllerBase
    {
        private IRedeemVoucherService _redeemVoucherService;
        public VouchersController(IRedeemVoucherService redeemVoucherService)
        {
            _redeemVoucherService = redeemVoucherService;
        }

        /// <summary>
        /// Redeem voucher async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("redeem/{userId}")]
        public async Task<ActionResult<AppResponse<RedeemVoucherResponse>>> RedeemVoucherAsync(string userId, RedeemVoucherRequest request)
        {
            if (userId != request.UserId)
            {
                return BadRequest();
            }

            Console.Clear();

            Parallel.ForEach(Enumerable.Range(1, 100), _ =>
            {
                _redeemVoucherService.RedeemVoucherAsync(request);
            });

            return Ok();
        }
    }
}
