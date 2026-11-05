using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Commons.Bases.Response
{
    public class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}
