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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Управление.сайтом
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyCSSCustom : Page
    {
        public MyCSSCustom()
        {
            this.InitializeComponent();
        }
        private async void LoadFileTCatalog_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".customcss");
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
                    TextBoxDIVtovarimage.Text = line.Split('|')[0];
                    TextBoxDIVtovartext.Text = line.Split('|')[1];
                    TextBoxH4tovar.Text = line.Split('|')[2];
                    TextBoxPtovar.Text = line.Split('|')[3];

                    TextBoxDIVclientsimage.Text = line.Split('|')[4];
                    TextBoxDIVclientstext.Text = line.Split('|')[5];
                    TextBoxH4clients.Text = line.Split('|')[6];
                    TextBoxPclients.Text = line.Split('|')[7];

                    TextBoxDIVworksimage.Text = line.Split('|')[8];
                    TextBoxDIVworkstext.Text = line.Split('|')[9];
                    TextBoxH4works.Text = line.Split('|')[10];
                    TextBoxPworks.Text = line.Split('|')[11];

                    TextBoxCSS.Text = line.Split('|')[12];



                    TextBoxFTPServer.Text = line.Split('|')[13];
                    TextBoxFTPUser.Text = line.Split('|')[14];
                    TextBoxFTPPass.Password = line.Split('|')[15];

                    try { TextBoxIMGclients.Text = line.Split('|')[16]; TextBoxIMGtovar.Text = line.Split('|')[17]; TextBoxIMGworks.Text = line.Split('|')[18]; TextBoxH5news.Text = line.Split('|')[19]; TextBoxPnews.Text = line.Split('|')[20];
                        TextBoxPcenatovar.Text = line.Split('|')[21]; TextBoxSPANcenatovar.Text = line.Split('|')[22];
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

        private async void SaveFileKatalogTovarov_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл настроек кастомных стилей ", new List<string>() { ".customcss" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "customstyle";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxDIVtovarimage.Text + "|" +
                    TextBoxDIVtovartext.Text + "|" +
                    TextBoxH4tovar.Text + "|" +
                    TextBoxPtovar.Text + "|" +

                    TextBoxDIVclientsimage.Text + "|" +
                    TextBoxDIVclientstext.Text + "|" +
                    TextBoxH4clients.Text + "|" +
                    TextBoxPclients.Text + "|" +

                    TextBoxDIVworksimage.Text + "|" +
                    TextBoxDIVworkstext.Text + "|" +
                    TextBoxH4works.Text + "|" +
                    TextBoxPworks.Text + "|" +

                    TextBoxCSS.Text + "|" +



                    TextBoxFTPServer.Text + "|" +
                    TextBoxFTPUser.Text + "|" +
                    TextBoxFTPPass.Password + "|"+
                    
                    TextBoxIMGclients.Text+"|"+TextBoxIMGtovar.Text+"|"+TextBoxIMGworks.Text+"|" + TextBoxH5news.Text + "|" + TextBoxPnews.Text + "|"+ TextBoxPcenatovar.Text+"|"+TextBoxSPANcenatovar.Text+"|");






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

                    this.StatusFile.Text = "Файл настроек кастомных стилей " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл настроек кастомных стилей " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл настроек кастомных стилей " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл настроек кастомных стилей " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла настроек кастомных стилей была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла настроек кастомных стилей была прервана.");
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
            savePicker4.FileTypeChoices.Add("CSS файл кастомных стилей ", new List<string>() { ".css" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "customstyle";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "div.tovar-image {"+TextBoxDIVtovarimage.Text+"}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "div.tovar-text {" + TextBoxDIVtovartext.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "h4.tovar {" + TextBoxH4tovar.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "p.tovar {" + TextBoxPtovar.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "img.tovar-image {"+TextBoxIMGtovar.Text+"}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "p.cenatovar {"+TextBoxPcenatovar.Text+ "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "span.cenatovar {" + TextBoxSPANcenatovar.Text + "}\r\n");

                await FileIO.AppendTextAsync(Myfile4, "div.works-image {" + TextBoxDIVworksimage.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "div.works-text {" + TextBoxDIVworkstext.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "h4.works {" + TextBoxH4works.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "p.works {" + TextBoxPworks.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "img.works-image {" + TextBoxIMGworks.Text + "}\r\n");

                await FileIO.AppendTextAsync(Myfile4, "div.clients-image {" + TextBoxDIVclientsimage.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "div.clients-text {" + TextBoxDIVclientstext.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "h4.clients {" + TextBoxH4clients.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "p.clients {" + TextBoxPclients.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "img.clients-image {" + TextBoxIMGclients.Text + "}\r\n");

                await FileIO.AppendTextAsync(Myfile4, "h5.news {" + TextBoxH5news.Text + "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "p.news {" + TextBoxPnews.Text + "}\r\n");

                await FileIO.AppendTextAsync(Myfile4, TextBoxCSS.Text+"\r\n");

                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "CSS файл кастомных стилей " + Myfile4.Name + " успешно экспортирован.";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;


                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("CSS файл кастомных стилей " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();

                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить CSS файл кастомных стилей " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить CSS файл кастомных стилей " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи CSS файла кастомных стилей была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи CSS файла кастомных стилей была прервана.");
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
            savePicker4.FileTypeChoices.Add("Файл настроек кастомных стилей ", new List<string>() { ".customcss" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "customstyle";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxDIVtovarimage.Text + "|" +
                    TextBoxDIVtovartext.Text + "|" +
                    TextBoxH4tovar.Text + "|" +
                    TextBoxPtovar.Text + "|" +

                    TextBoxDIVclientsimage.Text + "|" +
                    TextBoxDIVclientstext.Text + "|" +
                    TextBoxH4clients.Text + "|" +
                    TextBoxPclients.Text + "|" +

                    TextBoxDIVworksimage.Text + "|" +
                    TextBoxDIVworkstext.Text + "|" +
                    TextBoxH4works.Text + "|" +
                    TextBoxPworks.Text + "|" +

                    TextBoxCSS.Text + "|" +



                    TextBoxFTPServer.Text + "|" +
                    TextBoxFTPUser.Text + "|" +
                    TextBoxFTPPass.Password + "|" +

                    TextBoxIMGclients.Text + "|" + TextBoxIMGtovar.Text + "|" + TextBoxIMGworks.Text + "|"+TextBoxH5news.Text + "|" +TextBoxPnews.Text + "|"
                    + TextBoxPcenatovar.Text + "|" + TextBoxSPANcenatovar.Text + "|");






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

                    this.StatusFile.Text = "Файл настроек кастомных стилей " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл настроек кастомных стилей " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл настроек кастомных стилей " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл настроек кастомных стилей " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла настроек кастомных стилей была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла настроек кастомных стилей была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "div.tovar-image {" + TextBoxDIVtovarimage.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "div.tovar-text {" + TextBoxDIVtovartext.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "h4.tovar {" + TextBoxH4tovar.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "p.tovar {" + TextBoxPtovar.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "img.tovar-image {" + TextBoxIMGtovar.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "p.cenatovar {" + TextBoxPcenatovar.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "span.cenatovar {" + TextBoxSPANcenatovar.Text + "}\r\n");

            await FileIO.AppendTextAsync(UPLOADFile, "div.works-image {" + TextBoxDIVworksimage.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "div.works-text {" + TextBoxDIVworkstext.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "h4.works {" + TextBoxH4works.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "p.works {" + TextBoxPworks.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "img.works-image {" + TextBoxIMGworks.Text + "}\r\n");

            await FileIO.AppendTextAsync(UPLOADFile, "div.clients-image {" + TextBoxDIVclientsimage.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "div.clients-text {" + TextBoxDIVclientstext.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "h4.clients {" + TextBoxH4clients.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "p.clients {" + TextBoxPclients.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "img.clients-image {" + TextBoxIMGclients.Text + "}\r\n");

            await FileIO.AppendTextAsync(UPLOADFile, "h5.news {" + TextBoxH5news.Text + "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "p.news {" + TextBoxPnews.Text + "}\r\n");

            await FileIO.AppendTextAsync(UPLOADFile, TextBoxCSS.Text + "\r\n");


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

        private void AddCSSMegamenu_Click(object sender, RoutedEventArgs e)
        {
            string CSSCode = "body {padding-bottom: 40px;color: #666;}  pre {margin: 0;padding: 10px 20px !important;}  footer {margin-top: 200px;}  .container,.jumbotron .container {width: auto;max-width: 1280px;}  .jumbotron {margin: 60px 0;padding-left: 0;padding-right: 0;}  .jumbotron.intro {margin-top: 0;}  .jumbotron .navbar {font-size: 14px;line-height: 1.6;}  a.navbar-brand {margin-top:10px;font-family:corpid_regular;}  /* menu styes */    .list-unstyled,.list-unstyled ul {min-width: 120px}  @media (min-width: 767px) {.panel-group {width: 400px;}    .thumbnail {margin: 0;}  }  /* Grid demo styles */    .grid-demo {    padding: 10px 30px;  }  .grid-demo[class*=\"col-\"] {margin-top: 5px;margin-bottom: 5px;font-size: 1em;text-align: center;line-height: 2;background-color: #e5e1ea;border: 1px solid #d1d1d1;} .yamm .nav, .yamm .collapse, .yamm .dropup,  .yamm .dropdown {position: static;}  .yamm .container {position: relative;font-family:corpid_regular;}  .yamm .dropdown-menu {left: auto;}  .yamm .yamm-content {padding: 20px 30px;}  .yamm .dropdown.yamm-fw .dropdown-menu {left: 0;right: 0;font-family:corpid_regular;}";
            TextBoxCSS.Text = TextBoxCSS.Text + CSSCode;
        }
    }
}
