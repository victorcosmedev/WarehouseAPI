using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.Application.DTOs;

public class ProductDTO : CoreDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }


}
