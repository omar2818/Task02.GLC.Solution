using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryDto>> GetAllSalariesAsync();
    }
}
