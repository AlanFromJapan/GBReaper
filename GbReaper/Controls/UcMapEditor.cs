using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GbReaper.Classes;
using GbReaper.Forms;
using FloydSteinberg;

namespace GbReaper.Controls {
    public partial class UcMapEditor : UserControl {
        public const int TILE_ZOOM_FACTOR = 3;
        public const int TILE_SIZE = Tile.HEIGHT_PX * TILE_ZOOM_FACTOR;

        protected enum GridMode { Background, Foreground, None }
        protected GridMode mGridMode = GridMode.Background;

        

        protected Map mCurrentMap = null;
        protected Tile mCurrentTile = null;
        protected UcLibraryList mLibraryList = null;
        public UcLibraryList LibraryList {
            set { mLibraryList = value; }
        }

        
        public Map CurrentMap { 
            get { return this.mCurrentMap; } 
            set {
                if (this.mCurrentMap != null) {
                    this.mCurrentMap.MapChanged -= new EventHandler(CurrentMap_MapChanged);
                }

                this.mCurrentMap = value;
                if (this.mCurrentMap.EmptyTile != null)
                    panEmpty.BackgroundImage = this.mCurrentMap.EmptyTile.Image;
                

                this.mCurrentMap.MapChanged -= new EventHandler(CurrentMap_MapChanged);
                this.mCurrentMap.MapChanged += new EventHandler(CurrentMap_MapChanged);

                this.Invalidate(); 
            } 
        }
        public Tile CurrentTile {
            get { return this.mCurrentTile; }
            set { this.mCurrentTile = value; }
        }
        protected Rectangle GridBorders {
            get {
                return new Rectangle(
                ((panMap.Width - TILE_SIZE * this.mCurrentMap.Width) / 2),
                ((panMap.Height - TILE_SIZE * this.mCurrentMap.Height) / 2) + VertOffset,
                TILE_SIZE * this.mCurrentMap.Width,
                TILE_SIZE * this.mCurrentMap.Height);
            }
        }

        /// <summary>
        /// Gets the VERTICAL offset to apply due to the scrollbar
        /// </summary>
        protected int VertOffset {
            get {
                return (scrolVert.Maximum / 2 - scrolVert.Value) * 5;
            }
        }

        public event EventHandler NewMap;
        public event EventHandler DuplicateMap;

        /// <summary>
        /// THE library used so we can call it back
        /// </summary>
        protected UcLibraryList uclibLibrary = null;

        public UcMapEditor(UcLibraryList pLib) {
            InitializeComponent();

            this.uclibLibrary = pLib;            

            panMap.Paint += new PaintEventHandler(panMap_Paint);
            panMap.MouseDown += new MouseEventHandler(panMap_MouseDown);
            panMap.MouseMove += new MouseEventHandler(panMap_MouseMove);
            
        }



        void panMap_MouseMove(object sender, MouseEventArgs e) {
            //drag n draw
            MousePaintCell(e);


            //update position label
            if (this.mCurrentMap == null)
                return;

            Point vMouse = this.PointToClient(MousePosition);
            vMouse.X -= panTools.Width;

            Rectangle vBorders = GridBorders;
            if (!vBorders.Contains(vMouse)) {
                lblXY.Text = string.Empty;
                return;
            }

            Point vP = new Point(
                (vMouse.X - vBorders.X) / TILE_SIZE,
                (vMouse.Y - vBorders.Y) / TILE_SIZE
                );

            lblXY.Text = "" + vP.X + ";" + vP.Y;            
        }

        public void DeleteTiles(IList<Tile> pTiles) {
            for (int x = 0; x < this.mCurrentMap.Width; x++) {
                for (int y = 0; y < this.mCurrentMap.Height; y++) {
                    Tile vT = this.mCurrentMap[x, y];

                    if (vT != null) {
                        if (pTiles.Contains(vT)) {
                            this.mCurrentMap.ClearTileAt(x, y);
                        }
                    }
                }
            }

            this.panMap.Invalidate();
        }

