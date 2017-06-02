using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SharePointProjectwebpartconnections.ConsumerCourses
{
    [ToolboxItemAttribute(false)]
    public class ConsumerCourses : WebPart
    {
        IFucultydropdown _ifuculty;
        Label l;
        protected override void CreateChildControls()
        {
            l = new Label();


            string str = "";
            var site = SPContext.Current.Web.Lists["courseslist"].Items;

            foreach (SPListItem fac in site)
            {
                if (_ifuculty == null)
                    str += "Factulty:" + "  " + fac["Title"].ToString() + " - <br>";
                else if (fac["faculty"].ToString().Contains(_ifuculty.fucultylist))
                    str += "Factulty:" + "  " +(int) fac["Fees"] + "<br>";
            }




            l.Text = str;
            this.Controls.Add(l);
        }
       
        [ConnectionConsumer("prop")]
        public void reciever(IFucultydropdown fuculty)
        {
            _ifuculty = fuculty;
        }
    }
}
