namespace WinFormsApp1
{
    partial class MainDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            panel1 = new Panel();
            comboBoxLimit = new ComboBox();
            label5 = new Label();
            comboBoxInvertFFB = new ComboBox();
            label4 = new Label();
            numericUpDownDeadzone = new NumericUpDown();
            label3 = new Label();
            numericUpDownForce = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            comboBoxDamper = new ComboBox();
            comboBoxConstant = new ComboBox();
            comboBoxSpring = new ComboBox();
            label17 = new Label();
            numericUpDownBrakingScale = new NumericUpDown();
            label16 = new Label();
            numericUpDownDamperScale = new NumericUpDown();
            label15 = new Label();
            label14 = new Label();
            numericUpDownConstantScale = new NumericUpDown();
            label13 = new Label();
            label12 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            buttonRefresh = new Button();
            comboBoxDirectInput = new ComboBox();
            comboBoxVersion = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label11 = new Label();
            buttonSave = new Button();
            buttonRun = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDeadzone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownForce).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBrakingScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDamperScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownConstantScale).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBoxLimit);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBoxInvertFFB);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(numericUpDownDeadzone);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numericUpDownForce);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(139, 161);
            panel1.TabIndex = 0;
            // 
            // comboBoxLimit
            // 
            comboBoxLimit.FormattingEnabled = true;
            comboBoxLimit.Items.AddRange(new object[] { "false", "true" });
            comboBoxLimit.Location = new Point(70, 126);
            comboBoxLimit.Name = "comboBoxLimit";
            comboBoxLimit.Size = new Size(53, 23);
            comboBoxLimit.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 126);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 7;
            label5.Text = "Limit:";
            // 
            // comboBoxInvertFFB
            // 
            comboBoxInvertFFB.FormattingEnabled = true;
            comboBoxInvertFFB.Items.AddRange(new object[] { "false", "true" });
            comboBoxInvertFFB.Location = new Point(70, 97);
            comboBoxInvertFFB.Name = "comboBoxInvertFFB";
            comboBoxInvertFFB.Size = new Size(53, 23);
            comboBoxInvertFFB.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 100);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 5;
            label4.Text = "Invert FFB:";
            // 
            // numericUpDownDeadzone
            // 
            numericUpDownDeadzone.Location = new Point(70, 68);
            numericUpDownDeadzone.Name = "numericUpDownDeadzone";
            numericUpDownDeadzone.Size = new Size(43, 23);
            numericUpDownDeadzone.TabIndex = 4;
            numericUpDownDeadzone.TextAlign = HorizontalAlignment.Right;
            numericUpDownDeadzone.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 70);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 3;
            label3.Text = "DeadZone:";
            // 
            // numericUpDownForce
            // 
            numericUpDownForce.Location = new Point(70, 39);
            numericUpDownForce.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownForce.Name = "numericUpDownForce";
            numericUpDownForce.Size = new Size(43, 23);
            numericUpDownForce.TabIndex = 2;
            numericUpDownForce.TextAlign = HorizontalAlignment.Right;
            numericUpDownForce.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 1;
            label2.Text = "FFB Config";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 41);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Force:";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(comboBoxDamper);
            panel2.Controls.Add(comboBoxConstant);
            panel2.Controls.Add(comboBoxSpring);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(numericUpDownBrakingScale);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(numericUpDownDamperScale);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(numericUpDownConstantScale);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(157, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(219, 161);
            panel2.TabIndex = 1;
            // 
            // comboBoxDamper
            // 
            comboBoxDamper.FormattingEnabled = true;
            comboBoxDamper.Items.AddRange(new object[] { "false", "true" });
            comboBoxDamper.Location = new Point(66, 67);
            comboBoxDamper.Name = "comboBoxDamper";
            comboBoxDamper.Size = new Size(53, 23);
            comboBoxDamper.TabIndex = 19;
            // 
            // comboBoxConstant
            // 
            comboBoxConstant.FormattingEnabled = true;
            comboBoxConstant.Items.AddRange(new object[] { "false", "true" });
            comboBoxConstant.Location = new Point(66, 39);
            comboBoxConstant.Name = "comboBoxConstant";
            comboBoxConstant.Size = new Size(53, 23);
            comboBoxConstant.TabIndex = 18;
            // 
            // comboBoxSpring
            // 
            comboBoxSpring.FormattingEnabled = true;
            comboBoxSpring.Items.AddRange(new object[] { "false", "true" });
            comboBoxSpring.Location = new Point(100, 128);
            comboBoxSpring.Name = "comboBoxSpring";
            comboBoxSpring.Size = new Size(53, 23);
            comboBoxSpring.TabIndex = 17;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(3, 131);
            label17.Name = "label17";
            label17.Size = new Size(92, 15);
            label17.TabIndex = 16;
            label17.Text = "Spring (Legacy):";
            // 
            // numericUpDownBrakingScale
            // 
            numericUpDownBrakingScale.Location = new Point(101, 100);
            numericUpDownBrakingScale.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDownBrakingScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownBrakingScale.Name = "numericUpDownBrakingScale";
            numericUpDownBrakingScale.Size = new Size(43, 23);
            numericUpDownBrakingScale.TabIndex = 15;
            numericUpDownBrakingScale.TextAlign = HorizontalAlignment.Right;
            numericUpDownBrakingScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(3, 102);
            label16.Name = "label16";
            label16.Size = new Size(80, 15);
            label16.TabIndex = 14;
            label16.Text = "Braking Scale:";
            // 
            // numericUpDownDamperScale
            // 
            numericUpDownDamperScale.Location = new Point(168, 69);
            numericUpDownDamperScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDamperScale.Name = "numericUpDownDamperScale";
            numericUpDownDamperScale.Size = new Size(43, 23);
            numericUpDownDamperScale.TabIndex = 13;
            numericUpDownDamperScale.TextAlign = HorizontalAlignment.Right;
            numericUpDownDamperScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(125, 71);
            label15.Name = "label15";
            label15.Size = new Size(37, 15);
            label15.TabIndex = 12;
            label15.Text = "Scale:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(3, 70);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 10;
            label14.Text = "Damper:";
            // 
            // numericUpDownConstantScale
            // 
            numericUpDownConstantScale.Location = new Point(168, 38);
            numericUpDownConstantScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownConstantScale.Name = "numericUpDownConstantScale";
            numericUpDownConstantScale.Size = new Size(43, 23);
            numericUpDownConstantScale.TabIndex = 9;
            numericUpDownConstantScale.TextAlign = HorizontalAlignment.Right;
            numericUpDownConstantScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(125, 41);
            label13.Name = "label13";
            label13.Size = new Size(37, 15);
            label13.TabIndex = 8;
            label13.Text = "Scale:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 41);
            label12.Name = "label12";
            label12.Size = new Size(58, 15);
            label12.TabIndex = 3;
            label12.Text = "Constant:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(2, 9);
            label6.Name = "label6";
            label6.Size = new Size(76, 17);
            label6.TabIndex = 2;
            label6.Text = "Effects Mix";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(buttonRefresh);
            panel3.Controls.Add(comboBoxDirectInput);
            panel3.Controls.Add(comboBoxVersion);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(12, 179);
            panel3.Name = "panel3";
            panel3.Size = new Size(257, 112);
            panel3.TabIndex = 2;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Image = (Image)resources.GetObject("buttonRefresh.Image");
            buttonRefresh.Location = new Point(219, 34);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(30, 30);
            buttonRefresh.TabIndex = 6;
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // comboBoxDirectInput
            // 
            comboBoxDirectInput.FormattingEnabled = true;
            comboBoxDirectInput.Location = new Point(52, 37);
            comboBoxDirectInput.Name = "comboBoxDirectInput";
            comboBoxDirectInput.Size = new Size(165, 23);
            comboBoxDirectInput.TabIndex = 6;
            // 
            // comboBoxVersion
            // 
            comboBoxVersion.FormattingEnabled = true;
            comboBoxVersion.Items.AddRange(new object[] { "ICR2DOS", "ICR2REND" });
            comboBoxVersion.Location = new Point(88, 70);
            comboBoxVersion.Name = "comboBoxVersion";
            comboBoxVersion.Size = new Size(161, 23);
            comboBoxVersion.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 73);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 5;
            label9.Text = "Game Version:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 40);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 3;
            label8.Text = "Device:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 9);
            label7.Name = "label7";
            label7.Size = new Size(93, 17);
            label7.TabIndex = 2;
            label7.Text = "Plugin Config";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 303);
            label11.Name = "label11";
            label11.Size = new Size(276, 15);
            label11.TabIndex = 3;
            label11.Text = "ICR2FFB Plugin by GPLaps | Config UI by Menkaura";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(283, 189);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(86, 34);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save Config";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(283, 236);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(86, 34);
            buttonRun.TabIndex = 5;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // MainDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 327);
            Controls.Add(buttonRun);
            Controls.Add(buttonSave);
            Controls.Add(label11);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainDialog";
            ShowInTaskbar = false;
            Text = "ICR2FFB Config";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDeadzone).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownForce).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBrakingScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDamperScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownConstantScale).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private NumericUpDown numericUpDownForce;
        private Label label2;
        private ComboBox comboBoxInvertFFB;
        private Label label4;
        private NumericUpDown numericUpDownDeadzone;
        private Label label3;
        private Label label5;
        private ComboBox comboBoxLimit;
        private Panel panel2;
        private Label label6;
        private Panel panel3;
        private Label label7;
        protected internal Label label8;
        private Label label9;
        private ComboBox comboBoxVersion;
        private Label label11;
        private Button buttonSave;
        private Button buttonRun;
        private NumericUpDown numericUpDownConstantScale;
        private Label label13;
        private Label label12;
        private NumericUpDown numericUpDownDamperScale;
        private Label label15;
        private Label label14;
        private Label label17;
        private NumericUpDown numericUpDownBrakingScale;
        private Label label16;
        private ComboBox comboBoxSpring;
        private ComboBox comboBoxDamper;
        private ComboBox comboBoxConstant;
        private ComboBox comboBoxDirectInput;
        private Button buttonRefresh;
    }
}
