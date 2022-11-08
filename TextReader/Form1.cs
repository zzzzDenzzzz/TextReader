using System;
using System.IO;
using System.Windows.Forms;

namespace TextReader
{
    public partial class Form1 : Form
    {
        string path = "";

        public Form1()
        {
            InitializeComponent();
            Text = path;
        }

        void Open()
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                // создали экземпляр установим фильтр для файлов
                open.Filter = "All Files(*.*)|*.*| Text Files(*.txt)|*.txt || ";
                open.FilterIndex = 1; // по умолчанию фильтруются
                                      // текстовые файлы
                if (open.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = File.OpenText(open.FileName))
                    {
                        textBox.Text = reader.ReadToEnd(); // считываем файл до конца
                    }
                }
            }  
        }

        void Save()
        {

        }

        void NewDocument()
        {

        }

        void Copy()
        {

        }

        void Cut()
        {

        }

        void Insert()
        {

        }

        void Cancel()
        {

        }

        void FontColor()
        {

        }

        void BackgroundColor()
        {

        }

        new void Font()
        {

        }

        void SelectAll()
        {

        }

        void SaveAs()
        {

        }

        private void toolStripLabelOpen_Click(object sender, EventArgs e)
        {
            Open();
        }
    }
}
