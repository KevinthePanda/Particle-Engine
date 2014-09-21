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
    class ParticleEngine
    {
        private MouseState mouseStateCurrent;
        private int textureState = 1;
        private KeyboardState textureOldState = Keyboard.GetState();

        int total = 10; //total number of particles. edit to create more/less
        //properties and fields
        private Random random; // random number generator
        public Vector2 EmitterLocation { get; set; } //loction of the emitter of particles
        private List<Particle> particles;//list of particles active in the engine
        private List<Texture2D> textures;// list of textures avaliable 

        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location; //user choses the location
            this.textures = textures; //user choses the textures
            this.particles = new List<Particle>(); //creates the list of particles
            random = new Random(); //creates the random generator
        }

        // add fps
        // add ability to increase particles
        // add ability to change particle colours
        // add ability to change particle shapes

        public void Update() //update method which adds new particles, gets particles to update themselves, and removes particles from the engine
        {
            KeyboardState newState = Keyboard.GetState();
            
            if (newState.IsKeyDown(Keys.W) && total < 600)
            {
                total++;
            }
            else if(newState.IsKeyDown(Keys.S) && total >= 5)
            {
                total--;
            }

            if (newState.IsKeyDown(Keys.D) &&  textureOldState.IsKeyUp(Keys.D))
            {
                textureState++;
            }
            else if (newState.IsKeyDown(Keys.A) && textureOldState.IsKeyUp(Keys.A))
            {
                textureState--;
            }

            if (textureState <= 0)
            {
                textureState = 4;
            }
            else if (textureState >=5)
            {
                textureState = 1;
            }
            textureOldState = newState;

            mouseStateCurrent = Mouse.GetState();
            for (int i = 0; i < total; i++)
            {
                if (mouseStateCurrent.LeftButton == ButtonState.Pressed)
                {
                    particles.Add(GenerateNewParticle()); //creates all the particles 
                }
            }

            for (int particle = 0; particle < particles.Count; particle++) //loops through every particle 
            {
                particles[particle].Update(); //calls update to each particle
                if (particles[particle].TTL <= 0) //removes the particle if it dies
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        private Particle GenerateNewParticle() //method reates the actual particle
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 pos = EmitterLocation;
            Vector2 vel = new Vector2(
                                    1f * (float)(random.NextDouble() * 2 - 1),
                                    1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVel = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color();
            if (textureState == 1)
            {
                color = new Color(
                            (float)random.NextDouble(),
                            (float)random.NextDouble(),
                            (float)random.NextDouble());               
            }
            else if(textureState == 2)
            {
                color = Color.Cyan;
            }
            else if(textureState == 3)
            {
                color = Color.Red;
            }
            else
            {                
                color = Color.Gold;
            }
            float size = (float)random.NextDouble();
            int ttl = 20 + random.Next(40);
            return new Particle(texture, pos, vel, angle, angularVel, color, size, ttl);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch); //calls Particle class's draw method for each particle
            }

            
        }


    }

}
