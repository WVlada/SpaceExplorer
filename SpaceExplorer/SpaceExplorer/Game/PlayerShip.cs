using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using SpaceExplorer.Engine;
using Microsoft.Xna.Framework.Content;

namespace SpaceExplorer.Game
{
    delegate void UcitajSistem(Sistem vju, PlayerShip ship);
    
    class PlayerShip : Ship
    {
        public static List<GameNode> PlayerShips = new List<GameNode>();

        public ShipEngine shipEngine;
        public ShipHealthBar shipHealthBar;
        public event UcitajSistem sudarSaSistemom;
        public static SpriteFont polozajUGalaksiji;
        public int daljinaOdProslogSistema;
        public Vector2 Position2;
        public float kilometara;
        public float kilometaraZaVracanjeUSistem;
        public bool spremanZaPonovanUlazakUSistem;


        public PlayerShip(SpriteSheet spriteSheet)
            : base(spriteSheet)
        {
            PlayerShips.Add(this);
            this.Speed = Config.PlayerShipSpeed;
            this.Health = Config.PlayerShipHealth;
            this.Position = Config.PlayerShipSpawnPosition;
            this.CollisionList = new List<GameNode>();

            this.rotationAngle = 0f;
            this.shipEngine = new ShipEngine(Config.PlayerShipEngine);
            this.shipHealthBar = new ShipHealthBar(Config.ShipHealthBar);
            this.ExplosionSpriteSheet = Config.PlayerShipExplosionSpriteSheet;
            this.kilometara = 0;
            this.kilometaraZaVracanjeUSistem = 0;
            this.spremanZaPonovanUlazakUSistem = true;
            // da registrujem event tek nakon sto napravim brod
            Config.TrenutniPogledi[0] = new GalaxyView(this);
        }

        public override void Move(Vector2 amount)
        {
            base.Move(amount);
            this.kilometara += (Math.Abs(amount.X) + Math.Abs(amount.Y)) / Config.brzinaTrosenjaGoriva;
            this.kilometaraZaVracanjeUSistem += (Math.Abs(amount.X) + Math.Abs(amount.Y)) / Config.brzinaTrosenjaGoriva;
            if (kilometaraZaVracanjeUSistem >= Config.kilometaraZaVracanjeuSistem) { this.spremanZaPonovanUlazakUSistem = true;}
        }

        public override void Update(GameTime gameTime)
        {
            if (this.CollisionList != null)
            {
                for (int i = CollisionList.Count - 1; i >= 0; i--)
                {
                    if (this.CollisionList.Count != 0)
                    {
                        if (PlayerShip.PlayerShips[0].CollisionList[i] is Sistem)
                        {

                            if (Node.CheckCollision(PlayerShip.PlayerShips[0], PlayerShip.PlayerShips[0].CollisionList[i]))
                            { this.Collide(this.CollisionList[i]); }
                            //this mi zamenjjuje -> PlayerShip.PlayerShips[0]
                        }
                    }
                }
            }
            base.Update(gameTime);
         }
        
        public void Collide(GameNode nodeSaKojimSamSeSudario)
        {
            // nije sjajno resenje jer ne mogu da se vratim u sistem iz kog sam izasao, mozda kad istrosim koju litru goriva da resetujem trenutni sistem?
            if (nodeSaKojimSamSeSudario is Sistem && Config.TrenutniPogledi[0] is GalaxyView)
                //{ Config.TrenutniPogledi[0] = new SistemView(nodeSaKojimSamSeSudario, this); Config.TrenutniPogledi[1] = new SistemMenuView(); }
                this.sudarSaSistemom(nodeSaKojimSamSeSudario as Sistem, this);
            //nodeSaKojimSamSeSudario != SistemView.TrenutniSistem
            if (nodeSaKojimSamSeSudario is Enemy && Config.TrenutniPogledi[0] is SistemView)
            {
                this.TakeDamage(nodeSaKojimSamSeSudario.Health);
                nodeSaKojimSamSeSudario.TakeDamage(this.Health);
            }
            //ovde mi je greska, jer u drugom updajtu, vrednost helta enemija je -80, pa to oduzimam od mog helta...
            // znaci moram da implamentiram Remove()
        }
        public override void TakeDamage(double iznosStete)
        // znaci ne mogu i GameNode i PlayerShip da imaju TakeDamage metod, tome sluzi VIRTUAL metod
        {
            this.Health -= iznosStete;
            if (this.Health <= 0)
            { this.Explode(); PlayerShip.PlayerShips.Remove(this); 
              Nodes.Remove(this); Nodes.Remove(this.shipHealthBar); 
              Nodes.Remove(this.shipEngine); this.CollisionList.Clear(); 
            // moram sve poskidati, jer dobijam index out of range - svi ovi nodovi
            // zavise od polozaja playershipa za crtanje, a njega vise nema
            }
        }
        public float rotationAngle;
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Sprite.Texture, this.Position + this.Sprite.Origin, this.Sprite.FrameBounds, Color.White, this.rotationAngle, this.Sprite.Origin, 1f, SpriteEffects.None, 0f);
            if (Config.TrenutniPogledi[0] is GalaxyView)
            { spriteBatch.DrawString(polozajUGalaksiji, this.Position.ToString().TrimStart(char.Parse("{")).TrimEnd(char.Parse("}")), new Vector2(Config.TrenutniPogledi[0].horizontalSize/2,0), Color.Wheat); }
            spriteBatch.DrawString(polozajUGalaksiji, this.kilometara.ToString("0.##"), new Vector2(Config.TrenutniPogledi[0].horizontalSize / 2 - 100, 0), Color.Wheat); 
                
        }

        // pomeranje svake sekunde za po (1,1)
        Timer tajmer;
        public void Makac()
        {
            tajmer = new Timer();
            tajmer.Start(1);
            tajmer.Fire += new NotifyHandler(tajmer_Fire);
        }
        void tajmer_Fire()
        {
            this.Direction = new Vector2(1, 1);
            tajmer.Stop();
        }

        public void PomeriSe()
        {
            if (Config.currentSpeed > 200) { Config.currentSpeed = 200; }
            if (Config.currentSpeed <= 0) { Config.currentSpeed = 0; }
            // jer su u xna-u 0 rotacija sprajta je udesno
            Vector2 pravac = new Vector2((float)Math.Sin(rotationAngle), - (float)Math.Cos(rotationAngle));
            pravac.Normalize();
            this.Move(pravac*Config.currentSpeed);
        }
        
        public static void ucitajPodatke(ContentManager cont)
        {
            polozajUGalaksiji = cont.Load<SpriteFont>("Tahoma");
        }



        // parametri broda

        public int Gorivo;


    }
}
