namespace employee
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShowConfirmPassword = new System.Windows.Forms.CheckBox();
            this.ConfirmPasswordInput = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordErrorText = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PasswordErrorText = new System.Windows.Forms.Label();
            this.userNameErrorText = new System.Windows.Forms.Label();
            this.ShowPassword = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(24)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 37);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee management system";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(24)))), ((int)(((byte)(64)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(837, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 37);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Register";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ShowConfirmPassword);
            this.panel2.Controls.Add(this.ConfirmPasswordInput);
            this.panel2.Controls.Add(this.ConfirmPasswordErrorText);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.PasswordErrorText);
            this.panel2.Controls.Add(this.userNameErrorText);
            this.panel2.Controls.Add(this.ShowPassword);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.LoginBtn);
            this.panel2.Controls.Add(this.PasswordInput);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.UserInput);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(183, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 345);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ShowConfirmPassword
            // 
            this.ShowConfirmPassword.AutoSize = true;
            this.ShowConfirmPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.ShowConfirmPassword.Location = new System.Drawing.Point(366, 214);
            this.ShowConfirmPassword.Name = "ShowConfirmPassword";
            this.ShowConfirmPassword.Size = new System.Drawing.Size(55, 17);
            this.ShowConfirmPassword.TabIndex = 13;
            this.ShowConfirmPassword.Text = "Show";
            this.ShowConfirmPassword.UseVisualStyleBackColor = true;
            this.ShowConfirmPassword.CheckedChanged += new System.EventHandler(this.ShowConfirmPassword_CheckedChanged);
            // 
            // ConfirmPasswordInput
            // 
            this.ConfirmPasswordInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(35)))), ((int)(((byte)(64)))));
            this.ConfirmPasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPasswordInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordInput.ForeColor = System.Drawing.Color.White;
            this.ConfirmPasswordInput.HideSelection = false;
            this.ConfirmPasswordInput.Location = new System.Drawing.Point(132, 207);
            this.ConfirmPasswordInput.Name = "ConfirmPasswordInput";
            this.ConfirmPasswordInput.PasswordChar = '*';
            this.ConfirmPasswordInput.Size = new System.Drawing.Size(299, 29);
            this.ConfirmPasswordInput.TabIndex = 16;
            this.ConfirmPasswordInput.TextChanged += new System.EventHandler(this.ConfirmPasswordInput_TextChanged);
            // 
            // ConfirmPasswordErrorText
            // 
            this.ConfirmPasswordErrorText.AutoSize = true;
            this.ConfirmPasswordErrorText.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmPasswordErrorText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordErrorText.ForeColor = System.Drawing.Color.Red;
            this.ConfirmPasswordErrorText.Location = new System.Drawing.Point(134, 241);
            this.ConfirmPasswordErrorText.Name = "ConfirmPasswordErrorText";
            this.ConfirmPasswordErrorText.Size = new System.Drawing.Size(0, 17);
            this.ConfirmPasswordErrorText.TabIndex = 15;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(102, 207);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(129, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Confirm password";
            // 
            // PasswordErrorText
            // 
            this.PasswordErrorText.AutoSize = true;
            this.PasswordErrorText.BackColor = System.Drawing.Color.Transparent;
            this.PasswordErrorText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordErrorText.ForeColor = System.Drawing.Color.Red;
            this.PasswordErrorText.Location = new System.Drawing.Point(134, 155);
            this.PasswordErrorText.Name = "PasswordErrorText";
            this.PasswordErrorText.Size = new System.Drawing.Size(0, 17);
            this.PasswordErrorText.TabIndex = 9;
            // 
            // userNameErrorText
            // 
            this.userNameErrorText.AutoSize = true;
            this.userNameErrorText.BackColor = System.Drawing.Color.Transparent;
            this.userNameErrorText.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameErrorText.ForeColor = System.Drawing.Color.Red;
            this.userNameErrorText.Location = new System.Drawing.Point(134, 68);
            this.userNameErrorText.Name = "userNameErrorText";
            this.userNameErrorText.Size = new System.Drawing.Size(0, 17);
            this.userNameErrorText.TabIndex = 5;
            this.userNameErrorText.Click += new System.EventHandler(this.label5_Click);
            // 
            // ShowPassword
            // 
            this.ShowPassword.AutoSize = true;
            this.ShowPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowPassword.ForeColor = System.Drawing.Color.White;
            this.ShowPassword.Location = new System.Drawing.Point(366, 127);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(55, 17);
            this.ShowPassword.TabIndex = 8;
            this.ShowPassword.Text = "Show";
            this.ShowPassword.UseVisualStyleBackColor = true;
            this.ShowPassword.CheckedChanged += new System.EventHandler(this.ShowPassword_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(102, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(102, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel1.Location = new System.Drawing.Point(187, 319);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(167, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Already have an account? login";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.Transparent;
            this.LoginBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoginBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.LoginBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.Location = new System.Drawing.Point(187, 277);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(167, 39);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // PasswordInput
            // 
            this.PasswordInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(35)))), ((int)(((byte)(64)))));
            this.PasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.ForeColor = System.Drawing.Color.White;
            this.PasswordInput.HideSelection = false;
            this.PasswordInput.Location = new System.Drawing.Point(132, 121);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(299, 29);
            this.PasswordInput.TabIndex = 5;
            this.PasswordInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(129, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // UserInput
            // 
            this.UserInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.UserInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(35)))), ((int)(((byte)(64)))));
            this.UserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInput.ForeColor = System.Drawing.Color.White;
            this.UserInput.HideSelection = false;
            this.UserInput.Location = new System.Drawing.Point(132, 34);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(299, 29);
            this.UserInput.TabIndex = 3;
            this.UserInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(129, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(878, 456);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 493);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ConfirmPasswordErrorText;
        private System.Windows.Forms.CheckBox ShowConfirmPassword;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label PasswordErrorText;
        private System.Windows.Forms.Label userNameErrorText;
        private System.Windows.Forms.CheckBox ShowPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UserInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox ConfirmPasswordInput;
    }
}

