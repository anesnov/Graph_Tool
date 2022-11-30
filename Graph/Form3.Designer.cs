namespace Graph
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.EdgeChoice = new System.Windows.Forms.GroupBox();
            this.undirected = new System.Windows.Forms.RadioButton();
            this.directed = new System.Windows.Forms.RadioButton();
            this.cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.EdgeChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(1, 2);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(332, 40);
            this.label.TabIndex = 0;
            this.label.Text = "Adding edge ";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EdgeChoice
            // 
            this.EdgeChoice.Controls.Add(this.directed);
            this.EdgeChoice.Controls.Add(this.undirected);
            this.EdgeChoice.Location = new System.Drawing.Point(0, 45);
            this.EdgeChoice.Name = "EdgeChoice";
            this.EdgeChoice.Size = new System.Drawing.Size(332, 54);
            this.EdgeChoice.TabIndex = 1;
            this.EdgeChoice.TabStop = false;
            // 
            // undirected
            // 
            this.undirected.Appearance = System.Windows.Forms.Appearance.Button;
            this.undirected.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.undirected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undirected.Location = new System.Drawing.Point(188, 14);
            this.undirected.Name = "undirected";
            this.undirected.Size = new System.Drawing.Size(133, 34);
            this.undirected.TabIndex = 0;
            this.undirected.TabStop = true;
            this.undirected.Text = "Undirected";
            this.undirected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.undirected.UseVisualStyleBackColor = false;
            // 
            // directed
            // 
            this.directed.Appearance = System.Windows.Forms.Appearance.Button;
            this.directed.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.directed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directed.Location = new System.Drawing.Point(12, 14);
            this.directed.Name = "directed";
            this.directed.Size = new System.Drawing.Size(133, 34);
            this.directed.TabIndex = 1;
            this.directed.TabStop = true;
            this.directed.Text = "Directed";
            this.directed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.directed.UseVisualStyleBackColor = false;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(17, 107);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(128, 29);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Ok
            // 
            this.Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ok.Location = new System.Drawing.Point(188, 107);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(128, 29);
            this.Ok.TabIndex = 3;
            this.Ok.Text = "Confirm";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(333, 141);
            this.ControlBox = false;
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.EdgeChoice);
            this.Controls.Add(this.label);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add edge";
            this.EdgeChoice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox EdgeChoice;
        private System.Windows.Forms.RadioButton directed;
        private System.Windows.Forms.RadioButton undirected;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button Ok;
    }
}