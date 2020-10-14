using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_7_Forms
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random generator = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                numbers.Add(generator.Next(100));
            lstNumbers.DataSource = numbers;

            heroes.Add("SUPERMAN");
            heroes.Add("BATMAN");

            lstHeroes.DataSource = heroes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            for (int i = 0; i < 20; i++)
                numbers.Add(generator.Next(100));
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: New Numbers Generated";
        }

        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: Numbers Sorted";

        }

        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: Heroes Sorted";
        }

        private void lstNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            heroes.Add("SUPERMAN");
            heroes.Add("BATMAN");
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: New heroes Generated";
        }

        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedIndex >= 0)
            {
                numbers.RemoveAt(lstNumbers.SelectedIndex);
                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
                lblStatus.Text = "Status: Number Removed";
            }
            else
            { 
                lblStatus.Text = "Status: No Numbers Left";
            }
            
               
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lstNumbers.SelectedItem != null)
            {
                while (numbers.Contains((Int32)lstNumbers.SelectedItem))
                {
                    numbers.Remove((Int32)lstNumbers.SelectedItem);

                }
                lstNumbers.DataSource = null;
                lstNumbers.DataSource = numbers;
                lblStatus.Text = "Status: Removed Those Values";
            }            
            else
            {
                lblStatus.Text = "Status: No Numbers Left";
            } 
        }

        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            if (heroes.Contains(txtRemoveHero.Text.Trim().ToUpper()))
            {
                heroes.Remove(txtRemoveHero.Text.Trim().ToUpper());
                txtRemoveHero.Clear();
                lstHeroes.DataSource = null;
                lstHeroes.DataSource = heroes;
                lblStatus.Text = "Status: Removed Hero";
            }
            else
            {
                lblStatus.Text = "Status: Error, That is not in the list";
            }
            
        }

        private void btnAddHero_Click(object sender, EventArgs e)
        {
            if (txtAddHero.Text != "")
            {
                if (!heroes.Contains(txtAddHero.Text.Trim().ToUpper()))
                {
                    heroes.Add(txtAddHero.Text.Trim().ToUpper());
                    txtAddHero.Clear();
                    lstHeroes.DataSource = null;
                    lstHeroes.DataSource = heroes;
                    lblStatus.Text = "Status: Added Hero";
                }
                else
                {
                    lblStatus.Text = "Status: Nothing Added";
                }
            }
            else
            {
                lblStatus.Text = "Status: Nothing Added";
            }

        }
    }
}
