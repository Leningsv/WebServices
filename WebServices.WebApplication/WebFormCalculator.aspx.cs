using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServices.WebApplication
{
    public partial class WebFormCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReferenceCalculator.WebServiceCalculatorSoapClient wSCalculator = new ServiceReferenceCalculator.WebServiceCalculatorSoapClient();
            Label1.Text= wSCalculator.Add(Convert.ToInt32(TextBox1.Text),Convert.ToInt32(TextBox2.Text)).ToString();
            GridView1.DataSource = wSCalculator.GetCalculations();
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Recents Calculations";
        }
    }
}