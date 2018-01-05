﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using NUnit.Framework;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Testing;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Framework.Tests.Visual
{
    [TestFixture]
    public class TestCaseSliderbar : TestCase
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly BindableDouble sliderBarValue; //keep a reference to avoid GC of the bindable
        private readonly SpriteText sliderbarText;

        public TestCaseSliderbar()
        {
            sliderBarValue = new BindableDouble(8)
            {
                MinValue = -10,
                MaxValue = 10
            };
            sliderBarValue.ValueChanged += sliderBarValueChanged;

            sliderbarText = new SpriteText
            {
                Text = $"Selected value: {sliderBarValue.Value}",
                Position = new Vector2(25, 0)
            };

            SliderBar<double> sliderBar = new BasicSliderBar<double>
            {
                Size = new Vector2(200, 10),
                Position = new Vector2(25, 25),
                Color = Color4.White,
                SelectionColor = Color4.Pink,
                KeyboardStep = 1
            };

            sliderBar.Current.BindTo(sliderBarValue);

            Add(sliderBar);
            Add(sliderbarText);

            Add(sliderBar = new BasicSliderBar<double>
            {
                Size = new Vector2(200, 10),
                RangePadding = 20,
                Position = new Vector2(25, 45),
                Color = Color4.White,
                SelectionColor = Color4.Pink,
                KeyboardStep = 1,
            });

            sliderBar.Current.BindTo(sliderBarValue);

            AddSliderStep("Value", -10.0, 10.0, 0.0, v => sliderBarValue.Value = v);
        }

        private void sliderBarValueChanged(double newValue)
        {
            sliderbarText.Text = $"Selected value: {newValue:N}";
        }
    }
}
