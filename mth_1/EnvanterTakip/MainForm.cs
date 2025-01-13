using System;
using System.Windows.Forms;

namespace EnvanterTakip
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Visible = false;
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    ShowProductsForm();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void ShowProductsForm()
        {
            var productsForm = new ProductsForm();
            productsForm.Show();
            this.Hide();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }
    }
} 