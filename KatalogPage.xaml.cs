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
    public sealed partial class KatalogPage : Page
    {
        public KatalogPage()
        {
            this.InitializeComponent();
        }

        private async void LoadFileTCatalog_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tcatalog");
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
                    TextBoxKategoriiTextColor.Text = line.Split('|')[1];
                    TextBoxButtonTextColor.Text = line.Split('|')[2];
                    TextBoxBackgroundColor.Text = line.Split('|')[3];
                    TextBoxNavigationTextColor.Text = line.Split('|')[4];
                    TextBoxNazvanijeKataloga.Text = line.Split('|')[5];

                    TextBoxNazvanijeRazdel1.Text = line.Split('|')[6];
                    TextBoxLinkRazdel1.Text = line.Split('|')[7];
                    TextBoxIMGLinkRazdel1.Text = line.Split('|')[8];

                    TextBoxNazvanijeRazdel2.Text = line.Split('|')[9];
                    TextBoxLinkRazdel2.Text = line.Split('|')[10];
                    TextBoxIMGLinkRazdel2.Text = line.Split('|')[11];

                    TextBoxNazvanijeRazdel3.Text = line.Split('|')[12];
                    TextBoxLinkRazdel3.Text = line.Split('|')[13];
                    TextBoxIMGLinkRazdel3.Text = line.Split('|')[14];

                    TextBoxNazvanijeRazdel4.Text = line.Split('|')[15];
                    TextBoxLinkRazdel4.Text = line.Split('|')[16];
                    TextBoxIMGLinkRazdel4.Text = line.Split('|')[17];

                    TextBoxNazvanijeRazdel5.Text = line.Split('|')[18];
                    TextBoxLinkRazdel5.Text = line.Split('|')[19];
                    TextBoxIMGLinkRazdel5.Text = line.Split('|')[20];

                    TextBoxNazvanijeRazdel6.Text = line.Split('|')[21];
                    TextBoxLinkRazdel6.Text = line.Split('|')[22];
                    TextBoxIMGLinkRazdel6.Text = line.Split('|')[23];

                    TextBoxNazvanijeRazdel7.Text = line.Split('|')[24];
                    TextBoxLinkRazdel7.Text = line.Split('|')[25];
                    TextBoxIMGLinkRazdel7.Text = line.Split('|')[26];

                    TextBoxNazvanijeRazdel8.Text = line.Split('|')[27];
                    TextBoxLinkRazdel8.Text = line.Split('|')[28];
                    TextBoxIMGLinkRazdel8.Text = line.Split('|')[29];

                    TextBoxNazvanijeRazdel9.Text = line.Split('|')[30];
                    TextBoxLinkRazdel9.Text = line.Split('|')[31];
                    TextBoxIMGLinkRazdel9.Text = line.Split('|')[32];

                    TextBoxNazvanijeRazdel10.Text = line.Split('|')[33];
                    TextBoxLinkRazdel10.Text = line.Split('|')[34];
                    TextBoxIMGLinkRazdel10.Text = line.Split('|')[35];

                    TextBoxNazvanijeRazdel11.Text = line.Split('|')[36];
                    TextBoxLinkRazdel11.Text = line.Split('|')[37];
                    TextBoxIMGLinkRazdel11.Text = line.Split('|')[38];

                    TextBoxNazvanijeRazdel12.Text = line.Split('|')[39];
                    TextBoxLinkRazdel12.Text = line.Split('|')[40];
                    TextBoxIMGLinkRazdel12.Text = line.Split('|')[41];

                    TextBoxZagolovokPage.Text = line.Split('|')[42];
                    TextBoxKeywords.Text = line.Split('|')[43];
                    TextBoxMetaDescription.Text = line.Split('|')[44];
                    TextBoxFont.Text= line.Split('|')[45];

                    TextBoxFTPServer.Text = line.Split('|')[46];
                    TextBoxFTPUser.Text = line.Split('|')[47];
                    TextBoxFTPPass.Password = line.Split('|')[48];

                    try { TextBoxSTYLE.Text = line.Split('|')[49]; TextBoxSTYLEButton.Text = line.Split('|')[50]; TextBoxCUSTOMCSS.Text = line.Split('|')[51]; }
                   
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
            savePicker4.FileTypeChoices.Add("Файл данных страницы \"КАТАЛОГ ТОВАРОВ\"", new List<string>() { ".tcatalog" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "catalog1";
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
                    TextBoxKategoriiTextColor.Text + "|" +
                    TextBoxButtonTextColor.Text + "|" +
                    TextBoxBackgroundColor.Text + "|" +
                    TextBoxNavigationTextColor.Text + "|" +
                    TextBoxNazvanijeKataloga.Text + "|" +

                    TextBoxNazvanijeRazdel1.Text + "|" +
                    TextBoxLinkRazdel1.Text + "|" + 
                    TextBoxIMGLinkRazdel1.Text + "|" +

                    TextBoxNazvanijeRazdel2.Text + "|" + 
                    TextBoxLinkRazdel2.Text + "|" + 
                    TextBoxIMGLinkRazdel2.Text + "|" + 

                    TextBoxNazvanijeRazdel3.Text + "|" + 
                    TextBoxLinkRazdel3.Text + "|" + 
                    TextBoxIMGLinkRazdel3.Text + "|" + 

                    TextBoxNazvanijeRazdel4.Text + "|" + 
                    TextBoxLinkRazdel4.Text + "|" + 
                    TextBoxIMGLinkRazdel4.Text + "|" + 

                    TextBoxNazvanijeRazdel5.Text + "|" + 
                    TextBoxLinkRazdel5.Text + "|" + 
                    TextBoxIMGLinkRazdel5.Text + "|" + 

                    TextBoxNazvanijeRazdel6.Text + "|" + 
                    TextBoxLinkRazdel6.Text + "|" + 
                    TextBoxIMGLinkRazdel6.Text + "|" + 

                    TextBoxNazvanijeRazdel7.Text + "|" + 
                    TextBoxLinkRazdel7.Text + "|" + 
                    TextBoxIMGLinkRazdel7.Text + "|" + 

                    TextBoxNazvanijeRazdel8.Text + "|" + 
                    TextBoxLinkRazdel8.Text + "|" + 
                    TextBoxIMGLinkRazdel8.Text + "|" + 

                    TextBoxNazvanijeRazdel9.Text + "|" + 
                    TextBoxLinkRazdel9.Text + "|" + 
                    TextBoxIMGLinkRazdel9.Text + "|" + 

                    TextBoxNazvanijeRazdel10.Text + "|" + 
                    TextBoxLinkRazdel10.Text + "|" + 
                    TextBoxIMGLinkRazdel10.Text + "|" + 

                    TextBoxNazvanijeRazdel11.Text + "|" + 
                    TextBoxLinkRazdel11.Text + "|" + 
                    TextBoxIMGLinkRazdel11.Text + "|" + 

                    TextBoxNazvanijeRazdel12.Text + "|" + 
                    TextBoxLinkRazdel12.Text + "|" + 
                    TextBoxIMGLinkRazdel12.Text + "|"+
                    TextBoxZagolovokPage.Text + "|" +
                    TextBoxKeywords.Text + "|" +
                    TextBoxMetaDescription.Text + "|" + TextBoxFont.Text + "|"+
                    TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|"+TextBoxSTYLE.Text+"|"+TextBoxSTYLEButton.Text+"|"
                    +TextBoxCUSTOMCSS.Text+"|");






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

                    this.StatusFile.Text = "Файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных страницы \"КАТАЛОГ ТОВАРОВ\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла данных страницы \"КАТАЛОГ ТОВАРОВ\" была прервана.");
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
            savePicker4.FileTypeChoices.Add("PHP файл страницы \"КАТАЛОГ ТОВАРОВ\" ", new List<string>() { ".php" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "catalog1";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<?php require('header.tpl');?><title>" + TextBoxZagolovokPage.Text + "</title>\r\n<meta name=\"keywords\" content=\"" + TextBoxKeywords.Text + "\">\r\n<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\">\r\n");

                await FileIO.AppendTextAsync(Myfile4, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

                if (TextBoxCUSTOMCSS.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4,"<style>"+TextBoxSTYLE.Text+"</style>\r\n</head><body style=\"font-family:"+TextBoxFont.Text+";\"><?php require('navigation.tpl'); ?>");
                await FileIO.AppendTextAsync(Myfile4, "<!--ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><div class=\"container\" style=\"margin-top:92px;\"><p><a href=\"index.php\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">На главную</a></p><h3 style=\"color:" + TextBoxZagolovokColor.Text + ";\">" + TextBoxNazvanijeKataloga.Text + "</h3>");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"row\" style=\"margin-top:40px;\">");

                if (TextBoxNazvanijeRazdel1.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel1.Text + "\" alt=\""+TextBoxNazvanijeRazdel1.Text+ "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">"+TextBoxNazvanijeRazdel1.Text+"</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\""+TextBoxLinkRazdel1.Text+"\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel2.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel2.Text + "\" alt=\"" + TextBoxNazvanijeRazdel2.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel2.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel2.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel3.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel3.Text + "\" alt=\"" + TextBoxNazvanijeRazdel3.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel3.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel3.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel4.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel4.Text + "\" alt=\"" + TextBoxNazvanijeRazdel4.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel4.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel4.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                await FileIO.AppendTextAsync(Myfile4, "</div><!--/.row--><div class=\"row\" style=\"margin-top:20px;\">");


                if (TextBoxNazvanijeRazdel5.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel5.Text + "\" alt=\"" + TextBoxNazvanijeRazdel5.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel5.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel5.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel6.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel6.Text + "\" alt=\"" + TextBoxNazvanijeRazdel6.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel6.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel6.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel7.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel7.Text + "\" alt=\"" + TextBoxNazvanijeRazdel7.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel7.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel7.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel8.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel8.Text + "\" alt=\"" + TextBoxNazvanijeRazdel8.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel8.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel8.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                await FileIO.AppendTextAsync(Myfile4, "</div><!--/.row--><div class=\"row\" style=\"margin-top:20px;\">");


                if (TextBoxNazvanijeRazdel9.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel9.Text + "\" alt=\"" + TextBoxNazvanijeRazdel9.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel9.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel9.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel10.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel10.Text + "\" alt=\"" + TextBoxNazvanijeRazdel10.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel10.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel10.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel11.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel11.Text + "\" alt=\"" + TextBoxNazvanijeRazdel11.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel11.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel11.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }


                if (TextBoxNazvanijeRazdel12.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel12.Text + "\" alt=\"" + TextBoxNazvanijeRazdel12.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel12.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel12.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
                }

                

                await FileIO.AppendTextAsync(Myfile4, "</div><!--/.row--></div><!-- /.container marketing --><!-- КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ --><?php require('footer.tpl'); ?><?php require('footerscripts.tpl'); ?>");



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

                    var messagedialog = new MessageDialog("PHP файл страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();

                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить PHP-файл страницы \"КАТАЛОГ ТОВАРОВ\"  " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить PHP-файл страницы \"КАТАЛОГ ТОВАРОВ\"  " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи PHP-файла страницы \"КАТАЛОГ ТОВАРОВ\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи PHP-файла страницы \"КАТАЛОГ ТОВАРОВ\" была прервана.");
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
            savePicker4.FileTypeChoices.Add("Файл данных страницы \"КАТАЛОГ ТОВАРОВ\"", new List<string>() { ".tcatalog" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "catalog1";
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
                    TextBoxKategoriiTextColor.Text + "|" +
                    TextBoxButtonTextColor.Text + "|" +
                    TextBoxBackgroundColor.Text + "|" +
                    TextBoxNavigationTextColor.Text + "|" +
                    TextBoxNazvanijeKataloga.Text + "|" +

                    TextBoxNazvanijeRazdel1.Text + "|" +
                    TextBoxLinkRazdel1.Text + "|" +
                    TextBoxIMGLinkRazdel1.Text + "|" +

                    TextBoxNazvanijeRazdel2.Text + "|" +
                    TextBoxLinkRazdel2.Text + "|" +
                    TextBoxIMGLinkRazdel2.Text + "|" +

                    TextBoxNazvanijeRazdel3.Text + "|" +
                    TextBoxLinkRazdel3.Text + "|" +
                    TextBoxIMGLinkRazdel3.Text + "|" +

                    TextBoxNazvanijeRazdel4.Text + "|" +
                    TextBoxLinkRazdel4.Text + "|" +
                    TextBoxIMGLinkRazdel4.Text + "|" +

                    TextBoxNazvanijeRazdel5.Text + "|" +
                    TextBoxLinkRazdel5.Text + "|" +
                    TextBoxIMGLinkRazdel5.Text + "|" +

                    TextBoxNazvanijeRazdel6.Text + "|" +
                    TextBoxLinkRazdel6.Text + "|" +
                    TextBoxIMGLinkRazdel6.Text + "|" +

                    TextBoxNazvanijeRazdel7.Text + "|" +
                    TextBoxLinkRazdel7.Text + "|" +
                    TextBoxIMGLinkRazdel7.Text + "|" +

                    TextBoxNazvanijeRazdel8.Text + "|" +
                    TextBoxLinkRazdel8.Text + "|" +
                    TextBoxIMGLinkRazdel8.Text + "|" +

                    TextBoxNazvanijeRazdel9.Text + "|" +
                    TextBoxLinkRazdel9.Text + "|" +
                    TextBoxIMGLinkRazdel9.Text + "|" +

                    TextBoxNazvanijeRazdel10.Text + "|" +
                    TextBoxLinkRazdel10.Text + "|" +
                    TextBoxIMGLinkRazdel10.Text + "|" +

                    TextBoxNazvanijeRazdel11.Text + "|" +
                    TextBoxLinkRazdel11.Text + "|" +
                    TextBoxIMGLinkRazdel11.Text + "|" +

                    TextBoxNazvanijeRazdel12.Text + "|" +
                    TextBoxLinkRazdel12.Text + "|" +
                    TextBoxIMGLinkRazdel12.Text + "|" +
                    TextBoxZagolovokPage.Text + "|" +
                    TextBoxKeywords.Text + "|" +
                    TextBoxMetaDescription.Text + "|" + TextBoxFont.Text + "|" +
                    TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|" +TextBoxSTYLE.Text+"|"+TextBoxSTYLEButton.Text+"|"+TextBoxCUSTOMCSS.Text+"|");






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

                    this.StatusFile.Text = "Файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных страницы \"КАТАЛОГ ТОВАРОВ\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных страницы \"КАТАЛОГ ТОВАРОВ\" была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла данных страницы \"КАТАЛОГ ТОВАРОВ\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<?php require('header.tpl');?><title>" + TextBoxZagolovokPage.Text + "</title>\r\n<meta name=\"keywords\" content=\"" + TextBoxKeywords.Text + "\">\r\n<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

            if (TextBoxCUSTOMCSS.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "<style>" + TextBoxSTYLE.Text+"</style>\r\n</head><body style=\"font-family:" + TextBoxFont.Text + ";\"><?php require('navigation.tpl'); ?>");
            await FileIO.AppendTextAsync(UPLOADFile, "<!--ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><div class=\"container\" style=\"margin-top:92px;\"><p><a href=\"index.php\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">На главную</a></p><h3 style=\"color:" + TextBoxZagolovokColor.Text + ";\">" + TextBoxNazvanijeKataloga.Text + "</h3>");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"row\" style=\"margin-top:40px;\">");

            if (TextBoxNazvanijeRazdel1.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel1.Text + "\" alt=\"" + TextBoxNazvanijeRazdel1.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel1.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel1.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel2.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel2.Text + "\" alt=\"" + TextBoxNazvanijeRazdel2.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel2.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel2.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel3.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel3.Text + "\" alt=\"" + TextBoxNazvanijeRazdel3.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel3.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel3.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel4.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel4.Text + "\" alt=\"" + TextBoxNazvanijeRazdel4.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel4.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel4.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            await FileIO.AppendTextAsync(UPLOADFile, "</div><!--/.row--><div class=\"row\" style=\"margin-top:20px;\">");


            if (TextBoxNazvanijeRazdel5.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel5.Text + "\" alt=\"" + TextBoxNazvanijeRazdel5.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel5.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel5.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel6.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel6.Text + "\" alt=\"" + TextBoxNazvanijeRazdel6.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel6.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel6.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel7.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel7.Text + "\" alt=\"" + TextBoxNazvanijeRazdel7.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel7.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel7.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel8.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel8.Text + "\" alt=\"" + TextBoxNazvanijeRazdel8.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel8.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel8.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            await FileIO.AppendTextAsync(UPLOADFile, "</div><!--/.row--><div class=\"row\" style=\"margin-top:20px;\">");


            if (TextBoxNazvanijeRazdel9.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel9.Text + "\" alt=\"" + TextBoxNazvanijeRazdel9.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel9.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel9.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel10.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel10.Text + "\" alt=\"" + TextBoxNazvanijeRazdel10.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel10.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel10.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel11.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel11.Text + "\" alt=\"" + TextBoxNazvanijeRazdel11.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel11.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel11.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }


            if (TextBoxNazvanijeRazdel12.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"catalog-image\"><img class=\"img-responsive\" style=\"align:middle; height:180px;\" align=\"center\" src=\"" + TextBoxIMGLinkRazdel12.Text + "\" alt=\"" + TextBoxNazvanijeRazdel12.Text + "\"></div><div class=\"catalog-text\"><h4 style=\"text-align:center;\">" + TextBoxNazvanijeRazdel12.Text + "</h4><p style=\"text-align:center;\"><a class=\"btn btn-default\" href=\"" + TextBoxLinkRazdel12.Text + "\" role =\"button\" style=\""+TextBoxSTYLEButton.Text+"\">Перейти в каталог &raquo;</a></p></div></div><!-- /.col-lg-4 -->");
            }



            await FileIO.AppendTextAsync(UPLOADFile, "</div><!--/.row--></div><!-- /.container marketing --><!-- КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ --><?php require('footer.tpl'); ?><?php require('footerscripts.tpl'); ?>");


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
