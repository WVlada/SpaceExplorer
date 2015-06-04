using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SpaceExplorer.Engine
{
    enum SpriteSheetMode
    {   Normalan = 0,
        BezTekstureZaStetu = 1,}
    
    class SpriteSheet
    {
        public static List<SpriteSheet> spriteSheets = new List<SpriteSheet>();
        public string assetName;
        int tilesX;
        int tilesY;
        int tileWidth;
        int tileHeight;
        int frameCount;
        double frameInterval;
        SpriteSheetMode mode;
        Texture2D[] teksture;

        public int TilesX { get { return this.tilesX; } }
        public int TileWidth { get { return this.tileWidth; } }
        public int TileHeight { get { return this.tileHeight; } }
        public int FrameCount { get { return this.frameCount; } }
        public double FrameInterval { get { return this.frameInterval; } }
        public Texture2D[] Teksture { get { return this.teksture; } }

        public SpriteSheet(string assetName, int tilesX, int tilesY, double frameRate, int frameCount, SpriteSheetMode mod)
        {
            spriteSheets.Add(this);
            this.teksture = new Texture2D[2];
            this.assetName = assetName;
            this.tilesX = tilesX;
            this.tilesY = tilesY;
            this.frameCount = frameCount;
            this.frameInterval = 1 / frameRate;
            this.mode = mod;
        }

        void PostaviTeksturu(Texture2D tekstura, GraphicsDevice graphicDevice)
        {
            this.teksture[0] = tekstura;
            if (mode == SpriteSheetMode.Normalan)
            { this.teksture[1] = NapraviDamageTeksturu(tekstura, graphicDevice); }
            else
            { this.teksture[1] = null; }

            this.tileWidth = tekstura.Width / this.tilesX;
            this.tileHeight = tekstura.Height / this.tilesY;
        }
        static Texture2D NapraviDamageTeksturu(Texture2D tekstura, GraphicsDevice graphicsDevice)
        {
            int brojpixela = tekstura.Width * tekstura.Height;
            Color[] pikseli = new Color[brojpixela];
            tekstura.GetData<Color>(pikseli);
            for (int i = 0; i < pikseli.Length; i++)
            {
                if (pikseli[i].A > 10)
                {
                    byte offset = 100;
                    byte r = (byte)Math.Min(pikseli[i].R + offset, 255);
                    byte g = (byte)Math.Min(pikseli[i].G + offset, 255);
                    byte b = (byte)Math.Min(pikseli[i].B + offset, 255);
                    float alfa = pikseli[i].A;
                    pikseli[i] = new Color(r, g, b, alfa);
                }
            }
            Texture2D outTekstura = new Texture2D(graphicsDevice, tekstura.Width, tekstura.Height, false, SurfaceFormat.Color);
            outTekstura.SetData<Color>(pikseli);
            return outTekstura;
        }

        public static void UcitajSadrzaj(ContentManager content, GraphicsDevice graphicDevice)
        {
            foreach (SpriteSheet sprajtsheet in spriteSheets)
            {
                sprajtsheet.PostaviTeksturu(content.Load<Texture2D>(sprajtsheet.assetName), graphicDevice);
            }
        }
    }
}
