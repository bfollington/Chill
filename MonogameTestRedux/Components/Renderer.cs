using System;
using Artemis;
using Artemis.Attributes;

namespace Chill
{
    [ArtemisComponentPool(InitialSize = 5, IsResizable = true, ResizeSize = 20, IsSupportMultiThread = false)]
    public abstract class Renderer : ComponentPoolable
    {
        
    }
}

