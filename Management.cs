using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace employee
{
    public partial class Management : Form
    {


        /// <summary>
        /// Initializes a new instance of the Management class.
        /// </summary>
        public Management()
        {
            // Initialize the form components.
            InitializeComponent();

            // Set initial visibility of group boxes.
            EditGroupbox.Visible = false;
            displayGroupbox.Visible = false;
            incGroupbox.Visible = false;

            // Attach event handlers for text changes.
            EDIT_empIdInput.TextChanged += textBox1_TextChanged;
            SALARY_emIdInput.TextChanged += SALARY_emIdInput_TextChanged;

            // Hide error labels.
            ADD_empNameError.Hide();
            ADD_emailError.Hide();
            ADD_AddressError.Hide();
            ADD_salaryError.Hide();

            // Set default state for salary checkboxes.
            SALARY_allEmpCheckbox.Checked = true;
            SALARY_empIdLabel.Hide();
            SALARY_emIdInput.Hide();
            SALARY_emIdError.Hide();
        }



        /// <summary>
        /// Displays a success message on a label for a specified duration and then clears the message.
        /// </summary>
        /// <param name="successLabel">The label where the success message will be displayed.</param>
        /// <param name="message">The success message to be displayed.</param>
        /// <param name="durationInSeconds">The duration, in seconds, for which the success message will be visible. Default is 3 seconds.</param>
        private void ShowSuccessMessage(Label successLabel, string message, int durationInSeconds = 3)
        {
            // Set the success message on the specified label.
            successLabel.Text = message;

            // Create a timer to clear the success message after the specified duration.
            Timer timer = new Timer();
            timer.Interval = durationInSeconds * 1000;
            timer.Tick += (sender, e) =>
            {
                // Clear the success message.
                successLabel.Text = "";

                // Stop and dispose of the timer.
                timer.Stop();
                timer.Dispose();
            };

            // Start the timer.
            timer.Start();
        }



        /// <summary>
        /// Validates the provided employee name, displaying an error message if invalid.
        /// </summary>
        /// <param name="empName">The employee name to validate.</param>
        /// <param name="errorLabel">The label used to display error messages.</param>
        /// <returns>
        /// True if the employee name is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using the provided <paramref name="errorLabel"/>.
        /// </returns>
        private bool ValidateEmpName(string empName, Label errorLabel)
        {
            // Display the error message area for employee name validation.
            errorLabel.Show();

            // Check if the employee name is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(empName) || string.IsNullOrWhiteSpace(empName))
            {
                errorLabel.Text = "Employee name is required.";
                return false;
            }
            // Check if the employee name length is within the acceptable range.
            else if (empName.Length < 3 || empName.Length >= 18)
            {
                errorLabel.Text = "Employee name must be between 3 and 18 characters.";
                return false;
            }

            // Hide the error message area if the validation passes.
            errorLabel.Hide();
            return true;
        }


        /// <summary>
        /// Validates the provided email address, displaying an error message if invalid.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <param name="errorLabel">The label used to display error messages.</param>
        /// <returns>
        /// True if the email address is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using the provided <paramref name="errorLabel"/>.
        /// </returns>
        private bool ValidateEmail(string email, Label errorLabel)
        {
            // Display the error message area for email validation.
            errorLabel.Show();

            // Define a regular expression pattern for a valid email address.
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Check if the email address is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                errorLabel.Text = "Email is required.";
                return false;
            }
            // Check if the email address matches the defined pattern.
            else if (!Regex.IsMatch(email, emailPattern))
            {
                errorLabel.Text = "Invalid email format.";
                return false;
            }

            // Hide the error message area if the validation passes.
            errorLabel.Hide();
            return true;
        }



        /// <summary>
        /// Validates the provided address, displaying an error message if invalid.
        /// </summary>
        /// <param name="address">The address to validate.</param>
        /// <param name="errorLabel">The label used to display error messages.</param>
        /// <returns>
        /// True if the address is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using the provided <paramref name="errorLabel"/>.
        /// </returns>
        private bool ValidateAddress(string address, Label errorLabel)
        {
            // Display the error message area for address validation.
            errorLabel.Show();

            // Check if the address is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                errorLabel.Text = "Address is required.";
                return false;
            }
            // Check if the address length is within the acceptable range.
            else if (address.Length < 3 || address.Length >= 18)
            {
                errorLabel.Text = "Address must be between 3 and 18 characters.";
                return false;
            }

            // Hide the error message area if the validation passes.
            errorLabel.Hide();
            return true;
        }


        /// <summary>
        /// Validates the provided salary, displaying an error message if invalid.
        /// </summary>
        /// <param name="salary">The salary to validate as a string.</param>
        /// <param name="errorLabel">The label used to display error messages.</param>
        /// <returns>
        /// True if the salary is valid; otherwise, false. 
        /// If the validation fails, an appropriate error message is displayed using the provided <paramref name="errorLabel"/>.
        /// </returns>
        private bool ValidateSalary(string salary, Label errorLabel)
        {
            // Display the error message area for salary validation.
            errorLabel.Show();

            // Check if the salary is empty or contains only whitespaces.
            if (string.IsNullOrEmpty(salary) || string.IsNullOrWhiteSpace(salary))
            {
                errorLabel.Text = "Salary is required.";
                return false;
            }

            // Check if the salary can be parsed as a decimal number.
            if (!decimal.TryParse(salary, out _))
            {
                errorLabel.Text = "Invalid salary format. Please enter a valid number.";
                return false;
            }

            // Hide the error message area if the validation passes.
            errorLabel.Hide();
            return true;
        }


        /// <summary>
        /// Creates and returns a new instance of <see cref="SqlConnection"/> configured with the connection string
        /// for the 'employeedb' database on the 'LAPTOP-IKKAO70T' server, using Windows Integrated Security and encryption.
        /// </summary>
        /// <returns>A new instance of <see cref="SqlConnection"/>.</returns>
        private SqlConnection GetSqlConnection()
        {
            // Create a SqlConnectionStringBuilder to configure the connection parameters.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(@"Data Source=LAPTOP-IKKAO70T;Initial Catalog=employeedb;Integrated Security=True;Encrypt=True;");
            builder.TrustServerCertificate = true;

            // Return a new SqlConnection instance with the configured connection string.
            return new SqlConnection(builder.ConnectionString);
        }


        /// <summary>
        /// Retrieves employee data from the 'employee' table and displays it in the DataGridView.
        /// </summary>
        private void DisplayEmployeeData()
        {
            // Using statement ensures the SqlConnection is properly disposed after use.
            using (SqlConnection con = GetSqlConnection())
            {
                // Open the database connection.
                con.Open();

                // Create a SqlCommand to retrieve all records from the 'employee' table.
                SqlCommand checkCmd = new SqlCommand("SELECT * FROM employee", con);

                // Create a SqlDataAdapter to execute the SqlCommand and fill a DataTable.
                SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Set the DataGridView's data source to the filled DataTable.
                dataGridView1.DataSource = dt;
            }
        }


        /// <summary>
        /// Updates employee information in the 'employee' table based on the provided inputs.
        /// </summary>
        private void UpdateEmployeeData()
        {
            // Using statement ensures the SqlConnection is properly disposed after use.
            using (SqlConnection con = GetSqlConnection())
            {
                // Open the database connection.
                con.Open();

                // Create a SqlCommand to update the 'employee' table with new values.
                SqlCommand checkCmd = new SqlCommand("UPDATE employee SET empName = @empName, address = @address, email = @email, salary = @salary WHERE id = @empId", con);
                checkCmd.Parameters.AddWithValue("@empId", int.Parse(EDIT_empIdInput.Text));
                checkCmd.Parameters.AddWithValue("@empName", EDIT_empNameInput.Text);
                checkCmd.Parameters.AddWithValue("@address", EDIT_empAddressInput.Text);
                checkCmd.Parameters.AddWithValue("@email", EDIT_empEmailInput.Text);
                checkCmd.Parameters.AddWithValue("@salary", int.Parse(EDIT_empSalaryInput.Text));

                // Execute the SqlCommand to perform the update.
                checkCmd.ExecuteNonQuery();

                // Display a success message for a brief duration.
                ShowSuccessMessage(EDIT_success, "Employee information updated", 3);
            }
        }


        /// <summary>
        /// Inserts a new employee record into the 'employee' table with the provided information.
        /// </summary>
        private void SaveEmployeeData()
        {
            // Using statement ensures the SqlConnection is properly disposed after use.
            using (SqlConnection con = GetSqlConnection())
            {
                // Open the database connection.
                con.Open();

                // Create a SqlCommand to insert a new record into the 'employee' table.
                SqlCommand checkCmd = new SqlCommand("INSERT INTO employee VALUES(@empName, @address, @email, @salary)", con);
                checkCmd.Parameters.AddWithValue("@empName", empNameInput.Text);
                checkCmd.Parameters.AddWithValue("@address", empAddressInput.Text);
                checkCmd.Parameters.AddWithValue("@email", empEmailInput.Text);
                checkCmd.Parameters.AddWithValue("@salary", int.Parse(empSalaryInput.Text));

                // Execute the SqlCommand to perform the insertion.
                checkCmd.ExecuteNonQuery();

                // Display a success message for a brief duration.
                ShowSuccessMessage(ADD_success, "Employee information added", 3);
            }
        }


        /// <summary>
        /// Deletes an employee record from the 'employee' table based on the provided employee ID.
        /// </summary>
        private void DeleteEmployeeData()
        {
            // Using statement ensures the SqlConnection is properly disposed after use.
            using (SqlConnection con = GetSqlConnection())
            {
                // Open the database connection.
                con.Open();

                // Create a SqlCommand to delete a record from the 'employee' table.
                SqlCommand checkCmd = new SqlCommand("DELETE FROM employee WHERE id = @empId", con);
                checkCmd.Parameters.AddWithValue("@empId", int.Parse(EDIT_empIdInput.Text));

                // Execute the SqlCommand to perform the deletion.
                checkCmd.ExecuteNonQuery();

                // Display a success message for a brief duration.
                ShowSuccessMessage(EDIT_success, "Employee information deleted", 3);
            }
        }

        /// <summary>
        /// Event handler for the click event of the 'saveBtn'. Validates and saves employee data if input is valid.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Retrieve input values from the UI controls.
            string empName = empNameInput.Text;
            string email = empEmailInput.Text;
            string salary = empSalaryInput.Text;
            string address = empAddressInput.Text;

            // Validate input values.
            bool empNameValidate = this.ValidateEmpName(empName, ADD_empNameError);
            bool emailValidate = this.ValidateEmail(email, ADD_emailError);
            bool addressValidate = this.ValidateAddress(address, ADD_AddressError);
            bool salaryValidate = this.ValidateSalary(salary, ADD_salaryError);

            // If all validations pass, save the employee data.
            if (empNameValidate && emailValidate && addressValidate && salaryValidate)
            {
                SaveEmployeeData();
            }
            else
            {
                // If validation fails, do not proceed with saving and return.
                return;
            }
        }


        /// <summary>
        /// Event handler for the click event of 'button1'. Closes the current form and exits the application.
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
        /// Event handler for the click event of 'button2'. Shows the 'addGroupBox' and hides other group boxes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Show the 'addGroupBox' and hide other group boxes.
            addGroupBox.Visible = true;
            incGroupbox.Visible = false;
            displayGroupbox.Visible = false;
            EditGroupbox.Visible = false;
        }

        /// <summary>
        /// Event handler for the click event of 'button3'. Shows the 'EditGroupbox' and hides other group boxes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Show the 'EditGroupbox' and hide other group boxes.
            incGroupbox.Visible = false;
            displayGroupbox.Visible = false;
            EditGroupbox.Visible = true;
        }


        /// <summary>
        /// Event handler for the click event of 'displayBtn'. Shows the 'displayGroupbox' and invokes data display operation.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void displayBtn_Click(object sender, EventArgs e)
        {
            // Show the 'displayGroupbox' and hide other group boxes.
            incGroupbox.Visible = false;
            displayGroupbox.Visible = true;

            // Invoke the operation to display employee data.
            DisplayEmployeeData();
        }


        /// <summary>
        /// Event handler for the click event of 'button6'. Shows the 'incGroupbox' and hides the 'searchGroupbox'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            // Show the 'incGroupbox' and hide the 'searchGroupbox'.
            searchGroupbox.Visible = false;
            incGroupbox.Visible = true;
        }


        /// <summary>
        /// Event handler for the click event of 'searchBtn'. Shows the 'searchGroupbox'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Show the 'searchGroupbox'.
            searchGroupbox.Visible = true;
        }


        /// <summary>
        /// Event handler for the text changed event of 'textBox1' (likely an employee ID input). Retrieves employee data based on the provided ID.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Retrieve the entered employee ID from the input textbox.
            string id = EDIT_empIdInput.Text;

            // Check if the entered ID is a valid integer.
            if (int.TryParse(id, out _))
            {
                // Using statement ensures the SqlConnection is properly disposed after use.
                using (SqlConnection con = GetSqlConnection())
                {
                    // Open the database connection.
                    con.Open();

                    // Create a SqlCommand to select employee data based on the provided ID.
                    SqlCommand checkCmd = new SqlCommand("SELECT * FROM employee WHERE id = @empid", con);
                    checkCmd.Parameters.AddWithValue("@empid", int.Parse(id));

                    // Execute the SqlCommand and process the SqlDataReader.
                    using (SqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the UI controls with retrieved employee data.
                            EDIT_empNameInput.Text = reader["empName"].ToString();
                            EDIT_empEmailInput.Text = reader["email"].ToString();
                            EDIT_empAddressInput.Text = reader["address"].ToString();
                            EDIT_empSalaryInput.Text = reader["salary"].ToString();

                            // Enable input fields and hide any existing error messages.
                            EDIT_empNameInput.Enabled = true;
                            EDIT_empEmailInput.Enabled = true;
                            EDIT_empAddressInput.Enabled = true;
                            EDIT_empSalaryInput.Enabled = true;
                            EDIT_existError.Hide();
                        }
                        else
                        {
                            // Show an error message if the ID doesn't exist and disable input fields.
                            EDIT_existError.Show();
                            EDIT_existError.Text = "The provided ID doesn't exist";
                            EDIT_empNameInput.Enabled = false;
                            EDIT_empEmailInput.Enabled = false;
                            EDIT_empAddressInput.Enabled = false;
                            EDIT_empSalaryInput.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                // Show an error message if the entered ID is not a valid integer and disable input fields.
                EDIT_existError.Show();
                EDIT_existError.Text = "ID is required and must be a number";
                EDIT_empNameInput.Enabled = false;
                EDIT_empEmailInput.Enabled = false;
                EDIT_empAddressInput.Enabled = false;
                EDIT_empSalaryInput.Enabled = false;
            }
        }


        /// <summary>
        /// Event handler for the click event of 'editBtn'. Validates and updates employee data if input is valid.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            // Retrieve input values from the UI controls.
            string empName = EDIT_empNameInput.Text;
            string email = EDIT_empEmailInput.Text;
            string salary = EDIT_empSalaryInput.Text;
            string address = EDIT_empAddressInput.Text;

            // Validate input values.
            bool empNameValidate = this.ValidateEmpName(empName, EDIT_empNameError);
            bool emailValidate = this.ValidateEmail(email, EDIT_emailError);
            bool addressValidate = this.ValidateAddress(address, EDIT_salaryError);
            bool salaryValidate = this.ValidateSalary(salary, EDIT_addressError);

            // If all validations pass, update the employee data.
            if (empNameValidate && emailValidate && addressValidate && salaryValidate)
            {
                UpdateEmployeeData();
            }
            else
            {
                // If validation fails, do not proceed with the update and return.
                return;
            }
        }


        /// <summary>
        /// Event handler for the click event of 'deleteBtn'. Checks if the employee ID exists before deleting the employee data.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void deleteBtn_Click_1(object sender, EventArgs e)
        {
            // Using statement ensures the SqlConnection is properly disposed after use.
            using (SqlConnection con = GetSqlConnection())
            {
                // Check if the entered ID is a valid integer.
                if (int.TryParse(EDIT_empIdInput.Text, out _))
                {
                    // Open the database connection.
                    con.Open();

                    // Create a SqlCommand to select employee data based on the provided ID.
                    SqlCommand checkCmd = new SqlCommand("SELECT * FROM employee WHERE id = @empid", con);
                    checkCmd.Parameters.AddWithValue("@empid", int.Parse(EDIT_empIdInput.Text));

                    // Execute the SqlCommand and fill the DataTable.
                    SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // If the DataTable contains rows, proceed with deleting the employee data.
                    if (dt.Rows.Count > 0)
                    {
                        DeleteEmployeeData();
                    }
                }
            }
        }


        /// <summary>
        /// Event handler for the text changed event of 'SALARY_emIdInput' (likely an employee ID input) in the salary-related section. Enables or disables salary-related controls based on the provided ID.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SALARY_emIdInput_TextChanged(object sender, EventArgs e)
        {
            // Retrieve the entered employee ID from the input textbox.
            string id = SALARY_emIdInput.Text;

            // Check if the entered ID is a valid integer.
            if (int.TryParse(id, out _))
            {
                // Using statement ensures the SqlConnection is properly disposed after use.
                using (SqlConnection con = GetSqlConnection())
                {
                    // Open the database connection.
                    con.Open();

                    // Create a SqlCommand to select employee data based on the provided ID.
                    SqlCommand checkCmd = new SqlCommand("SELECT * FROM employee WHERE id = @empid", con);
                    checkCmd.Parameters.AddWithValue("@empid", int.Parse(id));

                    // Execute the SqlCommand and process the SqlDataReader.
                    using (SqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Enable salary-related controls and hide any existing error messages.
                            SALARY_decreaseCheckbox.Enabled = true;
                            SALARY_increaseCheckbox.Enabled = true;
                            SALARY_amout.Enabled = true;
                            SALARY_emIdError.Hide();
                        }
                        else
                        {
                            // Show an error message if the ID doesn't exist and disable salary-related controls.
                            SALARY_emIdError.Show();
                            SALARY_emIdError.Text = "The provided ID doesn't exist";
                            SALARY_decreaseCheckbox.Enabled = false;
                            SALARY_increaseCheckbox.Enabled = false;
                            SALARY_amout.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                // Show an error message if the entered ID is not a valid integer and disable salary-related controls.
                SALARY_emIdError.Show();
                SALARY_emIdError.Text = "ID is required and must be a number";
                SALARY_decreaseCheckbox.Enabled = false;
                SALARY_increaseCheckbox.Enabled = false;
                SALARY_amout.Enabled = false;
            }
        }


        /// <summary>
        /// Event handler for the checked changed event of 'SALARY_singleEmpCheckbox' in the salary-related section. Controls the visibility and state of related controls based on whether the checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the 'SALARY_singleEmpCheckbox' is checked.
            if (SALARY_singleEmpCheckbox.Checked)
            {
                // Set related checkboxes and controls to the appropriate state when 'SALARY_singleEmpCheckbox' is checked.
                SALARY_allEmpCheckbox.Checked = false;
                SALARY_singleEmpCheckbox.Checked = true;
                SALARY_empIdLabel.Show();
                SALARY_emIdInput.Show();
                SALARY_emIdError.Show();

                SALARY_decreaseCheckbox.Enabled = false;
                SALARY_increaseCheckbox.Enabled = false;
                SALARY_amout.Enabled = false;
                SALARY_emIdError.Show();
            }
            else
            {
                // Set related checkboxes and controls to the appropriate state when 'SALARY_singleEmpCheckbox' is unchecked.
                SALARY_increaseCheckbox.Enabled = true;
                SALARY_amout.Enabled = true;
                SALARY_emIdError.Hide();

                SALARY_empIdLabel.Hide();
                SALARY_emIdInput.Hide();
                SALARY_emIdError.Hide();
            }
        }


        /// <summary>
        /// Event handler for the checked changed event of 'SALARY_allEmpCheckbox' in the salary-related section. Enables salary-related controls and hides error messages. If 'SALARY_singleEmpCheckbox' is checked, it unchecks it.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SALARY_allEmpCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable salary-related controls and hide error messages when 'SALARY_allEmpCheckbox' is checked.
            SALARY_decreaseCheckbox.Enabled = true;
            SALARY_increaseCheckbox.Enabled = true;
            SALARY_amout.Enabled = true;
            SALARY_emIdError.Hide();

            // If 'SALARY_singleEmpCheckbox' is checked, uncheck it.
            if (SALARY_singleEmpCheckbox.Checked)
            {
                SALARY_singleEmpCheckbox.Checked = false;
            }
        }


        /// <summary>
        /// Event handler for the checked changed event of 'SALARY_increaseCheckbox' in the salary-related section. Updates related controls when the checkbox is checked, ensuring mutual exclusivity with 'SALARY_decreaseCheckbox'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SALARY_increaseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if 'SALARY_increaseCheckbox' is checked.
            if (SALARY_increaseCheckbox.Checked)
            {
                // Uncheck 'SALARY_decreaseCheckbox' and update the button text when 'SALARY_increaseCheckbox' is checked.
                SALARY_decreaseCheckbox.Checked = false;
                SALARY_btn.Text = "Increase";
            }
        }


        /// <summary>
        /// Event handler for the checked changed event of 'SALARY_decreaseCheckbox' in the salary-related section. Updates related controls when the checkbox is checked, ensuring mutual exclusivity with 'SALARY_increaseCheckbox'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SALARY_decreaseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if 'SALARY_decreaseCheckbox' is checked.
            if (SALARY_decreaseCheckbox.Checked)
            {
                // Uncheck 'SALARY_increaseCheckbox' and update the button text when 'SALARY_decreaseCheckbox' is checked.
                SALARY_increaseCheckbox.Checked = false;
                SALARY_btn.Text = "Decrease";
            }
        }


        /// <summary>
        /// Event handler for the button click in the salary-related section. Updates employee salaries based on the selected options (all employees or single employee) and the chosen action (increase or decrease).
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SALARY_btn_Click(object sender, EventArgs e)
        {
            // Get the entered amount from 'SALARY_amout'.
            string amount = SALARY_amout.Text;

            // Validate the entered amount.
            bool amountValidation = ValidateSalary(amount, SALARY_amoutError);

            // Open a connection to the database.
            using (SqlConnection con = GetSqlConnection())
            {
                con.Open();

                // Check if the amount is valid.
                if (amountValidation)
                {
                    // Check if 'SALARY_allEmpCheckbox' is checked.
                    if (SALARY_allEmpCheckbox.Checked)
                    {
                        // Check if 'SALARY_increaseCheckbox' is checked.
                        if (SALARY_increaseCheckbox.Checked)
                        {
                            // Execute SQL command to increase the salary of all employees.
                            SqlCommand increaseCmd = new SqlCommand("UPDATE employee SET salary = salary + @amount", con);
                            increaseCmd.Parameters.AddWithValue("@amount", int.Parse(SALARY_amout.Text));
                            increaseCmd.ExecuteNonQuery();

                            // Display success message for all employees.
                            ShowSuccessMessage(SALARY_success, "The salary of all employees has increased by " + amount);
                        }
                        else
                        {
                            // Execute SQL command to decrease the salary of all employees.
                            SqlCommand decreaseCmd = new SqlCommand("UPDATE employee SET salary = salary - @amount", con);
                            decreaseCmd.Parameters.AddWithValue("@amount", int.Parse(SALARY_amout.Text));
                            decreaseCmd.ExecuteNonQuery();

                            // Display success message for all employees.
                            ShowSuccessMessage(SALARY_success, "The salary of all employees has decreased by " + amount);
                        }
                    }

                    // Check if 'SALARY_singleEmpCheckbox' is checked.
                    if (SALARY_singleEmpCheckbox.Checked)
                    {
                        // Check if 'SALARY_increaseCheckbox' is checked.
                        if (SALARY_increaseCheckbox.Checked)
                        {
                            // Execute SQL command to increase the salary of a single employee.
                            SqlCommand increaseCmd = new SqlCommand("UPDATE employee SET salary = salary + @amount WHERE id = @empId", con);
                            increaseCmd.Parameters.AddWithValue("@amount", int.Parse(SALARY_amout.Text));
                            increaseCmd.Parameters.AddWithValue("@empId", int.Parse(SALARY_emIdInput.Text));
                            increaseCmd.ExecuteNonQuery();

                            // Display success message for the single employee.
                            ShowSuccessMessage(SALARY_success, "The salary of employee with ID " + SALARY_emIdInput.Text + " has increased by " + amount);
                        }
                        else
                        {
                            // Execute SQL command to decrease the salary of a single employee.
                            SqlCommand decreaseCmd = new SqlCommand("UPDATE employee SET salary = salary - @amount WHERE id = @empId", con);
                            decreaseCmd.Parameters.AddWithValue("@amount", int.Parse(SALARY_amout.Text));
                            decreaseCmd.Parameters.AddWithValue("@empId", int.Parse(SALARY_emIdInput.Text));
                            decreaseCmd.ExecuteNonQuery();

                            // Display success message for the single employee.
                            ShowSuccessMessage(SALARY_success, "The salary of employee with ID " + SALARY_emIdInput.Text + " has decreased by " + amount);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Event handler for the text changed in the search input field. Searches and displays employees whose names contain the entered keyword in the data grid.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SEARCH_usernameInput_TextChanged(object sender, EventArgs e)
        {
            // Get the search keyword from 'SEARCH_usernameInput'.
            string searchKeyword = SEARCH_usernameInput.Text.Trim();

            // Open a connection to the database.
            using (SqlConnection con = GetSqlConnection())
            {
                con.Open();

                // Execute SQL command to search for employees whose names contain the entered keyword.
                SqlCommand searchCmd = new SqlCommand("SELECT * FROM employee WHERE empName LIKE @searchKeyword", con);
                searchCmd.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%");

                // Use a data adapter to fill the DataTable with the search results.
                SqlDataAdapter adapter = new SqlDataAdapter(searchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Set the data grid's data source to the DataTable with the search results.
                searchDataGrid.DataSource = dt;
            }
        }


        /// <summary>
        /// Event handler for the log out button click. Logs the user out and navigates back to the login screen.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void logOut_Click(object sender, EventArgs e)
        {
            // Create a new instance of the login form.
            login login = new login();

            // Hide the current form (assuming 'this' refers to the current form).
            this.Hide();

            // Show the login form.
            login.Show();
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
        }

        private void ADD_AddressError_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void incGroupbox_Enter(object sender, EventArgs e)
        {
        }

        private void EditGroupbox_Enter(object sender, EventArgs e)
        {
        }
    }
}
