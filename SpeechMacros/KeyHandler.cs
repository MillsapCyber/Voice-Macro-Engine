using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public class KeyHandler {
    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    private int key;
    private IntPtr hWnd;
    private int id;

    public KeyHandler(Keys key, Form form) {
        this.key = (int)key;
        this.hWnd = form.Handle;
        id = this.GetHashCode();
    }

    public override int GetHashCode() {
        return key ^ hWnd.ToInt32();
    }

    public bool Register() {
        return RegisterHotKey(hWnd, id, 0, key);
    }

    public bool Unregiser() {
        return UnregisterHotKey(hWnd, id);
    }

    [DllImport("user32.dll")]
    static extern int SetForegroundWindow(IntPtr point);

    public static void injectKeystroke(string appTargetName, bool isDown, byte key) {
        var targetParent = Process.GetProcessesByName(appTargetName);
        var currentParent = Process.GetProcessesByName(getCurrentAppName());
        Process target = Process.GetProcessesByName(appTargetName).FirstOrDefault();
        IntPtr targetHandle = target.MainWindowHandle;
        Process current = Process.GetProcessesByName(getCurrentAppName()).FirstOrDefault();
        IntPtr currentHandle = current.MainWindowHandle;

        foreach (var i in currentParent) {
            if (i.MainWindowTitle != "") {
                currentHandle = i.MainWindowHandle;
                break;
            }
        }
        if (target != null) {
            foreach (var i in targetParent) {
                if (i.MainWindowTitle != "") {
                    targetHandle = i.MainWindowHandle;
                    break;
                }
            }
            SetForegroundWindow(targetHandle);
            //must let windows catch up, can't switch context instantly
            Thread.Sleep(10);
            if (isDown) {
                keyDown(key);
            }
            else {
                keyUp(key);
            }
            //must let windows catch up, can't switch context instantly
            Thread.Sleep(10);
            SetForegroundWindow(currentHandle);
        }
    }
    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    public static string getCurrentAppName() {
        IntPtr hWnd = GetForegroundWindow();
        uint procId = 0;
        GetWindowThreadProcessId(hWnd, out procId);
        var proc = Process.GetProcessById((int)procId);
        try {
            Console.WriteLine("Current application: " + proc.MainModule.ModuleName.Substring(0, proc.MainModule.ModuleName.LastIndexOf(".exe")));
        } catch {
            Console.WriteLine("Current application: " + proc.MainModule.ModuleName);
            return proc.MainModule.ModuleName;
        }
        return proc.MainModule.ModuleName.Substring(0,proc.MainModule.ModuleName.LastIndexOf(".exe"));
    }


    [DllImport("user32.dll", SetLastError = true)]
    static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    const int KEY_DOWN_EVENT = 0x0001; //Key down flag
    const int KEY_UP_EVENT = 0x0002; //Key up flag

    public static void keyDown(byte key) {
        keybd_event(key, 0, KEY_DOWN_EVENT, 0);
    }
    public static void keyUp(byte key) {
        keybd_event(key, 0, KEY_UP_EVENT, 0);
    }
    public static void HoldKey(byte key, int duration) {
        keybd_event(key, 0, KEY_DOWN_EVENT, 0);
        System.Threading.Thread.Sleep(duration);
        keybd_event(key, 0, KEY_UP_EVENT, 0);
    }

}