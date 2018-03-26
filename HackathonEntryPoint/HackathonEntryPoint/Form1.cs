using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackathonEntryPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webbyDisplay.ScriptErrorsSuppressed = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            webbyDisplay.Url = new Uri("http://" + searchBox.Text);
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            webbyDisplay.GoForward();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            webbyDisplay.GoBack();
        }
    }
}
