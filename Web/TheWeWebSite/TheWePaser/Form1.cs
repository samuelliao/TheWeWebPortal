﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWeParser.Output;

namespace TheWeParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTypeSelect();
        }


        private void InitializeTypeSelect()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(new Item("Church", "Church"));
            comboBox1.Items.Add(new Item("Dress", "Dress"));
            //comboBox1.Items.Add(new Item("Dress", ""));
        }



        private class Item
        {
            public string Name;
            public string Value;
            public Item(string name, string value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void GetChurchFile()
        {
            ChurchDataParser church = new ChurchDataParser(@"Data Source=60.205.146.133;Initial Catalog=TheWe_C;Persist Security Info=True;User ID=TheWe;Password=!QAZ2wsx#EDC");
            church.FileReader(textBox1.Text);
            bool result;
            result = church.WriteBackChurch(church.GetChurchDbList());
            result = church.WriteBackChurchServiceTime(church.GetChurchServiceTime());
        }

        private void GetDressFile()
        {
            DressDataParser dress = new DressDataParser(@"Data Source=60.205.146.133;Initial Catalog=TheWe_C;Persist Security Info=True;User ID=TheWe;Password=!QAZ2wsx#EDC");
            dress.FileReader(textBox1.Text);
            bool result;
            dress.GetDressDbListAndWrite();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (((Item)comboBox1.SelectedItem).Value == "Church")
            {
                GetChurchFile();
            }
            else if (((Item)comboBox1.SelectedItem).Value == "Dress")
            {
                GetDressFile();
            }
            this.Cursor = Cursors.Arrow;
        }
    }

}
