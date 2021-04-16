using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HalloGoogleBooks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}";

            var web = new WebClient();
            var json = web.DownloadString(url);

            textBox2.Text = json;

            BooksResult result = JsonConvert.DeserializeObject<BooksResult>(json);

            dataGridView1.DataSource = result.items.Select(x => x.volumeInfo).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is List<Volumeinfo> data)
            {
                using var sw = new StreamWriter("Books.xml");

                var serial = new XmlSerializer(typeof(List<Volumeinfo>));

                serial.Serialize(sw, data);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using var sr = new StreamReader("Books.xml");

            var serial = new XmlSerializer(typeof(List<Volumeinfo>));

            dataGridView1.DataSource = serial.Deserialize(sr);
        }
    }
}
