using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechMacros {
    public partial class Form1 : Form {
        private KeyHandler gkh;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            notifyIcon1.BalloonTipTitle = "Voice Macro Engine";
            notifyIcon1.BalloonTipText = "Running in the background";
            notifyIcon1.Text = "Voice Macro Engine";
            notifyIcon1.Icon = this.Icon;

        }

        private void button1_Click(object sender, EventArgs e) {

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

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void SetHotkeyButton_Click(object sender, EventArgs e) {
            try {
                if (gkh != null) {
                    gkh.Unregiser();
                }
                KeysConverter kc = new KeysConverter();
                var testkey = Keys.F11;
                Keys mykey = (Keys)kc.ConvertFromString(hotkeyInput.Text);
                gkh = new KeyHandler(mykey, this);
                gkh.Register();
            }
            catch (ArgumentException) {
                MessageBox.Show("Please try a real key");
            }
            hotkeyInput.Text = "";
        }
    }
}
