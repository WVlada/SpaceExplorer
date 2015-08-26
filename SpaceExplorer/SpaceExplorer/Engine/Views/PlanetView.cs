using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceExplorer.Engine;
using SpaceExplorer.Game;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceExplorer.Engine
{
    class PlanetView : GameView
    {

        public Rectangle DonjiDeoEkrana;
        public Rectangle GornjiDeoEkrana;
        public static Texture2D donjiMeni;
        public static Texture2D gornjiMeni;
        public Planet planeta;
        // Minus 30 je velicina gornjeg menija, ne znam zasto mora -
        Vector3 modelPosition = new Vector3(0, 200 - 50, 0);
        float modelRotation = 0.0f;
        Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 1500.0f);
        public int GornjiPlanetInfoMenuDuzina = 35;

        public PlanetView(Planet planet, PlayerShip playerShip)
        {
            DonjiDeoEkrana = new Rectangle(0, base.verticalSize - 250, base.horizontalSize, 250);
            GornjiDeoEkrana = new Rectangle(0, 0, base.horizontalSize, GornjiPlanetInfoMenuDuzina);
            this.planeta = planet;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(donjiMeni, DonjiDeoEkrana, Color.White);
            spriteBatch.Draw(gornjiMeni, GornjiDeoEkrana, Color.White);
            
            planeta.Draw(spriteBatch);
            
            // kopiranje postojecih transformacija
            Matrix[] transforms = new Matrix[planeta.modelPlanete.Bones.Count];
            planeta.modelPlanete.CopyAbsoluteBoneTransformsTo(transforms);
            foreach (ModelMesh mesh in planeta.modelPlanete.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] *
                    Matrix.CreateRotationY(modelRotation)
                    * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition,
                    Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.ToRadians(45.0f), 1.33f,
                    1f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
                MathHelper.ToRadians(-0.02f);

            base.Update(gameTime);
        }
        public static void UcitajPlanetView(ContentManager content)
        {
            donjiMeni = content.Load<Texture2D>("Models\\GasGiantGreen");
            gornjiMeni = content.Load<Texture2D>("Menus\\PlanetTopInfo");
        }

    }
}
