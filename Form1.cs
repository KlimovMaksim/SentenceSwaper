using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] sentence;
        int start, end;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sentence = textBox1.Text.Split(' ');
            sentence = sentence.Where(x => !x.Equals("")).ToArray();
            setResult();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            start = Convert.ToInt32(numericUpDown1.Value);
            if (sentence == null || sentence.Length == 0 ) {
            label1.Text = "Строка пустая";
            }
            else {
            setResult();
            }
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            end = Convert.ToInt32(numericUpDown2.Value);
            if (sentence == null || sentence.Length == 0 ) {
            label1.Text = "Строка пустая";
            }
            else {
            setResult();
            }
        }

        public void setResult()
        {
            string[] edit = new string[sentence.Length];
            sentence.CopyTo(edit, 0);

            if (textBox1.Text.Length != 0)
            {
                if ((start != 0) && (end != 0))
                {
                    if (start <= end)
                    {
                        if (end <= edit.Length)
                        {
                            string temp;
                            for (int i = 0; i < end - start + 1; i++)
                            {
                                temp = edit[edit.Length - i - 1];
                                edit[edit.Length - i - 1] = edit[end - 1 - i];
                                edit[end - 1 - i] = temp;
                            }
                            label1.Text = string.Join(" ", edit);
                        }
                        else label1.Text = "Номер \"до\" не должен выходить за пределы предложения";
                    }
                    else label1.Text = "Номер \"с\" должен быть меньше или равен \"до\"";
                }
                else label1.Text = "Номера \"с\" и \"до\" не могут быть раны 0 или быть его меньше";
            }
            else label1.Text = "Введите предложение";
        }
    }
}
