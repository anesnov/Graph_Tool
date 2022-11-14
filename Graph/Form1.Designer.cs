namespace Graph
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.move = new System.Windows.Forms.RadioButton();
            this.remove = new System.Windows.Forms.RadioButton();
            this.AddE = new System.Windows.Forms.RadioButton();
            this.AddV = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjacencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.move);
            this.groupBox1.Controls.Add(this.remove);
            this.groupBox1.Controls.Add(this.AddE);
            this.groupBox1.Controls.Add(this.AddV);
            this.groupBox1.Location = new System.Drawing.Point(548, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 404);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // move
            // 
            this.move.Appearance = System.Windows.Forms.Appearance.Button;
            this.move.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.move.Location = new System.Drawing.Point(6, 119);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(228, 35);
            this.move.TabIndex = 4;
            this.move.TabStop = true;
            this.move.Text = "Move";
            this.move.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.move.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Appearance = System.Windows.Forms.Appearance.Button;
            this.remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remove.Location = new System.Drawing.Point(6, 169);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(228, 35);
            this.remove.TabIndex = 3;
            this.remove.TabStop = true;
            this.remove.Text = "Remove Element";
            this.remove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remove.UseVisualStyleBackColor = true;
            // 
            // AddE
            // 
            this.AddE.Appearance = System.Windows.Forms.Appearance.Button;
            this.AddE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddE.Location = new System.Drawing.Point(6, 69);
            this.AddE.Name = "AddE";
            this.AddE.Size = new System.Drawing.Size(228, 35);
            this.AddE.TabIndex = 2;
            this.AddE.TabStop = true;
            this.AddE.Text = "Add Edge";
            this.AddE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddE.UseVisualStyleBackColor = true;
            // 
            // AddV
            // 
            this.AddV.Appearance = System.Windows.Forms.Appearance.Button;
            this.AddV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddV.Location = new System.Drawing.Point(6, 18);
            this.AddV.Name = "AddV";
            this.AddV.Size = new System.Drawing.Size(228, 35);
            this.AddV.TabIndex = 1;
            this.AddV.TabStop = true;
            this.AddV.Text = "Add Vertex";
            this.AddV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AddV.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 411);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.matrixesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.sToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // matrixesToolStripMenuItem
            // 
            this.matrixesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjacencyToolStripMenuItem,
            this.incidenceToolStripMenuItem});
            this.matrixesToolStripMenuItem.Name = "matrixesToolStripMenuItem";
            this.matrixesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.matrixesToolStripMenuItem.Text = "Matrixes";
            // 
            // adjacencyToolStripMenuItem
            // 
            this.adjacencyToolStripMenuItem.Name = "adjacencyToolStripMenuItem";
            this.adjacencyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adjacencyToolStripMenuItem.Text = "Adjacency";
            this.adjacencyToolStripMenuItem.Click += new System.EventHandler(this.adjacencyToolStripMenuItem_Click);
            // 
            // incidenceToolStripMenuItem
            // 
            this.incidenceToolStripMenuItem.Name = "incidenceToolStripMenuItem";
            this.incidenceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.incidenceToolStripMenuItem.Text = "Incidence";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutCreatorToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutCreatorToolStripMenuItem
            // 
            this.aboutCreatorToolStripMenuItem.Name = "aboutCreatorToolStripMenuItem";
            this.aboutCreatorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutCreatorToolStripMenuItem.Text = "About creator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Graph Tool";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutCreatorToolStripMenuItem;
        private System.Windows.Forms.RadioButton move;
        private System.Windows.Forms.RadioButton remove;
        private System.Windows.Forms.RadioButton AddE;
        private System.Windows.Forms.RadioButton AddV;
        private System.Windows.Forms.ToolStripMenuItem matrixesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjacencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidenceToolStripMenuItem;
    }
}

