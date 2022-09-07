﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace GbReaper.Classes {
    public class GbProject {
        public List<Map> mMaps = new List<Map>();
        public List<Library> mLibraries = new List<Library>();
        protected string mLatestKnownFilename = null;

        protected Palette mPalette = Palette.DEFAULT_PALETTE;
        public Palette Palette {
            get { return this.mPalette; }
            set { this.mPalette = value; }
        }

        public string LatestKnownFilename {
            get { return mLatestKnownFilename; }
            set { mLatestKnownFilename = value; }
        }

        public GbProject() { 
            
        }

        public void AddMap(Map pNewMap) {
            this.mMaps.Add(pNewMap);
            pNewMap.ParentProject = this;
        }

        public void DeleteMap(Map pMap) {
            this.mMaps.Remove(pMap);
            pMap.ParentProject = null;
        }

        /// <summary>
        /// Exports the library and maps to C files
        /// </summary>
        /// <param name="pPath"></param>
        /// <param name="pGenerateStubMain"></param>
        /// <param name="pGridOnMaps"></param>
        /// <param name="pRemoveUnusedTiles"></param>
        public void ExportToGBDK(string pPath, bool pGenerateStubMain, bool pGridOnMaps, bool pRemoveUnusedTiles) {
            foreach (Library vLin in mLibraries) {
                vLin.ExportToGBDK(pPath);
                vLin.ExportToPNG(pPath);
            }

            foreach (Map vM in mMaps) {
                vM.ExportToGBDK(pPath, mLibraries);
                vM.ExportToPNG(pPath, pGridOnMaps);
            }

            if (pGenerateStubMain)
                this.ExportToGBDK_Main(pPath);
        }

        private void ExportToGBDK_Main(string pPath) {
            string vFilename = Path.Combine(pPath, "main.c");

            using (FileStream vFS = new FileStream(vFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
                using (StreamWriter vSW = new StreamWriter(vFS)) {
                    vSW.WriteLine(@"
/*************************
**
** Autogenerated stub for basic program that just displays the first Map.
** Made by GbReaper at {0}
** AlanFromJapan - https://electrogeek.cc
**
*/

#include <gb/gb.h>
#include <gb/drawing.h>

#include ""{1}.h""
#include ""{2}.h""

void main() {{
    SPRITES_8x8;

    set_sprite_data(0, {1}_COUNT, {1});
    set_bkg_data(0, {1}_COUNT, {1});
    set_bkg_tiles(0, 0, {2}_WIDTH, {2}_HEIGHT, {2});

    SHOW_BKG;
    SHOW_SPRITES;

    wait_vbl_done();

    while (1) {{
        wait_vbl_done();

    }}
}}

", DateTime.Now.ToString(), this.mLibraries[0].NameClean, this.mMaps[0].Name);
                }
            }
        }

        public void SaveAs(string pFilename) {

            
            using (FileStream vFS = new FileStream(pFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
                using (StreamWriter vSW = new StreamWriter(vFS)) {
                    vSW.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
                    vSW.WriteLine("<gbProject format=\"1.0\">");

                    vSW.WriteLine("\t<palette name=\""+this.mPalette.mName+"\">");
                    vSW.WriteLine("\t</palette>");

                    vSW.WriteLine("\t<libraries>");
                    foreach (Library vLib in this.mLibraries) {
                        vLib.SaveToStream(vSW);
                    }    
                    vSW.WriteLine("\t</libraries>");

                    vSW.WriteLine("\t<maps>");
                    foreach (Map vM in this.mMaps) {
                        vM.SaveToStream(vSW);
                    }    
                    vSW.WriteLine("\t</maps>");

                    vSW.WriteLine("</gbProject>");
                }                
            }
        }

        public static GbProject LoadFromFile(String pFilename) {
            GbProject vResult = new GbProject();

            using (FileStream vFS = new FileStream(pFilename, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                using (StreamReader vSR = new StreamReader(vFS)) {
                    XmlDocument vDoc = new XmlDocument();
                    vDoc.LoadXml(vSR.ReadToEnd());

                    //pick the palette
                    XmlNode vPalet = vDoc.DocumentElement.SelectSingleNode("/gbProject/palette");
                    if (vPalet != null && Palette.WellknownPalettes.ContainsKey(vPalet.Attributes["name"].Value))
                        vResult.mPalette = Palette.WellknownPalettes[vPalet.Attributes["name"].Value];
                    else
                        vResult.mPalette = Palette.DEFAULT_PALETTE;

                    //First, load the library and its tiles
                    foreach (XmlNode vNode in vDoc.DocumentElement.SelectNodes("/gbProject/libraries/library")) {
                        Library vLib = new Library(vNode.Attributes["name"].Value);

                        foreach (XmlNode vNodeTile in vNode.SelectNodes("./tile")) {
                            Tile vS = Tile.LoadFromXml(vNodeTile, vResult.Palette);
                            vLib.AddTile(vS);
                        }

                        vResult.mLibraries.Add(vLib);
                    }

                    //Second, load the maps
                    foreach (XmlNode vNode in vDoc.DocumentElement.SelectNodes("/gbProject/maps/map")) {
                        Map vMap = new Map(
                            Convert.ToInt32(vNode.Attributes["width"].Value),
                            Convert.ToInt32(vNode.Attributes["height"].Value)
                            );
                        vMap.Name = vNode.Attributes["name"].Value;
                        //if there IS an empty tile
                        if (vNode.Attributes["emptyTile"] != null && !string.IsNullOrEmpty(vNode.Attributes["emptyTile"].Value)) {
                            vMap.EmptyTile = vResult.mLibraries[0].GetTileByID(Guid.Parse(vNode.Attributes["emptyTile"].Value));
                        }
                        //if there IS a start position
                        if (vNode.Attributes["startX"] != null && !string.IsNullOrEmpty(vNode.Attributes["startX"].Value)) {
                            Point p = new Point(Int32.Parse(vNode.Attributes["startX"].Value), Int32.Parse(vNode.Attributes["startY"].Value));
                            vMap.PlayerStart = p;
                        }

                        foreach (XmlNode vNodeCell in vNode.SelectNodes("./cell")) {
                            Guid vG = new Guid(vNodeCell.Attributes["tileID"].Value);
                            Tile vT = null;

                            foreach (Library vL in vResult.mLibraries) {
                                vT = vL.GetTileByID(vG);
                                if (vT != null)
                                    break;
                            }

                            if (vT != null) {
                                vMap.SetTile(
                                    vT,
                                    Convert.ToInt32(vNodeCell.Attributes["x"].Value),
                                    Convert.ToInt32(vNodeCell.Attributes["y"].Value)
                                );
                            }
                        }

                        vResult.AddMap(vMap);
                    }
                }
            }

            return vResult;
        }

        /// <summary>
        /// Remove all the tiles from the library that are not used somewhere in a map
        /// </summary>
        public void RemoveUnusedTiles() {
            //ok I&m too lazy to think of optimized code

            foreach (Library l in this.mLibraries) {

                for (int i = 0; i < l.Count<Tile>(); ) {
                    Tile t = l[i];

                    //used?
                    bool used = false;
                    foreach (Map m in this.mMaps) {
                        for (int x = 0; !used && x < m.Width; x++) {
                            for (int y = 0; !used && y < m.Height; y++) {
                                used = used || t == m[x, y];
                            }
                        }

                        if (used)
                            break;
                    }

                    if (used)
                        i++;
                    else {
                        //not used
                        l.DeleteTile(t);
                        //don't increment i
                    }
                }
            }
        }
    }
}
