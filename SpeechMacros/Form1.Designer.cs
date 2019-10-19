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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.hotkeyInput = new System.Windows.Forms.TextBox();
            this.setHotkeyButton = new System.Windows.Forms.Button();
            this.actionListBox = new System.Windows.Forms.ListBox();
            this.alwaysListeningCheckBox = new System.Windows.Forms.CheckBox();
            this.alwaysListeningLabel = new System.Windows.Forms.Label();
            this.defaultHotkeyLabel = new System.Windows.Forms.Label();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.programPathLabel = new System.Windows.Forms.Label();
            this.programPathInput = new System.Windows.Forms.TextBox();
            this.programTargetLabel = new System.Windows.Forms.Label();
            this.programTargetInput = new System.Windows.Forms.TextBox();
            this.setProgramPathButton = new System.Windows.Forms.Button();
            this.setProgramTargetButton = new System.Windows.Forms.Button();
            this.triggerWordLabel = new System.Windows.Forms.Label();
            this.triggerWordButton = new System.Windows.Forms.Button();
            this.triggerWordInput = new System.Windows.Forms.TextBox();
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
            this.hotkeyInput.Location = new System.Drawing.Point(127, 52);
            this.hotkeyInput.Name = "hotkeyInput";
            this.hotkeyInput.Size = new System.Drawing.Size(166, 20);
            this.hotkeyInput.TabIndex = 0;
            // 
            // setHotkeyButton
            // 
            this.setHotkeyButton.Location = new System.Drawing.Point(23, 50);
            this.setHotkeyButton.Name = "setHotkeyButton";
            this.setHotkeyButton.Size = new System.Drawing.Size(98, 23);
            this.setHotkeyButton.TabIndex = 1;
            this.setHotkeyButton.Text = "Set Hotkey";
            this.setHotkeyButton.UseVisualStyleBackColor = true;
            this.setHotkeyButton.Click += new System.EventHandler(this.SetHotkeyButton_Click);
            // 
            // actionListBox
            // 
            this.actionListBox.FormattingEnabled = true;
            this.actionListBox.Location = new System.Drawing.Point(127, 205);
            this.actionListBox.Name = "actionListBox";
            this.actionListBox.Size = new System.Drawing.Size(166, 95);
            this.actionListBox.TabIndex = 4;
            // 
            // alwaysListeningCheckBox
            // 
            this.alwaysListeningCheckBox.AutoSize = true;
            this.alwaysListeningCheckBox.Location = new System.Drawing.Point(23, 11);
            this.alwaysListeningCheckBox.Name = "alwaysListeningCheckBox";
            this.alwaysListeningCheckBox.Size = new System.Drawing.Size(80, 17);
            this.alwaysListeningCheckBox.TabIndex = 5;
            this.alwaysListeningCheckBox.Text = "checkBox1";
            this.alwaysListeningCheckBox.UseVisualStyleBackColor = true;
            this.alwaysListeningCheckBox.Click += new System.EventHandler(this.alwaysListeningCheckBox_Click);
            // 
            // alwaysListeningLabel
            // 
            this.alwaysListeningLabel.AutoSize = true;
            this.alwaysListeningLabel.ForeColor = System.Drawing.Color.White;
            this.alwaysListeningLabel.Location = new System.Drawing.Point(36, 12);
            this.alwaysListeningLabel.Name = "alwaysListeningLabel";
            this.alwaysListeningLabel.Size = new System.Drawing.Size(85, 13);
            this.alwaysListeningLabel.TabIndex = 6;
            this.alwaysListeningLabel.Text = "Always Listening";
            this.alwaysListeningLabel.Click += new System.EventHandler(this.alwaysListeningLabel_Click);
            // 
            // defaultHotkeyLabel
            // 
            this.defaultHotkeyLabel.AutoSize = true;
            this.defaultHotkeyLabel.BackColor = System.Drawing.Color.Black;
            this.defaultHotkeyLabel.ForeColor = System.Drawing.Color.White;
            this.defaultHotkeyLabel.Location = new System.Drawing.Point(22, 31);
            this.defaultHotkeyLabel.Name = "defaultHotkeyLabel";
            this.defaultHotkeyLabel.Size = new System.Drawing.Size(99, 13);
            this.defaultHotkeyLabel.TabIndex = 7;
            this.defaultHotkeyLabel.Text = "defaultHotkeyLabel";
            // 
            // profileComboBox
            // 
            this.profileComboBox.Location = new System.Drawing.Point(147, 12);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(146, 21);
            this.profileComboBox.TabIndex = 9;
            this.profileComboBox.SelectedIndexChanged += new System.EventHandler(this.profileComboBox_SelectedIndexChanged);
            // 
            // programPathLabel
            // 
            this.programPathLabel.AutoSize = true;
            this.programPathLabel.ForeColor = System.Drawing.Color.White;
            this.programPathLabel.Location = new System.Drawing.Point(20, 76);
            this.programPathLabel.Name = "programPathLabel";
            this.programPathLabel.Size = new System.Drawing.Size(74, 13);
            this.programPathLabel.TabIndex = 10;
            this.programPathLabel.Text = "Program Path:";
            this.programPathLabel.Click += new System.EventHandler(this.programPathLabel_Click);
            // 
            // programPathInput
            // 
            this.programPathInput.Location = new System.Drawing.Point(127, 95);
            this.programPathInput.Name = "programPathInput";
            this.programPathInput.Size = new System.Drawing.Size(166, 20);
            this.programPathInput.TabIndex = 11;
            this.programPathInput.TextChanged += new System.EventHandler(this.programPathInput_TextChanged);
            // 
            // programTargetLabel
            // 
            this.programTargetLabel.AutoSize = true;
            this.programTargetLabel.ForeColor = System.Drawing.Color.White;
            this.programTargetLabel.Location = new System.Drawing.Point(20, 118);
            this.programTargetLabel.Name = "programTargetLabel";
            this.programTargetLabel.Size = new System.Drawing.Size(83, 13);
            this.programTargetLabel.TabIndex = 12;
            this.programTargetLabel.Text = "Program Target:";
            // 
            // programTargetInput
            // 
            this.programTargetInput.Location = new System.Drawing.Point(127, 137);
            this.programTargetInput.Name = "programTargetInput";
            this.programTargetInput.Size = new System.Drawing.Size(166, 20);
            this.programTargetInput.TabIndex = 13;
            // 
            // setProgramPathButton
            // 
            this.setProgramPathButton.Location = new System.Drawing.Point(23, 92);
            this.setProgramPathButton.Name = "setProgramPathButton";
            this.setProgramPathButton.Size = new System.Drawing.Size(98, 23);
            this.setProgramPathButton.TabIndex = 14;
            this.setProgramPathButton.Text = "Set Path";
            this.setProgramPathButton.UseVisualStyleBackColor = true;
            // 
            // setProgramTargetButton
            // 
            this.setProgramTargetButton.Location = new System.Drawing.Point(23, 134);
            this.setProgramTargetButton.Name = "setProgramTargetButton";
            this.setProgramTargetButton.Size = new System.Drawing.Size(98, 23);
            this.setProgramTargetButton.TabIndex = 15;
            this.setProgramTargetButton.Text = "Set Target";
            this.setProgramTargetButton.UseVisualStyleBackColor = true;
            // 
            // triggerWordLabel
            // 
            this.triggerWordLabel.AutoSize = true;
            this.triggerWordLabel.ForeColor = System.Drawing.Color.White;
            this.triggerWordLabel.Location = new System.Drawing.Point(22, 160);
            this.triggerWordLabel.Name = "triggerWordLabel";
            this.triggerWordLabel.Size = new System.Drawing.Size(75, 13);
            this.triggerWordLabel.TabIndex = 16;
            this.triggerWordLabel.Text = "Trigger Word: ";
            // 
            // triggerWordButton
            // 
            this.triggerWordButton.Location = new System.Drawing.Point(25, 176);
            this.triggerWordButton.Name = "triggerWordButton";
            this.triggerWordButton.Size = new System.Drawing.Size(98, 23);
            this.triggerWordButton.TabIndex = 17;
            this.triggerWordButton.Text = "Set Trigger Word";
            this.triggerWordButton.UseVisualStyleBackColor = true;
            // 
            // triggerWordInput
            // 
            this.triggerWordInput.Location = new System.Drawing.Point(129, 179);
            this.triggerWordInput.Name = "triggerWordInput";
            this.triggerWordInput.Size = new System.Drawing.Size(166, 20);
            this.triggerWordInput.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(307, 309);
            this.Controls.Add(this.triggerWordInput);
            this.Controls.Add(this.triggerWordButton);
            this.Controls.Add(this.triggerWordLabel);
            this.Controls.Add(this.setProgramTargetButton);
            this.Controls.Add(this.setProgramPathButton);
            this.Controls.Add(this.programTargetInput);
            this.Controls.Add(this.programTargetLabel);
            this.Controls.Add(this.programPathInput);
            this.Controls.Add(this.programPathLabel);
            this.Controls.Add(this.profileComboBox);
            this.Controls.Add(this.defaultHotkeyLabel);
            this.Controls.Add(this.alwaysListeningLabel);
            this.Controls.Add(this.alwaysListeningCheckBox);
            this.Controls.Add(this.actionListBox);
            this.Controls.Add(this.setHotkeyButton);
            this.Controls.Add(this.hotkeyInput);
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
        private System.Windows.Forms.Button setHotkeyButton;
        private System.Windows.Forms.ListBox actionListBox;
        private System.Windows.Forms.CheckBox alwaysListeningCheckBox;
        private System.Windows.Forms.Label alwaysListeningLabel;
        private System.Windows.Forms.Label defaultHotkeyLabel;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.Label programPathLabel;
        private System.Windows.Forms.TextBox programPathInput;
        private System.Windows.Forms.Label programTargetLabel;
        private System.Windows.Forms.TextBox programTargetInput;
        private System.Windows.Forms.Button setProgramPathButton;
        private System.Windows.Forms.Button setProgramTargetButton;
        private System.Windows.Forms.Label triggerWordLabel;
        private System.Windows.Forms.Button triggerWordButton;
        private System.Windows.Forms.TextBox triggerWordInput;
    }
}

