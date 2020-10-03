using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDeadlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // UI Synchronization Context blocked here 
            DoSomethingAsync().Wait();
        }

        private async Task DoSomethingAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            // UI Synchronization Context is trying to continue method on the UI thread here but it has already blocked
        }
    }
}
