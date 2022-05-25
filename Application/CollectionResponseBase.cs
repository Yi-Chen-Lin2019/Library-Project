using System;
using System.Collections.Generic;

namespace Application
{
    public class CollectionResponseBase<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
