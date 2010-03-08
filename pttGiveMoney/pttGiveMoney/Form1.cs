using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace pttGiveMoney
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            string[] source_string = textBox1.Lines;
            if (textBox1.Lines[textBox1.Lines.Length - 1].StartsWith("分析截取完畢!"))
            {
                return;
            }
            Hashtable hs = new Hashtable();
            foreach (string pushline in source_string)
            {
                try
                {
                    string account = pushline.Split(new string[] { " [33m", " [m" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    hs.Add(account, account);
                }
                catch
                {
                }
            }
            string accountlist = "";
            int count_account = 0;
            foreach (string account in hs.Keys)
            {
                accountlist += account + Environment.NewLine;
                count_account++;
            }
            textBox1.Text = accountlist + "分析截取完畢! 共:" + count_account + "人";
        }
        //全選
        private void textBox_SelectAll(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
