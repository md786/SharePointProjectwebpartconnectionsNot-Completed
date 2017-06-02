using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;

namespace SharePointProjectwebpartconnections.providerfuculty
{
    [ToolboxItemAttribute(false)]
    public class providerfuculty : WebPart, IFucultydropdown
    {
        DropDownList dropdown;
        Button button;

        public string fucultylist { get => dropdown.SelectedValue; set => dropdown.SelectedValue=value; }

        protected override void CreateChildControls()
        {
            button = new Button();
            button.Text = "submit";
            button.Click += Button_Click;
            this.Controls.Add(button);
            dropdown = new DropDownList();
            dropdown.AutoPostBack = false;
            this.Controls.Add(dropdown);



        }

        private void Button_Click(object sender, EventArgs e)
        {

            List<Myclass> clas = new List<Myclass>();
            var site = SPContext.Current.Web.Lists["Faculty"].Items;
            foreach (SPListItem item in site)
            {
                dropdown.Items.Add(new ListItem(item["Name"].ToString(), item["Name"].ToString()));
            }

            fucultylist = dropdown.SelectedValue;
        }


        
    
        [ConnectionProvider("prop")]
        public IFucultydropdown Sender()
        {
        return this;
        }
    }
}
