namespace xDGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnGen = new Button();
            label1 = new Label();
            lstNames = new ListBox();
            numCodes = new TextBox();
            label2 = new Label();
            label3 = new Label();
            prefixCodes = new TextBox();
            copySelect = new Button();
            copyAll = new Button();
            chkDarkMode = new CheckBox();
            label4 = new Label();
            WarningText = new Label();
            SuspendLayout();
            // 
            // btnGen
            // 
            btnGen.AutoSize = true;
            btnGen.Location = new Point(138, 186);
            btnGen.Name = "btnGen";
            btnGen.Size = new Size(182, 25);
            btnGen.TabIndex = 3;
            btnGen.Text = "Generate";
            btnGen.UseVisualStyleBackColor = true;
            btnGen.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Codes";
            // 
            // lstNames
            // 
            lstNames.FormattingEnabled = true;
            lstNames.ItemHeight = 15;
            lstNames.Location = new Point(12, 27);
            lstNames.Name = "lstNames";
            lstNames.SelectionMode = SelectionMode.MultiExtended;
            lstNames.Size = new Size(120, 184);
            lstNames.TabIndex = 2;
            lstNames.KeyDown += lstNames_KeyDown;
            // 
            // numCodes
            // 
            numCodes.Location = new Point(221, 107);
            numCodes.Name = "numCodes";
            numCodes.Size = new Size(100, 23);
            numCodes.TabIndex = 2;
            numCodes.Text = "1";
            numCodes.TextAlign = HorizontalAlignment.Right;
            numCodes.TextChanged += numCodes_TextChanged;
            numCodes.KeyPress += numCodes_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 110);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 4;
            label2.Text = "Num. Codes:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 59);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 5;
            label3.Text = "Prefix ID:";
            // 
            // prefixCodes
            // 
            prefixCodes.Location = new Point(221, 51);
            prefixCodes.MaxLength = 10;
            prefixCodes.Name = "prefixCodes";
            prefixCodes.Size = new Size(100, 23);
            prefixCodes.TabIndex = 6;
            prefixCodes.Text = "0";
            prefixCodes.TextAlign = HorizontalAlignment.Right;
            prefixCodes.TextChanged += prefixCodes_TextChanged;
            prefixCodes.KeyPress += prefixCodes_KeyPress;
            // 
            // copySelect
            // 
            copySelect.Location = new Point(154, 157);
            copySelect.Name = "copySelect";
            copySelect.Size = new Size(76, 23);
            copySelect.TabIndex = 7;
            copySelect.Text = "Copy Selected";
            copySelect.UseVisualStyleBackColor = true;
            copySelect.Click += copySelect_Click;
            // 
            // copyAll
            // 
            copyAll.Location = new Point(236, 157);
            copyAll.Name = "copyAll";
            copyAll.Size = new Size(75, 23);
            copyAll.TabIndex = 8;
            copyAll.Text = "Copy All";
            copyAll.UseVisualStyleBackColor = true;
            copyAll.Click += copyAll_Click;
            // 
            // chkDarkMode
            // 
            chkDarkMode.AutoSize = true;
            chkDarkMode.Location = new Point(237, 9);
            chkDarkMode.Name = "chkDarkMode";
            chkDarkMode.Size = new Size(84, 19);
            chkDarkMode.TabIndex = 9;
            chkDarkMode.Text = "Dark Mode";
            chkDarkMode.UseVisualStyleBackColor = true;
            chkDarkMode.CheckedChanged += chkDarkMode_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(168, 82);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 10;
            label4.Text = "6-10 Digits | 0 = Random";
            // 
            // WarningText
            // 
            WarningText.AutoSize = true;
            WarningText.ForeColor = Color.Red;
            WarningText.Location = new Point(146, 135);
            WarningText.Name = "WarningText";
            WarningText.Size = new Size(0, 15);
            WarningText.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 223);
            Controls.Add(WarningText);
            Controls.Add(label4);
            Controls.Add(chkDarkMode);
            Controls.Add(copyAll);
            Controls.Add(copySelect);
            Controls.Add(prefixCodes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numCodes);
            Controls.Add(lstNames);
            Controls.Add(label1);
            Controls.Add(btnGen);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Gen";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGen;
        private Label label1;
        private ListBox lstNames;
        private TextBox numCodes;
        private Label label2;
        private Label label3;
        private TextBox prefixCodes;
        private Button copySelect;
        private Button copyAll;
        private CheckBox chkDarkMode;
        private Label label4;
        private Label WarningText;
    }
}