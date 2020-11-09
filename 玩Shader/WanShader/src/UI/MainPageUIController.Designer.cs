namespace bluebean.ShaderToyOffline
{
    partial class MainPageUIController
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addNewButton = new System.Windows.Forms.Button();
            this.PanelLoading = new System.Windows.Forms.Panel();
            this.loadingText = new System.Windows.Forms.Label();
            this.glCanvas = new SharpGL.OpenGLControl();
            this.PanelMainPage = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.PanelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas)).BeginInit();
            this.PanelMainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.addNewButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1260, 602);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnScroll);
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(3, 3);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(231, 138);
            this.addNewButton.TabIndex = 0;
            this.addNewButton.Text = "New";
            this.addNewButton.UseVisualStyleBackColor = true;
            this.addNewButton.Click += new System.EventHandler(this.OnNewButtonClick);
            // 
            // PanelLoading
            // 
            this.PanelLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelLoading.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PanelLoading.Controls.Add(this.loadingText);
            this.PanelLoading.Controls.Add(this.glCanvas);
            this.PanelLoading.Location = new System.Drawing.Point(0, 0);
            this.PanelLoading.Name = "PanelLoading";
            this.PanelLoading.Size = new System.Drawing.Size(1260, 602);
            this.PanelLoading.TabIndex = 1;
            // 
            // loadingText
            // 
            this.loadingText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loadingText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loadingText.Location = new System.Drawing.Point(1069, 541);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(150, 33);
            this.loadingText.TabIndex = 3;
            this.loadingText.Text = "loading";
            this.loadingText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // glCanvas
            // 
            this.glCanvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.glCanvas.DrawFPS = false;
            this.glCanvas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.glCanvas.Location = new System.Drawing.Point(355, 108);
            this.glCanvas.Name = "glCanvas";
            this.glCanvas.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.glCanvas.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.glCanvas.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.glCanvas.Size = new System.Drawing.Size(480, 320);
            this.glCanvas.TabIndex = 2;
            this.glCanvas.OpenGLDraw += new SharpGL.RenderEventHandler(this.OnGLDraw);
            // 
            // PanelMainPage
            // 
            this.PanelMainPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMainPage.Controls.Add(this.flowLayoutPanel1);
            this.PanelMainPage.Location = new System.Drawing.Point(0, 0);
            this.PanelMainPage.Name = "PanelMainPage";
            this.PanelMainPage.Size = new System.Drawing.Size(1260, 605);
            this.PanelMainPage.TabIndex = 2;
            // 
            // MainPageUIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 603);
            this.Controls.Add(this.PanelMainPage);
            this.Controls.Add(this.PanelLoading);
            this.Name = "MainPageUIController";
            this.Text = "MainPageUIController";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.Load += new System.EventHandler(this.OnLoad);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.PanelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas)).EndInit();
            this.PanelMainPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel PanelLoading;
        private System.Windows.Forms.Panel PanelMainPage;
        private SharpGL.OpenGLControl glCanvas;
        private System.Windows.Forms.Label loadingText;
        private System.Windows.Forms.Button addNewButton;
    }
}