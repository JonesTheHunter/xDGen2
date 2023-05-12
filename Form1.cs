using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IWshRuntimeLibrary;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace xDGen
{
    public partial class Form1 : Form
    {
        readonly Color darkBackgroundColor = Color.FromArgb(40, 40, 40);
        readonly Color lightForegroundColor = Color.FromArgb(240, 240, 240);

        private void SetDarkModeColors()
        {
            this.BackColor = darkBackgroundColor;
            this.ForeColor = lightForegroundColor;

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.ForeColor = Color.Black;
                }
                if (c is Label label && label.Name == "WarningText")
                {
                    c.ForeColor = Color.Yellow;
                }
            }
        }

        private void SetDefaultColors()
        {
            this.BackColor = lightForegroundColor;
            this.ForeColor = darkBackgroundColor;
            foreach (Control c in this.Controls)
            {
                if (c is Label label && label.Name == "WarningText")
                {
                    c.ForeColor = Color.Red;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void CreateDesktopShortcut(string shortcutPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            shortcut.Description = "Generate x number of Digits.";
            shortcut.IconLocation = Application.ExecutablePath + ",0";
            shortcut.Save();
        }

        public static void CopySelectedToClipBoard(ListBox list)
        {
            ListBox lstNames = list;
            if (lstNames.SelectedItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in lstNames.SelectedItems)
                {
                    sb.AppendLine(item.ToString());
                }
                Clipboard.SetText(sb.ToString());
            }
        }

        public static void CopyAllToClipboard(ListBox list)
        {
            ListBox lstNames = list;
            if (lstNames.Items.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in lstNames.Items)
                {
                    sb.AppendLine(item.ToString());
                }
                Clipboard.SetText(sb.ToString());
            }
        }

        public static bool numCheck(KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control character
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
            return e.Handled;
        }

        public static List<string> upcGen(string userPrefix, string userNumToGen)
        {
            int numToGen = int.Parse(userNumToGen);
            int digitsLeft = 12 - userPrefix.Length;
            int maxValue = (int)Math.Pow(10, digitsLeft);
            int minValue = (int)Math.Pow(10, (digitsLeft - 1));
            int availableSlots = Math.Max(10 - userPrefix.Length, 0);
            Random rnd = new();
            string genCode;
            List<string> CodesList = new List<string>();


            if (int.Parse(userPrefix) == 0)
            {
                int i = 0;
                while (i < numToGen)
                {
                    long x = rnd.Next(100000, 999999);
                    long y = rnd.Next(100000, 999999);
                    genCode = x.ToString() + y.ToString();
                    if (!CodesList.Contains(genCode))
                    {
                        CodesList.Add(genCode);
                        i++;
                    }
                }
            }
            else
            {
                int i = 0;
                while (i < numToGen)
                {
                    long x = rnd.Next(0, maxValue);
                    string dx = "D" + digitsLeft;
                    genCode = userPrefix + x.ToString(dx);
                    if (!CodesList.Contains(genCode))
                    {
                        CodesList.Add(genCode);
                        i++;
                    }
                    
                }
            }

            return CodesList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstNames.Items.Clear();
            foreach (string code in upcGen(prefixCodes.Text, numCodes.Text))
            {
                lstNames.Items.Add(code);
            }
        }

        private void lstNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            { CopySelectedToClipBoard(lstNames); }
        }

        private void copySelect_Click(object sender, EventArgs e) => CopySelectedToClipBoard(lstNames);

        private void copyAll_Click(object sender, EventArgs e) => CopyAllToClipboard(lstNames);

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "xDGen.lnk");

            string flagPath = Path.Combine(Application.StartupPath, "stj.dh");
            bool shortcutCreated = System.IO.File.Exists(flagPath);

            if (!shortcutCreated)
            {
                CreateDesktopShortcut(shortcutPath);
                using (FileStream fileStream = System.IO.File.Create(flagPath))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine("You shouldn't be in here...");
                    }
                };
            }
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDarkMode.Checked)
            {
                SetDarkModeColors();
            }
            else
            {
                SetDefaultColors();
            }
        }

        private void prefixCodes_TextChanged(object sender, EventArgs e)
        {
            int minLength = 6;
            int maxLength = 10;

            if (string.IsNullOrWhiteSpace(prefixCodes.Text))
            {
                btnGen.Enabled = false;
            }

            if (int.TryParse(prefixCodes.Text, out int number))
            {
                if (number == 0 || number >= Math.Pow(10, minLength - 1) && number < Math.Pow(10, maxLength))
                {
                    btnGen.Enabled = true;
                }
                else
                {
                    btnGen.Enabled = false;
                }
            }
        }

        private void prefixCodes_KeyPress(object sender, KeyPressEventArgs e)
        {
            numCheck(e);
        }

        private void numCodes_KeyPress(object sender, KeyPressEventArgs e)
        {
            numCheck(e);
        }

        private void numCodes_TextChanged(object sender, EventArgs e)
        {
            int digitsLeft = 12 - prefixCodes.Text.Length;
            int maxValue = (int)Math.Pow(10, digitsLeft);

            if (string.IsNullOrWhiteSpace(numCodes.Text))
            {
                btnGen.Enabled = false;
            }
            else if (int.Parse(numCodes.Text) <= 0)
            {
                btnGen.Enabled = false;
            }
            else if (prefixCodes.Text != "0" && numCodes.Text.Length >= maxValue.ToString().Length)
            {
                btnGen.Enabled = false; 
            }
            else
            { 
                btnGen.Enabled = true;
            }

            if (numCodes.Text.Length >= 5)
            {
                WarningText.Location = new Point(155, 135);
                WarningText.Text = "WARNING: May be unstable.";
            }
            else
            {
                WarningText.Location = new Point(146, 135);
                WarningText.Text = "";
            }
        }
    }
}
