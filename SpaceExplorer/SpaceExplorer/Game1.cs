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
            GalaxyView.UcitajSadrzaj(this.Content);
            GalaxyMenuView.UcitajPozadinu(this.Content);
            SistemMenuView.UcitajPozadinu(this.Content);
            Sistem.UcitajSadrzaj(this.Content);
            //Statistika.UcitajFontove(this.Content);
            //Sprite.UcitajFontove(this.Content);
            
            PlayerShip.ucitajPodatke(this.Content);
            //Level.UcitajPozadinu(this.Content);
            
            
            // ovde je bitan redosled jer mi se ne bio ucitale Origin vredsnosti za PlayerShip!!!!
            SpriteSheet.UcitajSadrzaj(this.Content, this.GraphicsDevice);
            Player Igrac = new Player();

            GalaxyMenuView.UcitajPozadinu(this.Content);
            Level.UcitajNeprijatelje();
            
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

            PlayerShip.PlayerShips[0].Update(gameTime);
            //Node.UpdateNodes(gameTime);
            Player.ProcessInput();

            Sistem.UpdateNodes(gameTime);

            // drzanje player u granicama - treba da implementirar izlazak iz sistema - mozda sa eventom? !!!!!Player.IzasaoSamIzSistema!!!!! - ovo sa eventom
            if (PlayerShip.PlayerShips[0].Position.X + PlayerShip.PlayerShips[0].Sprite.Width / 2 < 0) 
            {
                PlayerShip.PlayerShips[0].Position = new Vector2(0 - PlayerShip.PlayerShips[0].Sprite.Width / 2, PlayerShip.PlayerShips[0].Position.Y);
                
                if (Config.TrenutniPogledi[0] is SistemView) 
                    Config.TrenutniPogledi[0] = new GalaxyView(PlayerShip.PlayerShips[0], SistemView.TrenutniSistem); 
                    Config.TrenutniPogledi[1] = new GalaxyMenuView(); 
            }

            if (PlayerShip.PlayerShips[0].Position.Y < 0 - PlayerShip.PlayerShips[0].Sprite.Height / 2) 
            {
                PlayerShip.PlayerShips[0].Position = new Vector2(PlayerShip.PlayerShips[0].Position.X, 0 - PlayerShip.PlayerShips[0].Sprite.Height / 2 );
            
                if (Config.TrenutniPogledi[0] is SistemView) Config.TrenutniPogledi[0] = new GalaxyView(PlayerShip.PlayerShips[0], SistemView.TrenutniSistem);
                    Config.TrenutniPogledi[1] = new GalaxyMenuView(); 
            }
            if (PlayerShip.PlayerShips[0].Position.X > Config.TrenutniPogledi[0].horizontalSize - PlayerShip.PlayerShips[0].Sprite.Width/2)
            {
                PlayerShip.PlayerShips[0].Position = new Vector2(Config.TrenutniPogledi[0].horizontalSize - PlayerShip.PlayerShips[0].Sprite.Width / 2, PlayerShip.PlayerShips[0].Position.Y);
                if (Config.TrenutniPogledi[0] is SistemView) 
                    Config.TrenutniPogledi[0] = new GalaxyView(PlayerShip.PlayerShips[0], SistemView.TrenutniSistem); 
                    Config.TrenutniPogledi[1] = new GalaxyMenuView(); 
            }
            if (PlayerShip.PlayerShips[0].Position.Y > Config.TrenutniPogledi[0].verticalSize - PlayerShip.PlayerShips[0].Sprite.Height / 2) 
            {
                PlayerShip.PlayerShips[0].Position = new Vector2(PlayerShip.PlayerShips[0].Position.X, Config.TrenutniPogledi[0].verticalSize - PlayerShip.PlayerShips[0].Sprite.Height / 2);
                if (Config.TrenutniPogledi[0] is SistemView) 
                    Config.TrenutniPogledi[0] = new GalaxyView(PlayerShip.PlayerShips[0], SistemView.TrenutniSistem); 
                    Config.TrenutniPogledi[1] = new GalaxyMenuView(); 
            }
            
            particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();
                        
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Viewport = defaultViewport;
            GraphicsDevice.Clear(Color.Black);
            particleEngine.Draw(spriteBatch);
            
            GraphicsDevice.Viewport = leftViewport;
                
            
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

                          PlayerShip.PlayerShips[0].Draw(spriteBatch);
                        //Player.Players[0].Ship.Draw(spriteBatch);
                        spriteBatch.End();
                    } 
                }
                        
            base.Draw(gameTime);
        }
    }
}
