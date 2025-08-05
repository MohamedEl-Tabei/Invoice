using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.IRepositories
{
    public interface IUserRepo :IRepository<UserApp>
    {
        public Task<UserApp> FindByPhoneNumberAsync(string phoneNumber);

    }
}
