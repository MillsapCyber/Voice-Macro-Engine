using System;
using System.Speech.Recognition;
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
            }
            catch (Exception) {
                MessageBox.Show("Please try a real key");
            }

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
    }
}
