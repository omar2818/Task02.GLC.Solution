using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public sealed class EmployeeNotFoundException(int id) : NotFoundException($"Employee with id = {id} is Not Found")
    {
    }
}
