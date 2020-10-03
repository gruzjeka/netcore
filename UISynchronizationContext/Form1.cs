using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UISynchronizationContext
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int value = 13;

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);

            value *= 2;

            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int value = 13;

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);

            value *= 2;

            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
