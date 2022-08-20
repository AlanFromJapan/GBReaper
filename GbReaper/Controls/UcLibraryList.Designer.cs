namespace GbReaper.Controls {
    partial class UcLibraryList {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcLibraryList));
            this.lvLibrary = new System.Windows.Forms.ListView();
            this.panTop = new System.Windows.Forms.Panel();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.lblTileCount = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelX1 = new GbReaper.Controls.PanelX();
            this.panLast3 = new GbReaper.Controls.PanelX();
            this.panLast2 = new GbReaper.Controls.PanelX();
            this.panLast1 = new GbReaper.Controls.PanelX();
            this.panLast4 = new GbReaper.Controls.PanelX();
            this.panLast5 = new GbReaper.Controls.PanelX();
            this.panTop.SuspendLayout();
            this.panelX1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLibrary
            // 
            this.lvLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLibrary.HideSelection = false;
            this.lvLibrary.Location = new System.Drawing.Point(0, 35);
            this.lvLibrary.Name = "lvLibrary";
            this.lvLibrary.OwnerDraw = true;
            this.lvLibrary.Size = new System.Drawing.Size(381, 185);
            this.lvLibrary.TabIndex = 1;
            this.lvLibrary.UseCompatibleStateImageBehavior = false;
            this.lvLibrary.View = System.Windows.Forms.View.Tile;
            this.lvLibrary.SelectedIndexChanged += new System.EventHandler(this.lvLibrary_SelectedIndexChanged);
            this.lvLibrary.DoubleClick += new System.EventHandler(this.lvLibrary_DoubleClick);
            this.lvLibrary.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvLibrary_MouseDown);
            this.lvLibrary.MouseLeave += new System.EventHandler(this.lvLibrary_MouseLeave);
            this.lvLibrary.MouseHover += new System.EventHandler(this.lvLibrary_MouseHover);
            this.lvLibrary.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvLibrary_MouseMove);
            this.lvLibrary.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvLibrary_MouseUp);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnDuplicate);
            this.panTop.Controls.Add(this.lblTileCount);
            this.panTop.Controls.Add(this.btnRename);
            this.panTop.Controls.Add(this.btnDel);
            this.panTop.Controls.Add(this.btnNew);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(381, 35);
            this.panTop.TabIndex = 2;
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuplicate.Location = new System.Drawing.Point(96, 0);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(32, 35);
            this.btnDuplicate.TabIndex = 4;
            this.btnDuplicate.Text = "Dup";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // lblTileCount
            // 
            this.lblTileCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTileCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileCount.Location = new System.Drawing.Point(312, 0);
            this.lblTileCount.Name = "lblTileCount";
            this.lblTileCount.Size = new System.Drawing.Size(69, 35);
            this.lblTileCount.TabIndex = 3;
            this.lblTileCount.Text = "Tiles: 0";
            this.lblTileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRename
            // 
            this.btnRename.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.Location = new System.Drawing.Point(64, 0);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(32, 35);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Ren";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDel.Image = global::GbReaper.Properties.Resources.delete;
            this.btnDel.Location = new System.Drawing.Point(32, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(32, 35);
            this.btnDel.TabIndex = 1;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 35);
            this.btnNew.TabIndex = 0;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panelX1
            // 
            this.panelX1.Controls.Add(this.panLast5);
            this.panelX1.Controls.Add(this.panLast4);
            this.panelX1.Controls.Add(this.panLast3);
            this.panelX1.Controls.Add(this.panLast2);
            this.panelX1.Controls.Add(this.panLast1);
            this.panelX1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelX1.Location = new System.Drawing.Point(0, 220);
            this.panelX1.Name = "panelX1";
            this.panelX1.Size = new System.Drawing.Size(381, 57);
            this.panelX1.TabIndex = 3;
            // 
            // panLast3
            // 
            this.panLast3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLast3.Location = new System.Drawing.Point(79, 6);
            this.panLast3.Name = "panLast3";
            this.panLast3.Size = new System.Drawing.Size(32, 32);
            this.panLast3.TabIndex = 3;
            this.panLast3.Click += new System.EventHandler(this.panLast1_Click);
            this.panLast3.Paint += new System.Windows.Forms.PaintEventHandler(this.panLast1_Paint);
            // 
            // panLast2
            // 
            this.panLast2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLast2.Location = new System.Drawing.Point(41, 6);
            this.panLast2.Name = "panLast2";
            this.panLast2.Size = new System.Drawing.Size(32, 32);
            this.panLast2.TabIndex = 3;
            this.panLast2.Click += new System.EventHandler(this.panLast1_Click);
            this.panLast2.Paint += new System.Windows.Forms.PaintEventHandler(this.panLast1_Paint);
            // 
            // panLast1
            // 
            this.panLast1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLast1.Location = new System.Drawing.Point(3, 6);
            this.panLast1.Name = "panLast1";
            this.panLast1.Size = new System.Drawing.Size(32, 32);
            this.panLast1.TabIndex = 3;
            this.panLast1.Click += new System.EventHandler(this.panLast1_Click);
            this.panLast1.Paint += new System.Windows.Forms.PaintEventHandler(this.panLast1_Paint);
            // 
            // panLast4
            // 
            this.panLast4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLast4.Location = new System.Drawing.Point(117, 6);
            this.panLast4.Name = "panLast4";
            this.panLast4.Size = new System.Drawing.Size(32, 32);
            this.panLast4.TabIndex = 4;
            this.panLast4.Click += new System.EventHandler(this.panLast1_Click);
            this.panLast4.Paint += new System.Windows.Forms.PaintEventHandler(this.panLast1_Paint);
            // 
            // panLast5
            // 
            this.panLast5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLast5.Location = new System.Drawing.Point(155, 6);
            this.panLast5.Name = "panLast5";
            this.panLast5.Size = new System.Drawing.Size(32, 32);
            this.panLast5.TabIndex = 4;
            this.panLast5.Click += new System.EventHandler(this.panLast1_Click);
            this.panLast5.Paint += new System.Windows.Forms.PaintEventHandler(this.panLast1_Paint);
            // 
            // UcLibraryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvLibrary);
            this.Controls.Add(this.panelX1);
            this.Controls.Add(this.panTop);
            this.Name = "UcLibraryList";
            this.Size = new System.Drawing.Size(381, 277);
            this.Load += new System.EventHandler(this.UcLibraryList_Load);
            this.panTop.ResumeLayout(false);
            this.panelX1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLibrary;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Label lblTileCount;
        private System.Windows.Forms.Button btnDuplicate;
        private PanelX panelX1;
        private PanelX panLast3;
        private PanelX panLast2;
        private PanelX panLast1;
        private PanelX panLast5;
        private PanelX panLast4;
    }
}
