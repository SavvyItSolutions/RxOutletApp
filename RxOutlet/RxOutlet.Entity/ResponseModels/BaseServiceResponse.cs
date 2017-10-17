using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxOutlet.Entity
{
    public class BaseServiceResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}
