using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceExplorer.Game;

namespace SpaceExplorer.Engine
{
    class Node
    {
        public static List<Node> Nodes = new List<Node>();//static. ima samo jedna lista
        public static void UpdateNodes(GameTime gameTime)
        {
            for (int i = Nodes.Count - 1; i >= 0; i--)
            { Nodes[i].Update(gameTime); }
        }
        public virtual void Update(GameTime gameTime)
        { this.Move(this.Direction * this.Speed); this.Sprite.Update(gameTime); }
        public virtual void Draw(SpriteBatch spriteBatch)
            { this.Sprite.Draw(spriteBatch, this.position); }
        //public virtual void Remove()
        //{ this.dead = true;
        //    foreach (Node nod in this.children) { nod.Remove(); }  }
        public static void RemoveDead()
        {
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                if (Nodes[i].dead)
                    { if (Nodes[i].parent != null) {Nodes[i].SetParent(null);} Nodes.RemoveAt(i); }
            }
        }
        private Node parent;
        private List<Node> children = new List<Node>();//private. zato svaki nod ima jednu listu
        Vector2 position;
        public Vector2 Position { get { return this.position; } set { this.Move(value - this.position); } }
        public Vector2 Direction;
        public float Speed;
        public Sprite Sprite;
        private bool dead;
        public bool Dead { get { return this.dead; } }
        
        public Node(SpriteSheet spriteSheet)
        {
            Nodes.Add(this);
            this.Sprite = new Sprite(spriteSheet);
        }
        public void SetParent(Node parent)
        {
            if (this.parent != null)
            { this.parent.children.Remove(this); }
            this.parent = parent;
            if (parent != null)
            { parent.children.Add(this); }
        }
        public void Move(Vector2 amount)
        {   this.position += amount;
            foreach (Node nod in this.children)
                { nod.Move(amount); }
        }
        public Node Getroot()
        {   Node nod = this;
            while (nod.parent != null)
                { nod = nod.parent; }
            return nod;
        }

        #region collison;

        public static bool CheckCollision(Node a, Node b)
        {
            // jednostavni sudari
            if (Vector2.Distance(a.Position + a.Sprite.Origin, b.Position + b.Sprite.Origin) < 70f) { return true; }
            else
                return false;
        }
        #endregion
    }
}
