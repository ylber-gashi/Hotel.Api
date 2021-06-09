using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Api.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid InsertedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
