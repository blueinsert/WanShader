namespace bluebean.ShaderToyOffline
{
    partial class InputChannelSelectUIController
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.miscTabPage = new System.Windows.Forms.TabPage();
            this.miscFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.textureTabPage = new System.Windows.Forms.TabPage();
            this.textureFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.miscTabPage.SuspendLayout();
            this.textureTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.miscTabPage);
            this.tabControl1.Controls.Add(this.textureTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 524);
            this.tabControl1.TabIndex = 0;
            // 
            // miscTabPage
            // 
            this.miscTabPage.Controls.Add(this.miscFlowLayoutPanel);
            this.miscTabPage.Location = new System.Drawing.Point(4, 22);
            this.miscTabPage.Name = "miscTabPage";
            this.miscTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.miscTabPage.Size = new System.Drawing.Size(825, 498);
            this.miscTabPage.TabIndex = 0;
            this.miscTabPage.Text = "Misc";
            this.miscTabPage.UseVisualStyleBackColor = true;
            // 
            // miscFlowLayoutPanel
            // 
            this.miscFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miscFlowLayoutPanel.AutoScroll = true;
            this.miscFlowLayoutPanel.Location = new System.Drawing.Point(0, 2);
            this.miscFlowLayoutPanel.Name = "miscFlowLayoutPanel";
            this.miscFlowLayoutPanel.Size = new System.Drawing.Size(825, 495);
            this.miscFlowLayoutPanel.TabIndex = 1;
            // 
            // textureTabPage
            // 
            this.textureTabPage.Controls.Add(this.textureFlowLayoutPanel);
            this.textureTabPage.Location = new System.Drawing.Point(4, 22);
            this.textureTabPage.Name = "textureTabPage";
            this.textureTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.textureTabPage.Size = new System.Drawing.Size(825, 498);
            this.textureTabPage.TabIndex = 1;
            this.textureTabPage.Text = "Texture";
            this.textureTabPage.UseVisualStyleBackColor = true;
            // 
            // textureFlowLayoutPanel
            // 
            this.textureFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textureFlowLayoutPanel.AutoScroll = true;
            this.textureFlowLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.textureFlowLayoutPanel.Name = "textureFlowLayoutPanel";
            this.textureFlowLayoutPanel.Size = new System.Drawing.Size(825, 495);
            this.textureFlowLayoutPanel.TabIndex = 0;
            // 
            // InputChannelSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 523);
            this.Controls.Add(this.tabControl1);
            this.Name = "InputChannelSelectForm";
            this.Text = "InputChannelSelectForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.LocationChanged += new System.EventHandler(this.OnFormLocationChanged);
            this.tabControl1.ResumeLayout(false);
            this.miscTabPage.ResumeLayout(false);
            this.textureTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage miscTabPage;
        private System.Windows.Forms.FlowLayoutPanel miscFlowLayoutPanel;
        private System.Windows.Forms.TabPage textureTabPage;
        private System.Windows.Forms.FlowLayoutPanel textureFlowLayoutPanel;
    }
}