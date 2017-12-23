using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Searchors
{
    interface ICodeReverser
    {
        Dictionary<string, string> GetCodeFields(string code);
    }
}
