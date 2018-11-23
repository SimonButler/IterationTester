using System;
using System.Collections.Generic;
using System.Text;

namespace IterationTester.Models
{
    public class IterationResult
    {
        public int ID { get; set; }
        public int IterationCount { get; set; }
        public string DataType { get; set; }
        public string IterationType { get; set; }
        public long Ticks { get; set; }
    }
}
