using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechMacros
{
    public partial class Form1 : Form
    {
        private KeyHandler gkh;
        public Form1()
        {
            InitializeComponent();
            gkh = new KeyHandler(Keys.F11, this);
            gkh.Register();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void HandleHotkey() {
            Program.speechRecognizer.RecognizeAsync(RecognizeMode.Single);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
    }
}
