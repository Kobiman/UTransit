using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Data.Contracts
{
    public interface IDataSource
    {
        ITripVoucherRepository Vouchers { get; }
        IStudentRepository Students { get; }
        IUserRepository Users { get; }
        IBusRepository Buses { get; }
        //IStudentTransactionRepository Transactions { get; }
    }
}
