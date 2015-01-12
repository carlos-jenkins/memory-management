namespace MemoryManagement
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_separator0 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_close = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_about = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.workspace_actions = new System.Windows.Forms.GroupBox();
            this.workspace_tools_report_heapoption = new System.Windows.Forms.CheckBox();
            this.workspace_tools_dispose_label = new System.Windows.Forms.Label();
            this.workspace_tools_general_output = new System.Windows.Forms.TextBox();
            this.workspace_tools_dispose_input = new System.Windows.Forms.TextBox();
            this.workspace_tools_dispose_button = new System.Windows.Forms.Button();
            this.workspace_tools_defragment = new System.Windows.Forms.Button();
            this.workspace_tools_reorganize = new System.Windows.Forms.Button();
            this.workspace_tools_allocate_input_id = new System.Windows.Forms.TextBox();
            this.workspace_tools_allocate_input_size = new System.Windows.Forms.TextBox();
            this.workspace_tools_allocate_label = new System.Windows.Forms.Label();
            this.workspace_tools_report = new System.Windows.Forms.Button();
            this.workspace_tools_allocate_button = new System.Windows.Forms.Button();
            this.workspace_status = new System.Windows.Forms.GroupBox();
            this.workspace_log_output = new System.Windows.Forms.TextBox();
            this.workspace_graphics = new System.Windows.Forms.GroupBox();
            this.workspace_graphics_display = new System.Windows.Forms.PictureBox();
            this.workspace_tools_reorganize_reportoption = new System.Windows.Forms.CheckBox();
            this.workspace_tools_defragment_option1 = new System.Windows.Forms.RadioButton();
            this.workspace_tools_defragment_option2 = new System.Windows.Forms.RadioButton();
            this.workspace_tools_defragment_option3 = new System.Windows.Forms.RadioButton();
            this.workspace_tools_defragment_reportoption = new System.Windows.Forms.CheckBox();
            this.menu.SuspendLayout();
            this.workspace_actions.SuspendLayout();
            this.workspace_status.SuspendLayout();
            this.workspace_graphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspace_graphics_display)).BeginInit();
            this.SuspendLayout();
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file_save,
            this.menu_file_open,
            this.menu_file_separator0,
            this.menu_file_close});
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(35, 20);
            this.menu_file.Text = "File";
            // 
            // menu_file_save
            // 
            this.menu_file_save.Name = "menu_file_save";
            this.menu_file_save.Size = new System.Drawing.Size(152, 22);
            this.menu_file_save.Text = "Save log...";
            this.menu_file_save.Click += new System.EventHandler(this.menu_file_save_Click);
            // 
            // menu_file_open
            // 
            this.menu_file_open.Name = "menu_file_open";
            this.menu_file_open.Size = new System.Drawing.Size(152, 22);
            this.menu_file_open.Text = "Open...";
            this.menu_file_open.Click += new System.EventHandler(this.menu_file_open_click);
            // 
            // menu_file_separator0
            // 
            this.menu_file_separator0.Name = "menu_file_separator0";
            this.menu_file_separator0.Size = new System.Drawing.Size(149, 6);
            // 
            // menu_file_close
            // 
            this.menu_file_close.Name = "menu_file_close";
            this.menu_file_close.Size = new System.Drawing.Size(152, 22);
            this.menu_file_close.Text = "Close";
            this.menu_file_close.Click += new System.EventHandler(this.menu_file_close_Click);
            // 
            // menu_help
            // 
            this.menu_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_help_about});
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(40, 20);
            this.menu_help.Text = "Help";
            // 
            // menu_help_about
            // 
            this.menu_help_about.Name = "menu_help_about";
            this.menu_help_about.Size = new System.Drawing.Size(132, 22);
            this.menu_help_about.Text = "About MN";
            this.menu_help_about.Click += new System.EventHandler(this.menu_help_about_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file,
            this.menu_help});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(792, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // workspace_actions
            // 
            this.workspace_actions.Controls.Add(this.workspace_tools_defragment_reportoption);
            this.workspace_actions.Controls.Add(this.workspace_tools_defragment_option3);
            this.workspace_actions.Controls.Add(this.workspace_tools_defragment_option2);
            this.workspace_actions.Controls.Add(this.workspace_tools_defragment_option1);
            this.workspace_actions.Controls.Add(this.workspace_tools_reorganize_reportoption);
            this.workspace_actions.Controls.Add(this.workspace_tools_report_heapoption);
            this.workspace_actions.Controls.Add(this.workspace_tools_dispose_label);
            this.workspace_actions.Controls.Add(this.workspace_tools_general_output);
            this.workspace_actions.Controls.Add(this.workspace_tools_dispose_input);
            this.workspace_actions.Controls.Add(this.workspace_tools_dispose_button);
            this.workspace_actions.Controls.Add(this.workspace_tools_defragment);
            this.workspace_actions.Controls.Add(this.workspace_tools_reorganize);
            this.workspace_actions.Controls.Add(this.workspace_tools_allocate_input_id);
            this.workspace_actions.Controls.Add(this.workspace_tools_allocate_input_size);
            this.workspace_actions.Controls.Add(this.workspace_tools_allocate_label);
            this.workspace_actions.Controls.Add(this.workspace_tools_report);
            this.workspace_actions.Controls.Add(this.workspace_tools_allocate_button);
            this.workspace_actions.Location = new System.Drawing.Point(8, 32);
            this.workspace_actions.Name = "workspace_actions";
            this.workspace_actions.Size = new System.Drawing.Size(210, 414);
            this.workspace_actions.TabIndex = 18;
            this.workspace_actions.TabStop = false;
            this.workspace_actions.Text = "Tools";
            // 
            // workspace_tools_report_heapoption
            // 
            this.workspace_tools_report_heapoption.AutoSize = true;
            this.workspace_tools_report_heapoption.Enabled = false;
            this.workspace_tools_report_heapoption.Location = new System.Drawing.Point(6, 291);
            this.workspace_tools_report_heapoption.Name = "workspace_tools_report_heapoption";
            this.workspace_tools_report_heapoption.Size = new System.Drawing.Size(133, 17);
            this.workspace_tools_report_heapoption.TabIndex = 13;
            this.workspace_tools_report_heapoption.Text = "Generate heap report?";
            this.workspace_tools_report_heapoption.UseVisualStyleBackColor = true;
            // 
            // workspace_tools_dispose_label
            // 
            this.workspace_tools_dispose_label.AutoSize = true;
            this.workspace_tools_dispose_label.Location = new System.Drawing.Point(6, 59);
            this.workspace_tools_dispose_label.Name = "workspace_tools_dispose_label";
            this.workspace_tools_dispose_label.Size = new System.Drawing.Size(48, 13);
            this.workspace_tools_dispose_label.TabIndex = 13;
            this.workspace_tools_dispose_label.Text = "Block ID";
            // 
            // workspace_tools_general_output
            // 
            this.workspace_tools_general_output.BackColor = System.Drawing.SystemColors.Control;
            this.workspace_tools_general_output.Location = new System.Drawing.Point(6, 314);
            this.workspace_tools_general_output.Multiline = true;
            this.workspace_tools_general_output.Name = "workspace_tools_general_output";
            this.workspace_tools_general_output.ReadOnly = true;
            this.workspace_tools_general_output.Size = new System.Drawing.Size(198, 94);
            this.workspace_tools_general_output.TabIndex = 14;
            this.workspace_tools_general_output.Text = "No definition file loaded.";
            // 
            // workspace_tools_dispose_input
            // 
            this.workspace_tools_dispose_input.Enabled = false;
            this.workspace_tools_dispose_input.Location = new System.Drawing.Point(6, 75);
            this.workspace_tools_dispose_input.Name = "workspace_tools_dispose_input";
            this.workspace_tools_dispose_input.Size = new System.Drawing.Size(86, 20);
            this.workspace_tools_dispose_input.TabIndex = 3;
            this.workspace_tools_dispose_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numerical_KeyPress);
            // 
            // workspace_tools_dispose_button
            // 
            this.workspace_tools_dispose_button.Enabled = false;
            this.workspace_tools_dispose_button.Location = new System.Drawing.Point(107, 75);
            this.workspace_tools_dispose_button.Name = "workspace_tools_dispose_button";
            this.workspace_tools_dispose_button.Size = new System.Drawing.Size(96, 20);
            this.workspace_tools_dispose_button.TabIndex = 4;
            this.workspace_tools_dispose_button.Text = "Dispose";
            this.workspace_tools_dispose_button.UseVisualStyleBackColor = true;
            this.workspace_tools_dispose_button.Click += new System.EventHandler(this.workspace_tools_dispose_button_Click);
            // 
            // workspace_tools_defragment
            // 
            this.workspace_tools_defragment.Enabled = false;
            this.workspace_tools_defragment.Location = new System.Drawing.Point(6, 101);
            this.workspace_tools_defragment.Name = "workspace_tools_defragment";
            this.workspace_tools_defragment.Size = new System.Drawing.Size(198, 26);
            this.workspace_tools_defragment.TabIndex = 5;
            this.workspace_tools_defragment.Text = "Defragment";
            this.workspace_tools_defragment.UseVisualStyleBackColor = true;
            this.workspace_tools_defragment.Click += new System.EventHandler(this.workspace_tools_defragment_Click);
            // 
            // workspace_tools_reorganize
            // 
            this.workspace_tools_reorganize.Enabled = false;
            this.workspace_tools_reorganize.Location = new System.Drawing.Point(6, 204);
            this.workspace_tools_reorganize.Name = "workspace_tools_reorganize";
            this.workspace_tools_reorganize.Size = new System.Drawing.Size(198, 26);
            this.workspace_tools_reorganize.TabIndex = 10;
            this.workspace_tools_reorganize.Text = "Reorganize";
            this.workspace_tools_reorganize.UseVisualStyleBackColor = true;
            this.workspace_tools_reorganize.Click += new System.EventHandler(this.workspace_tools_reorganize_Click);
            // 
            // workspace_tools_allocate_input_id
            // 
            this.workspace_tools_allocate_input_id.Enabled = false;
            this.workspace_tools_allocate_input_id.Location = new System.Drawing.Point(52, 36);
            this.workspace_tools_allocate_input_id.Name = "workspace_tools_allocate_input_id";
            this.workspace_tools_allocate_input_id.Size = new System.Drawing.Size(40, 20);
            this.workspace_tools_allocate_input_id.TabIndex = 1;
            this.workspace_tools_allocate_input_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numerical_KeyPress);
            // 
            // workspace_tools_allocate_input_size
            // 
            this.workspace_tools_allocate_input_size.Enabled = false;
            this.workspace_tools_allocate_input_size.Location = new System.Drawing.Point(6, 36);
            this.workspace_tools_allocate_input_size.Name = "workspace_tools_allocate_input_size";
            this.workspace_tools_allocate_input_size.Size = new System.Drawing.Size(40, 20);
            this.workspace_tools_allocate_input_size.TabIndex = 0;
            this.workspace_tools_allocate_input_size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numerical_KeyPress);
            // 
            // workspace_tools_allocate_label
            // 
            this.workspace_tools_allocate_label.AutoSize = true;
            this.workspace_tools_allocate_label.Location = new System.Drawing.Point(3, 20);
            this.workspace_tools_allocate_label.Name = "workspace_tools_allocate_label";
            this.workspace_tools_allocate_label.Size = new System.Drawing.Size(95, 13);
            this.workspace_tools_allocate_label.TabIndex = 5;
            this.workspace_tools_allocate_label.Text = "Size         Block ID";
            // 
            // workspace_tools_report
            // 
            this.workspace_tools_report.Enabled = false;
            this.workspace_tools_report.Location = new System.Drawing.Point(6, 259);
            this.workspace_tools_report.Name = "workspace_tools_report";
            this.workspace_tools_report.Size = new System.Drawing.Size(198, 26);
            this.workspace_tools_report.TabIndex = 12;
            this.workspace_tools_report.Text = "Generate report";
            this.workspace_tools_report.UseVisualStyleBackColor = true;
            this.workspace_tools_report.Click += new System.EventHandler(this.workspace_tools_report_Click);
            // 
            // workspace_tools_allocate_button
            // 
            this.workspace_tools_allocate_button.Enabled = false;
            this.workspace_tools_allocate_button.Location = new System.Drawing.Point(108, 36);
            this.workspace_tools_allocate_button.Name = "workspace_tools_allocate_button";
            this.workspace_tools_allocate_button.Size = new System.Drawing.Size(96, 20);
            this.workspace_tools_allocate_button.TabIndex = 2;
            this.workspace_tools_allocate_button.Text = "Allocate";
            this.workspace_tools_allocate_button.UseVisualStyleBackColor = true;
            this.workspace_tools_allocate_button.Click += new System.EventHandler(this.workspace_tools_allocate_button_Click);
            // 
            // workspace_status
            // 
            this.workspace_status.Controls.Add(this.workspace_log_output);
            this.workspace_status.Location = new System.Drawing.Point(228, 32);
            this.workspace_status.Name = "workspace_status";
            this.workspace_status.Size = new System.Drawing.Size(552, 414);
            this.workspace_status.TabIndex = 17;
            this.workspace_status.TabStop = false;
            this.workspace_status.Text = "Log";
            // 
            // workspace_log_output
            // 
            this.workspace_log_output.BackColor = System.Drawing.SystemColors.Control;
            this.workspace_log_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspace_log_output.Location = new System.Drawing.Point(3, 16);
            this.workspace_log_output.Multiline = true;
            this.workspace_log_output.Name = "workspace_log_output";
            this.workspace_log_output.ReadOnly = true;
            this.workspace_log_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.workspace_log_output.Size = new System.Drawing.Size(546, 395);
            this.workspace_log_output.TabIndex = 15;
            // 
            // workspace_graphics
            // 
            this.workspace_graphics.Controls.Add(this.workspace_graphics_display);
            this.workspace_graphics.Location = new System.Drawing.Point(8, 452);
            this.workspace_graphics.Name = "workspace_graphics";
            this.workspace_graphics.Size = new System.Drawing.Size(772, 102);
            this.workspace_graphics.TabIndex = 16;
            this.workspace_graphics.TabStop = false;
            this.workspace_graphics.Text = "Memory";
            // 
            // workspace_graphics_display
            // 
            this.workspace_graphics_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspace_graphics_display.Location = new System.Drawing.Point(3, 16);
            this.workspace_graphics_display.Name = "workspace_graphics_display";
            this.workspace_graphics_display.Size = new System.Drawing.Size(766, 83);
            this.workspace_graphics_display.TabIndex = 0;
            this.workspace_graphics_display.TabStop = false;
            // 
            // workspace_tools_reorganize_reportoption
            // 
            this.workspace_tools_reorganize_reportoption.AutoSize = true;
            this.workspace_tools_reorganize_reportoption.Enabled = false;
            this.workspace_tools_reorganize_reportoption.Location = new System.Drawing.Point(6, 236);
            this.workspace_tools_reorganize_reportoption.Name = "workspace_tools_reorganize_reportoption";
            this.workspace_tools_reorganize_reportoption.Size = new System.Drawing.Size(111, 17);
            this.workspace_tools_reorganize_reportoption.TabIndex = 11;
            this.workspace_tools_reorganize_reportoption.Text = "Generate reports?";
            this.workspace_tools_reorganize_reportoption.UseVisualStyleBackColor = true;
            // 
            // workspace_tools_defragment_option1
            // 
            this.workspace_tools_defragment_option1.AutoSize = true;
            this.workspace_tools_defragment_option1.Checked = true;
            this.workspace_tools_defragment_option1.Enabled = false;
            this.workspace_tools_defragment_option1.Location = new System.Drawing.Point(6, 133);
            this.workspace_tools_defragment_option1.Name = "workspace_tools_defragment_option1";
            this.workspace_tools_defragment_option1.Size = new System.Drawing.Size(72, 17);
            this.workspace_tools_defragment_option1.TabIndex = 6;
            this.workspace_tools_defragment_option1.TabStop = true;
            this.workspace_tools_defragment_option1.Text = "High level";
            this.workspace_tools_defragment_option1.UseVisualStyleBackColor = true;
            // 
            // workspace_tools_defragment_option2
            // 
            this.workspace_tools_defragment_option2.AutoSize = true;
            this.workspace_tools_defragment_option2.Enabled = false;
            this.workspace_tools_defragment_option2.Location = new System.Drawing.Point(6, 156);
            this.workspace_tools_defragment_option2.Name = "workspace_tools_defragment_option2";
            this.workspace_tools_defragment_option2.Size = new System.Drawing.Size(59, 17);
            this.workspace_tools_defragment_option2.TabIndex = 7;
            this.workspace_tools_defragment_option2.Text = "System";
            this.workspace_tools_defragment_option2.UseVisualStyleBackColor = true;
            // 
            // workspace_tools_defragment_option3
            // 
            this.workspace_tools_defragment_option3.AutoSize = true;
            this.workspace_tools_defragment_option3.Enabled = false;
            this.workspace_tools_defragment_option3.Location = new System.Drawing.Point(6, 179);
            this.workspace_tools_defragment_option3.Name = "workspace_tools_defragment_option3";
            this.workspace_tools_defragment_option3.Size = new System.Drawing.Size(70, 17);
            this.workspace_tools_defragment_option3.TabIndex = 8;
            this.workspace_tools_defragment_option3.Text = "Low level";
            this.workspace_tools_defragment_option3.UseVisualStyleBackColor = true;
            // 
            // workspace_tools_defragment_reportoption
            // 
            this.workspace_tools_defragment_reportoption.AutoSize = true;
            this.workspace_tools_defragment_reportoption.Enabled = false;
            this.workspace_tools_defragment_reportoption.Location = new System.Drawing.Point(92, 133);
            this.workspace_tools_defragment_reportoption.Name = "workspace_tools_defragment_reportoption";
            this.workspace_tools_defragment_reportoption.Size = new System.Drawing.Size(111, 17);
            this.workspace_tools_defragment_reportoption.TabIndex = 9;
            this.workspace_tools_defragment_reportoption.Text = "Generate reports?";
            this.workspace_tools_defragment_reportoption.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.workspace_graphics);
            this.Controls.Add(this.workspace_status);
            this.Controls.Add(this.workspace_actions);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Management";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.workspace_actions.ResumeLayout(false);
            this.workspace_actions.PerformLayout();
            this.workspace_status.ResumeLayout(false);
            this.workspace_status.PerformLayout();
            this.workspace_graphics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workspace_graphics_display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menu_file;
        private System.Windows.Forms.ToolStripMenuItem menu_file_open;
        private System.Windows.Forms.ToolStripSeparator menu_file_separator0;
        private System.Windows.Forms.ToolStripMenuItem menu_file_close;
        private System.Windows.Forms.ToolStripMenuItem menu_help;
        private System.Windows.Forms.ToolStripMenuItem menu_help_about;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.GroupBox workspace_actions;
        private System.Windows.Forms.GroupBox workspace_status;
        private System.Windows.Forms.GroupBox workspace_graphics;
        private System.Windows.Forms.ToolStripMenuItem menu_file_save;
        private System.Windows.Forms.Button workspace_tools_report;
        private System.Windows.Forms.Button workspace_tools_allocate_button;
        private System.Windows.Forms.Label workspace_tools_allocate_label;
        private System.Windows.Forms.TextBox workspace_tools_allocate_input_id;
        private System.Windows.Forms.TextBox workspace_tools_allocate_input_size;
        private System.Windows.Forms.TextBox workspace_log_output;
        private System.Windows.Forms.Button workspace_tools_dispose_button;
        private System.Windows.Forms.Button workspace_tools_defragment;
        private System.Windows.Forms.Button workspace_tools_reorganize;
        private System.Windows.Forms.TextBox workspace_tools_dispose_input;
        private System.Windows.Forms.TextBox workspace_tools_general_output;
        private System.Windows.Forms.Label workspace_tools_dispose_label;
        private System.Windows.Forms.PictureBox workspace_graphics_display;
        private System.Windows.Forms.CheckBox workspace_tools_report_heapoption;
        private System.Windows.Forms.RadioButton workspace_tools_defragment_option3;
        private System.Windows.Forms.RadioButton workspace_tools_defragment_option2;
        private System.Windows.Forms.RadioButton workspace_tools_defragment_option1;
        private System.Windows.Forms.CheckBox workspace_tools_reorganize_reportoption;
        private System.Windows.Forms.CheckBox workspace_tools_defragment_reportoption;

    }
}

