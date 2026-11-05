using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Domain.Entities.BD_EMPLEADO
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public int? Estado { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
