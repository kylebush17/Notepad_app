/*
 * Programmer: Kyle Bush
 * Class: CPT_S 321: Evan Olds
 * Date: Feb 2nd, 2017
 * Assignment: Notepad application
 * sources: microsoft MSDN, Evan Olds
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BushKyle_HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //loadText is a function that calls the overridden readtoend function
        private void loadText(TextReader sr)
        {
            string FileText = sr.ReadToEnd();
            textBox1.Text = FileText;   //set textbox text
        }

        //uses SaveFileDialog to save a .txt
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Text Files | *.txt";
            s.DefaultExt = "txt";   //by default save as a .txt
            if (s.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(s.FileName, textBox1.Text); //write to file
            }
        }

        //uses OpenFileDialogues to load in a .txt file
        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if(o.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(o.FileName);   //reads all text from the given file path and sets it to the textbox
            }
        }

        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader F50 = new FibonacciTextReader(50);
            this.loadText(F50);
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader F100 = new FibonacciTextReader(100);
            this.loadText(F100);
        }
    }
}
