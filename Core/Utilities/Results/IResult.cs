using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public interface IResult
    {
        public string Message { get; }
        public bool Success { get; }

    }
}
