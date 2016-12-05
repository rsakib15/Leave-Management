using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leave
{
    public partial class Approval : MetroFramework.Forms.MetroForm
    {
        string SessionID;
        public Approval(string session)
        {
            InitializeComponent();
            ShowApproval();
            SessionID = session;
        }
        public void RequestApproval(OracleDataReader thisReader)
        {
        
            string s = thisReader["leaveid"].ToString();
            metroLabel1.Text = s;
            MessageBox.Show(s);
        }

        public void showInfo()
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText = "SELECT * FROM leave WHERE status= 'Pending'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    thisCommand.CommandText = "SELECT * FROM leave WHERE status= 'Pending'";
                    RequestApproval(thisReader);
                    
                }
                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        public void ShowApproval()
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText = "SELECT * FROM leave WHERE status= 'Pending'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();
                int count = 0;
                while (thisReader.Read())
                {
                    count++;
                }

                showInfo();
                //MessageBox.Show(count.ToString());
                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
