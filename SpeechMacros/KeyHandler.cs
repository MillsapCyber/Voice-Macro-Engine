using System;
using System.Runtime.InteropServices;
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