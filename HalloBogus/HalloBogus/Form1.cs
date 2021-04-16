using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HalloBogus
{
    public partial class Form1 : Form
    {
        BindingList<Auto> liste = new BindingList<Auto>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = liste;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime dt)
                e.Value = dt.ToLongDateString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            var faker = new Faker<Auto>("fr");
            faker.UseSeed(7);
            faker.RuleFor(x => x.Hersteller, f => f.Vehicle.Manufacturer());
            faker.RuleFor(x => x.Name, f => f.Person.FullName);
            faker.RuleFor(x => x.Modell, f => f.Vehicle.Model());
            faker.RuleFor(x => x.PS, f => f.Random.Number(10, 1000));
            faker.RuleFor(x => x.Farbe, f => f.Commerce.Color());
            faker.RuleFor(x => x.Baujahr, f => f.Date.Past(5));

            for (int i = 0; i < 100; i++)
            {
                liste.Add(faker.Generate());
            }

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            //dataGridView1.DataSource = liste.Where(x => x.PS > 500).ToList();

            //DateTime.Now.GetKW();

            var query = from auto in liste
                        where auto.Baujahr.DayOfWeek == DayOfWeek.Monday
                        orderby auto.Baujahr.Year, auto.Farbe
                        select auto;

            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = liste.Where(auto => auto.Baujahr.DayOfWeek == DayOfWeek.Monday)
                                            .OrderBy(x => x.Baujahr.Year)
                                            .ThenBy(a => a.Farbe)
                                            .ToList();
        }
    }

    static class DateTimeEx
    {

        public static int GetKW(this DateTime dt)
        {
            return 15;
        }
    }

    public class Auto
    {
        public string Name { get; set; }
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public int PS { get; set; }
        public string Farbe { get; set; }
        public DateTime Baujahr { get; set; }
    }
}
