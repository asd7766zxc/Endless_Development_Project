using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Chat_Pro_NCP
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromDown(this Page page, float seconds)
        {
            var Sb = new Storyboard();
            Sb.AddSlideFromDowm(seconds, page.WindowHeight);
            Sb.AddFadeIn(seconds);
            Sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToUp(this Page page, float seconds)
        {
            var Sb = new Storyboard();
            Sb.AddSlideToUp(seconds, page.WindowHeight);
            Sb.AddFadeOut(seconds);
            Sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToUpNoFade(this Page page, float seconds,float offset)
        {
            var Sb = new Storyboard();
            Sb.AddSlideToUp(seconds, page.WindowHeight- offset);
            Sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

    }
}