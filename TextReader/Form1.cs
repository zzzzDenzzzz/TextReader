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
            Clipboard.Clear();
            Text = path;
        }

        void Open()
        {
            using (var open = new OpenFileDialog())
            {
                open.Filter = "All Files(*.*)|*.*| Text Files(*.txt)|*.txt";
                open.FilterIndex = 2;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = File.OpenText(open.FileName))
                    {
                        textBox.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        void Save()
        {
            using (var save = new SaveFileDialog())
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(save.FileName))
                    {
                        writer.Write(textBox.Text);
                    }
                }
            }
        }

        void NewDocument()
        {
            var form = new Form1();
            form.Show();
        }

        void Copy()
        {
            if (textBox.SelectedText == "")
            {
                MessageBox.Show("Текст не выделен");
            }
            else
            {
                textBox.Copy();
                MessageBox.Show("Текст скопирован в буфер");
            }
        }

        void Cut()
        {
            if (textBox.SelectedText == "")
            {
                MessageBox.Show("Текст не выделен");
            }
            else
            {
                textBox.Cut();
            }
        }

        void Insert()
        {
            if (Clipboard.ContainsText())
            {
                textBox.Paste();
            }
            else
            {
                MessageBox.Show("Буфер пуст");
            }
        }

        void Cancel()
        {
            textBox.Undo();
        }

        void FontColor()
        {
            using (var fontColor = new ColorDialog())
            {
                if (fontColor.ShowDialog() == DialogResult.OK)
                {
                    textBox.ForeColor = fontColor.Color;
                }
            }
        }

        void BackgroundColor()
        {
            using (var background = new ColorDialog())
            {
                if (background.ShowDialog() == DialogResult.OK)
                {
                    textBox.BackColor = background.Color;
                }
            }
        }

        new void Font()
        {
            using (var font = new FontDialog())
            {
                if (font.ShowDialog() == DialogResult.OK)
                {
                    textBox.Font = font.Font;
                }
            }
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

        private void toolStripLabelSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void toolStripLabelNewDocument_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void toolStripLabelCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void toolStripLabelCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void toolStripLabelInsert_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void toolStripLabelCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void panelFont_Click(object sender, EventArgs e)
        {
            Font();
        }

        private void panelBackgroundColor_Click(object sender, EventArgs e)
        {
            BackgroundColor();
        }

        private void panelFontColor_Click(object sender, EventArgs e)
        {
            FontColor();
        }
    }
}
