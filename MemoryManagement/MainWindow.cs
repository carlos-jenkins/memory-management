using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoryManagement
{
    public partial class MainWindow : Form
    {
        private Memory memory = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Log("Memory simulation program initiated.");
        }

        private void Log(string message)
        {
            DateTime eventTime = DateTime.Now;
            this.workspace_log_output.AppendText(
                eventTime.ToShortDateString() + " " +
                eventTime.ToShortTimeString() + " " +
                message +
                System.Environment.NewLine);
        }

        private void UpdateGraphics()
        {
            float memoryUnit = ((float)this.workspace_graphics_display.Size.Width / (float)memory.TotalMemory);

            int width = this.workspace_graphics_display.Size.Width;
            int height = this.workspace_graphics_display.Size.Height;

            System.Drawing.Bitmap graphicMemory = new Bitmap(width, height);
            System.Drawing.Graphics bufferGraphics = Graphics.FromImage(graphicMemory);

            float x;

            x = 0;
            memory.PhysicalMemory.ForEach(delegate(Block block)
            {
                if (block.InUse)
                {
                    bufferGraphics.FillRectangle(System.Drawing.Brushes.Red, x, 0, (x + (block.Size * memoryUnit)), height);
                }
                else
                {
                    bufferGraphics.FillRectangle(System.Drawing.Brushes.White, x, 0, (x + (block.Size * memoryUnit)), height);
                }
                x += (block.Size * memoryUnit);
            });

            x = 0;
            memory.PhysicalMemory.ForEach(delegate(Block block)
            {
                bufferGraphics.DrawLine(System.Drawing.Pens.Black, new PointF(x, 0), new PointF(x, height));
                x += (block.Size * memoryUnit);
                //Log(x + "");
            });

            this.workspace_graphics_display.Image = graphicMemory;

        }

        private void UpdateStatus()
        {
            this.workspace_tools_general_output.Text = 
                "Total memory: " + memory.TotalMemory +
                System.Environment.NewLine +
                "Free memory: " + memory.FreeMemory +
                System.Environment.NewLine +
                (int)(100.0 - (((float)memory.FreeMemory / (float)memory.TotalMemory) * 100.0)) + "% memory used." +
                System.Environment.NewLine +
                "Total blocks: " + memory.PhysicalMemory.Count;
        }

        private void EnableTools()
        {
            this.workspace_tools_allocate_input_size.Enabled = true;
            this.workspace_tools_allocate_input_id.Enabled = true;
            this.workspace_tools_allocate_button.Enabled = true;
            this.workspace_tools_dispose_input.Enabled = true;
            this.workspace_tools_dispose_button.Enabled = true;
            this.workspace_tools_defragment.Enabled = true;
            this.workspace_tools_defragment_option1.Enabled = true;
            this.workspace_tools_defragment_option2.Enabled = true;
            this.workspace_tools_defragment_option3.Enabled = true;
            this.workspace_tools_defragment_reportoption.Enabled = true;

            this.workspace_tools_reorganize.Enabled = true;
            this.workspace_tools_reorganize_reportoption.Enabled = true;

            this.workspace_tools_report.Enabled = true;
            this.workspace_tools_report_heapoption.Enabled = true;

            this.workspace_tools_allocate_input_size.Focus();
        }

        private void ClearInputs()
        {
            this.workspace_tools_allocate_input_size.Clear();
            this.workspace_tools_allocate_input_id.Clear();
            this.workspace_tools_dispose_input.Clear();
        }

        private void menu_file_save_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = dialog.FileName;
                if (!fileName.EndsWith(".txt"))
                    fileName += ".txt";

                System.IO.StreamWriter write = System.IO.File.CreateText(fileName);
                write.WriteLine(this.workspace_log_output.Text);
                write.Close();
            }

            dialog.Dispose();
        }

        private void menu_file_open_click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Title = "Open memory definiton file";
            dialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {

                this.Log("Opening memory definition file " + dialog.FileName);

                System.IO.StreamReader Reader = new System.IO.StreamReader(dialog.OpenFile());

                Memory newProgramData = new Memory();
                if (newProgramData.Load(Reader))
                {
                    Reader.Close();

                    memory = newProgramData;

                    this.UpdateGraphics();
                    this.UpdateStatus();
                    this.EnableTools();

                    this.Text = "Memory Management - " + dialog.FileName;

                    string message = "Definition file succefully loaded, a total of " +
                        memory.Blocks +
                        " blocks were created.";

                    this.Log(message);
                    System.Windows.Forms.MessageBox.Show(this,
                        message,
                        "Success!");
                }
                else
                {

                    string message = "Invalid data file, posible causes:" +
                        System.Environment.NewLine +
                        "\t- No total memory is defined." +
                        System.Environment.NewLine +
                        "\t- A non number character is present in the memory definition file." +
                        System.Environment.NewLine +
                        "\t- No two column organization.";
                    
                    this.Log(message);
                    System.Windows.Forms.MessageBox.Show(this,
                        message,
                        "Error!");
                }
            }

            dialog.Dispose();
        }

        private void menu_file_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_help_about_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(this,
                "Memory Management created by Erick Rojas and Carlos Jenkins" +
                System.Environment.NewLine +
                "Algorythm and data structures 2 - 2008" +
                System.Environment.NewLine +
                "Code released under GPL",
                "About Memory Management");
        }

        private void numerical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (Char.IsControl(e.KeyChar))))
                e.Handled = true;
        }

        private void workspace_tools_allocate_button_Click(object sender, EventArgs e)
        {
            try
            {
                int size = int.Parse(this.workspace_tools_allocate_input_size.Text);
                int id = int.Parse(this.workspace_tools_allocate_input_id.Text);

                if (!memory.ExistsId(id))
                {
                    if (size <= memory.FreeMemory)
                    {
                        bool succefullAllocation = memory.Allocate(size, id);

                        if (succefullAllocation)
                        {
                            string message = String.Format("Successfully allocated block of {0} bytes. ID = {1}.", size, id);
                            this.Log(message);
                            ClearInputs();
                            UpdateGraphics();
                            UpdateStatus();
                        }
                        else
                        {
                            string message = String.Format("You have run out of available memory for blocks of {0}.", size);
                            this.Log(message);
                            System.Windows.Forms.MessageBox.Show(this,
                                message,
                                "Error!");
                        }
                    }
                    else
                    {
                        string message = String.Format("Imposible to allocate {0} bytes, only {1} bytes of free memory are avalaible.", size, memory.FreeMemory);
                        //this.Log(message);
                        System.Windows.Forms.MessageBox.Show(this,
                            message,
                            "Error!");
                    }
                }
                else
                {
                    string message = String.Format("A block with the ID \"{0}\" already exists, please choose another id.", id);
                    //this.Log(message);
                    System.Windows.Forms.MessageBox.Show(this,
                        message,
                        "Error!");
                }
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show(this,
                        "Please fill out all required fields.",
                        "Error!");
            }
        }

        private void workspace_tools_dispose_button_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.workspace_tools_dispose_input.Text);

                bool disposed = memory.Dispose(id);

                if (disposed)
                {
                    string message = String.Format("Successfully disposed block ID = {0}.", id);
                    this.Log(message);
                    ClearInputs();
                    UpdateGraphics();
                    UpdateStatus();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(this,
                        String.Format("The block with ID \"{0}\" doesn't exists, please choose a valid ID.", id),
                        "Error!");
                }
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show(this,
                        "Please fill out all required fields.",
                        "Error!");
            }
        }

        private void workspace_tools_defragment_Click(object sender, EventArgs e)
        {
            bool generatereport = this.workspace_tools_defragment_reportoption.Checked;
            if (generatereport)
            {
                this.Log(memory.GenerateReport(false));
            }

            byte option;
            string[] options = {"High Level", "System", "Low Level"};
            if (this.workspace_tools_defragment_option1.Checked)
            {
                memory.DefragmentHighLevel();
                option = 0;
            }
            else if (this.workspace_tools_defragment_option2.Checked)
            {
                memory.DefragmentSystem();
                option = 1;
            }
            else
            {
                memory.DefragmentLowLevel();
                option = 2;
            }

            UpdateGraphics();

            this.Log(String.Format("Memory succefully defragmented. Method used: {0}.", options[option]));
            
            if (generatereport)
            {
                this.Log(memory.GenerateReport(false));
            }

        }

        private void workspace_tools_reorganize_Click(object sender, EventArgs e)
        {
            bool generatereport = this.workspace_tools_reorganize_reportoption.Checked;
            if (generatereport)
            {
                this.Log(memory.GenerateReport(false));
            }

            if (memory.Reorganize())
            {
                this.Log(String.Format("Memory succefully reorganized. A total of {0} blocks are now avalaible.", memory.PhysicalMemory.Count));
                UpdateGraphics();
            }
            else
            {
                string message = "No allocations has been made, unable to reorganize memory";
                System.Windows.Forms.MessageBox.Show(this,
                    message,
                    "Error!");
            }

            if (generatereport)
            {
                this.Log(memory.GenerateReport(false));
            }
        }

        private void workspace_tools_report_Click(object sender, EventArgs e)
        {
            bool includeHead = this.workspace_tools_report_heapoption.Checked;
            this.Log(memory.GenerateReport(includeHead));
        }
    }
}
