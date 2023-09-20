using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicQueuingCashier
{
    public partial class CustomerView : Form
    {
        private CashierClass cash;
        public CustomerView()
        {
            InitializeComponent();
            cash = new CashierClass();
            timerTick();
        }

        public void timerTick()
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Contains(CashierClass.getNumberInQueue) && CashierClass.CashierQueue.Count > 0)
            {
                label2.Text = CashierClass.CashierQueue.Peek();
            }
            else
            {
                label2.Text = "P - ";
            }
        }
    }
}
