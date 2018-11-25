
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto
{
    public static class StoryboradHelpers
    {
        /// <summary>
        /// Slide in From right
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio= 0.9f)
        {
            //Create the margin animate from right
            var slideAnimaton = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimaton, new PropertyPath("Margin"));

            //Add this to the storyboard
            storyboard.Children.Add(slideAnimaton);
            
        }

        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            //Create the margin animate from right
            var slideAnimaton = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From =0,
                To = 1
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimaton, new PropertyPath("Opacity"));

            //Add this to the storyboard
            storyboard.Children.Add(slideAnimaton);

        }

        /// <summary>
        /// Add Slide to left
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            //Create the margin animate from right
            var slideAnimaton = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimaton, new PropertyPath("Margin"));

            //Add this to the storyboard
            storyboard.Children.Add(slideAnimaton);

        }

        /// <summary>
        /// Fadeout to left
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>

        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            //Create the margin animate from right
            var slideAnimaton = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimaton, new PropertyPath("Opacity"));

            //Add this to the storyboard
            storyboard.Children.Add(slideAnimaton);

        }
    }
}
