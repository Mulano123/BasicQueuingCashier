using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicQueuingCashier
{
    public partial class CashierWindowQueueForm : Form
    {
        public CashierWindowQueueForm()
        {
            InitializeComponent();
            timerTick();
        }


        public void timerTick()
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
        

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(CashierClass.CashierQueue != null && CashierClass.CashierQueue.Count > 0) 
            { 
                string pop = CashierClass.CashierQueue.Dequeue();

                if (CashierClass.CashierQueue.Count == 0)
                {
                    MessageBox.Show("The queue is now empty!" + "\n" + "Get a number at the Cashier.");

                }
            }
        }
    }
}
