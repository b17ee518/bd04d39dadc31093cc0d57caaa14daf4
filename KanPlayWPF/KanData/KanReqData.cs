using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanPlayWPF.KanData
{
    public class KanReqData
    {
        public KanReqData() { }

        public void ReadFromString(string strFunc, string reqStr)
        {
            _reqFunc = strFunc;

            _query = System.Web.HttpUtility.ParseQueryString(reqStr);
        }
        public string GetItemAsString(string item)
        {
            return _query[item];
        }

        private string _reqFunc;
        private NameValueCollection _query = null;
    }
}
