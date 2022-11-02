using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EditableDropDownListTest
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		private bool gridLoaded;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Standard DropDown datasource
				List<ListItem> list = new List<ListItem>();
				list.Add(new ListItem("Hello", "English"));
				list.Add(new ListItem("Kumusta po kayo?", "Tagalog "));
				list.Add(new ListItem("Privet!", "Russian"));
				list.Add(new ListItem("Oi, boas, olá or alô", "Portuguese"));
				list.Add(new ListItem("안녕하세요", "Korean"));
				list.Add(new ListItem("Salut", "French"));
				list.Add(new ListItem("Hallo", "German"));
				list.Add(new ListItem("Aloha", "Hawaiian"));
				list.Add(new ListItem("Xin chào", "Vietnamese"));
				list.Add(new ListItem("Shalom", "Hebrew"));
				list = list.OrderBy(a => a.Text).ToList();
				EditableDropDownList2.DataSource = list;
				EditableDropDownList2.DataTextField = "Text";
				EditableDropDownList2.DataValueField = "Value";
				EditableDropDownList2.DataBind();

				// Custom Datasource
				var type = typeof(System.Web.UI.Control);
				var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
					.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p));
				EditableDropDownList3.DataSource = types;
				EditableDropDownList3.DataTextField = "Name";
				EditableDropDownList3.DataValueField = "FullName";
				EditableDropDownList3.DataBind();
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			LoadGridWithSelections();
		}

		protected void EditableDropDownList_TextChanged(object sender, EventArgs e)
		{
			LoadGridWithSelections();
		}

		private void LoadGridWithSelections()
		{
			// Only do this once
			if (!gridLoaded)
			{
				gridLoaded = true;
				List<object> results = new List<object>();
				results.Add(new { Name = EditableDropDownList1.ID, Text = EditableDropDownList1.Text, Index = EditableDropDownList1.SelectedIndex, Value = EditableDropDownList1.SelectedValue });
				results.Add(new { Name = EditableDropDownList2.ID, Text = EditableDropDownList2.Text, Index = EditableDropDownList2.SelectedIndex, Value = EditableDropDownList2.SelectedValue });
				results.Add(new { Name = EditableDropDownList3.ID, Text = EditableDropDownList3.Text, Index = EditableDropDownList3.SelectedIndex, Value = EditableDropDownList3.SelectedValue });
				grdResults.DataSource = results;
				grdResults.DataBind();
			}
		}

		protected void EditableDropDownList_OnClick(object sender, EventArgs e)
		{
			EditableControls.EditableDropDownList editableList = sender as EditableControls.EditableDropDownList;
			if (editableList != null)
			{
				lblInfo.Text = string.Format("{0} was clicked.", editableList.ID);
			}
		}

	}
}