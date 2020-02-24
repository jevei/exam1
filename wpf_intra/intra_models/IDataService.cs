using System;
using System.Collections.Generic;
using System.Text;

namespace intra_models
{
    public interface IDataService<T>
    {
        public IEnumerable<T> All { get; }
    }
}
