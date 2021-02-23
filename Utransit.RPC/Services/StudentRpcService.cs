using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utransit.RPC.Protos;
using Utransit.Services.Contracts;

namespace Utransit.RPC.Services
{
    public class StudentRpcService : StudentRpc.StudentRpcBase
    {
        readonly IStudentService _studentService;
        public StudentRpcService(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async override Task AddStudent(IAsyncStreamReader<AddStudentRequest> requestStream, IServerStreamWriter<Response> responseStream, ServerCallContext context)
        {
            await foreach (var m in requestStream.ReadAllAsync())
            {
                var result = _studentService.AddStudent(new UTransit.Models.Student { IndexNumber = m.IndexNumber });
                await responseStream.WriteAsync(new Response { Issuccessful = result.IsSucessful, Message = result.Message });
            }
        }

        public async override Task<Response> BuyVoucher(BuyVoucherRequest request, ServerCallContext context)
        {
           var result = _studentService.BuyVoucher(new UTransit.Models.Requests.BuyVoucherRequest 
            { IndexNumber = request.IndexNumber, VoucherId = request.VoucherId });
            return await Task.FromResult(new Response {  Issuccessful = result.IsSucessful, Message = result.Message });
        }
    }
}
