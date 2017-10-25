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

        public static String GetCombineComponetCode(Object [] objs, int cnt)
        {
            string code = "";
            for (int i = 0; i < cnt; i++)
            {
                if (objs[i] is TextBox) 
                {
                    TextBox tb = (TextBox) objs[i];
                    code = code + tb.Text;
                }

                if (objs[i] is ComboBox)
                {
                    ComboBox cb = (ComboBox)objs[i];
                    code = code + cb.Text;
                }

                if (objs[i] is RadioButton) 
                {
                    RadioButton rdo = (RadioButton)objs[i];
                    if (rdo.Text == "1 通电")
                        code = code + getRadioButtonCode(rdo, "1");
                    if(rdo.Text == "0 断电")
                        code = code + getRadioButtonCode(rdo, "0");
                }
            }
            return code;
        }
    }
}
