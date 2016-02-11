using System;
using Artemis;
using Artemis.Attributes;
using Microsoft.Xna.Framework.Graphics;
using Chill;
using Artemis.Blackboard;

namespace Chill
{
    [ArtemisComponentPool(InitialSize = 5, IsResizable = true, ResizeSize = 20, IsSupportMultiThread = false)]
    public class Texture2DRenderer : Renderer
    {
        public string TextureName { get; set; }
        public Texture2DRenderer () {}
    }
}

