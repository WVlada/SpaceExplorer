using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SpaceExplorer.Engine
{
    class Sprite
    {
        SpriteSheet sheet;
        int frame;
        double frameTimeRemaining;
        uint textureIndex;
        public event NotifyHandler KrajLoopa;
        public static SpriteFont pozicijaSprajta;
                
        public Vector2 Origin;
        public int Width { get { return this.sheet.TileWidth; } }
        public int Height { get { return this.sheet.TileHeight; } }
        public Texture2D Texture { get { return this.sheet.Teksture[textureIndex]; } }
        public uint TextureIndex { get { return this.textureIndex; } set { if (value < this.sheet.Teksture.Length && this.sheet.Teksture[value] != null) { this.textureIndex = value; } } }

        public Sprite(SpriteSheet spriteSheet)
            {
            this.sheet = spriteSheet;
            this.frameTimeRemaining = sheet.FrameInterval;
            this.Origin = new Vector2(spriteSheet.TileWidth / 2, spriteSheet.TileHeight / 2);
            }
        public void Update(GameTime gameTime)
            {
            this.frameTimeRemaining -= gameTime.ElapsedGameTime.TotalSeconds;
            if (this.frameTimeRemaining <= 0)
                {
                    this.frame++;
                    if (this.frame >= this.sheet.FrameCount)
                        {
                            this.frame = 0;
                            
                            if (this.KrajLoopa != null)
                            { this.KrajLoopa(); }
                            //ako postoji registrovan risiver, pokreni metod}
                            //a risiver registrujem u trenutku stvaranja eksplozije
                        }
                    this.frameTimeRemaining = this.sheet.FrameInterval;    
                }
            }

        public Rectangle FrameBounds { get { int x = frame % sheet.TilesX * sheet.TileWidth;
                                             int y = frame / sheet.TilesX * sheet.TileHeight;
                                             return new Rectangle(x, y, sheet.TileWidth, sheet.TileHeight);}}
        
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
            {
            spriteBatch.Draw(this.Texture, position, this.FrameBounds, Color.White);
            spriteBatch.DrawString(pozicijaSprajta, position.ToString(), position, Color.Wheat,0f,new Vector2(0,0),0.5f,SpriteEffects.None,0f);
            }
        public static void UcitajFontove(ContentManager con)
        {
            
            pozicijaSprajta = con.Load<SpriteFont>("Tahoma");
        }
        
    }
}
