using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using Utransit.RPC.Protos;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //    //VoucherResponse response = null;
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var buy = new StudentRpc.StudentRpcClient(channel);
            var result = buy.BuyVoucher(new BuyVoucherRequest {  VoucherId = "69d215ad-2f8d-45b9-9cf1-033443b49226", IndexNumber = "rUENR1109" });// c73cf88a-0529-4f21-98e8-0723739af169
            Console.WriteLine(result.Message);
            Console.ReadKey();
        }

        //    var client = new Voucher.VoucherClient(channel);
        //    //Parallel.For(0, 1000, x =>
        //    //{
        //    //    response = client.UpdateVoucher(new UpdateVoucherRequest { VoucherId = "9dfbb537-5d9b-460f-a1ad-309299efe0c7" });
        //    //    Console.WriteLine(response.Message);
        //    //});


        //    using var call = client.UploadVoucher();
        //    for (var i = 0; i < 100000; i++)
        //    {
        //        await call.RequestStream.WriteAsync(new VoucherRequest { Amount = 10, });
        //    }

        //    await call.RequestStream.CompleteAsync();

        //    var response = await call;


        //await call.RequestStream.CompleteAsync();

        //ar response = call;


        //AsyncDuplexStreamingCall<AddStudentRequest, Response> call;
        //Task writeTask, readTask;
        //AddStudent(channel, out call, out writeTask, out readTask);

        //await writeTask;
        //await readTask;
        //private static void AddStudent(GrpcChannel channel, out AsyncDuplexStreamingCall<AddStudentRequest, Response> call, out Task writeTask, out Task readTask)
        //{
        //    var studentService = new StudentRpc.StudentRpcClient(channel);
        //    call = studentService.AddStudent();
        //    writeTask = Task.Run(async () =>
        //    {
        //        for (var i = 0; i < 100000; i++)
        //        {
        //            await call.RequestStream.WriteAsync(new AddStudentRequest { IndexNumber = $"UENR{i}", });
        //        }
        //    });
        //    readTask = Task.Run(async () =>
        //    {
        //        await foreach (var response in call.ResponseStream.ReadAllAsync())
        //        {
        //            Console.WriteLine(response.Message);
        //        }
        //    });
        //}
    }
}
