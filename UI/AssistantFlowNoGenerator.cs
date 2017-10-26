using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class AssistantFlowNoGenerator:IFlowNoGenerator
    {
        public String getFlowNo()
        {
            Random ran = new Random();
            return ran.Next(1000, 9999).ToString();
        }
    }
}
