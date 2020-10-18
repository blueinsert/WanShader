namespace bluebean.ShaderToyOffline
{
    partial class FullScreenEffectUIController
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
            this.openGLCanvas = new SharpGL.OpenGLControl();
            this.resetButton = new System.Windows.Forms.Button();
            this.stopOrContinueButton = new System.Windows.Forms.Button();
            this.fpsText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLCanvas
            // 
            this.openGLCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLCanvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.openGLCanvas.DrawFPS = false;
            this.openGLCanvas.FrameRate = 60;
            this.openGLCanvas.Location = new System.Drawing.Point(-1, -1);
            this.openGLCanvas.Name = "openGLCanvas";
            this.openGLCanvas.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLCanvas.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLCanvas.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLCanvas.Size = new System.Drawing.Size(804, 451);
            this.openGLCanvas.TabIndex = 0;
            this.openGLCanvas.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGLCanvas_OnDraw);
            this.openGLCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseDown);
            this.openGLCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseMove);
            this.openGLCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenGLCanvas_OnMouseUp);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetButton.Location = new System.Drawing.Point(12, 415);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // stopOrContinueButton
            // 
            this.stopOrContinueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopOrContinueButton.Location = new System.Drawing.Point(114, 415);
            this.stopOrContinueButton.Name = "stopOrContinueButton";
            this.stopOrContinueButton.Size = new System.Drawing.Size(75, 23);
            this.stopOrContinueButton.TabIndex = 2;
            this.stopOrContinueButton.Text = "Stop";
            this.stopOrContinueButton.UseVisualStyleBackColor = true;
            this.stopOrContinueButton.Click += new System.EventHandler(this.OnStopOrContinueButtonClick);
            // 
            // fpsText
            // 
            this.fpsText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpsText.AutoSize = true;
            this.fpsText.Location = new System.Drawing.Point(722, 27);
            this.fpsText.Name = "fpsText";
            this.fpsText.Size = new System.Drawing.Size(41, 12);
            this.fpsText.TabIndex = 3;
            this.fpsText.Text = "fps:60";
            // 
            // FullScreenEffectUIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fpsText);
            this.Controls.Add(this.stopOrContinueButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.openGLCanvas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullScreenEffectUIController";
            this.Text = "FullScreenEffectUIController";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.Load += new System.EventHandler(this.OnLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.openGLCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLCanvas;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button stopOrContinueButton;
        private System.Windows.Forms.Label fpsText;
    }
}