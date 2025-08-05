using InvoiceBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.IManagers
{
    public interface IUserAppManager
    {
        Task<Result<UserDTOAuthenticated>> RegisterAsync(UserDTORegister userDTORegister);
        Task<Result<UserDTOAuthenticated>> LoginWithEmailAsync(UserDTOLoginEmail userDTOLoginEmail);
        Task<Result<UserDTOAuthenticated>> LoginWithUserNameAsync(UserDTOLoginUserName userDTOLoginUserName);
        Task<Result<UserDTOAuthenticated>> LoginWithPhoneNumberAsync(UserDTOLoginPhoneNumber userDTOLoginPhoneNumber);
    }
}
