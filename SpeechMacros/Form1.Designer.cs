namespace SpeechMacros
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.hotkeyInput = new System.Windows.Forms.TextBox();
            this.SetHotkeyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // hotkeyInput
            // 
            this.hotkeyInput.Location = new System.Drawing.Point(104, 22);
            this.hotkeyInput.Name = "hotkeyInput";
            this.hotkeyInput.Size = new System.Drawing.Size(100, 20);
            this.hotkeyInput.TabIndex = 0;
            this.hotkeyInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SetHotkeyButton
            // 
            this.SetHotkeyButton.Location = new System.Drawing.Point(23, 22);
            this.SetHotkeyButton.Name = "SetHotkeyButton";
            this.SetHotkeyButton.Size = new System.Drawing.Size(75, 23);
            this.SetHotkeyButton.TabIndex = 1;
            this.SetHotkeyButton.Text = "Set Hotkey";
            this.SetHotkeyButton.UseVisualStyleBackColor = true;
            this.SetHotkeyButton.Click += new System.EventHandler(this.SetHotkeyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(237, 66);
            this.Controls.Add(this.SetHotkeyButton);
            this.Controls.Add(this.hotkeyInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Voice Macro Engine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox hotkeyInput;
        private System.Windows.Forms.Button SetHotkeyButton;
    }
}

