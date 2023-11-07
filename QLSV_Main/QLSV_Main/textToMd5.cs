using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QLSV_Main
{    
    public class textToMd5
    {
        public static string converText(string text)
        {
            MD5 mD5 = MD5.Create();
            
            byte[] b = Encoding.ASCII.GetBytes(text);
            byte[] hash = mD5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
            {
                sb.Append(a.ToString("x2"));
            }
            string rs = sb.ToString();
            return rs;            
        }
    }
}
