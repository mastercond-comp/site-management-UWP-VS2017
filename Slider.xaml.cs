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
using System.Net;
using Windows.Networking;
using FtpClientSample;
using System.Text;
using Windows.UI.Popups;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace Управление.сайтом
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Slider : Page
    {
        public Slider()
        {
            this.InitializeComponent();
        }

        private async void LoadFileSlider_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".indexslider");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {

                //IAsyncOperation<IUICommand> asyncOperation; //используется для последующей отмены асинхронной операции - для закрытия messagedialog
                //var messagedialogLoading = new MessageDialog("ЗАГРУЗКА ДАННЫХ...");
                //messagedialogLoading.Commands.Add(new UICommand("...Ожидайте..."));
                //asyncOperation = messagedialogLoading.ShowAsync();

                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxSliderShrift.Text = line.Split('|')[0];

                    TextBoxSlide1Header.Text = line.Split('|')[1];
                    TextBoxSlide1Text.Text = line.Split('|')[2];
                    TextBoxSlide1Image.Text = line.Split('|')[3];

                    TextBoxSlide2Header.Text = line.Split('|')[4];
                    TextBoxSlide2Text.Text = line.Split('|')[5];
                    TextBoxSlide2Image.Text = line.Split('|')[6];

                    TextBoxSlide3Header.Text = line.Split('|')[7];
                    TextBoxSlide3Text.Text = line.Split('|')[8];
                    TextBoxSlide3Image.Text = line.Split('|')[9];

                    TextBoxSlide4Header.Text = line.Split('|')[10];
                    TextBoxSlide4Text.Text = line.Split('|')[11];
                    TextBoxSlide4Image.Text = line.Split('|')[12];

                    TextBoxSlide5Header.Text = line.Split('|')[13];
                    TextBoxSlide5Text.Text = line.Split('|')[14];
                    TextBoxSlide5Image.Text = line.Split('|')[15];

                    TextBoxFTPServer.Text = line.Split('|')[16];
                    TextBoxFTPUser.Text = line.Split('|')[17];
                    TextBoxFTPPass.Password = line.Split('|')[18];

                    TextBoxSlide1ImageALT.Text = line.Split('|')[19];
                    TextBoxSlide2ImageALT.Text = line.Split('|')[20];
                    TextBoxSlide3ImageALT.Text = line.Split('|')[21];
                    TextBoxSlide4ImageALT.Text = line.Split('|')[22];
                    TextBoxSlide5ImageALT.Text = line.Split('|')[23];

                    try
                    {
                        TextBoxSlide6Header.Text = line.Split('|')[24];
                        TextBoxSlide6Text.Text = line.Split('|')[25];
                        TextBoxSlide6Image.Text = line.Split('|')[26];
                        TextBoxSlide6ImageALT.Text = line.Split('|')[27];

                        TextBoxSlide7Header.Text = line.Split('|')[28];
                        TextBoxSlide7Text.Text = line.Split('|')[29];
                        TextBoxSlide7Image.Text = line.Split('|')[30];
                        TextBoxSlide7ImageALT.Text = line.Split('|')[31];

                        TextBoxSlide8Header.Text = line.Split('|')[32];
                        TextBoxSlide8Text.Text = line.Split('|')[33];
                        TextBoxSlide8Image.Text = line.Split('|')[34];
                        TextBoxSlide8ImageALT.Text = line.Split('|')[35];

                        TextBoxSlide9Header.Text = line.Split('|')[36];
                        TextBoxSlide9Text.Text = line.Split('|')[37];
                        TextBoxSlide9Image.Text = line.Split('|')[38];
                        TextBoxSlide9ImageALT.Text = line.Split('|')[39];

                        TextBoxSlide10Header.Text = line.Split('|')[40];
                        TextBoxSlide10Text.Text = line.Split('|')[41];
                        TextBoxSlide10Image.Text = line.Split('|')[42];
                        TextBoxSlide10ImageALT.Text = line.Split('|')[43];
                    }
                    catch { }

                    //asyncOperation.Cancel();

                }

            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
                Progress.IsActive = false;
            }
            Progress.IsActive = false;
        }
    

        

        private async void SaveFileSlider_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл модуля слайдер на главной странице", new List<string>() { ".indexslider" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "слайдер";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени


                string FILETEXT = TextBoxSliderShrift.Text + "|" +
                TextBoxSlide1Header.Text + "|" + TextBoxSlide1Text.Text + "|" + TextBoxSlide1Image.Text + "|" +
                TextBoxSlide2Header.Text + "|" + TextBoxSlide2Text.Text + "|" + TextBoxSlide2Image.Text + "|" +
                TextBoxSlide3Header.Text + "|" + TextBoxSlide3Text.Text + "|" + TextBoxSlide3Image.Text + "|" +
                TextBoxSlide4Header.Text + "|" + TextBoxSlide4Text.Text + "|" + TextBoxSlide4Image.Text + "|" +
                TextBoxSlide5Header.Text + "|" + TextBoxSlide5Text.Text + "|" + TextBoxSlide5Image.Text + "|" +
                TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|" +
                TextBoxSlide1ImageALT.Text + "|" +
                TextBoxSlide2ImageALT.Text + "|" +
                TextBoxSlide3ImageALT.Text + "|" +
                TextBoxSlide4ImageALT.Text + "|" +
                TextBoxSlide5ImageALT.Text + "|"+
                 
                TextBoxSlide6Header.Text + "|" +
                TextBoxSlide6Text.Text + "|" +
                TextBoxSlide6Image.Text + "|" +
                TextBoxSlide6ImageALT.Text + "|" +

                TextBoxSlide7Header.Text + "|" +
                TextBoxSlide7Text.Text + "|" +
                TextBoxSlide7Image.Text + "|" +
                TextBoxSlide7ImageALT.Text + "|" +

                TextBoxSlide8Header.Text + "|" +
                TextBoxSlide8Text.Text + "|" +
                TextBoxSlide8Image.Text + "|" +
                TextBoxSlide8ImageALT.Text + "|" +

                TextBoxSlide9Header.Text + "|" +
                TextBoxSlide9Text.Text + "|" +
                TextBoxSlide9Image.Text + "|" +
                TextBoxSlide9ImageALT.Text + "|" +

                TextBoxSlide10Header.Text + "|" +
                TextBoxSlide10Text.Text + "|" +
                TextBoxSlide10Image.Text + "|" +
                TextBoxSlide10ImageALT.Text + "|";

                string FILETEXTREADY= FILETEXT.Replace("\r\n", " ");
                string FILETEXTREADY1 = FILETEXTREADY.Replace("\r", " ");
                string FILETEXTREADY2 = FILETEXTREADY1.Replace("\n", " ");

                await FileIO.WriteTextAsync(Myfile4, FILETEXTREADY2);






                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "Файл модуля слайдер " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл модуля слайдер " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл модуля слайдер " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл модуля слайдер " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла модуля Слайдер была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла модуля Слайдер была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private async void SaveFileSliderTPL_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("TPL файл модуля Слайдер на главной", new List<string>() { ".tpl" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "slider";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<!-- ================================НАЧАЛО КОДА КАРУСЕЛИ============================================== -->\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "< !--Indicators-- >\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<ol class=\"carousel-indicators\">\r\n");

                await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"0\" class=\"active\"></li>\r\n");

                if (TextBoxSlide2Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"1\"></li>\r\n");
                }

                if (TextBoxSlide3Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"2\"></li>\r\n");
                }

                if (TextBoxSlide4Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"3\"></li>\r\n");
                }

                if (TextBoxSlide5Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"4\"></li>\r\n");
                }

                if (TextBoxSlide6Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"5\"></li>\r\n");
                }

                if (TextBoxSlide7Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"6\"></li>\r\n");
                }

                if (TextBoxSlide8Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"7\"></li>\r\n");
                }

                if (TextBoxSlide9Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"8\"></li>\r\n");
                }

                if (TextBoxSlide10Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<li data-target=\"#myCarousel\" data-slide-to=\"9\"></li>\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4, "</ol>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-inner\" role=\"listbox\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                
                if (TextBoxSlide1Header.Text.Length !=0 )
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item active\" style=\"font-family:"+TextBoxSliderShrift.Text+";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"first-slide\" src=\"" + TextBoxSlide1Image.Text + "\" alt=\""+TextBoxSlide1ImageALT.Text+"\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide1Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide1Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
          
                }

                if (TextBoxSlide2Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"second-slide\" src=\"" + TextBoxSlide2Image.Text + "\" alt=\"" + TextBoxSlide2ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide2Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide2Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide3Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"third-slide\" src=\"" + TextBoxSlide3Image.Text + "\" alt=\"" + TextBoxSlide3ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide3Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide3Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide4Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"forth-slide\" src=\"" + TextBoxSlide4Image.Text + "\" alt=\"" + TextBoxSlide4ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide4Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide4Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide5Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide5Image.Text + "\" alt=\"" + TextBoxSlide5ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide5Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide5Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide6Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide6Image.Text + "\" alt=\"" + TextBoxSlide6ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide6Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide6Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide7Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide7Image.Text + "\" alt=\"" + TextBoxSlide7ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide7Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide7Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide8Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide8Image.Text + "\" alt=\"" + TextBoxSlide8ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide8Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide8Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide9Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide9Image.Text + "\" alt=\"" + TextBoxSlide9ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide9Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide9Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                if (TextBoxSlide10Header.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide10Image.Text + "\" alt=\"" + TextBoxSlide10ImageALT.Text + "\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"carousel-caption\">\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<h1>" + TextBoxSlide10Header.Text + "</h1>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p>" + TextBoxSlide10Text.Text + "</p>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                }

                await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<a class=\"left carousel-control\" href=\"#myCarousel\" role=\"button\" data-slide=\"prev\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"sr-only\">Предыдущий</span>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "</a>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<a class=\"right carousel-control\" href=\"#myCarousel\" role=\"button\" data-slide=\"next\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"sr-only\">Следующий</span>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "</a>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<!-- =====================================КОНЕЦ КОДА КАРУСЕЛИ========================================-->\r\n");

                
                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "TPL файл модуля Слайдер " + Myfile4.Name + " успешно экспортирован.";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  ");
                    string text002 = text02.Replace("\n", "  ");
                    string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;


                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("TPL-файл модуля Слайдер " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();

                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл навигационного меню " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить TPL-файл модуля Слайдер " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла навигационного меню была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи TPL-файла модуля Слайдер была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
        }

        private async void DoDownloadOrUpload(bool isDownload)
        {
            Progress.IsActive = true;
            Uri uri = new Uri(TextBoxFTPServer.Text);

            StatusFile.Text = "Соединяюсь с сервером.....";

            FtpClient client = new FtpClient();

            try
            {
                Progress.IsActive = true;
                await client.ConnectAsync(
                new HostName(uri.Host),
                uri.Port.ToString(),
                TextBoxFTPUser.Text,
                TextBoxFTPPass.Password);

                if (isDownload)
                {

                    Progress.IsActive = true;

                    StatusFile.Text = "Загружаю с сервера.....";

                    byte[] data = await client.DownloadAsync(uri.AbsolutePath);

                    FileTextBox.Text = Encoding.UTF8.GetString(data, 0, data.Length);
                }
                else
                {
                    Progress.IsActive = true;

                    StatusFile.Text = "Выгружаю файл на FTP сервер.....";

                    byte[] data = Encoding.UTF8.GetBytes(FileTextBox.Text);

                    await client.UploadAsync(uri.AbsolutePath, data);
                }

                StatusFile.Text = "Файл успешно выгружен на FTP сервер.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Файл успешно выгружен на FTP сервер.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            catch
            {
                StatusFile.Text = "Невозможно соединиться с сервером FTP: неправильное имя пользователя или пароль, либо сервер недоступен.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Невозможно соединиться с сервером FTP: неправильное имя пользователя или пароль, либо сервер недоступен.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }


        private void FTPFileSliderTPL_Click(object sender, RoutedEventArgs e)
        {
            DoDownloadOrUpload(false); ////см.проект kiewic ftp client
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileTextBox.Text = "";
            Progress.IsActive = true;
            ///////////////////////////////////////////////////////////////////////////////

            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл модуля слайдер на главной странице", new List<string>() { ".indexslider" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "слайдер";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени


                string FILETEXT = TextBoxSliderShrift.Text + "|" +
                TextBoxSlide1Header.Text + "|" + TextBoxSlide1Text.Text + "|" + TextBoxSlide1Image.Text + "|" +
                TextBoxSlide2Header.Text + "|" + TextBoxSlide2Text.Text + "|" + TextBoxSlide2Image.Text + "|" +
                TextBoxSlide3Header.Text + "|" + TextBoxSlide3Text.Text + "|" + TextBoxSlide3Image.Text + "|" +
                TextBoxSlide4Header.Text + "|" + TextBoxSlide4Text.Text + "|" + TextBoxSlide4Image.Text + "|" +
                TextBoxSlide5Header.Text + "|" + TextBoxSlide5Text.Text + "|" + TextBoxSlide5Image.Text + "|" +
                TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|" +
                TextBoxSlide1ImageALT.Text + "|" +
                TextBoxSlide2ImageALT.Text + "|" +
                TextBoxSlide3ImageALT.Text + "|" +
                TextBoxSlide4ImageALT.Text + "|" +
                TextBoxSlide5ImageALT.Text + "|"+

                TextBoxSlide6Header.Text + "|" +
                TextBoxSlide6Text.Text + "|" +
                TextBoxSlide6Image.Text + "|" +
                TextBoxSlide6ImageALT.Text + "|" +

                TextBoxSlide7Header.Text + "|" +
                TextBoxSlide7Text.Text + "|" +
                TextBoxSlide7Image.Text + "|" +
                TextBoxSlide7ImageALT.Text + "|" +

                TextBoxSlide8Header.Text + "|" +
                TextBoxSlide8Text.Text + "|" +
                TextBoxSlide8Image.Text + "|" +
                TextBoxSlide8ImageALT.Text + "|" +

                TextBoxSlide9Header.Text + "|" +
                TextBoxSlide9Text.Text + "|" +
                TextBoxSlide9Image.Text + "|" +
                TextBoxSlide9ImageALT.Text + "|" +

                TextBoxSlide10Header.Text + "|" +
                TextBoxSlide10Text.Text + "|" +
                TextBoxSlide10Image.Text + "|" +
                TextBoxSlide10ImageALT.Text + "|";

                string FILETEXTREADY = FILETEXT.Replace("\r\n", " ");
                string FILETEXTREADY1 = FILETEXTREADY.Replace("\r", " ");
                string FILETEXTREADY2 = FILETEXTREADY1.Replace("\n", " ");

                await FileIO.WriteTextAsync(Myfile4, FILETEXTREADY2);






                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "Файл модуля слайдер " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл модуля слайдер " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл модуля слайдер " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл модуля слайдер " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла модуля Слайдер была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла модуля Слайдер была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<!-- ================================НАЧАЛО КОДА КАРУСЕЛИ============================================== -->\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "< !--Indicators-- >\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<ol class=\"carousel-indicators\">\r\n");

            await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"0\" class=\"active\"></li>\r\n");

            if (TextBoxSlide2Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"1\"></li>\r\n");
            }

            if (TextBoxSlide3Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"2\"></li>\r\n");
            }

            if (TextBoxSlide4Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"3\"></li>\r\n");
            }

            if (TextBoxSlide5Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"4\"></li>\r\n");
            }

            if (TextBoxSlide6Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"5\"></li>\r\n");
            }

            if (TextBoxSlide7Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"6\"></li>\r\n");
            }

            if (TextBoxSlide8Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"7\"></li>\r\n");
            }

            if (TextBoxSlide9Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"8\"></li>\r\n");
            }

            if (TextBoxSlide10Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<li data-target=\"#myCarousel\" data-slide-to=\"9\"></li>\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "</ol>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-inner\" role=\"listbox\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");

            if (TextBoxSlide1Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item active\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"first-slide\" src=\"" + TextBoxSlide1Image.Text + "\" alt=\"" + TextBoxSlide1ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide1Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide1Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide2Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"second-slide\" src=\"" + TextBoxSlide2Image.Text + "\" alt=\"" + TextBoxSlide2ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide2Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide2Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide3Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"third-slide\" src=\"" + TextBoxSlide3Image.Text + "\" alt=\"" + TextBoxSlide3ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide3Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide3Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide4Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"forth-slide\" src=\"" + TextBoxSlide4Image.Text + "\" alt=\"" + TextBoxSlide4ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide4Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide4Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide5Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide5Image.Text + "\" alt=\"" + TextBoxSlide5ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide5Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide5Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide6Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide6Image.Text + "\" alt=\"" + TextBoxSlide6ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide6Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide6Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide7Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide7Image.Text + "\" alt=\"" + TextBoxSlide7ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide7Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide7Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide8Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide8Image.Text + "\" alt=\"" + TextBoxSlide8ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide8Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide8Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide9Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide9Image.Text + "\" alt=\"" + TextBoxSlide9ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide9Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide9Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }

            if (TextBoxSlide10Header.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"item\" style=\"font-family:" + TextBoxSliderShrift.Text + ";\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"fifth-slide\" src=\"" + TextBoxSlide10Image.Text + "\" alt=\"" + TextBoxSlide10ImageALT.Text + "\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"carousel-caption\">\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<h1>" + TextBoxSlide10Header.Text + "</h1>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p>" + TextBoxSlide10Text.Text + "</p>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            }


            await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<a class=\"left carousel-control\" href=\"#myCarousel\" role=\"button\" data-slide=\"prev\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"sr-only\">Предыдущий</span>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</a>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<a class=\"right carousel-control\" href=\"#myCarousel\" role=\"button\" data-slide=\"next\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"sr-only\">Следующий</span>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</a>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<!-- =====================================КОНЕЦ КОДА КАРУСЕЛИ========================================-->\r\n");


            ///////////////////////////////////////////////////////////////////////////////

            string text11 = await Windows.Storage.FileIO.ReadTextAsync(UPLOADFile);
            string text102 = text11.Replace("\r\n", "  ");
            string text1002 = text102.Replace("\n", "  ");
            string text12 = text1002.Replace("\r", "  ");

            FileTextBox.Text = text12;

            ///////////////////////////////////////////////////////////////////////////////

            if (TextBoxFTPServer.Text != "")
            {
                DoDownloadOrUpload(false); ////см.проект kiewic ftp client 
            }

            else
            {
                StatusFile.Text = "Ошибка. Введите адрес FTP сервера.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Ошибка. Введите адрес FTP сервера.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            Progress.IsActive = false;
        }
    }
}
