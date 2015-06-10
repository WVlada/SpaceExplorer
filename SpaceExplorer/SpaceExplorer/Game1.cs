using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceExplorer.Engine;
using SpaceExplorer.Game;

namespace SpaceExplorer
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite TestSprite;
        
        ParticleEngine particleEngine;
        
        bool j;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = Config.Screen_Height;
            graphics.PreferredBackBufferWidth = Config.Screen_Width;
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Statistika.UcitajFontove(this.Content);
            SpriteSheet.UcitajSadrzaj(this.Content, this.GraphicsDevice);
            Player.SpawnShip(PlayerIndex.One);

            TestSprite = new Sprite(Config.AsteroidSpriteSheet);

            Level.UcitajPozadinu(this.Content);
            Level.UcitajNeprijatelje();


            // particle engine
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("circle"));
            textures.Add(Content.Load<Texture2D>("star"));
            textures.Add(Content.Load<Texture2D>("diamond"));
            textures.Add(Content.Load<Texture2D>("dot"));
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240));
         }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //pozivam metod koji onda prolazi kroz static listu - nije kao sa nodovima
            Timer.Update(gameTime);
            
            Node.UpdateNodes(gameTime);
            Player.ProcessInput(); 
            
            // Provera sudara
            int g = 0;
            for (int i = 0; i < PlayerShip.PlayerShips[0].CollisionList.Count; i++)
            {
                
                bool m = Node.CheckCollision(PlayerShip.PlayerShips[0], PlayerShip.PlayerShips[0].CollisionList[i]);
                if (m == true) { g += 1; }
                else { };
                if (g > 0) { j = true; } else { j = false; };
                // DOKLE GOD JE U PETLJI ON NE MOZE DA IZADJE
            }
            particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            Level.NacrtajPozadinu(spriteBatch);
            
            if (j == true)
                { TestSprite.Draw(spriteBatch, new Vector2(50f, 50f)); }

            foreach (Node node in Node.Nodes)
            {
                node.Draw(spriteBatch);    
            }

            Statistika.NacrtajFontove(spriteBatch, gameTime);
            spriteBatch.End();
            
            particleEngine.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
