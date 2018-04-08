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
using Windows.Storage;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Управление.сайтом
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Downloads : Page
    {
        public Downloads()
        {
            this.InitializeComponent();
        }

        private async void ButtonCopyBootstrapDistr_Click(object sender, RoutedEventArgs e)
        {

            #region Устанавливаем в переменные файл из папки программы
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Downloads");
            StorageFile exportFile = await folder.GetFileAsync("bootstrapdistr.zip");
            #endregion

            var savePicker1 = new Windows.Storage.Pickers.FolderPicker();
            savePicker1.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            savePicker1.FileTypeFilter.Add(".zip");
            // Default file name if the user does not type one in or select a file to replace


            Windows.Storage.StorageFolder destinationFolder = await savePicker1.PickSingleFolderAsync();
            if (destinationFolder != null)
            {
                try
                {
                    string dbfile = "bootstrapdistr.zip";
                    await exportFile.CopyAsync(destinationFolder, dbfile, NameCollisionOption.ReplaceExisting);

                    var messagedialogFile = new MessageDialog("Файл дистрибутива Bootstrap [bootstrapdistr.zip] успешно сохранен в выбранной папке.");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();

                }
                catch
                {
                    var messagedialogFile = new MessageDialog("Не удалось сохранить файл дистрибутива Bootstrap [bootstrapdistr.zip].");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
            }

        }

        private async void ButtonCopyDebugARM_Click(object sender, RoutedEventArgs e)
        {
            #region Устанавливаем в переменные файл из папки программы
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Downloads");
            StorageFile exportFile = await folder.GetFileAsync("Управление-сайтом-DEBUG-ARM-v111.zip");
            #endregion

            var savePicker1 = new Windows.Storage.Pickers.FolderPicker();
            savePicker1.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            savePicker1.FileTypeFilter.Add(".zip");
            // Default file name if the user does not type one in or select a file to replace


            Windows.Storage.StorageFolder destinationFolder = await savePicker1.PickSingleFolderAsync();
            if (destinationFolder != null)
            {
                try
                {
                    string dbfile = "Управление-сайтом-DEBUG-ARM-v112.zip";
                    await exportFile.CopyAsync(destinationFolder, dbfile, NameCollisionOption.ReplaceExisting);

                    var messagedialogFile = new MessageDialog("Debug-версия приложения Управление.сайтом [Управление-сайтом-DEBUG-ARM-v112.zip] успешно сохранена в выбранной папке.");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();

                }
                catch
                {
                    var messagedialogFile = new MessageDialog("Не удалось сохранить файл [Управление-сайтом-DEBUG-ARM-v112.zip].");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
            }
        }

        private async void ButtonCopySiteSample_Click(object sender, RoutedEventArgs e)
        {
            #region Устанавливаем в переменные файл из папки программы
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Downloads");
            StorageFile exportFile = await folder.GetFileAsync("SiteSample.zip");
            #endregion

            var savePicker1 = new Windows.Storage.Pickers.FolderPicker();
            savePicker1.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            savePicker1.FileTypeFilter.Add(".zip");
            // Default file name if the user does not type one in or select a file to replace


            Windows.Storage.StorageFolder destinationFolder = await savePicker1.PickSingleFolderAsync();
            if (destinationFolder != null)
            {
                try
                {
                    string dbfile = "SiteSample.zip";
                    await exportFile.CopyAsync(destinationFolder, dbfile, NameCollisionOption.ReplaceExisting);

                    var messagedialogFile = new MessageDialog("Архив с примером сайта [SiteSample.zip] успешно сохранен в выбранной папке.");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();

                }
                catch
                {
                    var messagedialogFile = new MessageDialog("Не удалось сохранить файл архива с примером сайта [SiteSample.zip].");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
            }
        }
    }
}
