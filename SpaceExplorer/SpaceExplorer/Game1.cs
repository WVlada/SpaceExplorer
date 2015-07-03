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
        
        ParticleEngine particleEngine;
        
        //splitscreen
        Viewport defaultViewport;
        Viewport leftViewport;
        Viewport rightViewport;
        
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
            Sistem.UcitajSadrzaj(this.Content);
            Statistika.UcitajFontove(this.Content);
            SpriteSheet.UcitajSadrzaj(this.Content, this.GraphicsDevice);
            Player.SpawnShip(PlayerIndex.One);
            Sprite.UcitajFontove(this.Content);

            Level.UcitajPozadinu(this.Content);
            Level.UcitajNeprijatelje();
            
            GalaxyMenuView.UcitajPozadinu(this.Content);

            // particle engine
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("circle"));
            textures.Add(Content.Load<Texture2D>("star"));
            textures.Add(Content.Load<Texture2D>("diamond"));
            textures.Add(Content.Load<Texture2D>("dot"));
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240));

            //split creen
            defaultViewport = GraphicsDevice.Viewport;
            leftViewport = defaultViewport;
            rightViewport = defaultViewport;
            leftViewport.Width = Config.Screen_Width - Config.VelicinaDesnogMenija;
            rightViewport.Width = Config.VelicinaDesnogMenija;
            rightViewport.X = leftViewport.Width;
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

            particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();
                        
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Viewport = defaultViewport;
            GraphicsDevice.Clear(Color.Black);
            particleEngine.Draw(spriteBatch);
            
            GraphicsDevice.Viewport = leftViewport;
                
             //   spriteBatch.Begin();
             //      foreach (Node node in Node.Nodes)
              //     {
              //         node.Draw(spriteBatch);
               //    }
                //   Level.NacrtajPozadinu(spriteBatch);
                //spriteBatch.End();
            
                foreach (View vju in Config.TrenutniPogledi)
                {
                    if (vju is MenuToolbarView)
                    {
                        GraphicsDevice.Viewport = rightViewport;
                        spriteBatch.Begin();
                        vju.Draw(spriteBatch);
                        spriteBatch.End();
                    }
                    if (vju is GameView)
                    {
                        GraphicsDevice.Viewport = leftViewport;
                        spriteBatch.Begin();
                        vju.Draw(spriteBatch);
                        foreach (Node node in Node.Nodes)
                                {
                                    node.Draw(spriteBatch);
                                }
                        spriteBatch.End();
                    } 
                }
            // Statistika.NacrtajFontove(spriteBatch, gameTime); 
            // spriteBatch.End();

            // GraphicsDevice.Viewport = rightViewport ;
            // spriteBatch.Begin();
            
            // Level.NacrtajPozadinu(spriteBatch);
    
            // spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