        private void MousePaintCell(MouseEventArgs e) {
            if (this.mCurrentTile == null || this.mCurrentMap == null)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Right) {
                Rectangle vBorders = GridBorders;
                if (!vBorders.Contains(e.Location))
                    return;

                Point vP = new Point(
                    (e.X - vBorders.X) / TILE_SIZE,
                    (e.Y - vBorders.Y) / TILE_SIZE
                    );

                if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                    if (ModifierKeys == Keys.Control) {
                        //4 cells
                        this.mCurrentMap.SetTile(this.mCurrentTile, vP.X, vP.Y);
                        this.mCurrentMap.SetTile(this.mLibraryList.GetNthNextTile(1) , vP.X, vP.Y +1);
                        this.mCurrentMap.SetTile(this.mLibraryList.GetNthNextTile(2), vP.X+1, vP.Y);
                        this.mCurrentMap.SetTile(this.mLibraryList.GetNthNextTile(3), vP.X+1, vP.Y + 1);

                        this.panMap.Invalidate();
                    }
                    else {
                        //1 cell at a time
                        if (!mFillMode) {

                            //Pick mode?
                            if (mPickMode) {
                                //PICK MODE
                                mPickMode = false;
                                btnPick.BackColor = Control.DefaultBackColor; 

                                Tile vCellTile = this.mCurrentMap[vP.X, vP.Y];

                                //tell the lib to change current tile
                                this.uclibLibrary.SetSelectedTile(vCellTile);
                            }
                            else {
                                //Set start mode?
                                if (mSetStartMode) {
                                    //Do NOT reset, it's a toggle otherwise you might switch to paint mode and overwrite the tiles below

                                    Point vStartPoint = new Point(
                                        (e.X - vBorders.X) / TILE_ZOOM_FACTOR,
                                        (e.Y - vBorders.Y) / TILE_ZOOM_FACTOR
                                        );
                                    mCurrentMap.PlayerStart = vStartPoint;
                                    this.panMap.Invalidate();
                                }
                                else {
                                    //REGULAR PAINT cell by cell
                                    if (this.mCurrentMap[vP.X, vP.Y] != null && this.mCurrentMap[vP.X, vP.Y].Equals(this.mCurrentTile)) {
                                        //ignore, already set
                                    }
                                    else {
                                        //set and repaint
                                        this.mCurrentMap.SetTile(this.mCurrentTile, vP.X, vP.Y);
                                        this.panMap.Invalidate();
                                    }
                                }
                            }
                        }
                        else {
                            //FILL MODE
                            Tile vCellTile = this.mCurrentMap[vP.X, vP.Y];
                            //don't replace by itself or you will have infinite reccursion
                            if (!this.mCurrentTile.Equals(vCellTile)) {
                                RecFillTile(vP, vCellTile, this.mCurrentTile);
                                this.panMap.Invalidate();
                            }
                        }
                    }

                }
                else { 
                    //right click clears
                    this.mCurrentMap.ClearTileAt(vP.X, vP.Y);
                    this.panMap.Invalidate();
                }
            }
        }

        /// <summary>
        /// Reccursive fill algo
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pReplacedTile"></param>
        /// <param name="pNewTile"></param>
        private void RecFillTile(Point pPosition, Tile pReplacedTile, Tile pNewTile) {
            if (pPosition.X < 0 || pPosition.X >= this.mCurrentMap.Width ||
                pPosition.Y < 0 || pPosition.Y >= this.mCurrentMap.Height) {
                    return;
            }

            if (this.mCurrentMap[pPosition.X, pPosition.Y] != null 
                && 
                !this.mCurrentMap[pPosition.X, pPosition.Y].Equals(pReplacedTile)) {
                return;
            }

            //new we know it's wether null wether same as replaceTile
            this.mCurrentMap.SetTile(pNewTile, pPosition.X, pPosition.Y);

            //reccurse
            RecFillTile(new Point(pPosition.X - 1, pPosition.Y), pReplacedTile, pNewTile);
            RecFillTile(new Point(pPosition.X + 1, pPosition.Y), pReplacedTile, pNewTile);
            RecFillTile(new Point(pPosition.X, pPosition.Y - 1), pReplacedTile, pNewTile);
            RecFillTile(new Point(pPosition.X, pPosition.Y + 1), pReplacedTile, pNewTile);
        }

        void panMap_MouseDown(object sender, MouseEventArgs e) {
            MousePaintCell(e);
        }

        void panMap_Paint(object sender, PaintEventArgs e) {
            if (this.mCurrentMap == null) {
                e.Graphics.DrawString("no map selected", this.panMap.Font, Brushes.Red, e.ClipRectangle, StringFormat.GenericDefault);
                return;
            }

            //make the grid
            int vMaxX = e.ClipRectangle.Width / TILE_SIZE;
            int vMaxY = e.ClipRectangle.Height / TILE_SIZE;

            //Get the limits
            Rectangle vBorders = GridBorders;

            //draw BACKGROUND grid
            if (mGridMode == GridMode.Background) {
                DrawingLogic.DrawGrid(e.Graphics, vBorders, Pens.LightGray, this.mCurrentMap.Width, this.mCurrentMap.Height);
            }

            //draw the external borders
            e.Graphics.DrawRectangle(Pens.Turquoise, vBorders);

            //if (mSelectedPoint != Point.Empty && vBorders.Contains(mSelectedPoint)) {
            //    Rectangle vSelected = new Rectangle(
            //        vBorders.X + TILE_SIZE * ((mSelectedPoint.X - vBorders.X) / TILE_SIZE) ,
            //        vBorders.Y + TILE_SIZE * ((mSelectedPoint.Y - vBorders.Y) / TILE_SIZE),
            //        TILE_SIZE,
            //        TILE_SIZE);
            //    e.Graphics.DrawRectangle(Pens.Red, vSelected);

            //}


            //Draw content at last
            DrawingLogic.SetGraphicsNoInterpol(e.Graphics);
            for (int x = 0; x < this.mCurrentMap.Width; x++) { 
                for (int y = 0; y < this.mCurrentMap.Height; y++) {
                    Tile vT = this.mCurrentMap[x, y];

                    if (vT != null) {
                        e.Graphics.DrawImage(vT.Image,
                            vBorders.X + x * TILE_SIZE,
                            vBorders.Y + y * TILE_SIZE,
                            TILE_SIZE,
                            TILE_SIZE
                            );
                    }
                } 
            }

            //draw FOREGROUND grid
            if (mGridMode == GridMode.Foreground) {
                DrawingLogic.DrawGrid(e.Graphics, vBorders, Pens.DarkRed, this.mCurrentMap.Width, this.mCurrentMap.Height);
            }

            //Draw start position
            Rectangle vStart = new Rectangle(
                vBorders.X + (-8 + mCurrentMap.PlayerStart.X) * TILE_ZOOM_FACTOR,
                vBorders.Y + (-16 + mCurrentMap.PlayerStart.Y) * TILE_ZOOM_FACTOR,
                16 * TILE_ZOOM_FACTOR,
                16 * TILE_ZOOM_FACTOR);
            e.Graphics.DrawRectangle(Pens.Red, vStart);

        }

        private void btnNew_Click(object sender, EventArgs e) {
            //using (FrmNewMap vFrm = new FrmNewMap()) {
            //    if (DialogResult.OK == vFrm.ShowDialog(this)) {
            //        if (this.mCurrentMap != null) {
            //            this.mCurrentMap.MapChanged -= new EventHandler(CurrentMap_MapChanged);
            //        }

            //        this.mCurrentMap = new Map(vFrm.CreateWidth, vFrm.CreateHeight);
            //        this.mCurrentMap.MapChanged -= new EventHandler(CurrentMap_MapChanged);
            //        this.mCurrentMap.MapChanged += new EventHandler(CurrentMap_MapChanged);
            //        this.mCurrentMap.Name = vFrm.CreateName;
                    
            //        this.Invalidate();
            //        //this.Refresh();
            //    }
            //}

            OnNewMap();

        }

        protected void OnNewMap() {
            if (this.NewMap != null) {
                this.NewMap(this, EventArgs.Empty);
            }
        }

        protected void OnDuplicateMap() {
            if (this.DuplicateMap != null) {
                this.DuplicateMap(this, EventArgs.Empty);
            }
        }

        void CurrentMap_MapChanged(object sender, EventArgs e) {
            this.Invalidate();
            //this.Refresh();
        }

        private void btnGrid_Click(object sender, EventArgs e) {
            if (this.mGridMode == GridMode.Background)
                this.mGridMode = GridMode.Foreground;
            else
                if (this.mGridMode == GridMode.Foreground)
                    this.mGridMode = GridMode.None;
                else
                    if (this.mGridMode == GridMode.None)
                        this.mGridMode = GridMode.Background;


            this.panMap.Invalidate();
        }

        private void btnTilizator_Click(object sender, EventArgs e) {
            using (FrmTilizator vFrm = new FrmTilizator()) {
                if (vFrm.ShowDialog(this) == DialogResult.OK) { 
                    //Start: create target bitmap with right size
                    Bitmap vTarget = DrawingLogic.CopyAndResize(vFrm.CreateBmp, Tile.WIDTH_PX * vFrm.CreateWidth, Tile.HEIGHT_PX * vFrm.CreateHeight);

                    //map colors
                    Palette vPal = Palette.DEFAULT_PALETTE;
                    
                    switch (vFrm.ColorMethod) {
                        case FrmTilizator.METHOD_NEAREST:
                            //Updates the bitmap in parameter
                            vTarget = DrawingLogic.MapBitmapColorsToPalette(vTarget, vPal);
                            break;
                        case FrmTilizator.METHOD_FLOYDSTEINBERG:
                            vTarget = FloydSteinbergDither.Process(vTarget, vPal.mColors);
                            break;

                    }

                    //tilization
                    int vTileNewCount = 0, vTileReusedCount = 0;
                    for (int x = 0; x < vFrm.CreateWidth; x++) {
                        for (int y = 0; y < vFrm.CreateHeight; y++) {
                            Rectangle vTileRect = new Rectangle(x * Tile.WIDTH_PX, y * Tile.HEIGHT_PX, Tile.WIDTH_PX, Tile.HEIGHT_PX);
                            Bitmap vTileBmp = (Bitmap)vTarget.Clone(vTileRect, vTarget.PixelFormat);

                            //make new tile and add/get similar from library
                            Tile vT = new Tile(vTileBmp, vPal);
                            bool vTileAlreadyExisted = false;
                            vT = this.mCurrentMap.ParentProject.mLibraries[0].AddTileWithoutDuplicate(vT, out vTileAlreadyExisted);

                            if (!vTileAlreadyExisted) 
                                vTileNewCount++;
                            else 
                                vTileReusedCount++;

                            //apply the tile to the map
                            this.mCurrentMap.SetTile(vT, vFrm.CreateLeft + x, vFrm.CreateTop+ y);
                        }
                    }

                    //refresh
                    panMap.Invalidate();

                    ((FrmMain)this.FindForm()).SetStatus("Tilization: generated " + vTileNewCount + " tiles, reused "+vTileReusedCount+" tiles.");
                }
            }
        }

        private bool mFillMode = false;
        private void btnFill_Click(object sender, EventArgs e) {
            mFillMode = !mFillMode;

            if (mFillMode) {
                ((Control)sender).BackColor = Color.Gold;
            }
            else { 
                ((Control)sender).BackColor = Control.DefaultBackColor; 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Really delete map?", "Comfirm map deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            this.mCurrentMap.ParentProject.DeleteMap(this.mCurrentMap);

            if (this.Parent is TabPage) {
                TabPage vTP = (TabPage)this.Parent;
                TabControl vTC = (TabControl)vTP.Parent;

                vTC.TabPages.Remove(vTP);
            }
        }

        private bool mPickMode = false;
        private void btnPick_Click(object sender, EventArgs e) {
            //MessageBox.Show("Click on a tile to make it the current one."); >> helper zone below screen is better
            mPickMode = !mPickMode;

            if (mSetStartMode) {
                btnPick.BackColor = Color.Gold;
            }
            else {
                btnPick.BackColor = Control.DefaultBackColor;
            }
        }



        private void btnDuplicate_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to duplicate that map?", "Confirm duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)) {
                this.OnDuplicateMap();
            }
        }

        private void scrolVert_ValueChanged(object sender, EventArgs e)
        {
            panMap.Invalidate();
        }

        private void panEmpty_Click(object sender, EventArgs e) {
            this.mCurrentMap.EmptyTile = this.mCurrentTile;
            panEmpty.BackgroundImage = this.mCurrentMap.EmptyTile.Image;
        }

        private void panEmpty_Paint(object sender, PaintEventArgs e) {

        }

        private bool mSetStartMode = false;
        private void btnSetStart_Click(object sender, EventArgs e) {
            mSetStartMode = !mSetStartMode;

            if (mSetStartMode) {
                btnSetStart.BackColor = Color.Gold;
            }
            else {
                btnSetStart.BackColor = Control.DefaultBackColor;
            }
        }
    }
}
