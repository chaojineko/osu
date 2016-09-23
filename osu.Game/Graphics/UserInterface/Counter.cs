﻿//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace osu.Game.Graphics.UserInterface
{
    abstract class Count : AutoSizeContainer
    {
        private Sprite buttonSprite;
        private Sprite glowSprite;
        private SpriteText keySpriteText;
        private SpriteText countSpriteText;

        public override string Name { get; }
        public bool IsCounting { get; set; }
        public int Counts { get; private set; }

        private bool isLit;
        public bool IsLit
        {
            get { return isLit; }
            set
            {
                if (value && !isLit && IsCounting)
                    Counts++;
                isLit = value;
            }
        }

        protected Count(string name)
        {
            Name = name;
        }

        public override void Load()
        {
            base.Load();
            Children = new Drawable[]
            {
                buttonSprite = new Sprite
                {
                    Texture = Game.Textures.Get(@"KeyCounter/key-up"),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Children = new Drawable[]
                    {
                        glowSprite = new Sprite
                        {
                            Texture = Game.Textures.Get(@"KeyCounter/key-glow"),
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                        }
                    }
                },
                keySpriteText = new SpriteText
                {
                    Text = Name,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Position = new Vector2(0, -buttonSprite.Height / 4)
                },
                countSpriteText = new SpriteText
                {
                    Text = Counts.ToString(),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Position = new Vector2(0, buttonSprite.Height / 4)
                }
            };
            glowSprite.Hide();
        }
    }
}
