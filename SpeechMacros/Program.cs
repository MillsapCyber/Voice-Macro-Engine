using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Runtime.InteropServices;
using System.Threading;

namespace SpeechMacros {

    static class Program {
        public static SpeechRecognitionEngine speechRecognizer = new SpeechRecognitionEngine();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main() {
            speechRecognizer.SpeechRecognized += speechRecognizer_SpeechRecognized;
            speechRecognizer.SetInputToDefaultAudioDevice();
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            Choices triggerWords = new Choices("begin", "end");
            grammarBuilder.Append(triggerWords);
            speechRecognizer.LoadGrammar(new Grammar(grammarBuilder));
            //double weight, if you don't do this you'll have tons of false positives
            speechRecognizer.LoadGrammar(new DictationGrammar());

            //always listening
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        // [DllImport("user32.dll")];
        private static void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
            string command = e.Result.Words[0].Text.ToLower();
            Console.WriteLine(e.Result.Words[0].Confidence + command);
            if (e.Result.Words[0].Confidence < 0.85f) {
                return;
            }
            switch (command) {
                case "begin":
                    // Press windows key
                    SendKeys.SendWait("^{ESC}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("Connor Goldsmith");
                    break;
                case "end":
                    SendKeys.SendWait("{ESC}");
                    break;
                default:
                    //do nothing
                    break;
            }
        }
    }
}