namespace Graph
{
    partial class EdgeDialogue
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
            this.directed = new System.Windows.Forms.RadioButton();
            this.undirected = new System.Windows.Forms.RadioButton();
            this.cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.EdgeChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(55, 2);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(332, 40);
            this.label.TabIndex = 0;
            this.label.Text = "Добавить ребро ";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EdgeChoice
            // 
            this.EdgeChoice.Controls.Add(this.directed);
            this.EdgeChoice.Controls.Add(this.undirected);
            this.EdgeChoice.Location = new System.Drawing.Point(0, 45);
            this.EdgeChoice.Name = "EdgeChoice";
            this.EdgeChoice.Size = new System.Drawing.Size(418, 54);
            this.EdgeChoice.TabIndex = 1;
            this.EdgeChoice.TabStop = false;
            // 
            // directed
            // 
            this.directed.Appearance = System.Windows.Forms.Appearance.Button;
            this.directed.BackColor = System.Drawing.SystemColors.Info;
            this.directed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.directed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directed.Location = new System.Drawing.Point(12, 14);
            this.directed.Name = "directed";
            this.directed.Size = new System.Drawing.Size(197, 34);
            this.directed.TabIndex = 1;
            this.directed.TabStop = true;
            this.directed.Text = "Ориентированное";
            this.directed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.directed.UseVisualStyleBackColor = false;
            // 
            // undirected
            // 
            this.undirected.Appearance = System.Windows.Forms.Appearance.Button;
            this.undirected.BackColor = System.Drawing.SystemColors.Info;
            this.undirected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.undirected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undirected.Location = new System.Drawing.Point(233, 14);
            this.undirected.Name = "undirected";
            this.undirected.Size = new System.Drawing.Size(179, 34);
            this.undirected.TabIndex = 0;
            this.undirected.TabStop = true;
            this.undirected.Text = "Неориентированное";
            this.undirected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.undirected.UseVisualStyleBackColor = false;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(81, 105);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(128, 29);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Ok
            // 
            this.Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ok.Location = new System.Drawing.Point(233, 105);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(128, 29);
            this.Ok.TabIndex = 3;
            this.Ok.Text = "Ок";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // EdgeDialogue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(430, 153);
            this.ControlBox = false;
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.EdgeChoice);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EdgeDialogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление ребра";
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