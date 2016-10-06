using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace todolist2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateList();
            }
        }

        protected void ToDoListBoxes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ToDoListBoxes.Items.Count; i++)
            {
                if (ToDoListBoxes.Items[i].Selected)
                {
                    ToDoSQLDataContext db = new ToDoSQLDataContext();

                    ToDo SelectedItem = db.ToDos.Where(p =>
                    p.ToDoID == Convert.ToInt32(ToDoListBoxes.Items[i].Value)).FirstOrDefault();

                    db.ToDos.DeleteOnSubmit(SelectedItem);
                    db.SubmitChanges();
                    PopulateList();
                }
            }
        }

        protected void CreateToDo_OnClick(object sender, EventArgs e)
        {
            ToDoSQLDataContext db = new ToDoSQLDataContext();
            ToDo CurrentToDo = new ToDo
            {
                dt = DateTime.Now,
                Name = ToDoName.Text
            };

            db.ToDos.InsertOnSubmit(CurrentToDo);
            db.SubmitChanges();
            PopulateList();

                    
        }
        



        private void PopulateList()
        {
            ToDoSQLDataContext db = new ToDoSQLDataContext();

            ToDoListBoxes.DataSource = db.ToDos;
            ToDoListBoxes.DataValueField = "ToDoID";
            ToDoListBoxes.DataTextField = "Name";

            ToDoListBoxes.DataBind();
        }
    }
}