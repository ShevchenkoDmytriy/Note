using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public string MainText
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem filestram = new ToolStripMenuItem("Файл");
            menuStrip1.Items.Add(filestram);
            ToolStripMenuItem crate = new ToolStripMenuItem("Створити");
            crate.Click+= crate_Click;
            filestram.DropDownItems.Add(crate);
            crate.ShortcutKeys = Keys.Control | Keys.N;
            ToolStripMenuItem open = new ToolStripMenuItem("Відкрити...");
            open.Click += open_Click;
            filestram.DropDownItems.Add(open);
            open.ShortcutKeys = Keys.Control | Keys.O;
            ToolStripMenuItem save = new ToolStripMenuItem("Зберегти");
            save.Click += save_Click;
            filestram.DropDownItems.Add(save);
            save.ShortcutKeys = Keys.Control | Keys.S;
            ToolStripMenuItem saveHow = new ToolStripMenuItem("Зберегти як...");
            saveHow.Click += save_Click;
            filestram.DropDownItems.Add(saveHow);
            ToolStripSeparator separator = new ToolStripSeparator();
            filestram.DropDownItems.Add(separator);
            ToolStripMenuItem paremeters = new ToolStripMenuItem("Параметри сторінки...");
            paremeters.Click += paremeters_Click;
            filestram.DropDownItems.Add(paremeters);
            ToolStripMenuItem print  = new ToolStripMenuItem("Друк");
            print.Click += print_Click;
            filestram.DropDownItems.Add(print);
            print.ShortcutKeys = Keys.Control | Keys.P;
            ToolStripSeparator separator1 = new ToolStripSeparator();
            filestram.DropDownItems.Add(separator1);
            ToolStripMenuItem exit = new ToolStripMenuItem("Вийти");
           exit.Click += exit_Click;
            filestram.DropDownItems.Add(exit);

            ToolStripMenuItem edit = new ToolStripMenuItem("Редагування");
            menuStrip1.Items.Add(edit);
            ToolStripMenuItem cancel = new ToolStripMenuItem("Скасувати");
            edit.DropDownItems.Add(cancel);
            cancel.ShortcutKeys = Keys.Control | Keys.Z;
            ToolStripSeparator separator2 = new ToolStripSeparator();
            edit.DropDownItems.Add(separator2);
            ToolStripMenuItem cut = new ToolStripMenuItem("Вирізати");
            edit.DropDownItems.Add(cut);
            cut.ShortcutKeys = Keys.Control | Keys.X;
            ToolStripMenuItem add = new ToolStripMenuItem("Копіювати");
            edit.DropDownItems.Add(add);
            add.ShortcutKeys = Keys.Control | Keys.C;
            ToolStripMenuItem insert = new ToolStripMenuItem("Вставити");
            edit.DropDownItems.Add(insert);
            insert.ShortcutKeys = Keys.Control | Keys.V;
            ToolStripMenuItem delete = new ToolStripMenuItem("Видалити");
            edit.DropDownItems.Add(delete);
            delete.ShortcutKeys = Keys.Delete;
            ToolStripSeparator separator3 = new ToolStripSeparator();
            edit.DropDownItems.Add(separator3);
            ToolStripMenuItem find = new ToolStripMenuItem("Знайти");
            edit.DropDownItems.Add(find);
            find.ShortcutKeys = Keys.Control|Keys.F;
            ToolStripMenuItem replace = new ToolStripMenuItem("Замінити");
            edit.DropDownItems.Add(replace);
            replace.ShortcutKeys = Keys.Control | Keys.H;
            ToolStripSeparator separator4 = new ToolStripSeparator();
            edit.DropDownItems.Add(separator4);
            ToolStripMenuItem all = new ToolStripMenuItem("Виділити все");
            edit.DropDownItems.Add(all);
            all.ShortcutKeys = Keys.Control | Keys.A;
            ToolStripMenuItem date = new ToolStripMenuItem("Дата й час");
            edit.DropDownItems.Add(date);
            date.ShortcutKeys = Keys.F5;

            ToolStripMenuItem form = new ToolStripMenuItem("Формат");
            menuStrip1.Items.Add(form);
            ToolStripMenuItem world = new ToolStripMenuItem("Перенос по словах") { Checked = true, CheckOnClick = true }; 
            form.DropDownItems.Add(world);
            ToolStripMenuItem world1 = new ToolStripMenuItem("Шрифт..."); 
            form.DropDownItems.Add(world1);

            ToolStripMenuItem form1 = new ToolStripMenuItem("Вигляд");
            menuStrip1.Items.Add(form1);
            ToolStripMenuItem size = new ToolStripMenuItem("Маштаб");
            form1.DropDownItems.Add(size);
            ToolStripMenuItem size1 = new ToolStripMenuItem("Збільшити");
            size1.Click += size_Click;
            size.DropDownItems.Add(size1);
            size1.ShortcutKeys = Keys.Control | Keys.Oemplus;
            ToolStripMenuItem size2 = new ToolStripMenuItem("Зменшити");
            size2.Click += size1_Click;
            size.DropDownItems.Add(size2);
            size2.ShortcutKeys = Keys.Control | Keys.OemMinus;
            ToolStripMenuItem size3 = new ToolStripMenuItem("Відновити маштабування за умовчуванням");
            size3.Click += size2_Click;
            size.DropDownItems.Add(size3);
            size3.ShortcutKeys = Keys.Control | Keys.NumPad0;
            ToolStripMenuItem line = new ToolStripMenuItem("Рядок стану") { Checked = true, CheckOnClick = true };
            form1.DropDownItems.Add(line);

            ToolStripMenuItem about = new ToolStripMenuItem("Довідка");
            menuStrip1.Items.Add(about);
            ToolStripMenuItem revision = new ToolStripMenuItem("Перегляд довідки");
            about.DropDownItems.Add(revision);
            ToolStripSeparator separator5 = new ToolStripSeparator();
            about.DropDownItems.Add(separator5);
            ToolStripMenuItem About = new ToolStripMenuItem("Про програму");
            about.DropDownItems.Add(About);
        }
        private void crate_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\");
        }
        private void open_Click(object sender, EventArgs e)
        {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "(*.txt)|*.txt";
                file.FilterIndex = 1;
                file.RestoreDirectory = true;

                if (file.ShowDialog() == DialogResult.OK)
                {
                MainText = File.ReadAllText(file.FileName, Encoding.Default);
                file.Dispose();
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "(*.txt)|*.txt";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(file.FileName, MainText);
                file.Dispose();
            }

        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void paremeters_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Color : White\n{richTextBox1.Size}");
        }
        private void print_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Принтер не подключен");
        }
        private void size_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
        }
        private void size1_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5);
        }
        private void size2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
        }
        private void about_Click(object sender, EventArgs e)
        {
        }
    }
}
