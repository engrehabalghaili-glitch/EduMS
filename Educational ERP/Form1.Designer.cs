namespace WindowsFormsApp10_listview
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("اسم الملف");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("حجم الملف");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("تاريخ دخول الملف");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("نوع الملف");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvdriv = new System.Windows.Forms.ListView();
            this.tvfol = new System.Windows.Forms.TreeView();
            this.lvfil = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvdriv
            // 
            this.lvdriv.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvdriv.HideSelection = false;
            this.lvdriv.Location = new System.Drawing.Point(0, 0);
            this.lvdriv.Name = "lvdriv";
            this.lvdriv.Size = new System.Drawing.Size(800, 92);
            this.lvdriv.TabIndex = 0;
            this.lvdriv.UseCompatibleStateImageBehavior = false;
            // 
            // tvfol
            // 
            this.tvfol.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvfol.Location = new System.Drawing.Point(0, 92);
            this.tvfol.Name = "tvfol";
            this.tvfol.Size = new System.Drawing.Size(381, 358);
            this.tvfol.TabIndex = 1;
            // 
            // lvfil
            // 
            this.lvfil.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvfil.HideSelection = false;
            this.lvfil.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lvfil.LargeImageList = this.imageList1;
            this.lvfil.Location = new System.Drawing.Point(387, 92);
            this.lvfil.Name = "lvfil";
            this.lvfil.Size = new System.Drawing.Size(413, 358);
            this.lvfil.SmallImageList = this.imageList1;
            this.lvfil.TabIndex = 2;
            this.lvfil.UseCompatibleStateImageBehavior = false;
            this.lvfil.SelectedIndexChanged += new System.EventHandler(this.lvfil_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "548285.jpg");
            this.imageList1.Images.SetKeyName(1, "thumb-1920-424608.jpg");
            this.imageList1.Images.SetKeyName(2, "thumb-1920-461038.jpg");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvfil);
            this.Controls.Add(this.tvfol);
            this.Controls.Add(this.lvdriv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvdriv;
        private System.Windows.Forms.TreeView tvfol;
        private System.Windows.Forms.ListView lvfil;
        private System.Windows.Forms.ImageList imageList1;
    }
}

