namespace PhotoAlbum
{
    partial class LoadFromFolder
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.Sall = new System.Windows.Forms.Button();
            this.DSall = new System.Windows.Forms.Button();
            this.Del = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1139, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Sall
            // 
            this.Sall.Location = new System.Drawing.Point(41, 445);
            this.Sall.Name = "Sall";
            this.Sall.Size = new System.Drawing.Size(86, 23);
            this.Sall.TabIndex = 1;
            this.Sall.Text = "Select All";
            this.Sall.UseVisualStyleBackColor = true;
            this.Sall.Click += new System.EventHandler(this.Sall_Click);
            // 
            // DSall
            // 
            this.DSall.Location = new System.Drawing.Point(174, 445);
            this.DSall.Name = "DSall";
            this.DSall.Size = new System.Drawing.Size(105, 23);
            this.DSall.TabIndex = 2;
            this.DSall.Text = "Dis Select All";
            this.DSall.UseVisualStyleBackColor = true;
            this.DSall.Click += new System.EventHandler(this.DSall_Click);
            // 
            // Del
            // 
            this.Del.Location = new System.Drawing.Point(333, 444);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(75, 23);
            this.Del.TabIndex = 3;
            this.Del.Text = "Delete";
            this.Del.UseVisualStyleBackColor = true;
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(474, 443);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // LoadFromFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 528);
            this.Controls.Add(this.save);
            this.Controls.Add(this.Del);
            this.Controls.Add(this.DSall);
            this.Controls.Add(this.Sall);
            this.Controls.Add(this.listView1);
            this.Name = "LoadFromFolder";
            this.Text = "LoadFromFolder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Sall;
        private System.Windows.Forms.Button DSall;
        private System.Windows.Forms.Button Del;
        private System.Windows.Forms.Button save;
    }
}