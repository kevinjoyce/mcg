using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    class Utility
    {
        public static String getRadioButtonCode(RadioButton rdb, String valueIfChecked) 
        {
            if (rdb.Checked)
            {
                return valueIfChecked;
            }
            else 
            {
                return "";
            }
        }

        public static String getFlowNoCode(IFlowNoGenerator flowNoGenerator)
        {
            return flowNoGenerator.getFlowNo();
        }
    }
}
