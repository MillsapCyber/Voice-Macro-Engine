using System;
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;

namespace SpeechMacros {
    public partial class Form1 : Form {
        private KeyHandler gkh;
        private void setHotkey(string key) {
            try {
                if (gkh != null) {
                    gkh.Unregiser();
                }
                KeysConverter kc = new KeysConverter();
                Keys mykey = (Keys)kc.ConvertFromString(key);
                gkh = new KeyHandler(mykey, this);
                gkh.Register();
                defaultHotkeyLabel.Text = "Default Hotkey: " + key;
            }
            catch (Exception) {
                MessageBox.Show("Please try a real key");
            }

        }
        private static void toggleAlwaysListening(CheckBox box, Label label) {
            Program.globalConfig.alwaysListening = !Program.globalConfig.alwaysListening;
            box.Checked = Program.globalConfig.alwaysListening;
            label.Text = Program.globalConfig.alwaysListening ? "Always Listening (On)" : "Always Listening (Off)";
        }
        public Form1() {    
            InitializeComponent();
            setHotkey(Program.globalConfig.defaultHotkey);
            if (Program.globalConfig.alwaysListening) {
                Program.speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            notifyIcon1.BalloonTipTitle = "Voice Macro Engine";
            notifyIcon1.BalloonTipText = "Running in the background";
            notifyIcon1.Text = "Voice Macro Engine";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = false;
            alwaysListeningLabel.Text = Program.globalConfig.alwaysListening ? "Always Listening (On)" : "Always Listening (Off)";
            defaultHotkeyLabel.Text = "Default Hotkey: " + Program.globalConfig.defaultHotkey;
            foreach (var i in Program.globalConfig.actionObjectList) {
                profileComboBox.Text = "Select a Macro";
                profileComboBox.Items.Add(i);
            }
        }

        private void HandleHotkey() {
            Program.speechRecognizer.RecognizeAsync(RecognizeMode.Single);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID) {
                Console.WriteLine("hooking hotkey");
                HandleHotkey();
            }
            base.WndProc(ref m);
        }

        private void Form1_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState) {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        //private void textBox1_TextChanged(object sender, EventArgs e) {

        //}

        private void SetHotkeyButton_Click(object sender, EventArgs e) {
            setHotkey(hotkeyInput.Text);
            hotkeyInput.Text = "";
        }

        private void alwaysListeningLabel_Click(object sender, EventArgs e) {
            toggleAlwaysListening(alwaysListeningCheckBox, alwaysListeningLabel);
        }

        private void alwaysListeningCheckBox_Click(object sender, EventArgs e) {
            toggleAlwaysListening(alwaysListeningCheckBox, alwaysListeningLabel);
        }

        private void profileComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Action tmp = profileComboBox.SelectedItem as Action;
            programPathLabel.Text = "Program Path: " + tmp.programPath;
            programTargetLabel.Text = "Program Target: " + tmp.programTarget;
            triggerWordLabel.Text = "Trigger Word: " + tmp.triggerWord;
            //if (tmp.programPath != "") {
            //    programPathLabel.Text = "Program Path: " + tmp.programPath;
            //}
            //if (tmp.programTarget != "") {
            //    programTargetLabel.Text = "Program Target: " + tmp.programTarget;
            //}
            actionListBox.Items.Clear();
            foreach (var i in tmp.actionList) {
                actionListBox.Items.Add(i);
            }
        }

        private void programPathLabel_Click(object sender, EventArgs e) {

        }

        private void programPathInput_TextChanged(object sender, EventArgs e) {

        }

        private void setProgramPathButton_Click(object sender, EventArgs e) {
            try {
                if (programPathInput.Text == "") {
                    MessageBox.Show("Please pick a word");
                    return;
                }
                Program.globalConfig.actionObjectList[profileComboBox.SelectedIndex].programPath = programPathInput.Text;
                programPathLabel.Text = "Program Path: " + programPathInput.Text;
                programPathInput.Text = "";
            }
            catch (NullReferenceException) {
                MessageBox.Show("Please select a profile");
            }

        }

        private void triggerWordButton_Click(object sender, EventArgs e) {
            try {
                if (triggerWordInput.Text == "") {
                    MessageBox.Show("Please pick a word");
                    return;
                }
                Program.globalConfig.actionObjectList[profileComboBox.SelectedIndex].triggerWord = triggerWordInput.Text;
                triggerWordLabel.Text = "Trigger Word: " + triggerWordInput.Text;
                triggerWordInput.Text = "";
            }
            catch (NullReferenceException) {
                MessageBox.Show("Please select a profile");
            }
        }

        private void setProgramTargetButton_Click(object sender, EventArgs e) {
            try {
                if (programTargetInput.Text == "") {
                    MessageBox.Show("Please pick a word");
                    return;
                }
                Program.globalConfig.actionObjectList[profileComboBox.SelectedIndex].programTarget = programTargetInput.Text;
                programTargetLabel.Text = "Program Target: " + programTargetInput.Text;
                programTargetInput.Text = "";
            }
            catch (NullReferenceException) {
                MessageBox.Show("Please select a profile");
            }
        }

        private void saveConfigButton_Click(object sender, EventArgs e) {
            Program.saveConfig();
        }
    }
}
