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
            this.DemoPagePanel = new System.Windows.Forms.Panel();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.stopOrContinueButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.fpsText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.savaButton = new System.Windows.Forms.Button();
            this.shaderNameTextBox = new System.Windows.Forms.TextBox();
            this.shaderDescTextBox = new System.Windows.Forms.TextBox();
            this.shaderTagsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.channelGroup = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.inputChannel0Group = new System.Windows.Forms.GroupBox();
            this.iChannel0DeleteButton = new System.Windows.Forms.Button();
            this.iChannel0PictureBox = new System.Windows.Forms.PictureBox();
            this.inputChannel1Group = new System.Windows.Forms.GroupBox();
            this.iChannel1DeleteButton = new System.Windows.Forms.Button();
            this.iChannel1PictureBox = new System.Windows.Forms.PictureBox();
            this.inputChannel2Group = new System.Windows.Forms.GroupBox();
            this.iChannel2DeleteButton = new System.Windows.Forms.Button();
            this.iChannel2PictureBox = new System.Windows.Forms.PictureBox();
            this.inputChannel3Group = new System.Windows.Forms.GroupBox();
            this.iChannel3DeleteButton = new System.Windows.Forms.Button();
            this.iChannel3PictureBox = new System.Windows.Forms.PictureBox();
            this.renderPassOperGroup = new System.Windows.Forms.GroupBox();
            this.m_renderPassAddButton = new System.Windows.Forms.Button();
            this.m_renderPassDeleteButton = new System.Windows.Forms.Button();
            this.codeEditorTabControl = new System.Windows.Forms.TabControl();
            this.compileButton = new System.Windows.Forms.Button();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.exportImgButton = new System.Windows.Forms.Button();
            this.DemoPagePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.channelGroup.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.inputChannel0Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iChannel0PictureBox)).BeginInit();
            this.inputChannel1Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iChannel1PictureBox)).BeginInit();
            this.inputChannel2Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iChannel2PictureBox)).BeginInit();
            this.inputChannel3Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iChannel3PictureBox)).BeginInit();
            this.renderPassOperGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // DemoPagePanel
            // 
            this.DemoPagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DemoPagePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DemoPagePanel.Controls.Add(this.exportImgButton);
            this.DemoPagePanel.Controls.Add(this.fullScreenButton);
            this.DemoPagePanel.Controls.Add(this.stopOrContinueButton);
            this.DemoPagePanel.Controls.Add(this.resetButton);
            this.DemoPagePanel.Controls.Add(this.fpsText);
            this.DemoPagePanel.Controls.Add(this.groupBox1);
            this.DemoPagePanel.Controls.Add(this.channelGroup);
            this.DemoPagePanel.Controls.Add(this.renderPassOperGroup);
            this.DemoPagePanel.Controls.Add(this.codeEditorTabControl);
            this.DemoPagePanel.Controls.Add(this.compileButton);
            this.DemoPagePanel.Controls.Add(this.openGLControl1);
            this.DemoPagePanel.Location = new System.Drawing.Point(-84, -84);
            this.DemoPagePanel.Name = "DemoPagePanel";
            this.DemoPagePanel.Size = new System.Drawing.Size(1507, 853);
            this.DemoPagePanel.TabIndex = 2;
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.Location = new System.Drawing.Point(551, 432);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(75, 23);
            this.fullScreenButton.TabIndex = 17;
            this.fullScreenButton.Text = "Full";
            this.fullScreenButton.UseVisualStyleBackColor = true;
            this.fullScreenButton.Click += new System.EventHandler(this.OnFullButtonClick);
            // 
            // stopOrContinueButton
            // 
            this.stopOrContinueButton.Location = new System.Drawing.Point(198, 432);
            this.stopOrContinueButton.Name = "stopOrContinueButton";
            this.stopOrContinueButton.Size = new System.Drawing.Size(75, 23);
            this.stopOrContinueButton.TabIndex = 16;
            this.stopOrContinueButton.Text = "Stop";
            this.stopOrContinueButton.UseVisualStyleBackColor = true;
            this.stopOrContinueButton.Click += new System.EventHandler(this.OnStopOrContinueButtonClick);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(108, 432);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // fpsText
            // 
            this.fpsText.AutoSize = true;
            this.fpsText.Location = new System.Drawing.Point(585, 161);
            this.fpsText.Name = "fpsText";
            this.fpsText.Size = new System.Drawing.Size(41, 12);
            this.fpsText.TabIndex = 14;
            this.fpsText.Text = "fps:60";
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
            this.groupBox1.Location = new System.Drawing.Point(97, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 254);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // savaButton
            // 
            this.savaButton.Location = new System.Drawing.Point(63, 199);
            this.savaButton.Name = "savaButton";
            this.savaButton.Size = new System.Drawing.Size(83, 37);
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
            this.shaderDescTextBox.Size = new System.Drawing.Size(464, 87);
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
            // channelGroup
            // 
            this.channelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.channelGroup.Controls.Add(this.flowLayoutPanel1);
            this.channelGroup.Location = new System.Drawing.Point(753, 645);
            this.channelGroup.Name = "channelGroup";
            this.channelGroup.Size = new System.Drawing.Size(657, 112);
            this.channelGroup.TabIndex = 12;
            this.channelGroup.TabStop = false;
            this.channelGroup.Text = "groupBox1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.inputChannel0Group);
            this.flowLayoutPanel1.Controls.Add(this.inputChannel1Group);
            this.flowLayoutPanel1.Controls.Add(this.inputChannel2Group);
            this.flowLayoutPanel1.Controls.Add(this.inputChannel3Group);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(657, 112);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // inputChannel0Group
            // 
            this.inputChannel0Group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputChannel0Group.Controls.Add(this.iChannel0DeleteButton);
            this.inputChannel0Group.Controls.Add(this.iChannel0PictureBox);
            this.inputChannel0Group.Location = new System.Drawing.Point(3, 3);
            this.inputChannel0Group.Name = "inputChannel0Group";
            this.inputChannel0Group.Size = new System.Drawing.Size(140, 100);
            this.inputChannel0Group.TabIndex = 8;
            this.inputChannel0Group.TabStop = false;
            this.inputChannel0Group.Text = "iChannel0";
            // 
            // iChannel0DeleteButton
            // 
            this.iChannel0DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel0DeleteButton.Location = new System.Drawing.Point(115, 18);
            this.iChannel0DeleteButton.Name = "iChannel0DeleteButton";
            this.iChannel0DeleteButton.Size = new System.Drawing.Size(18, 23);
            this.iChannel0DeleteButton.TabIndex = 8;
            this.iChannel0DeleteButton.Text = "X";
            this.iChannel0DeleteButton.UseVisualStyleBackColor = true;
            this.iChannel0DeleteButton.Click += new System.EventHandler(this.OnChannel0DeleteButtonClick);
            // 
            // iChannel0PictureBox
            // 
            this.iChannel0PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel0PictureBox.Location = new System.Drawing.Point(6, 17);
            this.iChannel0PictureBox.Name = "iChannel0PictureBox";
            this.iChannel0PictureBox.Size = new System.Drawing.Size(128, 77);
            this.iChannel0PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iChannel0PictureBox.TabIndex = 7;
            this.iChannel0PictureBox.TabStop = false;
            this.iChannel0PictureBox.Click += new System.EventHandler(this.OnInputChannel0Click);
            // 
            // inputChannel1Group
            // 
            this.inputChannel1Group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputChannel1Group.Controls.Add(this.iChannel1DeleteButton);
            this.inputChannel1Group.Controls.Add(this.iChannel1PictureBox);
            this.inputChannel1Group.Location = new System.Drawing.Point(149, 3);
            this.inputChannel1Group.Name = "inputChannel1Group";
            this.inputChannel1Group.Size = new System.Drawing.Size(140, 100);
            this.inputChannel1Group.TabIndex = 9;
            this.inputChannel1Group.TabStop = false;
            this.inputChannel1Group.Text = "iChannel1";
            // 
            // iChannel1DeleteButton
            // 
            this.iChannel1DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel1DeleteButton.Location = new System.Drawing.Point(116, 18);
            this.iChannel1DeleteButton.Name = "iChannel1DeleteButton";
            this.iChannel1DeleteButton.Size = new System.Drawing.Size(18, 23);
            this.iChannel1DeleteButton.TabIndex = 9;
            this.iChannel1DeleteButton.Text = "X";
            this.iChannel1DeleteButton.UseVisualStyleBackColor = true;
            this.iChannel1DeleteButton.Click += new System.EventHandler(this.OnChannel1DeleteButtonClick);
            // 
            // iChannel1PictureBox
            // 
            this.iChannel1PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel1PictureBox.Location = new System.Drawing.Point(6, 17);
            this.iChannel1PictureBox.Name = "iChannel1PictureBox";
            this.iChannel1PictureBox.Size = new System.Drawing.Size(128, 77);
            this.iChannel1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iChannel1PictureBox.TabIndex = 7;
            this.iChannel1PictureBox.TabStop = false;
            this.iChannel1PictureBox.Click += new System.EventHandler(this.OnInputChannel1Click);
            // 
            // inputChannel2Group
            // 
            this.inputChannel2Group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputChannel2Group.Controls.Add(this.iChannel2DeleteButton);
            this.inputChannel2Group.Controls.Add(this.iChannel2PictureBox);
            this.inputChannel2Group.Location = new System.Drawing.Point(295, 3);
            this.inputChannel2Group.Name = "inputChannel2Group";
            this.inputChannel2Group.Size = new System.Drawing.Size(140, 100);
            this.inputChannel2Group.TabIndex = 10;
            this.inputChannel2Group.TabStop = false;
            this.inputChannel2Group.Text = "iChannel2";
            // 
            // iChannel2DeleteButton
            // 
            this.iChannel2DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel2DeleteButton.Location = new System.Drawing.Point(116, 18);
            this.iChannel2DeleteButton.Name = "iChannel2DeleteButton";
            this.iChannel2DeleteButton.Size = new System.Drawing.Size(18, 23);
            this.iChannel2DeleteButton.TabIndex = 9;
            this.iChannel2DeleteButton.Text = "X";
            this.iChannel2DeleteButton.UseVisualStyleBackColor = true;
            this.iChannel2DeleteButton.Click += new System.EventHandler(this.OnChannel2DeleteButtonClick);
            // 
            // iChannel2PictureBox
            // 
            this.iChannel2PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel2PictureBox.Location = new System.Drawing.Point(6, 17);
            this.iChannel2PictureBox.Name = "iChannel2PictureBox";
            this.iChannel2PictureBox.Size = new System.Drawing.Size(128, 77);
            this.iChannel2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iChannel2PictureBox.TabIndex = 7;
            this.iChannel2PictureBox.TabStop = false;
            this.iChannel2PictureBox.Click += new System.EventHandler(this.OnInputChannel2Click);
            // 
            // inputChannel3Group
            // 
            this.inputChannel3Group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputChannel3Group.Controls.Add(this.iChannel3DeleteButton);
            this.inputChannel3Group.Controls.Add(this.iChannel3PictureBox);
            this.inputChannel3Group.Location = new System.Drawing.Point(441, 3);
            this.inputChannel3Group.Name = "inputChannel3Group";
            this.inputChannel3Group.Size = new System.Drawing.Size(140, 100);
            this.inputChannel3Group.TabIndex = 11;
            this.inputChannel3Group.TabStop = false;
            this.inputChannel3Group.Text = "iChannel3";
            // 
            // iChannel3DeleteButton
            // 
            this.iChannel3DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel3DeleteButton.Location = new System.Drawing.Point(116, 18);
            this.iChannel3DeleteButton.Name = "iChannel3DeleteButton";
            this.iChannel3DeleteButton.Size = new System.Drawing.Size(18, 23);
            this.iChannel3DeleteButton.TabIndex = 9;
            this.iChannel3DeleteButton.Text = "X";
            this.iChannel3DeleteButton.UseVisualStyleBackColor = true;
            this.iChannel3DeleteButton.Click += new System.EventHandler(this.OnChannel3DeleteButtonClick);
            // 
            // iChannel3PictureBox
            // 
            this.iChannel3PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iChannel3PictureBox.Location = new System.Drawing.Point(6, 17);
            this.iChannel3PictureBox.Name = "iChannel3PictureBox";
            this.iChannel3PictureBox.Size = new System.Drawing.Size(128, 77);
            this.iChannel3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iChannel3PictureBox.TabIndex = 7;
            this.iChannel3PictureBox.TabStop = false;
            this.iChannel3PictureBox.Click += new System.EventHandler(this.OnInputChannel3Click);
            // 
            // renderPassOperGroup
            // 
            this.renderPassOperGroup.Controls.Add(this.m_renderPassAddButton);
            this.renderPassOperGroup.Controls.Add(this.m_renderPassDeleteButton);
            this.renderPassOperGroup.Location = new System.Drawing.Point(682, 96);
            this.renderPassOperGroup.Name = "renderPassOperGroup";
            this.renderPassOperGroup.Size = new System.Drawing.Size(466, 47);
            this.renderPassOperGroup.TabIndex = 6;
            this.renderPassOperGroup.TabStop = false;
            this.renderPassOperGroup.Text = "RenderPass操作";
            // 
            // m_renderPassAddButton
            // 
            this.m_renderPassAddButton.Location = new System.Drawing.Point(122, 18);
            this.m_renderPassAddButton.Name = "m_renderPassAddButton";
            this.m_renderPassAddButton.Size = new System.Drawing.Size(75, 23);
            this.m_renderPassAddButton.TabIndex = 1;
            this.m_renderPassAddButton.Text = "Add";
            this.m_renderPassAddButton.UseVisualStyleBackColor = true;
            this.m_renderPassAddButton.Click += new System.EventHandler(this.OnRenderPassAddButtonClick);
            // 
            // m_renderPassDeleteButton
            // 
            this.m_renderPassDeleteButton.Location = new System.Drawing.Point(16, 18);
            this.m_renderPassDeleteButton.Name = "m_renderPassDeleteButton";
            this.m_renderPassDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.m_renderPassDeleteButton.TabIndex = 0;
            this.m_renderPassDeleteButton.Text = "Delete";
            this.m_renderPassDeleteButton.UseVisualStyleBackColor = true;
            this.m_renderPassDeleteButton.Click += new System.EventHandler(this.OnRenderPassDeleteButtonClick);
            // 
            // codeEditorTabControl
            // 
            this.codeEditorTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeEditorTabControl.Location = new System.Drawing.Point(682, 149);
            this.codeEditorTabControl.Name = "codeEditorTabControl";
            this.codeEditorTabControl.SelectedIndex = 0;
            this.codeEditorTabControl.Size = new System.Drawing.Size(714, 448);
            this.codeEditorTabControl.TabIndex = 4;
            // 
            // compileButton
            // 
            this.compileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.compileButton.Location = new System.Drawing.Point(682, 603);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(102, 36);
            this.compileButton.TabIndex = 3;
            this.compileButton.Text = "Compile";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.OnCompileButtonClick);
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 60;
            this.openGLControl1.Location = new System.Drawing.Point(96, 149);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl1.Size = new System.Drawing.Size(553, 318);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLInitialized += new System.EventHandler(this.OpenGL_OnInited);
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGL_OnDraw);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseUp);
            // 
            // exportImgButton
            // 
            this.exportImgButton.Location = new System.Drawing.Point(470, 432);
            this.exportImgButton.Name = "exportImgButton";
            this.exportImgButton.Size = new System.Drawing.Size(75, 23);
            this.exportImgButton.TabIndex = 18;
            this.exportImgButton.Text = "exportImg";
            this.exportImgButton.UseVisualStyleBackColor = true;
            this.exportImgButton.Click += new System.EventHandler(this.OnExportImgButtonClick);
            // 
            // DetailPageUIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 685);
            this.Controls.Add(this.DemoPagePanel);
            this.Name = "DetailPageUIController";
            this.Text = "DetailPageForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.DemoPagePanel.ResumeLayout(false);
            this.DemoPagePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.channelGroup.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.inputChannel0Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iChannel0PictureBox)).EndInit();
            this.inputChannel1Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iChannel1PictureBox)).EndInit();
            this.inputChannel2Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iChannel2PictureBox)).EndInit();
            this.inputChannel3Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iChannel3PictureBox)).EndInit();
            this.renderPassOperGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DemoPagePanel;
        private System.Windows.Forms.Button compileButton;
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.TabControl codeEditorTabControl;
        private System.Windows.Forms.GroupBox renderPassOperGroup;
        private System.Windows.Forms.Button m_renderPassAddButton;
        private System.Windows.Forms.Button m_renderPassDeleteButton;
        private System.Windows.Forms.GroupBox inputChannel1Group;
        private System.Windows.Forms.PictureBox iChannel1PictureBox;
        private System.Windows.Forms.GroupBox inputChannel0Group;
        private System.Windows.Forms.PictureBox iChannel0PictureBox;
        private System.Windows.Forms.GroupBox inputChannel3Group;
        private System.Windows.Forms.PictureBox iChannel3PictureBox;
        private System.Windows.Forms.GroupBox inputChannel2Group;
        private System.Windows.Forms.PictureBox iChannel2PictureBox;
        private System.Windows.Forms.GroupBox channelGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox shaderNameTextBox;
        private System.Windows.Forms.TextBox shaderDescTextBox;
        private System.Windows.Forms.TextBox shaderTagsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button iChannel0DeleteButton;
        private System.Windows.Forms.Button iChannel1DeleteButton;
        private System.Windows.Forms.Button iChannel2DeleteButton;
        private System.Windows.Forms.Button iChannel3DeleteButton;
        private System.Windows.Forms.Button savaButton;
        private System.Windows.Forms.Label fpsText;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.Button stopOrContinueButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button exportImgButton;
    }
}