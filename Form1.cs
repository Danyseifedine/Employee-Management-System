using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;
using System.Reflection;

namespace employee
{




    public partial class Form1 : Form
    {


        /// <summary>
        /// Main form for user registration.
        /// </summary>
        /// 

        public Form1()
        {

            /// <summary>
            /// Constructor for the Form1 class.
            /// </summary>      

            InitializeComponent();
            PasswordErrorText.Hide();
            userNameErrorText.Hide();
            ConfirmPasswordErrorText.Hide();
        }


        /// <summary>
        /// Validates the entered username, ensuring it adheres to specified criteria.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>
        /// True if the username is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using <see cref="userNameErrorText"/>.
        /// </returns>
        private bool userError(string username)
        {
            // Define a pattern allowing only letters and numbers in the username.
            string pattern = "^[a-zA-Z0-9]+$";

            // Display the error message area for username validation.
            userNameErrorText.Show();

            // Check if the username is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                userNameErrorText.Text = "Username is required.";
                return false;
            }
            // Check if the username length is within the acceptable range.
            else if (username.Length < 3 || username.Length >= 15)
            {
                userNameErrorText.Text = "Username must be between 3 and 15 characters.";
                return false;
            }
            // Check if the username contains only letters and numbers.
            else if (!Regex.IsMatch(username, pattern))
            {
                userNameErrorText.Text = "Username only accepts letters and numbers.";
                return false;
            }

            // Indicate that the validation passes if all conditions are met.
            return true;
        }




        /// <summary>
        /// Validates the entered password, providing visual feedback through an error message.
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
            // Check if the password length is within the acceptable range.
            else if (password.Length < 4 || password.Length >= 20)
            {
                PasswordErrorText.Text = "Password must be between 4 and 20 characters.";
                return false;
            }

            // Hide the error message area if the validation passes.
            PasswordErrorText.Hide();
            return true;
        }


        /// <summary>
        /// Validates the entered confirmed password, providing visual feedback through an error message.
        /// </summary>
        /// <param name="confirmPassword">The confirmed password to validate.</param>
        /// <returns>
        /// True if the confirmed password is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using <see cref="ConfirmPasswordErrorText"/>.
        /// </returns>
        private bool confirmPassword(string confirmPassword)
        {
            // Display the error message area for confirmed password validation.
            ConfirmPasswordErrorText.Show();

            // Check if the confirmed password is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(confirmPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ConfirmPasswordErrorText.Text = "Confirmed password is required.";
                return false;
            }
            // Check if the confirmed password matches the original password.
            else if (PasswordInput.Text != confirmPassword)
            {
                ConfirmPasswordErrorText.Text = "Password and confirmed password do not match.";
                return false;
            }

            // Hide the error message area if the validation passes.
            ConfirmPasswordErrorText.Hide();
            return true;
        }



        /// <summary>
        /// Event handler for the button click that initiates the user registration process.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Button2_Click(object sender, EventArgs e)
        {
            // Establish a connection to the SQL Server database.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(@"Data Source=LAPTOP-IKKAO70T;Initial Catalog=employeedb;Integrated Security=True;Encrypt=True;");
            builder.TrustServerCertificate = true;

            SqlConnection con = new SqlConnection(builder.ConnectionString);
            con.Open();

            // Retrieve user input from textboxes.
            string username = UserInput.Text;
            string password = PasswordInput.Text;
            string confirmPassword = ConfirmPasswordInput.Text;

            // Validate user input.
            bool checkUsernameValidation = this.userError(username);
            bool checkPasswordValidation = this.passwordError(password);
            bool checkCpasswordValidation = this.confirmPassword(confirmPassword);

            // Proceed with user registration if input is valid.
            if (checkPasswordValidation && checkUsernameValidation && checkCpasswordValidation)
            {
                // Check if the username already exists in the database.
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM logintab WHERE username = @username", con);
                checkCmd.Parameters.AddWithValue("@username", username);
                int existingUserCount = (int)checkCmd.ExecuteScalar();

                if (existingUserCount > 0)
                {
                    // Display an error message if the username already exists.
                    userNameErrorText.Text = "Username already exists.";
                }
                else
                {
                    // Insert the new user into the database.
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO logintab (username, password) VALUES (@username, @password)", con);
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Registration successful. Open the management form.
                        Management management = new Management();
                        this.Hide();
                        management.Show();
                    }
                    else
                    {
                        // Display an error message if the registration fails.
                        PasswordErrorText.Text = "Failed to create an account. Please try again.";
                    }
                }
            }
        }


        /// <summary>
        /// Event handler for the checkbox state change that toggles the visibility of the password characters.
        /// </summary>
        /// <param name="sender">The object that triggered the event (checkbox).</param>
        /// <param name="e">The event arguments.</param>
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // If the checkbox is checked, reveal the password characters.
            if (ShowPassword.Checked)
            {
                PasswordInput.PasswordChar = '\0'; // '\0' represents the null character, revealing the characters.
                ShowPassword.Text = "Hide"; // Change the checkbox label to "Hide".
            }
            else
            {
                // If the checkbox is unchecked, hide the password characters.
                PasswordInput.PasswordChar = '*'; // '*' represents the standard password mask character.
                ShowPassword.Text = "Show"; // Change the checkbox label to "Show".
            }
        }

        /// <summary>
        /// Event handler for the checkbox state change that toggles the visibility of the confirm password characters.
        /// </summary>
        /// <param name="sender">The object that triggered the event (checkbox).</param>
        /// <param name="e">The event arguments.</param>
        private void ShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            // If the checkbox is checked, reveal the confirm password characters.
            if (ShowConfirmPassword.Checked)
            {
                ConfirmPasswordInput.PasswordChar = '\0'; // '\0' represents the null character, revealing the characters.
            }
            else
            {
                // If the checkbox is unchecked, hide the confirm password characters.
                ConfirmPasswordInput.PasswordChar = '*'; // '*' represents the standard password mask character.
            }
        }



        /// <summary>
        /// Event handler for the link label click that hides the current form and opens the login form.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Hide the current form.
            this.Hide();

            // Create and show the login form.
            login loginForm = new login();
            loginForm.Show();
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




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void ShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void ConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmPasswordInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
