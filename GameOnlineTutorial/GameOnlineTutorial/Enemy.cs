using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOnlineTutorial
{
    public abstract class Enemy : Sprite
    {
        private int health;
        private int damage;

        protected Enemy(Texture2D texture, Rectangle form, int health, int damage)
        {
            this.texture = texture;
            this.form = form;
            this.Health = health;
            this.Damage = damage;
        }

        public Texture2D Texture { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }
    }
}
