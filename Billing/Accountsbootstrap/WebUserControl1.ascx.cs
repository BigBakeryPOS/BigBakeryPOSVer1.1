using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billing.Accountsbootstrap
{
	/// <summary>
	/// Web User Control Example
	/// </summary>
	public partial class WebUserControl1 : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            EditableDropDownList1.Focus();
		}

		public string Text
		{
			get
			{
				return EditableDropDownList1.Text;
			}
			set
			{
				EditableDropDownList1.Text = value;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return EditableDropDownList1.SelectedIndex;
			}
			set
			{
				EditableDropDownList1.SelectedIndex = value;
			}
		}

		public string SelectedValue
		{
			get
			{
				return EditableDropDownList1.SelectedValue;
			}
			set
			{
				EditableDropDownList1.SelectedValue = value;
			}
		}
	}
}