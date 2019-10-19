using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace SpeechMacros {
    public class Config {
        public string defaultHotkey { get; set; }
        public bool alwaysListening { get; set; }
        public List<Action> actionObjectList { get; set; }
        public Config(string dhk, bool alb, List<Action> al) {
            defaultHotkey = dhk;
            alwaysListening = alb;
            actionObjectList = al;
        }

    }
    public class Action {
        public string profileName { get; set; }
        public string triggerWord { get; set; }
        public string programPath { get; set; }
        public string programArgs { get; set; }
        public string programTarget { get; set; }
        public List<(actionType type, string aciton)> actionList { get; set; }
        public enum actionType {
            keyDown,
            keyUp,
            waitStatic,
            waitRandom
        }
        public Action(string trigger) {
            triggerWord = trigger;
            programPath = "";
            actionList = new List<(actionType type, string aciton)>();
        }
        public override string ToString() {
            return profileName;
        }

    }
    class Program {
        public static SpeechRecognitionEngine speechRecognizer = new SpeechRecognitionEngine();
        public static Config globalConfig;
        //public static List<Action> globalActionObjectList = new List<Action>();
        [STAThread]
        static void Main() {
            globalConfig = loadConfig();
            ////start building first action

            //Action a = new Action("begin");
            //var tmp = (Action.actionType.keyDown, "^{ESC}");
            //a.actionList.Add(tmp);
            //tmp = (Action.actionType.waitStatic, "1000");
            //a.actionList.Add(tmp);
            //tmp = (Action.actionType.keyDown, "Hello World");
            //a.actionList.Add(tmp);
            //globalActionObjectList.Add(a);

            ////stop building first action

            //a = new Action("end");
            //tmp = (Action.actionType.keyDown, "{ESC}");
            //a.actionList.Add(tmp);
            //globalActionObjectList.Add(a);
            //a = new Action("telegram");
            //globalActionObjectList.Add(a);
            //globalConfig = new Config("F1", false, globalActionObjectList);
            ////Save file
            //saveConfig();
            ProcessStartInfo procStart = new ProcessStartInfo();
            speechRecognizer.SpeechRecognized += speechRecognizer_SpeechRecognized;
            speechRecognizer.SetInputToDefaultAudioDevice();
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            Choices triggerWords = new Choices(parseGramar(globalConfig.actionObjectList));
            grammarBuilder.Append(triggerWords);
            speechRecognizer.LoadGrammar(new Grammar(grammarBuilder));
            //double weight, if you don't do this you'll have tons of false positives
            speechRecognizer.LoadGrammar(new DictationGrammar());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static string[] parseGramar(List<Action> data) {
            List<String> tmp = new List<String>();
            foreach(var i in data) {
                tmp.Add(i.triggerWord);
            }
            return tmp.ToArray();
        }
        private static void runMacro(List<(Action.actionType type, string aciton)> actions) {
            KeysConverter kc = new KeysConverter();
            foreach (var i in actions) {
                switch (i.type) {
                    case Action.actionType.keyDown:
                        //SendKeys.SendWait(i.aciton);
                        KeyHandler.keyDown((byte)(Keys)kc.ConvertFromString(i.aciton));
                        break;
                    case Action.actionType.keyUp:
                        KeyHandler.keyUp((byte)(Keys)kc.ConvertFromString(i.aciton));
                        break;
                    case Action.actionType.waitStatic:
                        Thread.Sleep(Int32.Parse(i.aciton));
                        break;
                    case Action.actionType.waitRandom:
                        break;
                    default:
                        break;
                }
            }
        }

        private static void runInjection(List<(Action.actionType type, string aciton)> actions, string target) {
            KeysConverter kc = new KeysConverter();
            foreach (var i in actions) {
                switch (i.type) {
                    case Action.actionType.keyDown:
                        KeyHandler.injectKeystroke(target, true, (byte)(Keys)kc.ConvertFromString(i.aciton));
                        break;
                    case Action.actionType.keyUp:
                        KeyHandler.injectKeystroke(target, false, (byte)(Keys)kc.ConvertFromString(i.aciton));
                        break;
                    default:
                        break;
                }
            }
        }

       private static void runExternalProgram(string Args, string Program) {
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = Args;
            // Enter the executable to run, including the complete path
            start.FileName = Program;
            // uncomment if you want to run the program in the background
            //start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            int exitCode;
            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start)) {
                proc.WaitForExit();
                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
       }
        private static void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) {
            string command = e.Result.Words[0].Text.ToLower();
            Console.WriteLine(e.Result.Words[0].Confidence + command);
            if (e.Result.Words[0].Confidence < 0.85f) {
                return;
            }
            foreach (var i in globalConfig.actionObjectList) {
                if (i.triggerWord == command) {
                    Console.WriteLine("found valid command " + command);
                    if (i.programTarget != "" && i.actionList.Count > 0) {
                        runInjection(i.actionList, i.programTarget);
                    }
                    else if (i.programPath != "") {
                        runExternalProgram(i.programArgs, i.programPath);
                    }
                    else if (i.actionList.Count > 0) {
                        runMacro(i.actionList);
                    }
                }
            }
        }

        public static Config loadConfig() {
            string dir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("SpeechMacros")) + "SpeechMacros\\config.json";
            //load file
            try {
                using (StreamReader file = File.OpenText(@dir)) {
                    JsonSerializer serializer = new JsonSerializer();
                    return (Config)serializer.Deserialize(file, typeof(Config));
                }
            }
            catch (Exception) {
                Console.WriteLine("failed to load config file");
                return null;
            }
        }
        public static void saveConfig() {
            string dir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("SpeechMacros")) + "SpeechMacros\\config.json";
            //Save file
            using (StreamWriter file = File.CreateText(@dir)) {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, globalConfig);
            }
        }
    }
}