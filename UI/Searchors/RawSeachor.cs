using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Searchors
{
    class RawSeachor:ICodeReverser
    {
        public Dictionary<string, string> GetCodeFields(string code) {
            string[] codeArr = code.Split('.');
            return new Dictionary<string,string>();
        }
    }
}
