using KenChanInventorySystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChanInventorySystem.Form
{
    public partial class LoginForm : System.Windows.Forms.Form
    {
        private readonly AuthService _authService = new AuthService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            try
            {
                var user = _authService.Authenticate(
                    txtUsername.Text.Trim(),
                    txtPassword.Text);

                if (user != null)
                {
                    MessageBox.Show(
                        $"Welcome, {user.Username}!\nRole: {user.Role}",
                        "Login Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid username or password.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var register = new RegisterForm();
            register.FormClosed += (s, args) => this.Close();
            register.Show();
            this.Hide();

        }

        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterCard();
            txtUsername.Focus();
        }
        private void CenterCard()
        {
            if (pnlCard == null || pnlCenter == null) return;
            int x = (pnlCenter.ClientSize.Width - pnlCard.Width) / 2;
            int y = (pnlCenter.ClientSize.Height - pnlCard.Height) / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            pnlCard.Location = new Point(x, y);
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
