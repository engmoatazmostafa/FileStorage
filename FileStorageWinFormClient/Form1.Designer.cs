namespace FileStorageWinFormClient
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameTxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            passwordTxt = new TextBox();
            baseURLTxt = new TextBox();
            button1 = new Button();
            tokenTxt = new TextBox();
            filePathLbl = new Label();
            browseBtn = new Button();
            SuspendLayout();
            // 
            // usernameTxt
            // 
            usernameTxt.Location = new Point(409, 78);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(355, 27);
            usernameTxt.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(264, 87);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 1;
            label1.Text = "username";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 139);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 2;
            label2.Text = "password";
            label2.Click += label2_Click;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(409, 142);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(355, 27);
            passwordTxt.TabIndex = 3;
            // 
            // baseURLTxt
            // 
            baseURLTxt.Location = new Point(270, 38);
            baseURLTxt.Name = "baseURLTxt";
            baseURLTxt.Size = new Size(499, 27);
            baseURLTxt.TabIndex = 4;
            baseURLTxt.Text = "http://localhost:5027/";
            baseURLTxt.TextChanged += baseURLTxt_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(272, 215);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tokenTxt
            // 
            tokenTxt.Location = new Point(45, 271);
            tokenTxt.Name = "tokenTxt";
            tokenTxt.Size = new Size(941, 27);
            tokenTxt.TabIndex = 6;
            // 
            // filePathLbl
            // 
            filePathLbl.AutoSize = true;
            filePathLbl.Location = new Point(97, 396);
            filePathLbl.Name = "filePathLbl";
            filePathLbl.Size = new Size(64, 20);
            filePathLbl.TabIndex = 7;
            filePathLbl.Text = "file path";
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(97, 325);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(94, 29);
            browseBtn.TabIndex = 8;
            browseBtn.Text = "browse";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 674);
            Controls.Add(browseBtn);
            Controls.Add(filePathLbl);
            Controls.Add(tokenTxt);
            Controls.Add(button1);
            Controls.Add(baseURLTxt);
            Controls.Add(passwordTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(usernameTxt);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTxt;
        private Label label1;
        private Label label2;
        private TextBox passwordTxt;
        private TextBox baseURLTxt;
        private Button button1;
        private TextBox tokenTxt;
        private Label filePathLbl;
        private Button browseBtn;
    }
}
