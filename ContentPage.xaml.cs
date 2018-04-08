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
    public sealed partial class ContentPage : Page
    {
        public ContentPage()
        {
            this.InitializeComponent();
        }

        private async void LoadFilePage_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".cpage");
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
                    TextBoxZagolovokPage.Text = line.Split('|')[0];
                    TextBoxKeywords.Text = line.Split('|')[1];
                    TextBoxMetaDescription.Text = line.Split('|')[2];
                    TextBoxFontBody.Text = line.Split('|')[3];
                    TextBoxFont.Text = line.Split('|')[4];

                    TextBoxZagolovokColor.Text = line.Split('|')[5];
                    TextBoxKategoriiTextColor.Text = line.Split('|')[6];
                    TextBoxBackgroundColor.Text = line.Split('|')[7];

                    TextBoxPart1.Text = line.Split('|')[8];
                    TextBoxPart2.Text = line.Split('|')[9];
                    TextBoxPart3.Text = line.Split('|')[10];
                    TextBoxPart4.Text = line.Split('|')[11];
                    TextBoxPart5.Text = line.Split('|')[12];
                    TextBoxPart6.Text = line.Split('|')[13];
                    TextBoxPart7.Text = line.Split('|')[14];
                    TextBoxPart8.Text = line.Split('|')[15];
                    TextBoxPart9.Text = line.Split('|')[16];
                    TextBoxPart10.Text = line.Split('|')[17];

                    TextBoxFTPServer.Text = line.Split('|')[18];
                    TextBoxFTPUser.Text = line.Split('|')[19];
                    TextBoxFTPPass.Password = line.Split('|')[20];

                    try { TextBoxSTYLE.Text = line.Split('|')[21]; TextBoxCUSTOMCSS.Text = line.Split('|')[22]; }
                    catch { }

                    //asyncOperation.Cancel();
                   
                }
                Progress.IsActive = false;
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
                Progress.IsActive = false;
            }
            Progress.IsActive = false;
        }

        private async void SaveFileTovarPHP_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("PHP файл страницы с контентом ", new List<string>() { ".php" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "page";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/header.tpl\"; ?>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<title>" + TextBoxZagolovokPage.Text + "</title>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<meta name=\"keywords\" content=\"" + TextBoxKeywords.Text + "\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

                if (TextBoxCUSTOMCSS.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4, "<style>"+TextBoxSTYLE.Text+"</style>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<body style=\"font-family:" + TextBoxFontBody.Text + "; background:"+TextBoxBackgroundColor.Text+";\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/navigation.tpl\"; ?>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<!-- СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА--><?php $file1=$_SERVER['DOCUMENT_ROOT'].\"/dollar.ini\"; $fd1=fopen($file1,\"r\"); $dollar=fgets($fd1,6); fclose ($fd1); $file2=$_SERVER['DOCUMENT_ROOT'].\"/euro.ini\"; $fd2=fopen($file2,\"r\"); $euro=fgets($fd2,6); fclose ($fd2); ?>\r\n<!-- КОНЕЦ СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-->\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<!--ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><div class=\"container\" style=\"margin-top:92px;\">\r\n");

                if (TextBoxPart1.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart1.Text); }
                if (TextBoxPart2.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart2.Text); }
                if (TextBoxPart3.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart3.Text); }
                if (TextBoxPart4.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart4.Text); }
                if (TextBoxPart5.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart5.Text); }
                if (TextBoxPart6.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart6.Text); }
                if (TextBoxPart7.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart7.Text); }
                if (TextBoxPart8.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart8.Text); }
                if (TextBoxPart9.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart9.Text); }
                if (TextBoxPart10.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, TextBoxPart10.Text); }

                await FileIO.AppendTextAsync(Myfile4, "</div><!--КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><?php require $_SERVER['DOCUMENT_ROOT'].\"/footer.tpl\"; ?><?php require $_SERVER['DOCUMENT_ROOT'].\"/footerscripts.tpl\"; ?>\r\n");




                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "PHP файл страницы с контентом " + Myfile4.Name + " успешно экспортирован.";
                    
                    FileTextBox.Text = "";

                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;

                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("PHP файл страницы с контентом " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();

                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить PHP-файл страницы с контентом " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить PHP-файл страницы с контентом " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи PHP-файла страницы с контентом была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи PHP-файла страницы с контентом была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }


        private async void SaveFileTovar_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл данных страницы с контентом", new List<string>() { ".cpage" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "page";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени


                await FileIO.WriteTextAsync(Myfile4, TextBoxZagolovokPage.Text + "|" +
                    TextBoxKeywords.Text + "|" + TextBoxMetaDescription.Text + "|" +
                TextBoxFontBody.Text + "|" +
                TextBoxFont.Text + "|" +
                TextBoxZagolovokColor.Text + "|" +
                TextBoxKategoriiTextColor.Text + "|" +
                TextBoxBackgroundColor.Text + "|" +
                TextBoxPart1.Text + "|" +
                TextBoxPart2.Text + "|" +
                TextBoxPart3.Text + "|" +
                TextBoxPart4.Text + "|" +
                TextBoxPart5.Text + "|" +
                TextBoxPart6.Text + "|" +
                TextBoxPart7.Text + "|" +
                TextBoxPart8.Text + "|" +
                TextBoxPart9.Text + "|" +
                TextBoxPart10.Text + "|" +

                TextBoxFTPServer.Text + "|" +
                TextBoxFTPUser.Text + "|" +
                TextBoxFTPPass.Password + "|" +TextBoxSTYLE.Text+"|"+TextBoxCUSTOMCSS.Text+"|");
                
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

                    this.StatusFile.Text = "Файл данных страницы с контентом " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл данных страницы с контентом " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных страницы с контентом " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных страницы с контентом " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных страницы с контентом была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла данных страницы с контентом была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private void FTPFileTovarPHP_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            if (TextBoxFTPServer.Text != "")
            {
                DoDownloadOrUpload(false); ////см.проект kiewic ftp client 
            }

            else { StatusFile.Text = "Ошибка. Введите адрес FTP сервера."; Progress.IsActive = false; }
            Progress.IsActive = false;
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
            savePicker4.FileTypeChoices.Add("Файл данных страницы с контентом", new List<string>() { ".cpage" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "page01";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени


                await FileIO.WriteTextAsync(Myfile4, TextBoxZagolovokPage.Text + "|" +
                    TextBoxKeywords.Text + "|" + TextBoxMetaDescription.Text + "|" +
                TextBoxFontBody.Text + "|" +
                TextBoxFont.Text + "|" +
                TextBoxZagolovokColor.Text + "|" +
                TextBoxKategoriiTextColor.Text + "|" +
                TextBoxBackgroundColor.Text + "|" +
                TextBoxPart1.Text + "|" +
                TextBoxPart2.Text + "|" +
                TextBoxPart3.Text + "|" +
                TextBoxPart4.Text + "|" +
                TextBoxPart5.Text + "|" +
                TextBoxPart6.Text + "|" +
                TextBoxPart7.Text + "|" +
                TextBoxPart8.Text + "|" +
                TextBoxPart9.Text + "|" +
                TextBoxPart10.Text + "|" +

                TextBoxFTPServer.Text + "|" +
                TextBoxFTPUser.Text + "|" +
                TextBoxFTPPass.Password + "|"+TextBoxSTYLE.Text+"|"+TextBoxCUSTOMCSS.Text+"|");

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

                    this.StatusFile.Text = "Файл данных страницы с контентом " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл данных страницы с контентом " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных страницы с контентом " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных страницы с контентом " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных страницы с контентом была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла данных страницы с контентом была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/header.tpl\"; ?>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<title>" + TextBoxZagolovokPage.Text + "</title>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<meta name=\"keywords\" content=\"" + TextBoxKeywords.Text + "\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\"></head>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

            if (TextBoxCUSTOMCSS.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "<style>" + TextBoxSTYLE.Text + "</style>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<body style=\"font-family:" + TextBoxFontBody.Text + "; background:" + TextBoxBackgroundColor.Text + ";\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/navigation.tpl\"; ?>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<!-- СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА--><?php $file1=$_SERVER['DOCUMENT_ROOT'].\"/dollar.ini\"; $fd1=fopen($file1,\"r\"); $dollar=fgets($fd1,6); fclose ($fd1); $file2=$_SERVER['DOCUMENT_ROOT'].\"/euro.ini\"; $fd2=fopen($file2,\"r\"); $euro=fgets($fd2,6); fclose ($fd2); ?>\r\n<!-- КОНЕЦ СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-->\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<!--ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><div class=\"container\" style=\"margin-top:92px;\">\r\n");

            if (TextBoxPart1.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart1.Text); }
            if (TextBoxPart2.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart2.Text); }
            if (TextBoxPart3.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart3.Text); }
            if (TextBoxPart4.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart4.Text); }
            if (TextBoxPart5.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart5.Text); }
            if (TextBoxPart6.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart6.Text); }
            if (TextBoxPart7.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart7.Text); }
            if (TextBoxPart8.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart8.Text); }
            if (TextBoxPart9.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart9.Text); }
            if (TextBoxPart10.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxPart10.Text); }

            await FileIO.AppendTextAsync(UPLOADFile, "</div><!--КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><?php require $_SERVER['DOCUMENT_ROOT'].\"/footer.tpl\"; ?><?php require $_SERVER['DOCUMENT_ROOT'].\"/footerscripts.tpl\"; ?>\r\n");


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
                StatusFile.Text = "Ошибка. Введите адрес FTP сервера."; Progress.IsActive = false;

                var messagedialog1 = new MessageDialog("Ошибка. Введите адрес FTP сервера.");
                messagedialog1.Commands.Add(new UICommand("Ok"));
                await messagedialog1.ShowAsync();
            }

            Progress.IsActive = false;
        }




    }
    }
