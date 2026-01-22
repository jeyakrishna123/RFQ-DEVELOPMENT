using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ.Common
{
    public class CommonDetails
    {
        public void LableProperty(List<Label> lstlable,System.Windows.Forms.Ribbon ribbon)
        {
            foreach (var lable in lstlable)
            {
                lable.BackColor = System.Drawing.Color.Transparent;
                lable.Parent = ribbon;
            }
        }
    }
}
