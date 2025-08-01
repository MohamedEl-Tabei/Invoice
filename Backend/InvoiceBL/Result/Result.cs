using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Successed { get; set; } = false;
        public List<Error> Errors { get; set; } = new List<Error>();

    }
}
