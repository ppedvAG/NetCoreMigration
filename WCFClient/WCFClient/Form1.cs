using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.BLZServicePortTypeClient(ServiceReference1.BLZServicePortTypeClient.EndpointConfiguration.BLZServiceSOAP12port_http);

            var result =  await client.getBankAsync(textBox1.Text);

            label1.Text = result.bezeichnung;
        }
    }
}
