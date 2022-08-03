namespace CVROfflinePreview
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
            this.label1 = new System.Windows.Forms.Label();
            this.localMapSelect = new System.Windows.Forms.ComboBox();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.btnMapLiveReload = new System.Windows.Forms.Button();
            this.btnForceInit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.localAvatarSelect = new System.Windows.Forms.ComboBox();
            this.btnLoadAvatar = new System.Windows.Forms.Button();
            this.btnLoadProp = new System.Windows.Forms.Button();
            this.localPropSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.propPosX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.propPosY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.propPosZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.getPlayerPos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a local map project 选择一个本地地图工程";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // localMapSelect
            // 
            this.localMapSelect.FormattingEnabled = true;
            this.localMapSelect.Location = new System.Drawing.Point(33, 98);
            this.localMapSelect.Name = "localMapSelect";
            this.localMapSelect.Size = new System.Drawing.Size(247, 25);
            this.localMapSelect.TabIndex = 1;
            this.localMapSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(33, 129);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(111, 23);
            this.btnLoadMap.TabIndex = 2;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMapClick);
            // 
            // btnMapLiveReload
            // 
            this.btnMapLiveReload.Location = new System.Drawing.Point(150, 129);
            this.btnMapLiveReload.Name = "btnMapLiveReload";
            this.btnMapLiveReload.Size = new System.Drawing.Size(130, 23);
            this.btnMapLiveReload.TabIndex = 3;
            this.btnMapLiveReload.Text = "Start Live Reload";
            this.btnMapLiveReload.UseVisualStyleBackColor = true;
            this.btnMapLiveReload.Click += new System.EventHandler(this.btnMapLiveReloadClick);
            // 
            // btnForceInit
            // 
            this.btnForceInit.Location = new System.Drawing.Point(33, 35);
            this.btnForceInit.Name = "btnForceInit";
            this.btnForceInit.Size = new System.Drawing.Size(247, 30);
            this.btnForceInit.TabIndex = 4;
            this.btnForceInit.Text = "Force init game without login";
            this.btnForceInit.UseVisualStyleBackColor = true;
            this.btnForceInit.Click += new System.EventHandler(this.forceInit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select a local avatar project 选择一个本地模型工程";
            // 
            // localAvatarSelect
            // 
            this.localAvatarSelect.FormattingEnabled = true;
            this.localAvatarSelect.Location = new System.Drawing.Point(33, 187);
            this.localAvatarSelect.Name = "localAvatarSelect";
            this.localAvatarSelect.Size = new System.Drawing.Size(247, 25);
            this.localAvatarSelect.TabIndex = 6;
            // 
            // btnLoadAvatar
            // 
            this.btnLoadAvatar.Location = new System.Drawing.Point(33, 218);
            this.btnLoadAvatar.Name = "btnLoadAvatar";
            this.btnLoadAvatar.Size = new System.Drawing.Size(247, 23);
            this.btnLoadAvatar.TabIndex = 7;
            this.btnLoadAvatar.Text = "Load Avatar";
            this.btnLoadAvatar.UseVisualStyleBackColor = true;
            this.btnLoadAvatar.Click += new System.EventHandler(this.btnLoadAvatrClick);
            // 
            // btnLoadProp
            // 
            this.btnLoadProp.Location = new System.Drawing.Point(33, 336);
            this.btnLoadProp.Name = "btnLoadProp";
            this.btnLoadProp.Size = new System.Drawing.Size(247, 23);
            this.btnLoadProp.TabIndex = 10;
            this.btnLoadProp.Text = "Load Prop";
            this.btnLoadProp.UseVisualStyleBackColor = true;
            this.btnLoadProp.Click += new System.EventHandler(this.btnLoadPropClick);
            // 
            // localPropSelect
            // 
            this.localPropSelect.FormattingEnabled = true;
            this.localPropSelect.Location = new System.Drawing.Point(33, 277);
            this.localPropSelect.Name = "localPropSelect";
            this.localPropSelect.Size = new System.Drawing.Size(247, 25);
            this.localPropSelect.TabIndex = 9;
            this.localPropSelect.SelectedIndexChanged += new System.EventHandler(this.localPropSelect_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select a local prop project 选择一个本地道具工程";
            // 
            // propPosX
            // 
            this.propPosX.Location = new System.Drawing.Point(54, 308);
            this.propPosX.Name = "propPosX";
            this.propPosX.Size = new System.Drawing.Size(46, 23);
            this.propPosX.TabIndex = 11;
            this.propPosX.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "X";
            // 
            // propPosY
            // 
            this.propPosY.Location = new System.Drawing.Point(141, 308);
            this.propPosY.Name = "propPosY";
            this.propPosY.Size = new System.Drawing.Size(46, 23);
            this.propPosY.TabIndex = 13;
            this.propPosY.Text = "0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Y";
            // 
            // propPosZ
            // 
            this.propPosZ.Location = new System.Drawing.Point(234, 308);
            this.propPosZ.Name = "propPosZ";
            this.propPosZ.Size = new System.Drawing.Size(46, 23);
            this.propPosZ.TabIndex = 15;
            this.propPosZ.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Z";
            // 
            // getPlayerPos
            // 
            this.getPlayerPos.Location = new System.Drawing.Point(35, 367);
            this.getPlayerPos.Name = "getPlayerPos";
            this.getPlayerPos.Size = new System.Drawing.Size(244, 22);
            this.getPlayerPos.TabIndex = 17;
            this.getPlayerPos.Text = "Get Player\'s Pos";
            this.getPlayerPos.UseVisualStyleBackColor = true;
            this.getPlayerPos.Click += new System.EventHandler(this.getPlayerPos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 471);
            this.Controls.Add(this.getPlayerPos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.propPosZ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.propPosY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.propPosX);
            this.Controls.Add(this.btnLoadProp);
            this.Controls.Add(this.localPropSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadAvatar);
            this.Controls.Add(this.localAvatarSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnForceInit);
            this.Controls.Add(this.btnMapLiveReload);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.localMapSelect);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(324, 510);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(324, 510);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "CVROfflinePreview | CVR地图离线预览";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox localMapSelect;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.Button btnMapLiveReload;
        private System.Windows.Forms.Button btnForceInit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox localAvatarSelect;
        private System.Windows.Forms.Button btnLoadAvatar;
        private System.Windows.Forms.Button btnLoadProp;
        private System.Windows.Forms.ComboBox localPropSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox propPosX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox propPosY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox propPosZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button getPlayerPos;
    }
}