namespace WindowsFormsApplication7
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上書き保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.書き込みToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOMへ書き込みToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "HEXソース(*.hex)|*.hex|全てのファイル (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "HEXソース(*.hex)|*.hex|全てのファイル (*.*)|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(618, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.書き込みToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くToolStripMenuItem,
            this.名前を付けて保存ToolStripMenuItem,
            this.上書き保存ToolStripMenuItem,
            this.新規作成ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
            // 
            // 名前を付けて保存ToolStripMenuItem
            // 
            this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
            this.名前を付けて保存ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存";
            this.名前を付けて保存ToolStripMenuItem.Click += new System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
            // 
            // 上書き保存ToolStripMenuItem
            // 
            this.上書き保存ToolStripMenuItem.Enabled = false;
            this.上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            this.上書き保存ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.上書き保存ToolStripMenuItem.Text = "上書き保存";
            this.上書き保存ToolStripMenuItem.Click += new System.EventHandler(this.上書き保存ToolStripMenuItem_Click);
            // 
            // 新規作成ToolStripMenuItem
            // 
            this.新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
            this.新規作成ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.新規作成ToolStripMenuItem.Text = "新規作成";
            this.新規作成ToolStripMenuItem.Click += new System.EventHandler(this.新規作成ToolStripMenuItem_Click);
            // 
            // 書き込みToolStripMenuItem
            // 
            this.書き込みToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rOMへ書き込みToolStripMenuItem});
            this.書き込みToolStripMenuItem.Name = "書き込みToolStripMenuItem";
            this.書き込みToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.書き込みToolStripMenuItem.Text = "書き込み";
            // 
            // rOMへ書き込みToolStripMenuItem
            // 
            this.rOMへ書き込みToolStripMenuItem.Name = "rOMへ書き込みToolStripMenuItem";
            this.rOMへ書き込みToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.rOMへ書き込みToolStripMenuItem.Text = "ROMへ書き込み";
            this.rOMへ書き込みToolStripMenuItem.Click += new System.EventHandler(this.rOMへ書き込みToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(593, 281);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "接続";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 19);
            this.textBox2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(450, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Erase";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(337, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "オペコード書き込み";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(261, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "MODE 1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(134, 1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(472, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(133, 19);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Location = new System.Drawing.Point(48, 340);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(180, 19);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox5.Location = new System.Drawing.Point(234, 340);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(185, 19);
            this.textBox5.TabIndex = 11;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(425, 340);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(181, 19);
            this.textBox6.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 384);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ROM_WRITER";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上書き保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新規作成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 書き込みToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOMへ書き込みToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
    }
}

