using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Application.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
