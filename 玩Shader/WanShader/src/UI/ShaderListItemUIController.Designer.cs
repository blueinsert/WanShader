namespace bluebean.ShaderToyOffline
{
    partial class ShaderListItemUIController
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.nameText = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.glCanvas = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nameText.AutoSize = true;
            this.nameText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nameText.Location = new System.Drawing.Point(104, 106);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(29, 12);
            this.nameText.TabIndex = 1;
            this.nameText.Text = "name";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(160, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
            // 
            // glCanvas
            // 
            this.glCanvas.DrawFPS = false;
            this.glCanvas.Location = new System.Drawing.Point(4, 4);
            this.glCanvas.Name = "glCanvas";
            this.glCanvas.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.glCanvas.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.glCanvas.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.glCanvas.Size = new System.Drawing.Size(231, 134);
            this.glCanvas.TabIndex = 3;
            this.glCanvas.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGL_OnDraw);
            this.glCanvas.Click += new System.EventHandler(this.OnClick);
            this.glCanvas.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.glCanvas.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // ShaderListItemUIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.glCanvas);
            this.Name = "ShaderListItemUIController";
            this.Size = new System.Drawing.Size(238, 138);
            this.Load += new System.EventHandler(this.OnLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameText;
        private System.Windows.Forms.Button deleteButton;
        private SharpGL.OpenGLControl glCanvas;
    }
}
