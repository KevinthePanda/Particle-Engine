﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Particle
{
    public class Particle
    {
        public Texture2D Texture { get; set; }        // The texture that will be drawn to represent the particle
        public Vector2 Position { get; set; }        // The current position of the particle        
        public Vector2 Velocity { get; set; }        // The speed of the particle at the current instance
        public float Angle { get; set; }            // The current angle of rotation of the particle
        public float AngularVelocity { get; set; }    // The speed that the angle is changing
        public Color Color { get; set; }            // The color of the particle
        public float Size { get; set; }                // The size of the particle
        public int TTL { get; set; }                // The 'time to live' of the particle
           
    }
}
