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

namespace KenChanInventorySystem.Forms
{
    public partial class RegisterForm : System.Windows.Forms.Form
    {
        private readonly AuthService _authService = new AuthService();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? "Staff";
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Clear();
                txtConfirm.Focus();
                return;
            }
            try
            {
                if (_authService.UsernameExists(username))
                {
                    MessageBox.Show("That username is already taken.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                int newId = _authService.RegisterUser(username, password, role);

                if (newId > 0)
                {
                    MessageBox.Show(
                        $"Account created!\n\nUsername: {username}\nRole: {role}\n\nYou may now log in.",
                        "Registration Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var login = new LoginForm();
                    login.FormClosed += (s, args) => this.Close();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create the account.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            this.Hide();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            CenterCard();
            txtUsername.Focus();
        }

        private void RegisterForm_Resize(object sender, EventArgs e)
        {
            CenterCard();
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

        private void lblConfirm_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
