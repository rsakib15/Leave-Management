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
    public partial class LeaveApp : MetroFramework.Forms.MetroForm
    {
        private string sessionID;

        public LeaveApp(string empid)
        {
            this.sessionID = empid;
       
            InitializeComponent();
            UiInitial();
            LoadInfo();

            LeaveInitialize();
        }

        private void UiInitial()
        {

        }
        public void LeaveInitialize()
        {
            try
            {

                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = new OracleCommand();
                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandText = "SELECT * FROM users WHERE employeeid='" + sessionID + "'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    metroTextBox6.Text = thisReader["name"].ToString();
                    metroTextBox4.Text = thisReader["employeeid"].ToString();
                    metroTextBox1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    metroTextBox5.Text = "Not Applied Yet";
                }

             

                CN.thisConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void  LoadInfo()
        {
            try
            {
           
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = new OracleCommand();
                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandText = "SELECT * FROM users WHERE employeeid='" + sessionID + "'";
                
                OracleDataReader thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    label13.Text = thisReader["name"].ToString();
                    label14.Text = thisReader["type"].ToString();
                    label15.Text = thisReader["join"].ToString();
                    
                }

                OracleCommand timeCommand = new OracleCommand();
                timeCommand.Connection = CN.thisConnection;
                timeCommand.CommandText = "SELECT * FROM dailywork WHERE employeeid='" + sessionID + "'";
                OracleDataReader timeReader = timeCommand.ExecuteReader();
                if (timeReader.Read())
                {
                    int len = Convert.ToInt32(timeReader["LENGTH"])/3600;
                    int min = Convert.ToInt32(timeReader["LENGTH"]) / 60;
                    MessageBox.Show(len.ToString());
                    label6.Text = len.ToString() + " Hours " + min.ToString() + " Minutes ";

                }



                OracleCommand totalCommand = new OracleCommand();
                totalCommand.Connection = CN.thisConnection;
                totalCommand.CommandText = "SELECT SUM(Length) FROM dailywork WHERE employeeid='" + sessionID + "'";
                OracleDataReader totalReader = totalCommand.ExecuteReader();
                if (totalReader.Read())
                {
                    int len = Convert.ToInt32(totalReader["SUM(Length)"]) / 3600;
                    int min = Convert.ToInt32(totalReader["SUM(Length)"]) / 60;
                    MessageBox.Show(len.ToString());
                    label17.Text = len.ToString() + " Hours " + min.ToString() + " Minutes ";

                }


                CN.thisConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 oform = new Form1();
            this.Hide();
            oform.Show();
        }

        private void metroTextBox8_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 oform = new Form1();
            this.Hide();
            oform.Show();
    
        }
    }
}
