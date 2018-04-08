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
    public sealed partial class RootNews : Page
    {
        public RootNews()
        {
            this.InitializeComponent();
        }


        private async void LoadFileIndexNews_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".indexnews");
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
                    TextBoxDataNovosti1.Text = line.Split('|')[0];
                    TextBoxTekstNovosti1.Text = line.Split('|')[1];

                    TextBoxDataNovosti2.Text = line.Split('|')[2];
                    TextBoxTekstNovosti2.Text = line.Split('|')[3];

                    TextBoxDataNovosti3.Text = line.Split('|')[4];
                    TextBoxTekstNovosti3.Text = line.Split('|')[5];

                    TextBoxDataNovosti4.Text = line.Split('|')[6];
                    TextBoxTekstNovosti4.Text = line.Split('|')[7];

                    TextBoxDataNovosti5.Text = line.Split('|')[8];
                    TextBoxTekstNovosti5.Text = line.Split('|')[9];

                    TextBoxDataNovosti6.Text = line.Split('|')[10];
                    TextBoxTekstNovosti6.Text = line.Split('|')[11];

                    TextBoxDataNovosti7.Text = line.Split('|')[12];
                    TextBoxTekstNovosti7.Text = line.Split('|')[13];

                    TextBoxDataNovosti8.Text = line.Split('|')[14];
                    TextBoxTekstNovosti8.Text = line.Split('|')[15];

                    TextBoxDataNovosti9.Text = line.Split('|')[16];
                    TextBoxTekstNovosti9.Text = line.Split('|')[17];

                    TextBoxDataNovosti10.Text = line.Split('|')[18];
                    TextBoxTekstNovosti10.Text = line.Split('|')[19];

                    TextBoxFTPServer.Text = line.Split('|')[20];
                    TextBoxFTPUser.Text = line.Split('|')[21];
                    TextBoxFTPPass.Password = line.Split('|')[22];

                    TextBoxZagolovokColor.Text = line.Split('|')[23];
                    TextBoxDataTextColor.Text = line.Split('|')[24];
                    TextBoxNewsTextColor.Text = line.Split('|')[25];
                    TextBoxDataShrift.Text = line.Split('|')[26];
                    TextBoxNewsShrift.Text = line.Split('|')[27];

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

        private async void SaveFileIndexNews_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл модуля новостей на главной странице", new List<string>() { ".indexnews" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "новости-на-главной";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxDataNovosti1.Text + "|" + TextBoxTekstNovosti1.Text + "|" +
                   TextBoxDataNovosti2.Text + "|" + TextBoxTekstNovosti2.Text + "|" +
                   TextBoxDataNovosti3.Text + "|" + TextBoxTekstNovosti3.Text + "|" +
                   TextBoxDataNovosti4.Text + "|" + TextBoxTekstNovosti4.Text + "|" +
                   TextBoxDataNovosti5.Text + "|" + TextBoxTekstNovosti5.Text + "|" +
                   TextBoxDataNovosti6.Text + "|" + TextBoxTekstNovosti6.Text + "|" +
                   TextBoxDataNovosti7.Text + "|" + TextBoxTekstNovosti7.Text + "|" +
                   TextBoxDataNovosti8.Text + "|" + TextBoxTekstNovosti8.Text + "|" +
                   TextBoxDataNovosti9.Text + "|" + TextBoxTekstNovosti9.Text + "|" +
                   TextBoxDataNovosti10.Text + "|" + TextBoxTekstNovosti10.Text + "|" +
                   TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|"+
                   TextBoxZagolovokColor.Text + "|" +
                   TextBoxDataTextColor.Text + "|" +
                   TextBoxNewsTextColor.Text + "|"+
                   TextBoxDataShrift.Text + "|" + TextBoxNewsShrift.Text + "|");






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

                    this.StatusFile.Text = "Файл модуля новостей " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл модуля новостей " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл модуля новостей " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл модуля новостей " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла модуля новостей была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла модуля новостей была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private async void SaveFileIndexNewsTPL_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("TPL файл модуля новостей", new List<string>() { ".tpl" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "news";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<div class=\"container\"><h3 style=\"color:"+TextBoxZagolovokColor.Text+";\">НАШИ НОВОСТИ</h3>\r\n");

                if (TextBoxDataNovosti1.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:"+TextBoxDataTextColor.Text+";\">" + TextBoxDataNovosti1.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti1.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti2.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti2.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti2.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti3.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti3.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti3.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti4.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti4.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti4.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti5.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti5.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti5.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti6.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti6.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti6.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti7.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti7.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti7.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti8.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti8.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti8.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti9.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti9.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti9.Text + "</p>\r\n");
                }

                if (TextBoxDataNovosti10.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti10.Text + "</h5>\r\n");
                    await FileIO.AppendTextAsync(Myfile4, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti10.Text + "</p>\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4, "</div>\r\n");

                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "TPL файл модуля новостей " + Myfile4.Name + " успешно экспортирован.";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;

                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("TPL файл модуля новостей " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл навигационного меню " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось экспортировать TPL-файл модуля новостей " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла навигационного меню была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи TPL-файла модуля новостей была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private void FTPFileIndexNewsTPL_Click(object sender, RoutedEventArgs e)
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

        private void ButtonAddNews_Click(object sender, RoutedEventArgs e)
        {
            TextBoxDataNovosti10.Text = TextBoxDataNovosti9.Text;
            TextBoxTekstNovosti10.Text = TextBoxTekstNovosti9.Text;

            TextBoxDataNovosti9.Text = TextBoxDataNovosti8.Text;
            TextBoxTekstNovosti9.Text = TextBoxTekstNovosti8.Text;

            TextBoxDataNovosti8.Text = TextBoxDataNovosti7.Text;
            TextBoxTekstNovosti8.Text = TextBoxTekstNovosti7.Text;

            TextBoxDataNovosti7.Text = TextBoxDataNovosti6.Text;
            TextBoxTekstNovosti7.Text = TextBoxTekstNovosti6.Text;

            TextBoxDataNovosti6.Text = TextBoxDataNovosti5.Text;
            TextBoxTekstNovosti6.Text = TextBoxTekstNovosti5.Text;

            TextBoxDataNovosti5.Text = TextBoxDataNovosti4.Text;
            TextBoxTekstNovosti5.Text = TextBoxTekstNovosti4.Text;

            TextBoxDataNovosti4.Text = TextBoxDataNovosti3.Text;
            TextBoxTekstNovosti4.Text = TextBoxTekstNovosti3.Text;

            TextBoxDataNovosti3.Text = TextBoxDataNovosti2.Text;
            TextBoxTekstNovosti3.Text = TextBoxTekstNovosti2.Text;

            TextBoxDataNovosti2.Text = TextBoxDataNovosti1.Text;
            TextBoxTekstNovosti2.Text = TextBoxTekstNovosti1.Text;

            TextBoxDataNovosti1.Text = TextBoxDataNovosti0.Text;
            TextBoxTekstNovosti1.Text = TextBoxTekstNovosti0.Text;

            TextBoxDataNovosti0.Text = "";
            TextBoxTekstNovosti0.Text = "";

            }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileTextBox.Text = "";
            Progress.IsActive = true;
            ///////////////////////////////////////////////////////////////////////////////

            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл модуля новостей на главной странице", new List<string>() { ".indexnews" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "новости-на-главной";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxDataNovosti1.Text + "|" + TextBoxTekstNovosti1.Text + "|" +
                   TextBoxDataNovosti2.Text + "|" + TextBoxTekstNovosti2.Text + "|" +
                   TextBoxDataNovosti3.Text + "|" + TextBoxTekstNovosti3.Text + "|" +
                   TextBoxDataNovosti4.Text + "|" + TextBoxTekstNovosti4.Text + "|" +
                   TextBoxDataNovosti5.Text + "|" + TextBoxTekstNovosti5.Text + "|" +
                   TextBoxDataNovosti6.Text + "|" + TextBoxTekstNovosti6.Text + "|" +
                   TextBoxDataNovosti7.Text + "|" + TextBoxTekstNovosti7.Text + "|" +
                   TextBoxDataNovosti8.Text + "|" + TextBoxTekstNovosti8.Text + "|" +
                   TextBoxDataNovosti9.Text + "|" + TextBoxTekstNovosti9.Text + "|" +
                   TextBoxDataNovosti10.Text + "|" + TextBoxTekstNovosti10.Text + "|" +
                   TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|" +
                   TextBoxZagolovokColor.Text + "|" +
                   TextBoxDataTextColor.Text + "|" +
                   TextBoxNewsTextColor.Text + "|" +
                   TextBoxDataShrift.Text + "|" + TextBoxNewsShrift.Text + "|");






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

                    this.StatusFile.Text = "Файл модуля новостей " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл модуля новостей " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл модуля новостей " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл модуля новостей " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла модуля новостей была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла модуля новостей была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<div class=\"container\"><h3 style=\"color:" + TextBoxZagolovokColor.Text + ";\">НАШИ НОВОСТИ</h3>\r\n");

            if (TextBoxDataNovosti1.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti1.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:"+ TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti1.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti2.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti2.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti2.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti3.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti3.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti3.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti4.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti4.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti4.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti5.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti5.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti5.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti6.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti6.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti6.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti7.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti7.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti7.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti8.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti8.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti8.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti9.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti9.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti9.Text + "</p>\r\n");
            }

            if (TextBoxDataNovosti10.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<h5 class=\"news\" style=\"font-family:" + TextBoxDataShrift.Text + ";font-weight:bold;color:" + TextBoxDataTextColor.Text + ";\">" + TextBoxDataNovosti10.Text + "</h5>\r\n");
                await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"news\" style=\"font-family:" + TextBoxNewsShrift.Text + ";color:" + TextBoxNewsTextColor.Text + "\">" + TextBoxTekstNovosti10.Text + "</p>\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "</div>\r\n");

            ///////////////////////////////////////////////////////////////////////////////

            string text11 = await Windows.Storage.FileIO.ReadTextAsync(UPLOADFile);
            string text102 = text11.Replace("\r\n", "  "); string text1002 = text102.Replace("\n", "  "); string text12 = text1002.Replace("\r", "  ");

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
