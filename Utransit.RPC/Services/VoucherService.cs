using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utransit.RPC.Protos;
using Utransit.Services.Contracts;
using UTransit.Models;

namespace Utransit.RPC.Services
{
    public class VoucherService : Voucher.VoucherBase
    {
        private readonly ITripVoucherService _tripVoucherService;
        public VoucherService(ITripVoucherService tripVoucherService)
        {
            _tripVoucherService = tripVoucherService;
        }

        public override Task<VoucherResponse> UpdateVoucher(UpdateVoucherRequest request, ServerCallContext context)
        {
            var result = _tripVoucherService.UpdateVoucher(request.VoucherId);
           return Task.FromResult(new VoucherResponse { Issuccessful = result.IsSucessful, Message = result.Message });
        }

        public async override Task<VoucherResponse> UploadVoucher(IAsyncStreamReader<VoucherRequest> requestStream, ServerCallContext context)
        {
            VoucherResponse response = new VoucherResponse { Message = "Operation Successful" };
            await foreach (var m in requestStream.ReadAllAsync())
            {
                _tripVoucherService.UploadVoucher(new TripVoucher 
                   {
                     Amount = m.Amount,
                   });
            }
            return response;
        }
    }
}
