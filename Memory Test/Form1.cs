using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Stimulsoft.Report;
using System.Reflection;

namespace MemoryTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			var data = new DataSet();
            data.ReadXmlSchema("..\\..\\..\\Data\\demo.xsd");
            data.ReadXml("..\\..\\..\\Data\\demo.xml");

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MemoryTest.Master-Detail-Subdetail.mrt"))
            {
                report1.RegData(data);
                report1.Load(stream);
                report1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV1;
                report1.Compile();
            }

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MemoryTest.Master-Detail-Subdetail.mrt"))
            {
                report2.RegData(data);
                report2.Load(stream);
                report2.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
                report2.Compile();
            }
		}

		StiReport report1 = new StiReport();
		StiReport report2 = new StiReport();

		private void button1_Click(object sender, EventArgs e)
		{
			report1.Render();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			report2.Render();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			report1.RenderedPages.Clear();
			GC.Collect();
			GC.Collect();
			GC.Collect();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			report2.RenderedPages.Clear();
			GC.Collect();
			GC.Collect();
			GC.Collect();
		}
		
	}
}