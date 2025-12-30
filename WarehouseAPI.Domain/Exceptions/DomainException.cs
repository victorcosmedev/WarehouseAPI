using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string error) : base(error)
    {
    }

    public static void When(bool condition, string error)
    {
        if (condition)
        {
            throw new DomainException(error);
        }
    }
}
