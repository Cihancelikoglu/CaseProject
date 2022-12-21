using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.Utilities.Result
{
    public class Result : IResult
    {
        //"Get" read only olduğu için constractor da set edilebilir.

        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
