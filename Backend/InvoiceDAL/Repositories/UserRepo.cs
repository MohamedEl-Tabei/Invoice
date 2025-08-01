using InvoiceDAL.Context;
using InvoiceDAL.IRepositories;
using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Repositories
{
    public class UserRepo : Repository<UserApp>, IUserRepo
    {
        public UserRepo(InvoiceContext context) : base(context) { }
    }
}
