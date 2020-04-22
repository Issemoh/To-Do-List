
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    class ToDo
    {
        public ToDo(string text, bool urgent)
        {
            Text = text;  // set the text property
            Urgent = urgent;  // set the urgent property
        }
        // A property, text. c# creates a text field to store
        public string Text { get; set; }

        // Another auto property, C# creates an urgent field

        public bool Urgent { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // A method that can be called for any Todo object

        public override string ToString()
        {
            string displayText = $"{Text} - Created on {DateCreated:f}";
            if (Urgent)
            {
                displayText += " URGENT!!";
            }
            return displayText;
        }
    }
}
