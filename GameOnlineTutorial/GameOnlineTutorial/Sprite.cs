using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOnlineTutorial
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        protected Rectangle form;
        protected Vector2 position;
        protected Color color;


        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.form, Color.White);
        }

        // Setting properties for all the fields
        protected Texture2D Texture { get; set; }

        protected Rectangle Form { get; set; }

        protected Vector2 Position { get; set; }

    }
}
