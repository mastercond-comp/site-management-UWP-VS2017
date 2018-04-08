using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Управление.сайтом
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //ContentFrame.Navigate(typeof(QuickPage));
            ContentFrame.Navigate(typeof(QuickPage));
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.MySplitView.IsPaneOpen = !(this.MySplitView.IsPaneOpen);
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataAndNavigation.IsSelected) { ContentFrame.Navigate(typeof(DataNavigationSettings)); }
            else

            if (IndexPageSettings.IsSelected) { ContentFrame.Navigate(typeof(RootPageSettings)); }
            else

             if (TovarKatalog.IsSelected) { ContentFrame.Navigate(typeof(KatalogPage)); }
            else

            if (TovarSpisokPage.IsSelected) { ContentFrame.Navigate(typeof(TovarSpisok)); }
            else

            if (ContentPageSettings.IsSelected) { ContentFrame.Navigate(typeof(ContentPage)); }
            else

            if (TovarPagesSettings.IsSelected) { ContentFrame.Navigate(typeof(TovarPage)); }
            else

            if (Distr.IsSelected) { ContentFrame.Navigate(typeof(Downloads)); }
            else

                if (TovarIndexPageSettings.IsSelected) { ContentFrame.Navigate(typeof(RootTovarPage)); }
            else

           if (ClientsModul.IsSelected) { ContentFrame.Navigate(typeof(Clients)); }
           else

           if (WorksModul.IsSelected) { ContentFrame.Navigate(typeof(OurWorks)); }
           else

            if (SliderModul.IsSelected) { ContentFrame.Navigate(typeof(Slider)); }
            else

            if (FooterModul.IsSelected) { ContentFrame.Navigate(typeof(Footer)); }
            else

            if (IndexNewsModul.IsSelected) { ContentFrame.Navigate(typeof(RootNews)); }
            else

            if (About.IsSelected) { ContentFrame.Navigate(typeof(AboutPage)); }
            else

            if (Help.IsSelected) { ContentFrame.Navigate(typeof(Spravka)); }
            else

            if (FooterScriptsModul.IsSelected) { ContentFrame.Navigate(typeof(FooterScripts)); }
            else

             if (CustomModul.IsSelected) { ContentFrame.Navigate(typeof(CustomSiteModul)); }
            else

             if (CustomCSS.IsSelected) { ContentFrame.Navigate(typeof(MyCSSCustom)); }
            else

             if(DataAndNavigationMEGA.IsSelected) { ContentFrame.Navigate(typeof(MEGAMENU)); }
            else

            if (HeaderModul.IsSelected) { ContentFrame.Navigate(typeof(HEADER)); }
            else


            if (CBR.IsSelected) { ContentFrame.Navigate(typeof(cbr)); }
        }

    }
}
