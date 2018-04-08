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
    public sealed partial class OurWorks : Page
    {
        public OurWorks()
        {
            this.InitializeComponent();
        }

        private async void LoadFileTCatalog_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".ourworks");
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
                    TextBoxZagolovokColor.Text = line.Split('|')[0];

                    TextBoxZagolovok1.Text = line.Split('|')[1];
                    TextBoxOpisanie1.Text = line.Split('|')[2];
                    TextBoxIMGLink1.Text = line.Split('|')[3];

                    TextBoxZagolovok2.Text = line.Split('|')[4];
                    TextBoxOpisanie2.Text = line.Split('|')[5];
                    TextBoxIMGLink2.Text = line.Split('|')[6];

                    TextBoxZagolovok2.Text = line.Split('|')[7];
                    TextBoxOpisanie2.Text = line.Split('|')[8];
                    TextBoxIMGLink2.Text = line.Split('|')[9];

                    TextBoxZagolovok3.Text = line.Split('|')[10];
                    TextBoxOpisanie3.Text = line.Split('|')[11];
                    TextBoxIMGLink3.Text = line.Split('|')[12];

                    TextBoxZagolovok4.Text = line.Split('|')[13];
                    TextBoxOpisanie4.Text = line.Split('|')[14];
                    TextBoxIMGLink4.Text = line.Split('|')[15];

                    TextBoxZagolovok5.Text = line.Split('|')[16];
                    TextBoxOpisanie5.Text = line.Split('|')[17];
                    TextBoxIMGLink5.Text = line.Split('|')[18];

                    TextBoxZagolovok6.Text = line.Split('|')[19];
                    TextBoxOpisanie6.Text = line.Split('|')[20];
                    TextBoxIMGLink6.Text = line.Split('|')[21];

                    TextBoxZagolovok7.Text = line.Split('|')[22];
                    TextBoxOpisanie7.Text = line.Split('|')[23];
                    TextBoxIMGLink7.Text = line.Split('|')[24];

                    TextBoxZagolovok8.Text = line.Split('|')[25];
                    TextBoxOpisanie8.Text = line.Split('|')[26];
                    TextBoxIMGLink8.Text = line.Split('|')[27];

                    TextBoxZagolovok9.Text = line.Split('|')[28];
                    TextBoxOpisanie9.Text = line.Split('|')[29];
                    TextBoxIMGLink9.Text = line.Split('|')[30];

                    TextBoxZagolovok10.Text = line.Split('|')[31];
                    TextBoxOpisanie10.Text = line.Split('|')[32];
                    TextBoxIMGLink10.Text = line.Split('|')[33];

                    TextBoxZagolovok11.Text = line.Split('|')[34];
                    TextBoxOpisanie11.Text = line.Split('|')[35];
                    TextBoxIMGLink11.Text = line.Split('|')[36];

                    TextBoxZagolovok12.Text = line.Split('|')[37];
                    TextBoxOpisanie12.Text = line.Split('|')[38];
                    TextBoxIMGLink12.Text = line.Split('|')[39];


                    TextBoxFTPServer.Text = line.Split('|')[40];
                    TextBoxFTPUser.Text = line.Split('|')[41];
                    TextBoxFTPPass.Password = line.Split('|')[42];

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

        private async void SaveFileKatalogTovarov_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл данных модуля \"НАШИ РАБОТЫ\" ", new List<string>() { ".ourworks" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "works";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxZagolovokColor.Text + "|" +

                    TextBoxZagolovok1.Text + "|" +
                    TextBoxOpisanie1.Text + "|" +
                    TextBoxIMGLink1.Text + "|" +

                    TextBoxZagolovok2.Text + "|" +
                    TextBoxOpisanie2.Text + "|" +
                    TextBoxIMGLink2.Text + "|" +

                    TextBoxZagolovok2.Text + "|" +
                    TextBoxOpisanie2.Text + "|" +
                    TextBoxIMGLink2.Text + "|" +

                    TextBoxZagolovok3.Text + "|" +
                    TextBoxOpisanie3.Text + "|" +
                    TextBoxIMGLink3.Text + "|" +

                    TextBoxZagolovok4.Text + "|" +
                    TextBoxOpisanie4.Text + "|" +
                    TextBoxIMGLink4.Text + "|" +

                    TextBoxZagolovok5.Text + "|" +
                    TextBoxOpisanie5.Text + "|" +
                    TextBoxIMGLink5.Text + "|" +

                    TextBoxZagolovok6.Text + "|" +
                    TextBoxOpisanie6.Text + "|" +
                    TextBoxIMGLink6.Text + "|" +

                    TextBoxZagolovok7.Text + "|" +
                    TextBoxOpisanie7.Text + "|" +
                    TextBoxIMGLink7.Text + "|" +

                    TextBoxZagolovok8.Text + "|" +
                    TextBoxOpisanie8.Text + "|" +
                    TextBoxIMGLink8.Text + "|" +

                    TextBoxZagolovok9.Text + "|" +
                    TextBoxOpisanie9.Text + "|" +
                    TextBoxIMGLink9.Text + "|" +

                    TextBoxZagolovok10.Text + "|" +
                    TextBoxOpisanie10.Text + "|" +
                    TextBoxIMGLink10.Text + "|" +

                    TextBoxZagolovok11.Text + "|" +
                    TextBoxOpisanie11.Text + "|" +
                    TextBoxIMGLink11.Text + "|" +

                    TextBoxZagolovok12.Text + "|" +
                    TextBoxOpisanie12.Text + "|" +
                    TextBoxIMGLink12.Text + "|" +


                    TextBoxFTPServer.Text + "|" +
                    TextBoxFTPUser.Text + "|" +
                    TextBoxFTPPass.Password + "|");






                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");
                    await FileIO.WriteTextAsync(Myfile4, text2);

                    this.StatusFile.Text = "Файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных модуля \"НАШИ РАБОТЫ\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла данных модуля \"НАШИ РАБОТЫ\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private async void SaveFileKatalogTovarovTPL_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("TPL файл модуля \"НАШИ РАБОТЫ\" ", new List<string>() { ".tpl" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "works";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<!-- ======================================МОДУЛЬ \"НАШИ РАБОТЫ\"======================================== -->\r\n" );
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"container marketing\"><h3 style=\"color:"+TextBoxZagolovokColor.Text+";\">НАШИ РАБОТЫ</h3>\r\n");

                if (TextBoxZagolovok1.Text.Length != 0 | TextBoxZagolovok2.Text.Length != 0 | TextBoxZagolovok3.Text.Length != 0 | TextBoxZagolovok4.Text.Length != 0)
                {

                    await FileIO.AppendTextAsync(Myfile4, "<!-- ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n<div class=\"row\" style=\"margin-top:20px;\">");

                    if (TextBoxZagolovok1.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink1.Text + "\" alt=\"" + TextBoxZagolovok1.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok1.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie1.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok2.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink2.Text + "\" alt=\"" + TextBoxZagolovok2.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok2.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie2.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok3.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink3.Text + "\" alt=\"" + TextBoxZagolovok3.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok3.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie3.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok4.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink4.Text + "\" alt=\"" + TextBoxZagolovok4.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok4.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie4.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    await FileIO.AppendTextAsync(Myfile4, "</div><!-- /.row -->\r\n<!-- КОНЕЦ ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n");
                }

                if (TextBoxZagolovok5.Text.Length != 0 | TextBoxZagolovok6.Text.Length != 0 | TextBoxZagolovok7.Text.Length != 0 | TextBoxZagolovok8.Text.Length != 0)
                {

                    await FileIO.AppendTextAsync(Myfile4, "<!-- ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n<div class=\"row\" style=\"margin-top:20px;\">");


                    if (TextBoxZagolovok5.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink5.Text + "\" alt=\"" + TextBoxZagolovok5.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok5.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie5.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok6.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink6.Text + "\" alt=\"" + TextBoxZagolovok6.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok6.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie6.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok7.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink7.Text + "\" alt=\"" + TextBoxZagolovok7.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok7.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie7.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok8.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink8.Text + "\" alt=\"" + TextBoxZagolovok8.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok8.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie8.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    await FileIO.AppendTextAsync(Myfile4, "</div><!-- /.row -->\r\n<!-- КОНЕЦ ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n");
                }


                if (TextBoxZagolovok9.Text.Length != 0 | TextBoxZagolovok10.Text.Length != 0 | TextBoxZagolovok11.Text.Length != 0 | TextBoxZagolovok12.Text.Length != 0)
                {

                    await FileIO.AppendTextAsync(Myfile4, "<!-- ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n<div class=\"row\" style=\"margin-top:20px;\">");

                    if (TextBoxZagolovok9.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink9.Text + "\" alt=\"" + TextBoxZagolovok9.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok9.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie9.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok10.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink10.Text + "\" alt=\"" + TextBoxZagolovok10.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok10.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie10.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok11.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink11.Text + "\" alt=\"" + TextBoxZagolovok11.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok11.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie11.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    if (TextBoxZagolovok12.Text.Length != 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink12.Text + "\" alt=\"" + TextBoxZagolovok12.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok12.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie12.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                    }

                    await FileIO.AppendTextAsync(Myfile4, "</div><!-- /.row -->\r\n<!-- КОНЕЦ ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4, "</div>\r\n<!-- ======================================КОНЕЦ МОДУЛЯ \"НАШИ РАБОТЫ\"======================================== -->\r\n");


                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "PHP файл страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + " успешно экспортирован.";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;


                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("TPL-файл модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл навигационного меню " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить TPL-файл модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла навигационного меню была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи TPL-файла модуля \"НАШИ РАБОТЫ\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }


        private void FTPFileKatalogTovarovTPL_Click(object sender, RoutedEventArgs e)
        {
            DoDownloadOrUpload(false); ////см.проект kiewic ftp client
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

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileTextBox.Text = "";
            Progress.IsActive = true;
            ///////////////////////////////////////////////////////////////////////////////

            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл данных модуля \"НАШИ РАБОТЫ\" ", new List<string>() { ".ourworks" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "works";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxZagolovokColor.Text + "|" +

                    TextBoxZagolovok1.Text + "|" +
                    TextBoxOpisanie1.Text + "|" +
                    TextBoxIMGLink1.Text + "|" +

                    TextBoxZagolovok2.Text + "|" +
                    TextBoxOpisanie2.Text + "|" +
                    TextBoxIMGLink2.Text + "|" +

                    TextBoxZagolovok2.Text + "|" +
                    TextBoxOpisanie2.Text + "|" +
                    TextBoxIMGLink2.Text + "|" +

                    TextBoxZagolovok3.Text + "|" +
                    TextBoxOpisanie3.Text + "|" +
                    TextBoxIMGLink3.Text + "|" +

                    TextBoxZagolovok4.Text + "|" +
                    TextBoxOpisanie4.Text + "|" +
                    TextBoxIMGLink4.Text + "|" +

                    TextBoxZagolovok5.Text + "|" +
                    TextBoxOpisanie5.Text + "|" +
                    TextBoxIMGLink5.Text + "|" +

                    TextBoxZagolovok6.Text + "|" +
                    TextBoxOpisanie6.Text + "|" +
                    TextBoxIMGLink6.Text + "|" +

                    TextBoxZagolovok7.Text + "|" +
                    TextBoxOpisanie7.Text + "|" +
                    TextBoxIMGLink7.Text + "|" +

                    TextBoxZagolovok8.Text + "|" +
                    TextBoxOpisanie8.Text + "|" +
                    TextBoxIMGLink8.Text + "|" +

                    TextBoxZagolovok9.Text + "|" +
                    TextBoxOpisanie9.Text + "|" +
                    TextBoxIMGLink9.Text + "|" +

                    TextBoxZagolovok10.Text + "|" +
                    TextBoxOpisanie10.Text + "|" +
                    TextBoxIMGLink10.Text + "|" +

                    TextBoxZagolovok11.Text + "|" +
                    TextBoxOpisanie11.Text + "|" +
                    TextBoxIMGLink11.Text + "|" +

                    TextBoxZagolovok12.Text + "|" +
                    TextBoxOpisanie12.Text + "|" +
                    TextBoxIMGLink12.Text + "|" +


                    TextBoxFTPServer.Text + "|" +
                    TextBoxFTPUser.Text + "|" +
                    TextBoxFTPPass.Password + "|");






                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");
                    await FileIO.WriteTextAsync(Myfile4, text2);

                    this.StatusFile.Text = "Файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных модуля \"НАШИ РАБОТЫ\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных модуля \"НАШИ РАБОТЫ\" была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла данных модуля \"НАШИ РАБОТЫ\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<!-- ======================================МОДУЛЬ \"НАШИ РАБОТЫ\"======================================== -->\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container marketing\"><h3 style=\"color:" + TextBoxZagolovokColor.Text + ";\">НАШИ РАБОТЫ</h3>\r\n");

            if (TextBoxZagolovok1.Text.Length != 0 | TextBoxZagolovok2.Text.Length != 0 | TextBoxZagolovok3.Text.Length != 0 | TextBoxZagolovok4.Text.Length != 0)
            {

                await FileIO.AppendTextAsync(UPLOADFile, "<!-- ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n<div class=\"row\" style=\"margin-top:20px;\">");

                if (TextBoxZagolovok1.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink1.Text + "\" alt=\"" + TextBoxZagolovok1.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok1.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie1.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok2.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink2.Text + "\" alt=\"" + TextBoxZagolovok2.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok2.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie2.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok3.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink3.Text + "\" alt=\"" + TextBoxZagolovok3.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok3.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie3.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok4.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink4.Text + "\" alt=\"" + TextBoxZagolovok4.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok4.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie4.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                await FileIO.AppendTextAsync(UPLOADFile, "</div><!-- /.row -->\r\n<!-- КОНЕЦ ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n");
            }

            if (TextBoxZagolovok5.Text.Length != 0 | TextBoxZagolovok6.Text.Length != 0 | TextBoxZagolovok7.Text.Length != 0 | TextBoxZagolovok8.Text.Length != 0)
            {

                await FileIO.AppendTextAsync(UPLOADFile, "<!-- ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n<div class=\"row\" style=\"margin-top:20px;\">");


                if (TextBoxZagolovok5.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink5.Text + "\" alt=\"" + TextBoxZagolovok5.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok5.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie5.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok6.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink6.Text + "\" alt=\"" + TextBoxZagolovok6.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok6.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie6.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok7.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink7.Text + "\" alt=\"" + TextBoxZagolovok7.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok7.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie7.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok8.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink8.Text + "\" alt=\"" + TextBoxZagolovok8.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok8.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie8.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                await FileIO.AppendTextAsync(UPLOADFile, "</div><!-- /.row -->\r\n<!-- КОНЕЦ ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n");
            }


            if (TextBoxZagolovok9.Text.Length != 0 | TextBoxZagolovok10.Text.Length != 0 | TextBoxZagolovok11.Text.Length != 0 | TextBoxZagolovok12.Text.Length != 0)
            {

                await FileIO.AppendTextAsync(UPLOADFile, "<!-- ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n<div class=\"row\" style=\"margin-top:20px;\">");

                if (TextBoxZagolovok9.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink9.Text + "\" alt=\"" + TextBoxZagolovok9.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok9.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie9.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok10.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink10.Text + "\" alt=\"" + TextBoxZagolovok10.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok10.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie10.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok11.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink11.Text + "\" alt=\"" + TextBoxZagolovok11.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok11.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie11.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                if (TextBoxZagolovok12.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\">\r\n<div class=\"works-image\"><img class=\"img-responsive\" src=\"" + TextBoxIMGLink12.Text + "\" alt=\"" + TextBoxZagolovok12.Text + "\">\r\n</div><div class=\"works-text\"><h4 class=\"works\">" + TextBoxZagolovok12.Text + "</h4>\r\n<p class=\"works\">" + TextBoxOpisanie12.Text + "</p>\r\n</div></div><!-- /.col-lg-4 -->\r\n");
                }

                await FileIO.AppendTextAsync(UPLOADFile, "</div><!-- /.row -->\r\n<!-- КОНЕЦ ЧЕТЫРЕ ЭЛЕМЕНТА В ОДНОЙ СТРОКЕ -->\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n<!-- ======================================КОНЕЦ МОДУЛЯ \"НАШИ РАБОТЫ\"======================================== -->\r\n");



            ///////////////////////////////////////////////////////////////////////////////

            string text11 = await Windows.Storage.FileIO.ReadTextAsync(UPLOADFile);
            string text102 = text11.Replace("\r\n", "  "); string text1002 = text102.Replace("\n", "  "); string text12 = text1002.Replace("\r", "  ");

            FileTextBox.Text = text12;

            ///////////////////////////////////////////////////////////////////////////////

            if (TextBoxFTPServer.Text != "")
            {
                Progress.IsActive = true;
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
