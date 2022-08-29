namespace GbReaper.Controls {
    partial class UcMapEditor {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMapEditor));
            this.panTools = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnTilizator = new System.Windows.Forms.Button();
            this.btnGrid = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panMap = new GbReaper.Controls.PanelX();
            this.label1 = new System.Windows.Forms.Label();
            this.panEmpty = new GbReaper.Controls.PanelX();
            this.lblXY = new System.Windows.Forms.Label();
            this.scrolVert = new System.Windows.Forms.VScrollBar();
            this.panTools.SuspendLayout();
            this.panMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTools
            // 
            this.panTools.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panTools.Controls.Add(this.btnNew);
            this.panTools.Controls.Add(this.btnDuplicate);
            this.panTools.Controls.Add(this.btnPick);
            this.panTools.Controls.Add(this.btnDelete);
            this.panTools.Controls.Add(this.btnFill);
            this.panTools.Controls.Add(this.btnTilizator);
            this.panTools.Controls.Add(this.btnGrid);
            this.panTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTools.Location = new System.Drawing.Point(0, 0);
            this.panTools.Name = "panTools";
            this.panTools.Size = new System.Drawing.Size(32, 308);
            this.panTools.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNew.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNew.Location = new System.Drawing.Point(0, 206);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 35);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.toolTip1.SetToolTip(this.btnNew, "Add a new map");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuplicate.Location = new System.Drawing.Point(0, 241);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(32, 32);
            this.btnDuplicate.TabIndex = 6;
            this.btnDuplicate.Text = "Dup";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnPick
            // 
            this.btnPick.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPick.Location = new System.Drawing.Point(0, 105);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(32, 35);
            this.btnPick.TabIndex = 5;
            this.btnPick.Text = "&Pick";
            this.toolTip1.SetToolTip(this.btnPick, "Pick the tile on the map and makes it current tile");
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(0, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 35);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Del";
            this.toolTip1.SetToolTip(this.btnDelete, "Deletes the current map");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFill
            // 
            this.btnFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFill.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFill.Image = ((System.Drawing.Image)(resources.GetObject("btnFill.Image")));
            this.btnFill.Location = new System.Drawing.Point(0, 70);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(32, 35);
            this.btnFill.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnFill, "Fill with current tile");
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnTilizator
            // 
            this.btnTilizator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTilizator.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTilizator.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTilizator.Image = ((System.Drawing.Image)(resources.GetObject("btnTilizator.Image")));
            this.btnTilizator.Location = new System.Drawing.Point(0, 35);
            this.btnTilizator.Name = "btnTilizator";
            this.btnTilizator.Size = new System.Drawing.Size(32, 35);
            this.btnTilizator.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnTilizator, "Tilizator: convert an image to tiles");
            this.btnTilizator.UseVisualStyleBackColor = true;
            this.btnTilizator.Click += new System.EventHandler(this.btnTilizator_Click);
            // 
            // btnGrid
            // 
            this.btnGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrid.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnGrid.Image")));
            this.btnGrid.Location = new System.Drawing.Point(0, 0);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(32, 35);
            this.btnGrid.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnGrid, "Grid mode: back, front, none");
            this.btnGrid.UseVisualStyleBackColor = true;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // panMap
            // 
            this.panMap.Controls.Add(this.label1);
            this.panMap.Controls.Add(this.panEmpty);
            this.panMap.Controls.Add(this.lblXY);
            this.panMap.Controls.Add(this.scrolVert);
            this.panMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMap.Location = new System.Drawing.Point(32, 0);
            this.panMap.Name = "panMap";
            this.panMap.Size = new System.Drawing.Size(373, 308);
            this.panMap.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(0, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Empty tile";
            // 
            // panEmpty
            // 
            this.panEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panEmpty.Location = new System.Drawing.Point(3, 3);
            this.panEmpty.Name = "panEmpty";
            this.panEmpty.Size = new System.Drawing.Size(32, 32);
            this.panEmpty.TabIndex = 4;
            this.panEmpty.Click += new System.EventHandler(this.panEmpty_Click);
            this.panEmpty.Paint += new System.Windows.Forms.PaintEventHandler(this.panEmpty_Paint);
            // 
            // lblXY
            // 
            this.lblXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXY.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblXY.Location = new System.Drawing.Point(309, 286);
            this.lblXY.Name = "lblXY";
            this.lblXY.Size = new System.Drawing.Size(47, 20);
            this.lblXY.TabIndex = 1;
            this.lblXY.Text = "x;y";
            this.lblXY.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // scrolVert
            // 
            this.scrolVert.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrolVert.Location = new System.Drawing.Point(356, 0);
            this.scrolVert.Name = "scrolVert";
            this.scrolVert.Size = new System.Drawing.Size(17, 308);
            this.scrolVert.TabIndex = 0;
            this.scrolVert.Value = 50;
            this.scrolVert.ValueChanged += new System.EventHandler(this.scrolVert_ValueChanged);
            // 
            // UcMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panMap);
            this.Controls.Add(this.panTools);
            this.DoubleBuffered = true;
            this.Name = "UcMapEditor";
            this.Size = new System.Drawing.Size(405, 308);
            this.panTools.ResumeLayout(false);
            this.panMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTools;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnGrid;
        private PanelX panMap;
        private System.Windows.Forms.Button btnTilizator;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.VScrollBar scrolVert;
        private System.Windows.Forms.Label lblXY;
        private PanelX panEmpty;
        private System.Windows.Forms.Label label1;
    }
}
