using System;
using Artemis;
using Artemis.System;
using Artemis.Attributes;
using Artemis.Manager;
using MonogameTestRedux;
using Microsoft.Xna.Framework.Graphics;


namespace Chill
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 0)]
    public class RenderSystem : EntityProcessingSystem
    {
        public RenderSystem () : base(Aspect.All(typeof(Transform), typeof(Texture2DRenderer))) { }


        public override void Process (Entity entity)
        {
            var transform = entity.GetComponent<Transform>();
            var renderer = entity.GetComponent<Texture2DRenderer>();
            var spriteBatch = BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");

            spriteBatch.Draw(renderer.Texture, transform.renderPosition, null, null, transform.globalOrigin, transform.renderRotation, transform.renderScale);
        }
    }
}

