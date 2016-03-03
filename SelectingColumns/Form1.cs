using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Stimulsoft.Report;

namespace SelectingColumns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            data.ReadXmlSchema("Demo.xsd");
            data.ReadXml("demo.xml");

            StiReport report = new StiReport();
            report.Load("SelectingColumns.mrt");
            report.RegData(data);
            report.Design();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            data.ReadXmlSchema("Demo.xsd");
            data.ReadXml("demo.xml");

            StiReport report = new StiReport();
            report.Load("SelectingColumns.mrt");
            report.RegData(data);
            report.Show();
        }
    }
}