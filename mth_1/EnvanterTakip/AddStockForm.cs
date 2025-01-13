using System;
using System.Windows.Forms;
using System.Drawing;

namespace EnvanterTakip
{
    public partial class AddStockForm : Form
    {
        public AddStockForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form properties
            this.Font = new Font("Segoe UI", 9F);
            
            this.txtSKUName = new TextBox();
            this.txtProductName = new TextBox();
            this.cmbCategory = new ComboBox();
            this.txtPrice = new TextBox();
            this.txtQuantity = new TextBox();
            this.btnConfirm = new Button();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();

            // SKU Name
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 15);
            this.label1.Size = new Size(100, 20);
            this.label1.Text = "SKU Name:";
            this.label1.Font = new Font("Segoe UI", 9F);

            this.txtSKUName.Location = new Point(140, 12);
            this.txtSKUName.Size = new Size(250, 27);
            this.txtSKUName.Font = new Font("Segoe UI", 9F);

            // Product Name
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 55);
            this.label2.Size = new Size(100, 20);
            this.label2.Text = "Product Name:";
            this.label2.Font = new Font("Segoe UI", 9F);

            this.txtProductName.Location = new Point(140, 52);
            this.txtProductName.Size = new Size(250, 27);
            this.txtProductName.Font = new Font("Segoe UI", 9F);

            // Category
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 95);
            this.label3.Size = new Size(100, 20);
            this.label3.Text = "Category:";
            this.label3.Font = new Font("Segoe UI", 9F);

            this.cmbCategory.Location = new Point(140, 92);
            this.cmbCategory.Size = new Size(250, 27);
            this.cmbCategory.Font = new Font("Segoe UI", 9F);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Electronics", "Accessories", "Office Supplies", "Furniture", "Other" });

            // Price
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 135);
            this.label4.Size = new Size(100, 20);
            this.label4.Text = "Price:";
            this.label4.Font = new Font("Segoe UI", 9F);

            this.txtPrice.Location = new Point(140, 132);
            this.txtPrice.Size = new Size(250, 27);
            this.txtPrice.Font = new Font("Segoe UI", 9F);

            // Quantity
            this.label5.AutoSize = true;
            this.label5.Location = new Point(12, 175);
            this.label5.Size = new Size(120, 20);
            this.label5.Text = "Available Quantity:";
            this.label5.Font = new Font("Segoe UI", 9F);

            this.txtQuantity.Location = new Point(140, 172);
            this.txtQuantity.Size = new Size(250, 27);
            this.txtQuantity.Font = new Font("Segoe UI", 9F);

            // Buttons
            this.btnConfirm.Location = new Point(140, 220);
            this.btnConfirm.Size = new Size(120, 35);
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Font = new Font("Segoe UI", 9F);
            this.btnConfirm.BackColor = Color.FromArgb(40, 167, 69);
            this.btnConfirm.ForeColor = Color.White;
            this.btnConfirm.Click += new EventHandler(btnConfirm_Click);

            this.btnCancel.Location = new Point(270, 220);
            this.btnCancel.Size = new Size(120, 35);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = new Font("Segoe UI", 9F);
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            // Form
            this.ClientSize = new Size(414, 277);
            this.Controls.AddRange(new Control[] { 
                this.label1, this.txtSKUName,
                this.label2, this.txtProductName,
                this.label3, this.cmbCategory,
                this.label4, this.txtPrice,
                this.label5, this.txtQuantity,
                this.btnConfirm, this.btnCancel
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Stock";
        }

        private TextBox txtSKUName;
        private TextBox txtProductName;
        private ComboBox cmbCategory;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Button btnConfirm;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        public void PreFillData(string skuName, string productName, string category, decimal price, int quantity)
        {
            txtSKUName.Text = skuName;
            txtProductName.Text = productName;
            cmbCategory.SelectedItem = category;
            txtPrice.Text = price.ToString();
            txtQuantity.Text = quantity.ToString();
            this.Text = "Edit Stock";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSKUName.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(cmbCategory.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Properties to access the form data
        public string SKUName => txtSKUName.Text;
        public string ProductName => txtProductName.Text;
        public string Category => cmbCategory.Text;
        public decimal Price => decimal.Parse(txtPrice.Text);
        public int Quantity => int.Parse(txtQuantity.Text);
    }
} 