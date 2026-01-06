using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Domain.Entities
{
    public abstract class CoreEntity
    {
        public int Id { get; private set; }
        public Guid ExternalId { get; private set; }

        protected abstract void EnsureValidState();
    }
}
