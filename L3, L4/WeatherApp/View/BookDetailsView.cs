using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;
using WeatherApp.ViewModel;
using WeatherApp.Model;
using WeatherApp.Controllers;

namespace WeatherApp.View
{
    public partial class BookDetailsView : Form
    {
        public BookDetailsView()
        {
            Form form = new Form1();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void InitializeComponent()
        {

        }

        private void BookDetailsView_Load(object sender, EventArgs e)
        {
        }
    }
}
