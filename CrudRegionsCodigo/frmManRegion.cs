using Business;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudRegionsCodigo
{
    public partial class frmManRegion : Form
    {
        public frmManRegion()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string message = string.Empty;
                BRegion bRegion = new BRegion();
                Entity.Region region = new Entity.Region { RegionName = txtRegion.Text };
                message=bRegion.Insert(region);
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Error");
            }
           

        }
    }
}
