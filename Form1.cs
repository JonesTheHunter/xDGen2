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
            }
        }

        private void SetDefaultColors()
        {
            this.BackColor = lightForegroundColor;
            this.ForeColor = darkBackgroundColor;
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

        public static List<long> upcGen(string userPrefix, string userNumToGen)
        {
            int prefix = int.Parse(userPrefix);
            int numToGen = int.Parse(userNumToGen);

            Random ranNum = new();
            List<long> codeList = new();

            for (int i = 0; i < numToGen; i++)
            {
                int[] genCode = new int[12];

                if (prefix != 0)
                {
                    // Convert prefix to string and add to code array
                    string prefixString = prefix.ToString("D6");
                    for (int j = 0; j < 6; j++)
                    {
                        genCode[j] = int.Parse(prefixString[j].ToString());
                    }
                }

                // Generate remaining digits
                for (int num = prefix != 0 ? 6 : 0; num < 12; num++)
                {
                    genCode[num] = ranNum.Next(0, 10);
                }

                // Check that code has 12 digits
                long code = long.Parse(string.Join("", genCode));
                while (code.ToString().Length < 12)
                {
                    // Add 1 to last digit and carry over to previous digit
                    for (int num = 11; num >= 0; num--)
                    {
                        if (genCode[num] == 9)
                        {
                            genCode[num] = 0;
                        }
                        else
                        {
                            genCode[num]++;
                            break;
                        }
                    }
                    code = long.Parse(string.Join("", genCode));
                }

                codeList.Add(code);
            }
            return codeList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstNames.Items.Clear();
            foreach (long code in upcGen(prefixCodes.Text, numCodes.Text))
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
    }
}
