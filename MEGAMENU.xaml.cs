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
    public sealed partial class MEGAMENU : Page
    {
        public MEGAMENU()
        {
            this.InitializeComponent();
        }

        private async void LoadFileMain_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".mainmega");
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
                    try
                    {
                    TextBoxName.Text = line.Split('¶')[0];
                    TextBoxSlogan.Text = line.Split('¶')[1];
                    TextBoxLogo.Text = line.Split('¶')[2];
                    TextBoxTel.Text = line.Split('¶')[3];
                    TextBoxGorod.Text = line.Split('¶')[4];
                    TextBoxBackgroundColor.Text = line.Split('¶')[5];
                    TextBoxShrift.Text = line.Split('¶')[6];
                    TextBoxShriftTel.Text = line.Split('¶')[7];
                    TextBoxSTYLENavigation.Text = line.Split('¶')[8];
                    TextBoxSTYLENavigationBar.Text = line.Split('¶')[9];

                    TextBoxMenuRazdel1Name.Text = line.Split('¶')[10];
                    TextBoxMenuRazdel1Link.Text = line.Split('¶')[11];
                    TextBoxMenuRazdel1HTML.Text = line.Split('¶')[12];

                    TextBoxMenuRazdel2Name.Text = line.Split('¶')[13];
                    TextBoxMenuRazdel2Link.Text = line.Split('¶')[14];
                    TextBoxMenuRazdel2HTML.Text = line.Split('¶')[15];

                    TextBoxMenuRazdel3Name.Text = line.Split('¶')[16];
                    TextBoxMenuRazdel3Link.Text = line.Split('¶')[17];
                    TextBoxMenuRazdel3HTML.Text = line.Split('¶')[18];

                    TextBoxMenuRazdel4Name.Text = line.Split('¶')[19];
                    TextBoxMenuRazdel4Link.Text = line.Split('¶')[20];
                    TextBoxMenuRazdel4HTML.Text = line.Split('¶')[21];

                    TextBoxMenuRazdel5Name.Text = line.Split('¶')[22];
                    TextBoxMenuRazdel5Link.Text = line.Split('¶')[23];
                    TextBoxMenuRazdel5HTML.Text = line.Split('¶')[24];

                    TextBoxFTPServer.Text = line.Split('¶')[25];
                    TextBoxFTPUser.Text = line.Split('¶')[26];
                    TextBoxFTPPass.Password = line.Split('¶')[27];

                    //asyncOperation.Cancel();


                    }

                    catch { }
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

        private async void SaveFileMain_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл навигационного МЕГАменю", new List<string>() { ".mainmega" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "menu";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxName.Text + "¶" +
                    TextBoxSlogan.Text + "¶" +
                    TextBoxLogo.Text + "¶" +
                    TextBoxTel.Text + "¶" +
                    TextBoxGorod.Text + "¶" +
                    TextBoxBackgroundColor.Text + "¶" +
                    TextBoxShrift.Text + "¶" +
                    TextBoxShriftTel.Text + "¶" +
                    TextBoxSTYLENavigation.Text + "¶" +
                    TextBoxSTYLENavigationBar.Text + "¶" +

                    TextBoxMenuRazdel1Name.Text + "¶" +
                    TextBoxMenuRazdel1Link.Text + "¶" +
                    TextBoxMenuRazdel1HTML.Text + "¶" +

                    TextBoxMenuRazdel2Name.Text + "¶" +
                    TextBoxMenuRazdel2Link.Text + "¶" +
                    TextBoxMenuRazdel2HTML.Text + "¶" +

                    TextBoxMenuRazdel3Name.Text + "¶" +
                    TextBoxMenuRazdel3Link.Text + "¶" +
                    TextBoxMenuRazdel3HTML.Text + "¶" +

                    TextBoxMenuRazdel4Name.Text + "¶" +
                    TextBoxMenuRazdel4Link.Text + "¶" +
                    TextBoxMenuRazdel4HTML.Text + "¶" +

                    TextBoxMenuRazdel5Name.Text + "¶" +
                    TextBoxMenuRazdel5Link.Text + "¶" +
                    TextBoxMenuRazdel5HTML.Text + "¶" +

                    TextBoxFTPServer.Text + "¶" +
                    TextBoxFTPUser.Text + "¶" +
                    TextBoxFTPPass.Password + "¶");






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

                    this.StatusFile.Text = "Файл навигационного МЕГАменю " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("Файл навигационного МЕГАменю " + Myfile4.Name + " успешно сохранен.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл навигационного МЕГАменю " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("Не удалось сохранить файл навигационного МЕГАменю " + Myfile4.Name + ".");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла навигационного МЕГАменю была прервана.";
                Progress.IsActive = false;
            }
            Progress.IsActive = false;
        }

        private async void SaveFileMainTPL_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;

            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("TPL файл навигационного МЕГАменю", new List<string>() { ".tpl" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "navigation";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<!-- ================================= НАЧАЛО КОДА ФИКСИРОВАННОГО НАВИГАЦИОННОГО МЕГА МЕНЮ ========================================= --> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<nav class=\"navbar yamm navbar-default navbar-fixed-top\" style=\"background:" + TextBoxBackgroundColor.Text + ";" + TextBoxSTYLENavigation.Text + "\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"navbar-header\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<button type= \"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#navbar-collapse-1\" aria-expanded=\"false\" aria-controls=\"navbar\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"sr-only\">Переключатель навигации</span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"icon-bar\"></span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"icon-bar\"></span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"icon-bar\"></span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "</button> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<a href = \"index.php\"><img class=\"navbar-brand\" src=\"" + TextBoxLogo.Text + "\" style=\"width:70px; height:65px; text-align:left;\"></a><p class=\"navbar-brand\" style=\"font-family: " + TextBoxShrift.Text + "; font-size:21px; line-height:18px; text-align:left;\">" + TextBoxName.Text + "<br><span style=\"font-size:12px;\"> " + TextBoxSlogan.Text + "</span></p> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "</div> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div id = \"navbar-collapse-1\" class=\"navbar-collapse collapse\" style=\"font-family: " + TextBoxShrift.Text + ";\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<ul class=\"nav navbar-nav\"> \r\n");

                if (TextBoxMenuRazdel1Name.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel1Link.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel1Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                        await FileIO.AppendTextAsync(Myfile4, TextBoxMenuRazdel1HTML.Text + "\r\n");
                        await FileIO.AppendTextAsync(Myfile4, "</div></li></ul></li>\r\n\r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel1Link.Text + "\">" + TextBoxMenuRazdel1Name.Text + "</a></li>\r\n"); }
                }


                if (TextBoxMenuRazdel2Name.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel2Link.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel2Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                        await FileIO.AppendTextAsync(Myfile4, TextBoxMenuRazdel2HTML.Text + "\r\n");
                        await FileIO.AppendTextAsync(Myfile4, "</div></li></ul></li>\r\n\r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel2Link.Text + "\">" + TextBoxMenuRazdel2Name.Text + "</a></li>\r\n"); }
                }


                if (TextBoxMenuRazdel3Name.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel3Link.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel3Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                        await FileIO.AppendTextAsync(Myfile4, TextBoxMenuRazdel3HTML.Text + "\r\n");
                        await FileIO.AppendTextAsync(Myfile4, "</div></li></ul></li>\r\n\r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel3Link.Text + "\">" + TextBoxMenuRazdel3Name.Text + "</a></li>\r\n"); }
                }


                if (TextBoxMenuRazdel4Name.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel4Link.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel4Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                        await FileIO.AppendTextAsync(Myfile4, TextBoxMenuRazdel4HTML.Text + "\r\n");
                        await FileIO.AppendTextAsync(Myfile4, "</div></li></ul></li>\r\n\r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel4Link.Text + "\">" + TextBoxMenuRazdel4Name.Text + "</a></li>\r\n"); }
                }

                if (TextBoxMenuRazdel5Name.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel5Link.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel5Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                        await FileIO.AppendTextAsync(Myfile4, TextBoxMenuRazdel5HTML.Text + "\r\n");
                        await FileIO.AppendTextAsync(Myfile4, "</div></li></ul></li>\r\n\r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel5Link.Text + "\">" + TextBoxMenuRazdel5Name.Text + "</a></li>\r\n"); }
                }



                await FileIO.AppendTextAsync(Myfile4, "</ul><ul class=\"nav navbar-nav navbar-right\"><li><p style=\"font-family:" + TextBoxShriftTel.Text + ",Helvetica Neue,Arial,sans-serif; font-size:18px; line-height:18px; text-align:right;\" class=\"navbar-brand\" id=\"tel\">" + TextBoxTel.Text + "<br><span style=\"font-size:12px; font-family:" + TextBoxShrift.Text + "; text-align:right;\" > " + TextBoxGorod.Text + "</span></p></li></ul></div><!--/.nav-collapse --></div></nav>\r\n <!-- ================================КОНЕЦ КОДА НАВИГАЦИОННОГО МЕГА МЕНЮ================================== --!>\r\n\r\n");






                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "TPL файл навигационного МЕГАменю " + Myfile4.Name + " успешно экспортирован.";

                    FileTextBox.Text = "";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("TPL файл навигационного МЕГАменю " + Myfile4.Name + " успешно экспортирован.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл навигационного МЕГАменю " + Myfile4.Name + ".";
                    Progress.IsActive = false;
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла навигационного МЕГАменю была прервана.";
                Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Операция записи TPL-файла навигационного МЕГАменю была прервана.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }
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



        private void FTPFileMainTPL_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            DoDownloadOrUpload(false); ////см.проект kiewic ftp client
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
            savePicker4.FileTypeChoices.Add("Файл навигационного МЕГАменю", new List<string>() { ".mainmega" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "menu";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени





                await FileIO.WriteTextAsync(Myfile4, TextBoxName.Text + "¶" +
                    TextBoxSlogan.Text + "¶" +
                    TextBoxLogo.Text + "¶" +
                    TextBoxTel.Text + "¶" +
                    TextBoxGorod.Text + "¶" +
                    TextBoxBackgroundColor.Text + "¶" +
                    TextBoxShrift.Text + "¶" +
                    TextBoxShriftTel.Text + "¶" +
                    TextBoxSTYLENavigation.Text + "¶" +
                    TextBoxSTYLENavigationBar.Text + "¶" +

                    TextBoxMenuRazdel1Name.Text + "¶" +
                    TextBoxMenuRazdel1Link.Text + "¶" +
                    TextBoxMenuRazdel1HTML.Text + "¶" +

                    TextBoxMenuRazdel2Name.Text + "¶" +
                    TextBoxMenuRazdel2Link.Text + "¶" +
                    TextBoxMenuRazdel2HTML.Text + "¶" +

                    TextBoxMenuRazdel3Name.Text + "¶" +
                    TextBoxMenuRazdel3Link.Text + "¶" +
                    TextBoxMenuRazdel3HTML.Text + "¶" +

                    TextBoxMenuRazdel4Name.Text + "¶" +
                    TextBoxMenuRazdel4Link.Text + "¶" +
                    TextBoxMenuRazdel4HTML.Text + "¶" +

                    TextBoxMenuRazdel5Name.Text + "¶" +
                    TextBoxMenuRazdel5Link.Text + "¶" +
                    TextBoxMenuRazdel5HTML.Text + "¶" +

                    TextBoxFTPServer.Text + "¶" +
                    TextBoxFTPUser.Text + "¶" +
                    TextBoxFTPPass.Password + "¶");






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

                    this.StatusFile.Text = "Файл навигационного МЕГАменю " + Myfile4.Name + " успешно сохранен.";

                    var messagedialogFile1 = new MessageDialog("Файл навигационного МЕГАменю " + Myfile4.Name + " успешно сохранен.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл навигационного МЕГАменю " + Myfile4.Name + ".";

                    var messagedialogFile1 = new MessageDialog("Не удалось сохранить файл навигационного МЕГАменю " + Myfile4.Name + ".");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла навигационного МЕГАменю была прервана.";

                var messagedialogFile1 = new MessageDialog("Операция записи файла навигационного МЕГАменю была прервана.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<!-- ================================= НАЧАЛО КОДА ФИКСИРОВАННОГО НАВИГАЦИОННОГО МЕГА МЕНЮ ========================================= --> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<nav class=\"navbar yamm navbar-default navbar-fixed-top\" style=\"background:" + TextBoxBackgroundColor.Text + ";" + TextBoxSTYLENavigation.Text + "\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"navbar-header\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<button type= \"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#navbar-collapse-1\" aria-expanded=\"false\" aria-controls=\"navbar\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"sr-only\">Переключатель навигации</span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"icon-bar\"></span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"icon-bar\"></span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"icon-bar\"></span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</button> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<a href = \"index.php\"><img class=\"navbar-brand\" src=\"" + TextBoxLogo.Text + "\" style=\"width:70px; height:65px; text-align:left;\"></a><p class=\"navbar-brand\" style=\"font-family: " + TextBoxShrift.Text + "; font-size:21px; line-height:18px; text-align:left;\">" + TextBoxName.Text + "<br><span style=\"font-size:12px;\"> " + TextBoxSlogan.Text + "</span></p> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</div> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div id = \"navbar-collapse-1\" class=\"navbar-collapse collapse\" style=\"font-family: " + TextBoxShrift.Text + ";\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<ul class=\"nav navbar-nav\"> \r\n");

            if (TextBoxMenuRazdel1Name.Text.Length != 0)
            { 
                if (TextBoxMenuRazdel1Link.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel1Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, TextBoxMenuRazdel1HTML.Text + "\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, "</div></li></ul></li>\r\n\r\n");
                } else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel1Link.Text + "\">" + TextBoxMenuRazdel1Name.Text + "</a></li>\r\n"); }
            }

            if (TextBoxMenuRazdel2Name.Text.Length != 0)
            {
                if (TextBoxMenuRazdel2Link.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel2Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, TextBoxMenuRazdel2HTML.Text + "\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, "</div></li></ul></li>\r\n\r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel2Link.Text + "\">" + TextBoxMenuRazdel2Name.Text + "</a></li>\r\n"); }
            }

            if (TextBoxMenuRazdel3Name.Text.Length != 0)
            {
                if (TextBoxMenuRazdel3Link.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel3Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, TextBoxMenuRazdel3HTML.Text + "\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, "</div></li></ul></li>\r\n\r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel3Link.Text + "\">" + TextBoxMenuRazdel3Name.Text + "</a></li>\r\n"); }
            }

            if (TextBoxMenuRazdel4Name.Text.Length != 0)
            {
                if (TextBoxMenuRazdel4Link.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel4Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, TextBoxMenuRazdel4HTML.Text + "\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, "</div></li></ul></li>\r\n\r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel4Link.Text + "\">" + TextBoxMenuRazdel4Name.Text + "</a></li>\r\n"); }
            }

            if (TextBoxMenuRazdel5Name.Text.Length != 0)
            {
                if (TextBoxMenuRazdel5Link.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown yamm-fw\"><a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\">" + TextBoxMenuRazdel5Name.Text + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\" style=\"" + TextBoxSTYLENavigationBar.Text + "\" ><li><div class=\"yamm-content\">\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, TextBoxMenuRazdel5HTML.Text + "\r\n");
                    await FileIO.AppendTextAsync(UPLOADFile, "</div></li></ul></li>\r\n\r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel5Link.Text + "\">" + TextBoxMenuRazdel5Name.Text + "</a></li>\r\n"); }
            }



            await FileIO.AppendTextAsync(UPLOADFile, "</ul><ul class=\"nav navbar-nav navbar-right\"><li><p style=\"font-family:" + TextBoxShriftTel.Text + ",Helvetica Neue,Arial,sans-serif; font-size:18px; line-height:18px; text-align:right;\" class=\"navbar-brand\" id=\"tel\">" + TextBoxTel.Text + "<br><span style=\"font-size:12px; font-family:" + TextBoxShrift.Text + "; text-align:right;\" > " + TextBoxGorod.Text + "</span></p></li></ul></div><!--/.nav-collapse --></div></nav>\r\n <!-- ================================КОНЕЦ КОДА НАВИГАЦИОННОГО МЕГА МЕНЮ================================== --!>\r\n\r\n");



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

                var messagedialogFile1 = new MessageDialog("Ошибка. Введите адрес FTP сервера.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }

            Progress.IsActive = false;
            
        }
    }
}
