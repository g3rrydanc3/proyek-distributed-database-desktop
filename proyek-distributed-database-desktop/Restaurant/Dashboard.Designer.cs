namespace proyek_distributed_database_desktop.Restaurant
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.payment = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.totalPayment = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalItem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bill = new System.Windows.Forms.DataGridView();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuName = new System.Windows.Forms.TextBox();
            this.tableNo = new System.Windows.Forms.TextBox();
            this.roomNo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.menuList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bill)).BeginInit();
            this.SuspendLayout();
            // 
            // menuList
            // 
            this.menuList.AllowUserToAddRows = false;
            this.menuList.AllowUserToDeleteRows = false;
            this.menuList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.menuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.menuList.DefaultCellStyle = dataGridViewCellStyle1;
            this.menuList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.menuList.Location = new System.Drawing.Point(449, 34);
            this.menuList.Margin = new System.Windows.Forms.Padding(4);
            this.menuList.Name = "menuList";
            this.menuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.menuList.Size = new System.Drawing.Size(588, 485);
            this.menuList.TabIndex = 4;
            this.menuList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menuList_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.payment);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.totalPayment);
            this.panel1.Controls.Add(this.total);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.totalItem);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bill);
            this.panel1.Controls.Add(this.menuName);
            this.panel1.Controls.Add(this.tableNo);
            this.panel1.Controls.Add(this.roomNo);
            this.panel1.Location = new System.Drawing.Point(31, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 485);
            this.panel1.TabIndex = 3;
            // 
            // payment
            // 
            this.payment.BackColor = System.Drawing.Color.Green;
            this.payment.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.payment.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.payment.Location = new System.Drawing.Point(172, 391);
            this.payment.Margin = new System.Windows.Forms.Padding(4);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(213, 86);
            this.payment.TabIndex = 19;
            this.payment.Text = "Payment";
            this.payment.UseVisualStyleBackColor = false;
            this.payment.Click += new System.EventHandler(this.payment_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Red;
            this.cancel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.cancel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancel.Location = new System.Drawing.Point(24, 436);
            this.cancel.Margin = new System.Windows.Forms.Padding(4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(140, 42);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.delete.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.delete.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.delete.Location = new System.Drawing.Point(24, 391);
            this.delete.Margin = new System.Windows.Forms.Padding(4);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(140, 42);
            this.delete.TabIndex = 15;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // totalPayment
            // 
            this.totalPayment.AutoSize = true;
            this.totalPayment.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.totalPayment.Location = new System.Drawing.Point(324, 357);
            this.totalPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.Size = new System.Drawing.Size(16, 18);
            this.totalPayment.TabIndex = 14;
            this.totalPayment.Text = "0";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.total.Location = new System.Drawing.Point(324, 313);
            this.total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(16, 18);
            this.total.TabIndex = 12;
            this.total.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(20, 334);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Order Tax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label6.Location = new System.Drawing.Point(224, 313);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label5.Location = new System.Drawing.Point(147, 335);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "10%";
            // 
            // totalItem
            // 
            this.totalItem.AutoSize = true;
            this.totalItem.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.totalItem.Location = new System.Drawing.Point(147, 313);
            this.totalItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalItem.Name = "totalItem";
            this.totalItem.Size = new System.Drawing.Size(16, 18);
            this.totalItem.TabIndex = 8;
            this.totalItem.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label3.Location = new System.Drawing.Point(20, 357);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Payable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(20, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label1.Location = new System.Drawing.Point(20, 313);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Items";
            // 
            // bill
            // 
            this.bill.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.bill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.price,
            this.qty,
            this.subtotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bill.DefaultCellStyle = dataGridViewCellStyle2;
            this.bill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.bill.Location = new System.Drawing.Point(20, 119);
            this.bill.Margin = new System.Windows.Forms.Padding(4);
            this.bill.Name = "bill";
            this.bill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bill.Size = new System.Drawing.Size(365, 185);
            this.bill.TabIndex = 4;
            this.bill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bill_CellClick);
            // 
            // product
            // 
            this.product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.Width = 86;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.Width = 69;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.Width = 59;
            // 
            // subtotal
            // 
            this.subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.Width = 89;
            // 
            // menuName
            // 
            this.menuName.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.menuName.ForeColor = System.Drawing.Color.Gray;
            this.menuName.Location = new System.Drawing.Point(20, 86);
            this.menuName.Margin = new System.Windows.Forms.Padding(4);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(364, 25);
            this.menuName.TabIndex = 3;
            this.menuName.Text = "Search menu by name";
            this.menuName.Click += new System.EventHandler(this.menuName_Click);
            this.menuName.Leave += new System.EventHandler(this.menuName_Leave);
            // 
            // tableNo
            // 
            this.tableNo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F);
            this.tableNo.ForeColor = System.Drawing.Color.Gray;
            this.tableNo.Location = new System.Drawing.Point(20, 54);
            this.tableNo.Margin = new System.Windows.Forms.Padding(4);
            this.tableNo.Name = "tableNo";
            this.tableNo.Size = new System.Drawing.Size(364, 25);
            this.tableNo.TabIndex = 2;
            this.tableNo.Text = "Table No";
            this.tableNo.Enter += new System.EventHandler(this.tableNo_Enter);
            this.tableNo.Leave += new System.EventHandler(this.tableNo_Leave);
            // 
            // roomNo
            // 
            this.roomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomNo.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.roomNo.FormattingEnabled = true;
            this.roomNo.Location = new System.Drawing.Point(20, 20);
            this.roomNo.Margin = new System.Windows.Forms.Padding(4);
            this.roomNo.Name = "roomNo";
            this.roomNo.Size = new System.Drawing.Size(364, 26);
            this.roomNo.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuList);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView menuList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button payment;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.TextBox menuName;
        private System.Windows.Forms.TextBox tableNo;
        public System.Windows.Forms.ComboBox roomNo;
        public System.Windows.Forms.DataGridView bill;
        public System.Windows.Forms.Label totalPayment;
        public System.Windows.Forms.Label total;
        public System.Windows.Forms.Label totalItem;
    }
}