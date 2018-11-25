using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto
{
    /// <summary>
    /// A Base page for all pages to get functionality from
    /// </summary>
    public class BasePage:Page
    {
        #region properties
        /// <summary>
        /// The animation that plays when the page is first loaded
        /// </summary>
        public PageAnimationsEnum PageLoadAnimation { get; set; } = PageAnimationsEnum.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation that plays when the page is unloaded
        /// </summary>
        public PageAnimationsEnum PageUnloadAnimation { get; set; } = PageAnimationsEnum.SlideAndFadeOutToLeft;


        /// <summary>
        /// The slide animation takes t o complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.9f;



        #endregion

        #region Constructor
        /// <summary>
        /// Default Consructor
        /// </summary>
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimationsEnum.None)
                this.Visibility = Visibility.Collapsed;
            this.Loaded += BasePage_Loaded;
        }



        #endregion

        #region Animation 
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimationsEnum.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimationsEnum.SlideAndFadeInFromRight:

                    //Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
                
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimationsEnum.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimationsEnum.SlideAndFadeOutToLeft:

                    //Start the animation
                    await this.SlideAndFadeToLeft(this.SlideSeconds);
                    break;

            }


        }

        #endregion


    }
}
