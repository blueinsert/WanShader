namespace bluebean.ShaderToyOffline
{
    partial class ThumbGenUIController
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
            this.loadingText = new System.Windows.Forms.Label();
            this.glCanvas = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingText
            // 
            this.loadingText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loadingText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loadingText.Location = new System.Drawing.Point(605, 385);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(150, 33);
            this.loadingText.TabIndex = 0;
            this.loadingText.Text = "loading";
            this.loadingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // glCanvas
            // 
            this.glCanvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.glCanvas.DrawFPS = false;
            this.glCanvas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.glCanvas.Location = new System.Drawing.Point(157, 40);
            this.glCanvas.Name = "glCanvas";
            this.glCanvas.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.glCanvas.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.glCanvas.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.glCanvas.Size = new System.Drawing.Size(480, 320);
            this.glCanvas.TabIndex = 1;
            this.glCanvas.OpenGLDraw += new SharpGL.RenderEventHandler(this.OnGLDraw);
            // 
            // ThumbGenUIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadingText);
            this.Controls.Add(this.glCanvas);
            this.Name = "ThumbGenUIController";
            this.Text = "ThumbGenUIController";
            this.Load += new System.EventHandler(this.OnLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loadingText;
        private SharpGL.OpenGLControl glCanvas;
    }
}