﻿using System;
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
        Process target = Process.GetProcessesByName(appTargetName).FirstOrDefault();
        Process current = Process.GetProcessesByName(getCurrentAppName()).FirstOrDefault();
        if (target != null) {
            IntPtr targetHandle = target.MainWindowHandle;
            SetForegroundWindow(targetHandle);
            if (getCurrentAppName() != appTargetName) { 
                Console.WriteLine("Did not switch to target app correctly. Falling back to ALT + TAB");
                SendKeys.SendWait("%{Tab}");
                Thread.Sleep(100);
            }
            //must let windows catch up, can't switch context instantly
            Thread.Sleep(10);
            if (isDown) {
                keyDown(key);
            }
            else {
                keyUp(key);
            }
            try {
                IntPtr currentHandle = current.MainWindowHandle;
                SetForegroundWindow(currentHandle);
                if (getCurrentAppName() == appTargetName) { //Not sure why but sometimes this doesn't crash but still won't reset the original window
                    Console.WriteLine("original app was not reset correctly. Falling back to ALT + TAB");
                    Thread.Sleep(100);
                    SendKeys.SendWait("%{Tab}");

                }
            } catch { //Not sure why this fails sometimes but if it does do it the stupid way
                Thread.Sleep(100);
                SendKeys.SendWait("%{Tab}");
            }
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