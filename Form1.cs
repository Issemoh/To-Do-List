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

            if(!string.IsNullOrWhiteSpace(newItem))
            {
                //use contains to check if item is already in items collection 
                if (clsToDo.Items.Contains(newItem))
                {
                    MessageBox.Show("You already added that item", "Error");
                }
                else
                {
                    //USe add to add new item to end of items collection
                    DateTime todoCreated = DateTime.Now;
                    bool urgent = chkUrgent.Checked;

                    // Format the text, date/time createdand urgent into one string 
                    string todoText = $"{newItem} - Created at {todoCreated:g}";
                    if (urgent)
                    {
                        todoText += "URGENT!";
                    }
                    // ADD to the listboxes item
                    clsToDo.Items.Add(todoText);

                    // clear inputs
                    txtNewToDo.Text = "";
                    chkUrgent.Checked = false;
                }
            }
            // no else , just ignore empty input 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // make new list 
            List<string> doneItems = new List<string>();

            foreach (string item in clsToDo.CheckedItems)
            {
                doneItems.Add(item);
            }
            //remove from clsTodo.item
            //add to lstdone.item
            foreach(string item in doneItems)
            {
                clsToDo.Items.Remove(item); //remove by value 
                LstDone.Items.Add(item);
            }

        }

    }
}
