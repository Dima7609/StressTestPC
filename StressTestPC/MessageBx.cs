using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StressTestPC
{
    public class MessageBx
    {
        public void MessageBoxNew()
        {

            string message = "StressTestYourPC";
            string message2 = "© 2016, Дима Вирич";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message2, message, buttons);
        }
    }
}