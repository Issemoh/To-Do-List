using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddToDo_Click(object sender, EventArgs e)
        {
            //Remove any spaces 
            string newItem = txtNewToDo.Text.Trim();
            bool urgent = chkUrgent.Checked;

            if(!string.IsNullOrWhiteSpace(newItem))
            {
                ToDo toDoItem = new ToDo(newItem, urgent);

                if (!TodoItemInlist(toDoItem))
                {
                    clsToDo.Items.Add(toDoItem);
                    txtNewToDo.Text = "";  //Clear
                }
                else
                {
                    MessageBox.Show("You already added that", "Duplicate");
                }
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool TodoItemInlist(ToDo toDoItem)
        {
            foreach (ToDo ListItem in clsToDo.Items)
            {
                if (toDoItem.Text.ToUpper() == ListItem.Text.ToUpper())
                {
                    return true; // This List item has the same text as toDoItem
                }
            }
            return false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // make new list 
            List<ToDo> doneItems = new List<ToDo>();

            foreach (ToDo item in clsToDo.CheckedItems)
            {
                doneItems.Add(item);
            }
            //remove from clsTodo.item
            //add to lstdone.item
            foreach(ToDo item in doneItems)
            {
                clsToDo.Items.Remove(item); //remove by value 
                LstDone.Items.Add(item);
            }

        }

    }
}
