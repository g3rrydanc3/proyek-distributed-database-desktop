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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.menuList.DefaultCellStyle = dataGridViewCellStyle5;
            this.menuList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.menuList.Location = new System.Drawing.Point(337, 28);
            this.menuList.Name = "menuList";
            this.menuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.menuList.Size = new System.Drawing.Size(441, 394);
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
            this.panel1.Location = new System.Drawing.Point(23, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 394);
            this.panel1.TabIndex = 3;
            // 
            // payment
            // 
            this.payment.BackColor = System.Drawing.Color.Green;
            this.payment.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.payment.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.payment.Location = new System.Drawing.Point(129, 318);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(160, 70);
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
            this.cancel.Location = new System.Drawing.Point(18, 354);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(105, 34);
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
            this.delete.Location = new System.Drawing.Point(18, 318);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(105, 34);
            this.delete.TabIndex = 15;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // totalPayment
            // 
            this.totalPayment.AutoSize = true;
            this.totalPayment.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.totalPayment.Location = new System.Drawing.Point(243, 290);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.Size = new System.Drawing.Size(13, 14);
            this.totalPayment.TabIndex = 14;
            this.totalPayment.Text = "0";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.total.Location = new System.Drawing.Point(243, 254);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(13, 14);
            this.total.TabIndex = 12;
            this.total.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(15, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "Order Tax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label6.Location = new System.Drawing.Point(168, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label5.Location = new System.Drawing.Point(110, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "10%";
            // 
            // totalItem
            // 
            this.totalItem.AutoSize = true;
            this.totalItem.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.totalItem.Location = new System.Drawing.Point(110, 254);
            this.totalItem.Name = "totalItem";
            this.totalItem.Size = new System.Drawing.Size(13, 14);
            this.totalItem.TabIndex = 8;
            this.totalItem.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label3.Location = new System.Drawing.Point(15, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Payable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(15, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.label1.Location = new System.Drawing.Point(15, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bill.DefaultCellStyle = dataGridViewCellStyle6;
            this.bill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.bill.Location = new System.Drawing.Point(15, 97);
            this.bill.Name = "bill";
            this.bill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bill.Size = new System.Drawing.Size(274, 150);
            this.bill.TabIndex = 4;
            this.bill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bill_CellClick);
            // 
            // product
            // 
            this.product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.product.HeaderText = "Product";
            this.product.Name = "product";
            this.product.Width = 69;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.Width = 56;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.Width = 48;
            // 
            // subtotal
            // 
            this.subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.Width = 71;
            // 
            // menuName
            // 
            this.menuName.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.menuName.ForeColor = System.Drawing.Color.Gray;
            this.menuName.Location = new System.Drawing.Point(15, 70);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(274, 21);
            this.menuName.TabIndex = 3;
            this.menuName.Text = "Search menu by name";
            this.menuName.Click += new System.EventHandler(this.menuName_Click);
            this.menuName.Leave += new System.EventHandler(this.menuName_Leave);
            // 
            // tableNo
            // 
            this.tableNo.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.tableNo.ForeColor = System.Drawing.Color.Gray;
            this.tableNo.Location = new System.Drawing.Point(15, 44);
            this.tableNo.Name = "tableNo";
            this.tableNo.Size = new System.Drawing.Size(274, 21);
            this.tableNo.TabIndex = 2;
            this.tableNo.Text = "Table No";
            this.tableNo.Click += new System.EventHandler(this.tableNo_Click);
            this.tableNo.Leave += new System.EventHandler(this.tableNo_Leave);
            // 
            // roomNo
            // 
            this.roomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomNo.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F);
            this.roomNo.FormattingEnabled = true;
            this.roomNo.Location = new System.Drawing.Point(15, 16);
            this.roomNo.Name = "roomNo";
            this.roomNo.Size = new System.Drawing.Size(274, 22);
            this.roomNo.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuList);
            this.Controls.Add(this.panel1);
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