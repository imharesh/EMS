using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace employee.HRS
{
    public class HRAlreadyExistsException : BusinessException
    {
        public HRAlreadyExistsException(string name)
       : base(employeeDomainErrorCodes.HRAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
