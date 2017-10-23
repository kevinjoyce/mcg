using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class StdFlowNoGenerator:IFlowNoGenerator
    {
        public String getFlowNo() 
        {
            return DateTime.Now.ToFileTimeUtc().ToString();
        }
    }
}
