using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto
{
    public static class PageAnimation
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            //Create Storyboard
            var storyboard = new Storyboard();

            //Add slide from right animation
            storyboard.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade from right animation
            storyboard.AddFadeIn(seconds);

            storyboard.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }


        public static async Task SlideAndFadeToLeft(this Page page, float seconds)
        {
            //Create Storyboard
            var storyboard = new Storyboard();

            //Add slide from right animation
            storyboard.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade from right animation
            storyboard.AddFadeOut(seconds);

            storyboard.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

    }
}
