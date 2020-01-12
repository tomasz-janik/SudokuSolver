using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTest.Helpers
{
    public interface IMnistReader<T>
    {
        List<T> Read();
    }
}
