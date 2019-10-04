using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedianFilterRESTService.Link
{
    public class Link
    {
        public IEnumerable<int> Data { get; private set; }
        public int WindowSize { get; private set; }

        public Link(IEnumerable<int> data, int windowSize)
        {
            Data = data;
            WindowSize = windowSize;
        }
    }
}