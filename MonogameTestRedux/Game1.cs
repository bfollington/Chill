#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Artemis;
using Artemis.System;

#endregion

namespace Chill
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        EntityWorld entityWorld;

        public Game1 ()
        {
            graphics = new GraphicsDeviceManager (this);
            Content.RootDirectory = "Content";                
            graphics.IsFullScreen = false;        
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize ()
        {

            spriteBatch = new SpriteBatch (GraphicsDevice);
            entityWorld = new EntityWorld();

            EntitySystem.BlackBoard.SetEntry("SpriteBatch", this.spriteBatch);
            EntitySystem.BlackBoard.SetEntry("ContentManager", this.Content);

            this.entityWorld.InitializeAll(true);

            var e = entityWorld.CreateEntity();
            e.AddComponentFromPool<Transform>();
            e.AddComponentFromPool<Texture2DRenderer>();
            e.GetComponent<Transform>().x = 128;
            e.GetComponent<Texture2DRenderer>().TextureName = "Area1Tileset";

            // TODO: Add your initialization logic here
            base.Initialize ();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent ()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update (GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            #if !__IOS__
            if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
                Exit ();
            }
            #endif
            // TODO: Add your update logic here     

            entityWorld.Update();
                          
            base.Update (gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw (GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

            spriteBatch.Begin();

            entityWorld.Draw();

            spriteBatch.End();
            
            base.Draw (gameTime);
        }
    }
}

