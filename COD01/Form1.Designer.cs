namespace COD01
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.SuspendLayout();
      // 
      // treeView1
      // 
      this.treeView1.LabelEdit = true;
      this.treeView1.Location = new System.Drawing.Point(116, 13);
      this.treeView1.Margin = new System.Windows.Forms.Padding(4);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(382, 289);
      this.treeView1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(13, 310);
      this.button1.Margin = new System.Windows.Forms.Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(485, 56);
      this.button1.TabIndex = 1;
      this.button1.Text = "載入XML文件";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Enabled = false;
      this.button2.Location = new System.Drawing.Point(13, 374);
      this.button2.Margin = new System.Windows.Forms.Padding(4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(485, 56);
      this.button2.TabIndex = 2;
      this.button2.Text = "匯出XML文件";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Enabled = false;
      this.button3.Location = new System.Drawing.Point(13, 13);
      this.button3.Margin = new System.Windows.Forms.Padding(4);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(95, 40);
      this.button3.TabIndex = 3;
      this.button3.Text = "↑";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Enabled = false;
      this.button4.Location = new System.Drawing.Point(13, 61);
      this.button4.Margin = new System.Windows.Forms.Padding(4);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(95, 40);
      this.button4.TabIndex = 5;
      this.button4.Text = "↓";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // button5
      // 
      this.button5.Enabled = false;
      this.button5.Location = new System.Drawing.Point(13, 212);
      this.button5.Margin = new System.Windows.Forms.Padding(4);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(95, 40);
      this.button5.TabIndex = 6;
      this.button5.Text = "+";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // button6
      // 
      this.button6.Enabled = false;
      this.button6.Location = new System.Drawing.Point(13, 260);
      this.button6.Margin = new System.Windows.Forms.Padding(4);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(95, 40);
      this.button6.TabIndex = 7;
      this.button6.Text = "-";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new System.EventHandler(this.button6_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.Filter = "XML檔案(*.xml)|*.xml";
      this.openFileDialog1.Title = "開啟舊檔";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.Filter = "XML檔案(*.xml)|*.xml";
      this.saveFileDialog1.Title = "另存新檔";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(508, 444);
      this.Controls.Add(this.button6);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.treeView1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form1";
      this.Text = "XML瀏覽器";
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
  }
}

