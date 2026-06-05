using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class CheckESSLAttendance : Form
    {
        public CheckESSLAttendance()
        {
            InitializeComponent();
        }

        private void SQLAttendance_Load(object sender, EventArgs e)
        {
            dtpInDateTime.Format = DateTimePickerFormat.Custom;
            dtpInDateTime.CustomFormat = "MM/dd/yyyy HH:mm";

            dtpOutDateTime.Format = DateTimePickerFormat.Custom;
            dtpOutDateTime.CustomFormat = "MM/dd/yyyy HH:mm";  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnESSLData_Click(object sender, EventArgs e)
        {
            //08/01/2023 - 19:01 
            //09/01/2023 - 07:10 

            //Time
            TimeSpan ts1 = TimeSpan.Parse(Convert.ToString(dtpInDateTime.Value.TimeOfDay)); // new TimeSpan(19, 9, 0);
            TimeSpan ts2 = TimeSpan.Parse(Convert.ToString(dtpOutDateTime.Value.TimeOfDay)); // new TimeSpan(7, 18, 0);

            //Date and Time
            //TimeSpan ts3 = TimeSpan.Parse(Convert.ToString(dtpInDateTime.Value)); // new TimeSpan(19, 9, 0);
            //TimeSpan ts4 = TimeSpan.Parse(Convert.ToString(dtpOutDateTime.Value)); // new TimeSpan(7, 18, 0);


            TimeSpan Duration_TS = dtpOutDateTime.Value.Subtract(dtpInDateTime.Value);
            double HoursCheck = Duration_TS.Hours;

            txtDuration.Text = Duration_TS.ToString();
            txtHours.Text = HoursCheck.ToString();

            
            //TimeSpan ts3 = TimeSpan.Parse(Convert.ToString(objPC.InTime.TimeOfDay)); // new TimeSpan(19, 9, 0);
            TimeSpan result = ts1 - ts2;


        }
    }
}
