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
    public sealed partial class cbr : Page
    {
        public cbr()
        {
            this.InitializeComponent();
        }

        private async void LoadFileTCatalog_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".cbr");
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
                    TextBoxDOLLAR.Text = line.Split('|')[0];
                    TextBoxEURO.Text= line.Split('|')[1];


                    TextBoxFTPServer.Text = line.Split('|')[2];
                    TextBoxFTPUser.Text = line.Split('|')[3];
                    TextBoxFTPPass.Password = line.Split('|')[4];

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
            savePicker4.FileTypeChoices.Add("Файл данных скрипта \"CBR.PHP\" ", new List<string>() { ".cbr" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "script";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxDOLLAR.Text + "|" + TextBoxEURO.Text + "|" +

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

                    this.StatusFile.Text = "Файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных скрипта \"CBR.PHP\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла данных скрипта \"CBR.PHP\" была прервана.");
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
            savePicker4.FileTypeChoices.Add("PHP файл скрипта \"CBR.PHP\" ", new List<string>() { ".php" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "CBR";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<?php\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$content = get_content();\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$pattern=\"#<Valute ID="+@"\"+"\"([^"+@"\"+"\"]+)[^>]+>[^>]+>([^<]+)[^>]+>[^>]+>[^>]+>[^>]+>[^>]+>[^>]+>([^<]+)[^>]+>[^>]+>([^<]+)#i\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "preg_match_all($pattern, $content, $out, PREG_SET_ORDER);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$dollar = \"\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$euro = \"\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "foreach($out as $cur)\r\n");
                await FileIO.AppendTextAsync(Myfile4, "{ \r\n");
                await FileIO.AppendTextAsync(Myfile4, "if ($cur[2]==840) $dollar=str_replace(\",\",\".\",$cur[4]);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "if($cur[2]==978) $euro=str_replace(\",\",\".\",$cur[4]);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "}\r\n");

                await FileIO.AppendTextAsync(Myfile4, "echo \"Dollar - \".$dollar.\"<br>\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "echo \"Euro - \".$euro.\"<br>\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "function get_content()\r\n");
                await FileIO.AppendTextAsync(Myfile4, "{\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$date=date(\"d/m/Y\");\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$link=\"http://www.cbr.ru/scripts/XML_daily.asp?date_req=$date\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$fd=fopen($link, \"r\");\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$text=\"\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "if (!$fd) echo \"Страница с валютами на сайте ЦБ РФ не найдена. Попробуйте выполнить скрипт позже.\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "else\r\n");
                await FileIO.AppendTextAsync(Myfile4, "{\r\n");
                await FileIO.AppendTextAsync(Myfile4, "while (!feof ($fd)) $text .= fgets($fd, 4096);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "fclose ($fd);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "return $text;\r\n");
                await FileIO.AppendTextAsync(Myfile4, "}\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$eurotable=$dollar/$euro;\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$fh1=fopen(\"" + TextBoxDOLLAR.Text + "\",\"w\");\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$line1 = fwrite($fh1,$dollar);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "fclose($fh1);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$fh2=fopen(\"" + TextBoxEURO.Text + "\",\"w\");\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$line2=fwrite($fh2,$euro);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "fclose($fh2);\r\n");
                await FileIO.AppendTextAsync(Myfile4, "?>");

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

                    var messagedialog = new MessageDialog("PHP-файл получения курсов валют " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();

                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл навигационного меню " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить PHP-файл получения курсов валют " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла навигационного меню была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи PHP-файла получения курсов валют была прервана.");
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
            savePicker4.FileTypeChoices.Add("Файл данных скрипта \"CBR.PHP\" ", new List<string>() { ".cbr" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "script";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxDOLLAR.Text + "|" + TextBoxEURO.Text + "|" +

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

                    this.StatusFile.Text = "Файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных скрипта \"CBR.PHP\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных скрипта \"CBR.PHP\" была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла данных скрипта \"CBR.PHP\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<?php\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$content = get_content();\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$pattern=\"#<Valute ID=" + @"\" + "\"([^" + @"\" + "\"]+)[^>]+>[^>]+>([^<]+)[^>]+>[^>]+>[^>]+>[^>]+>[^>]+>[^>]+>([^<]+)[^>]+>[^>]+>([^<]+)#i\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "preg_match_all($pattern, $content, $out, PREG_SET_ORDER);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$dollar = \"\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$euro = \"\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "foreach($out as $cur)\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "{ \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "if ($cur[2]==840) $dollar=str_replace(\",\",\".\",$cur[4]);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "if($cur[2]==978) $euro=str_replace(\",\",\".\",$cur[4]);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "}\r\n");

            await FileIO.AppendTextAsync(UPLOADFile, "echo \"Dollar - \".$dollar.\"<br>\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "echo \"Euro - \".$euro.\"<br>\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "function get_content()\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "{\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$date=date(\"d/m/Y\");\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$link=\"http://www.cbr.ru/scripts/XML_daily.asp?date_req=$date\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$fd=fopen($link, \"r\");\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$text=\"\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "if (!$fd) echo \"Страница с валютами на сайте ЦБ РФ не найдена. Попробуйте выполнить скрипт позже.\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "else\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "{\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "while (!feof ($fd)) $text .= fgets($fd, 4096);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "fclose ($fd);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "return $text;\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "}\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$eurotable =$dollar/$euro;\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$fh1=fopen(\"" + TextBoxDOLLAR.Text + "\",\"w\");\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$line1 = fwrite($fh1,$dollar);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "fclose($fh1);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$fh2 =fopen(\""+TextBoxEURO.Text+"\",\"w\");\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$line2 = fwrite($fh2,$euro);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "fclose($fh2);\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "?>");


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
