using System;
using Artemis;
using Artemis.Attributes;
using Microsoft.Xna.Framework.Graphics;
using Chill;

namespace MonogameTestRedux
{
    [ArtemisComponentPool(InitialSize = 5, IsResizable = true, ResizeSize = 20, IsSupportMultiThread = false)]
    public class Texture2DRenderer : Renderer
    {
        public Texture2D Texture { get; set; }
        public Texture2DRenderer () {}
    }
}

