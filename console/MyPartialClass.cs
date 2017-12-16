using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    public partial class MyPartialClass
    {

        partial void Show()
        {
            Console.WriteLine("Hello");
        }

        public void ShowInShow()
        {
            this.Show();
        }
       
    }
}
