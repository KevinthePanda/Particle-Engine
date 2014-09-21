using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PEngine
{
    class Particle //class for a single particle
    {
        //properties
        public Texture2D Texture { get; set; } //actual texture value either a circle/star/diamond
        public Vector2 Pos { get; set; } //position of the particle
        public Vector2 Vel { get; set; } //velocity of the particle
        public float Angle { get; set; } //angle in which the particle moves
        public float AngularVel { get; set; } //velocity in which the angle changes
        public Color Color { get; set; } //Color of the particle
        public float Size { get; set; } //size of the particle
        public int TTL { get; set; } //total time of life for the particle

        //constructor
        public Particle(Texture2D texture, Vector2 pos, Vector2 vel,
            float angle, float angularVel, Color color, float size, int ttl)
        {
            Texture = texture;
            Pos = pos;
            Vel = vel;
            Angle = angle;
            AngularVel = angularVel;
            Color = color;
            Size = size;
            TTL = ttl;
        }

        //update method
        //upadtes the position by the current velocity and the andgle by the angular velocity
        //also updates the total time of life for the particle
        public void Update()
        {
            TTL--;
            Pos += Vel;
            Angle += AngularVel;
        }

        //draw method
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height); //source rectangle which will cover the entire texture
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2); //orgin of the sprite used as the center of rotation. This will be the center of the texture

            spriteBatch.Draw(Texture, Pos, sourceRectangle, Color,
                Angle, origin, Size, SpriteEffects.None, 0f);
        }
    }
}
