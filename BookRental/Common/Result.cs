using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Common
{

    /// <summary>
    /// Stores information about the result of the function operation
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Description { get; set; }

        public Result(bool isSuccess, string description)
        {
            IsSuccess = isSuccess;
            Description = description;
        }
    }
}
