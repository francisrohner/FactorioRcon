namespace FactorioRcon.UserControls
{
    partial class UC_InsertCommand
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblItem = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TrackBar();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.pbItem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblItem.Location = new System.Drawing.Point(3, 18);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(42, 16);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item:";
            // 
            // cmbItem
            // 
            this.cmbItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(64, 15);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(439, 24);
            this.cmbItem.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(3, 59);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(54, 16);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Count:";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(63, 59);
            this.tbAmount.Maximum = 10000;
            this.tbAmount.Minimum = 1;
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(363, 45);
            this.tbAmount.SmallChange = 5;
            this.tbAmount.TabIndex = 4;
            this.tbAmount.TickFrequency = 150;
            this.tbAmount.Value = 100;
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(432, 59);
            this.nudCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(91, 23);
            this.nudCount.TabIndex = 5;
            this.nudCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pbItem
            // 
            this.pbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItem.Location = new System.Drawing.Point(509, 15);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(28, 24);
            this.pbItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItem.TabIndex = 2;
            this.pbItem.TabStop = false;
            // 
            // UsrCtl_InsertCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.pbItem);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.lblItem);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UsrCtl_InsertCommand";
            this.Size = new System.Drawing.Size(540, 243);
            ((System.ComponentModel.ISupportInitialize)(this.tbAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.PictureBox pbItem;
        public System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.NumericUpDown nudCount;
        public System.Windows.Forms.TrackBar tbAmount;
    }
}
