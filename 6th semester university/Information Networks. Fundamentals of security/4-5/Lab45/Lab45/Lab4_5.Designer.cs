namespace Lab45
{
    partial class Lab4_5
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            login_text = new TextBox();
            password_text = new TextBox();
            authorize = new Button();
            leave = new Button();
            input_text = new TextBox();
            message = new Button();
            output_text = new TextBox();
            clear = new Button();
            attackCheckedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // login_text
            // 
            login_text.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            login_text.Location = new Point(12, 13);
            login_text.Margin = new Padding(3, 4, 3, 4);
            login_text.Name = "login_text";
            login_text.Size = new Size(98, 24);
            login_text.TabIndex = 1;
            // 
            // password_text
            // 
            password_text.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            password_text.Location = new Point(121, 13);
            password_text.Margin = new Padding(3, 4, 3, 4);
            password_text.Name = "password_text";
            password_text.Size = new Size(93, 24);
            password_text.TabIndex = 3;
            // 
            // authorize
            // 
            authorize.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            authorize.Location = new Point(225, 13);
            authorize.Margin = new Padding(3, 4, 3, 4);
            authorize.Name = "authorize";
            authorize.Size = new Size(98, 24);
            authorize.TabIndex = 5;
            authorize.Text = "SignIn";
            authorize.UseVisualStyleBackColor = true;
            authorize.Click += Authorize_Click;
            // 
            // leave
            // 
            leave.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            leave.Location = new Point(334, 13);
            leave.Margin = new Padding(3, 4, 3, 4);
            leave.Name = "leave";
            leave.Size = new Size(93, 24);
            leave.TabIndex = 6;
            leave.Text = "SignOut";
            leave.UseVisualStyleBackColor = true;
            leave.Click += Leave_Clicked;
            // 
            // input_text
            // 
            input_text.Location = new Point(225, 45);
            input_text.Margin = new Padding(3, 4, 3, 4);
            input_text.Name = "input_text";
            input_text.Size = new Size(98, 27);
            input_text.TabIndex = 7;
            // 
            // message
            // 
            message.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            message.Location = new Point(334, 45);
            message.Margin = new Padding(3, 4, 3, 4);
            message.Name = "message";
            message.Size = new Size(93, 26);
            message.TabIndex = 8;
            message.Text = "Send";
            message.UseVisualStyleBackColor = true;
            message.Click += Message_Click;
            // 
            // output_text
            // 
            output_text.Location = new Point(225, 79);
            output_text.Margin = new Padding(3, 4, 3, 4);
            output_text.Multiline = true;
            output_text.Name = "output_text";
            output_text.ReadOnly = true;
            output_text.Size = new Size(202, 143);
            output_text.TabIndex = 9;
            // 
            // clear
            // 
            clear.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            clear.Location = new Point(225, 230);
            clear.Margin = new Padding(3, 4, 3, 4);
            clear.Name = "clear";
            clear.Size = new Size(202, 26);
            clear.TabIndex = 10;
            clear.Text = "clear";
            clear.UseVisualStyleBackColor = true;
            // 
            // attackCheckedListBox1
            // 
            attackCheckedListBox1.BackColor = SystemColors.AppWorkspace;
            attackCheckedListBox1.BorderStyle = BorderStyle.None;
            attackCheckedListBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            attackCheckedListBox1.FormattingEnabled = true;
            attackCheckedListBox1.Items.AddRange(new object[] { "XSS", "DOS", "Buffer overflow", "Canonization Error", "Privilege minimization" });
            attackCheckedListBox1.Location = new Point(12, 45);
            attackCheckedListBox1.Margin = new Padding(2);
            attackCheckedListBox1.Name = "attackCheckedListBox1";
            attackCheckedListBox1.Size = new Size(202, 210);
            attackCheckedListBox1.TabIndex = 12;
            // 
            // Lab4_5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(442, 270);
            Controls.Add(attackCheckedListBox1);
            Controls.Add(clear);
            Controls.Add(output_text);
            Controls.Add(message);
            Controls.Add(input_text);
            Controls.Add(leave);
            Controls.Add(authorize);
            Controls.Add(password_text);
            Controls.Add(login_text);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Lab4_5";
            Text = "Lab45";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox login_text;
        private TextBox password_text;
        private Button authorize;
        private Button leave;
        private TextBox input_text;
        private Button message;
        private TextBox output_text;
        private Button clear;
        private CheckedListBox attackCheckedListBox1;
    }
}