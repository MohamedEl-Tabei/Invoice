using InvoiceBL.DTOs;
using InvoiceDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.IManagers
{
    public interface ITokenManger
    {
        public string CreateToken(TokenDTOConfigurations tokenDTOConfigurations);
    }
}
