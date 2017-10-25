using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class ElecFlowNoGenerator:IFlowNoGenerator
    {
        public String getFlowNo()
        {
            Random ran = new Random();
            return ran.Next(100000, 999999).ToString();
        }
    }
}
