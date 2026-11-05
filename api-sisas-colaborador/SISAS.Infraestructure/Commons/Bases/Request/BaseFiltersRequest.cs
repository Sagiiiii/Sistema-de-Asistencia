using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Commons.Bases.Request
{
    public class BaseFiltersRequest : BasePaginationRequest
    {
        public int? NumFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
        public int? StateFilter { get; set; } = null;
        public string? StartDate { get; set; } = null;
        public string? EndDate { get; set; } = null;
        
    }
}
