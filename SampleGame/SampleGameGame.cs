// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace SampleGame
{
    public class SampleGameGame : Game
    {
        private Box box;
        private BufferedContainer container;

        [BackgroundDependencyLoader]
        private void load()
        {
            Masking = true;
            Add(container = new BufferedContainer(cachedFrameBuffer: false)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(150, 150),
                Colour = Color4.Tomato,
                Masking = false,
                Child = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Masking = false,

                    Child = box = new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(150, 150),

                    },
                }

            });
        }

        protected override void Update()
        {
            base.Update();
            container.Rotation += (float)Time.Elapsed / 10;
        }
    }
}
