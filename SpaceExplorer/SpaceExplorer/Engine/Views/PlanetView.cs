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
        public static Texture2D donjiMeni;
        public Planet planeta;
        Vector3 modelPosition = new Vector3(0, 0, 0);
        float modelRotation = 0.0f;
        Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 50.0f);

        public PlanetView(Planet planet, PlayerShip playerShip)
        {
            DonjiDeoEkrana = new Rectangle(0, base.verticalSize - 100, base.horizontalSize, 100);
            this.planeta = planet;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(donjiMeni, DonjiDeoEkrana, Color.Red);
            spriteBatch.Draw(planeta.Sprite.Texture, new Rectangle(0, 0, 100, 100), Color.Red);
            
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
                    MathHelper.ToRadians(45.0f), Game1.aspectRatio,
                    1.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
                MathHelper.ToRadians(-0.1f);

            base.Update(gameTime);
        }
        public static void UcitajPlanetView(ContentManager content)
        {
            donjiMeni = content.Load<Texture2D>("dot");
        }

    }
}
