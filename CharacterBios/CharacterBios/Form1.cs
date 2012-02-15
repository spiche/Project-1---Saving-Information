using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace CharacterBios
{
    public partial class Form1 : Form
    {
        private string lastN = null;
        private DataTable table = new DataTable();


        public Form1()
        {
            InitializeComponent();
        }


        //Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
         
            //saves information to a file by last name
            if (lastN != null)
            {
                if (tbGenInfo.Text.Length > 30 )
                {
                    table.Rows.Add(tbLastName.Text, tbFirstName.Text, tbGenInfo.Text.Substring(0, 30));
                }
                else
                {
                    table.Rows.Add(tbLastName.Text, tbFirstName.Text, tbGenInfo.Text);
                }
                TextWriter tw = new StreamWriter(lastN + ".txt");

                tw.WriteLine(tbLastName.Text);
                tw.WriteLine(tbFirstName.Text);
                tw.Write(tbGenInfo.Text);

                tw.Close();
            }
            else
            {
                MessageBox.Show("Please enter a Last Name");
            }

            lastN = null;

      
        }

        //New Button
        private void btnNew_Click(object sender, EventArgs e)
        {
            lastN = null;
            tbGenInfo.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            table.Columns.Add("Last");
            table.Columns.Add("First");
            table.Columns.Add("Other");
            database.DataSource = table;
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            if (tbLastName.Text != "")
            {
                lastN = tbLastName.Text;
            }
        }


    }


}
