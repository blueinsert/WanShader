namespace bluebean.ShaderToyOffline
{
    partial class DetailPageUIController
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
            this.DemoPagePanel = new System.Windows.Forms.Panel();
            this.compileOutputTextBox = new System.Windows.Forms.RichTextBox();
            this.canvasControlGroup = new System.Windows.Forms.GroupBox();
            this.fpsText = new System.Windows.Forms.Label();
            this.resulationText = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.stopOrContinueButton = new System.Windows.Forms.Button();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.savaButton = new System.Windows.Forms.Button();
            this.shaderNameTextBox = new System.Windows.Forms.TextBox();
            this.shaderDescTextBox = new System.Windows.Forms.TextBox();
            this.shaderTagsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.codeEditorTabControl = new System.Windows.Forms.TabControl();
            this.compileButton = new System.Windows.Forms.Button();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DemoPagePanel.SuspendLayout();
            this.canvasControlGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // DemoPagePanel
            // 
            this.DemoPagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DemoPagePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DemoPagePanel.Controls.Add(this.compileOutputTextBox);
            this.DemoPagePanel.Controls.Add(this.canvasControlGroup);
            this.DemoPagePanel.Controls.Add(this.groupBox1);
            this.DemoPagePanel.Controls.Add(this.codeEditorTabControl);
            this.DemoPagePanel.Controls.Add(this.compileButton);
            this.DemoPagePanel.Controls.Add(this.openGLControl1);
            this.DemoPagePanel.Location = new System.Drawing.Point(-84, -84);
            this.DemoPagePanel.Name = "DemoPagePanel";
            this.DemoPagePanel.Size = new System.Drawing.Size(1488, 838);
            this.DemoPagePanel.TabIndex = 2;
            // 
            // compileOutputTextBox
            // 
            this.compileOutputTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.compileOutputTextBox.Location = new System.Drawing.Point(684, 612);
            this.compileOutputTextBox.Name = "compileOutputTextBox";
            this.compileOutputTextBox.Size = new System.Drawing.Size(707, 130);
            this.compileOutputTextBox.TabIndex = 21;
            this.compileOutputTextBox.Text = "";
            // 
            // canvasControlGroup
            // 
            this.canvasControlGroup.Controls.Add(this.fpsText);
            this.canvasControlGroup.Controls.Add(this.resulationText);
            this.canvasControlGroup.Controls.Add(this.resetButton);
            this.canvasControlGroup.Controls.Add(this.stopOrContinueButton);
            this.canvasControlGroup.Controls.Add(this.fullScreenButton);
            this.canvasControlGroup.Location = new System.Drawing.Point(96, 445);
            this.canvasControlGroup.Name = "canvasControlGroup";
            this.canvasControlGroup.Size = new System.Drawing.Size(553, 45);
            this.canvasControlGroup.TabIndex = 19;
            this.canvasControlGroup.TabStop = false;
            // 
            // fpsText
            // 
            this.fpsText.Location = new System.Drawing.Point(179, 17);
            this.fpsText.Name = "fpsText";
            this.fpsText.Size = new System.Drawing.Size(41, 12);
            this.fpsText.TabIndex = 14;
            this.fpsText.Text = "fps:60";
            // 
            // resulationText
            // 
            this.resulationText.Location = new System.Drawing.Point(226, 12);
            this.resulationText.Name = "resulationText";
            this.resulationText.Size = new System.Drawing.Size(63, 23);
            this.resulationText.TabIndex = 19;
            this.resulationText.Text = "550x320";
            this.resulationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(6, 12);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // stopOrContinueButton
            // 
            this.stopOrContinueButton.Location = new System.Drawing.Point(87, 12);
            this.stopOrContinueButton.Name = "stopOrContinueButton";
            this.stopOrContinueButton.Size = new System.Drawing.Size(75, 23);
            this.stopOrContinueButton.TabIndex = 16;
            this.stopOrContinueButton.Text = "Stop";
            this.stopOrContinueButton.UseVisualStyleBackColor = true;
            this.stopOrContinueButton.Click += new System.EventHandler(this.OnStopOrContinueButtonClick);
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.Location = new System.Drawing.Point(472, 12);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(75, 23);
            this.fullScreenButton.TabIndex = 17;
            this.fullScreenButton.Text = "Full";
            this.fullScreenButton.UseVisualStyleBackColor = true;
            this.fullScreenButton.Click += new System.EventHandler(this.OnFullButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.savaButton);
            this.groupBox1.Controls.Add(this.shaderNameTextBox);
            this.groupBox1.Controls.Add(this.shaderDescTextBox);
            this.groupBox1.Controls.Add(this.shaderTagsTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(103, 534);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 208);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // savaButton
            // 
            this.savaButton.Location = new System.Drawing.Point(221, 176);
            this.savaButton.Name = "savaButton";
            this.savaButton.Size = new System.Drawing.Size(73, 26);
            this.savaButton.TabIndex = 6;
            this.savaButton.Text = "Save";
            this.savaButton.UseVisualStyleBackColor = true;
            this.savaButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // shaderNameTextBox
            // 
            this.shaderNameTextBox.Location = new System.Drawing.Point(63, 35);
            this.shaderNameTextBox.Name = "shaderNameTextBox";
            this.shaderNameTextBox.Size = new System.Drawing.Size(464, 21);
            this.shaderNameTextBox.TabIndex = 1;
            // 
            // shaderDescTextBox
            // 
            this.shaderDescTextBox.Location = new System.Drawing.Point(63, 106);
            this.shaderDescTextBox.Multiline = true;
            this.shaderDescTextBox.Name = "shaderDescTextBox";
            this.shaderDescTextBox.Size = new System.Drawing.Size(464, 47);
            this.shaderDescTextBox.TabIndex = 4;
            // 
            // shaderTagsTextBox
            // 
            this.shaderTagsTextBox.Location = new System.Drawing.Point(63, 71);
            this.shaderTagsTextBox.Name = "shaderTagsTextBox";
            this.shaderTagsTextBox.Size = new System.Drawing.Size(464, 21);
            this.shaderTagsTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "tags:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "desc:";
            // 
            // codeEditorTabControl
            // 
            this.codeEditorTabControl.AllowDrop = true;
            this.codeEditorTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.codeEditorTabControl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.codeEditorTabControl.Location = new System.Drawing.Point(684, 96);
            this.codeEditorTabControl.Name = "codeEditorTabControl";
            this.codeEditorTabControl.SelectedIndex = 0;
            this.codeEditorTabControl.Size = new System.Drawing.Size(707, 462);
            this.codeEditorTabControl.TabIndex = 4;
            // 
            // compileButton
            // 
            this.compileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.compileButton.Location = new System.Drawing.Point(684, 564);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(70, 28);
            this.compileButton.TabIndex = 3;
            this.compileButton.Text = "Compile";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.OnCompileButtonClick);
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 60;
            this.openGLControl1.Location = new System.Drawing.Point(96, 107);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl1.Size = new System.Drawing.Size(559, 332);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLInitialized += new System.EventHandler(this.OpenGL_OnInited);
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGL_OnDraw);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DetailPageUIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 670);
            this.Controls.Add(this.DemoPagePanel);
            this.Name = "DetailPageUIController";
            this.Text = "DetailPageForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.DemoPagePanel.ResumeLayout(false);
            this.canvasControlGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DemoPagePanel;
        private System.Windows.Forms.Button compileButton;
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.TabControl codeEditorTabControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox shaderNameTextBox;
        private System.Windows.Forms.TextBox shaderDescTextBox;
        private System.Windows.Forms.TextBox shaderTagsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button savaButton;
        private System.Windows.Forms.Label fpsText;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.Button stopOrContinueButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox canvasControlGroup;
        private System.Windows.Forms.Label resulationText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox compileOutputTextBox;
    }
}