namespace Graph
{
    partial class AdjMatrix
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.adj_matrix = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.adj_matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // adj_matrix
            // 
            this.adj_matrix.AllowUserToResizeColumns = false;
            this.adj_matrix.AllowUserToResizeRows = false;
            this.adj_matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adj_matrix.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.adj_matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adj_matrix.Cursor = System.Windows.Forms.Cursors.Default;
            this.adj_matrix.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.adj_matrix.Location = new System.Drawing.Point(1, 0);
            this.adj_matrix.Name = "adj_matrix";
            this.adj_matrix.RowHeadersWidth = 20;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adj_matrix.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.adj_matrix.Size = new System.Drawing.Size(250, 250);
            this.adj_matrix.TabIndex = 0;
            this.adj_matrix.TabStop = false;
            this.adj_matrix.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.adj_matrix_CellBeginEdit);
            this.adj_matrix.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.adj_matrix_CellEndEdit);
            this.adj_matrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.adj_matrix_CellValueChanged);
            this.adj_matrix.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.adj_matrix_RowsAdded);
            this.adj_matrix.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.adj_matrix_RowsRemoved);
            // 
            // confirm
            // 
            this.confirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.confirm.Enabled = false;
            this.confirm.Location = new System.Drawing.Point(134, 256);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(117, 24);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "Ок";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(11, 256);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(117, 24);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // AdjMatrix
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(253, 288);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.adj_matrix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdjMatrix";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Матрица смежности";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adj_matrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView adj_matrix;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}