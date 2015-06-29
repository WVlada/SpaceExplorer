using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SpaceExplorer.Game;

namespace SpaceExplorer.Engine
{
    class Statistika
    {
        static SpriteFont brojNeprijatelja;
        static SpriteFont protekloVreme;
        static SpriteFont enemyNodovi;
        static SpriteFont koJeUListi;
        static SpriteFont health;
        static SpriteFont ugao;
        
        
        public static void UcitajFontove(ContentManager content)
            {
                brojNeprijatelja = content.Load<SpriteFont>("Tahoma");
                protekloVreme    = content.Load<SpriteFont>("Tahoma");
                enemyNodovi = content.Load<SpriteFont>("Tahoma");
                koJeUListi = content.Load<SpriteFont>("Tahoma");
                health = content.Load<SpriteFont>("Tahoma");
                ugao = content.Load<SpriteFont>("Tahoma");
                
            }
        public static void NacrtajFontove(SpriteBatch spriteBatch, GameTime gametime)
        {
            spriteBatch.DrawString(brojNeprijatelja, String.Format("Nodes:{0}, Enemies {1}", Node.Nodes.Count, Enemy.Nodes.Count), new Vector2(Config.Screen_Width - 200, 0), Color.Red, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(protekloVreme, String.Format("Vreme {0}", gametime.TotalGameTime), new Vector2(0, 0), Color.Orange, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(ugao, String.Format("Radijani: {0}, Stepeni: {1}", Player.Players[0].Ship.rotationAngle.ToString("0.0#"), MathHelper.ToDegrees(Player.Players[0].Ship.rotationAngle).ToString("0.0#")), new Vector2((Config.Screen_Width - Config.VelicinaDesnogMenija) / 2, 0), Color.Red, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
            int x = 30;
            int y = 400;
            foreach (Node node in Enemy.Nodes)
            {
                spriteBatch.DrawString(enemyNodovi, String.Format("Svi nodovi: {0},{1},{2},{3},{4}", node.ToString(), node.Position.ToString(), node.Sprite.FrameBounds.Y, node.Sprite.Origin.X + node.Position.X, node.Sprite.Origin.Y + node.Position.Y), new Vector2(0, x), Color.Orange, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
                x += 20;
            }
            if (PlayerShip.PlayerShips.Count > 0)
            {
                foreach (Node node in PlayerShip.PlayerShips[0].CollisionList)
                {
                    spriteBatch.DrawString(koJeUListi, String.Format("Playerova Collision Lista: {0},{1},{2}", node.ToString(), node.Sprite.Origin.X + node.Position.X, node.Sprite.Origin.Y + node.Position.Y), new Vector2(0, y), Color.Orange, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
                    y += 20;
                }
                spriteBatch.DrawString(health, String.Format("Health:{0}", PlayerShip.PlayerShips[0].Health), new Vector2((Config.Screen_Width - Config.VelicinaDesnogMenija) / 2 - 100, 0), Color.Red, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
            }
        }
    }
}
