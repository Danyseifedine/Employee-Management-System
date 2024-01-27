using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee
{
    public partial class login : Form
    {
        /// <summary>
        /// Initializes a new instance of the login form, setting up the initial state and hiding error messages.
        /// </summary>
        public login()
        {
            InitializeComponent();
            PasswordErrorText.Hide();
            userNameErrorText.Hide();
        }


        /// <summary>
        /// Validates the entered username, ensuring it is not empty or consisting only of whitespaces.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>
        /// True if the username is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using <see cref="userNameErrorText"/>.
        /// </returns>
        private bool userError(string username)
        {
            // Display the error message area for username validation.
            userNameErrorText.Show();

            // Check if the username is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                userNameErrorText.Text = "Username is required.";
                return false;
            }

            // Hide the error message area if the validation passes.
            userNameErrorText.Hide();
            return true;
        }


        /// <summary>
        /// Validates the entered password, ensuring it is not empty or consisting only of whitespaces.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>
        /// True if the password is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using <see cref="PasswordErrorText"/>.
        /// </returns>
        private bool passwordError(string password)
        {
            // Display the error message area for password validation.
            PasswordErrorText.Show();

            // Check if the password is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                PasswordErrorText.Text = "Password is required.";
                return false;
            }

            // Hide the error message area if the validation passes.
            PasswordErrorText.Hide();
            return true;
        }


        /// <summary>
        /// Event handler for the button click that closes the current form and exits the application.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Close the current form.
            this.Close();

            // Exit the application.
            Application.Exit();
        }


        /// <summary>
        /// Event handler for the link label click that hides the current form and shows the main form (Form1).
        /// </summary>
        /// <param name="sender">The object that triggered the event (link label).</param>
        /// <param name="e">The event arguments.</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create and show the main form (Form1).
            Form1 mainForm = new Form1();
            mainForm.Show();
        }


        /// <summary>
        /// Event handler for the login button click that attempts to authenticate the user.
        /// </summary>
        /// <param name="sender">The object that triggered the event (login button).</param>
        /// <param name="e">The event arguments.</param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Set up the connection string for the SQL Server database.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(@"Data Source=LAPTOP-IKKAO70T;Initial Catalog=employeedb;Integrated Security=True;Encrypt=True;");
            builder.TrustServerCertificate = true;

            // Establish a connection to the database.
            SqlConnection con = new SqlConnection(builder.ConnectionString);
            con.Open();

            // Retrieve user input from textboxes.
            string username = UserInput.Text;
            string password = PasswordInput.Text;

            // Validate user input.
            bool checkUsernameValidation = this.userError(username);
            bool checkPasswordValidation = this.passwordError(password);

            // Proceed with authentication if input is valid.
            if (checkPasswordValidation && checkUsernameValidation)
            {
                // Check the database for the provided username and password.
                SqlCommand cmd = new SqlCommand("SELECT username, password FROM logintab WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                // Create a DataTable to store the query results.
                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);

                // If a matching record is found, open the management form; otherwise, display an error message.
                if (table.Rows.Count > 0)
                {
                    Management management = new Management();
                    this.Hide();
                    management.Show();
                }
                else
                {
                    PasswordErrorText.Show();
                    PasswordErrorText.Text = "Invalid username or password.";
                }
            }
        }


        private void UserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPassword.Checked)
            {
                PasswordInput.PasswordChar = '\0';
            }
            else
            {
                PasswordInput.PasswordChar = '*';
            }
        }
    }
}
