using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Core.Model
{
    public class Response
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public ICollection<string> Message { get; set; } = new List<string>();
    }
}
