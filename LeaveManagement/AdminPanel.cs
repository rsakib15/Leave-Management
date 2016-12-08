using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leave
{


    public partial class AdminPanel : MetroFramework.Forms.MetroForm
    {
        private string sessionID;
        private string userType;

        public AdminPanel(string session)

        {
            this.sessionID = session;
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 l = new Form1();
            l.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            LeaveRequest oform = new LeaveRequest(sessionID);
            this.Hide();
            oform.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            WorkerList l = new WorkerList(sessionID);
            l.Show();
            this.Hide();
        }
    }
}
