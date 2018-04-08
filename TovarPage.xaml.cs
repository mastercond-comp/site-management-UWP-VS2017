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
    public sealed partial class TovarPage : Page
    {
        public TovarPage()
        {
            this.InitializeComponent();
        }

        private async void LoadFileTovar_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
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
                    TextBoxFont.Text = line.Split('|')[3];
                    TextBoxZagolovokColor.Text = line.Split('|')[4];
                    TextBoxKategoriiTextColor.Text = line.Split('|')[5];
                    TextBoxButtonTextColor.Text = line.Split('|')[6];
                    TextBoxBackgroundColor.Text = line.Split('|')[7];
                    TextBoxNavigationTextColor.Text = line.Split('|')[8];
                    TextBoxNazvanijeTovara.Text = line.Split('|')[9];
                    TextBoxModelTovara.Text = line.Split('|')[10];
                    TextBoxCenaTovara.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { RadioButtonRub.IsChecked = true; }
                    if (t == "1") { RadioButtonDollar.IsChecked = true; }
                    if (t == "2") { RadioButtonEuro.IsChecked = true; }

                    TextBoxNazvanieChTovar1.Text = line.Split('|')[13];
                    TextBoxChTovar1.Text = line.Split('|')[14];

                    TextBoxNazvanieChTovar2.Text = line.Split('|')[15];
                    TextBoxChTovar2.Text = line.Split('|')[16];

                    TextBoxNazvanieChTovar3.Text = line.Split('|')[17];
                    TextBoxChTovar3.Text = line.Split('|')[18];

                    TextBoxNazvanieChTovar4.Text = line.Split('|')[19];
                    TextBoxChTovar4.Text = line.Split('|')[20];

                    TextBoxNazvanieChTovar5.Text = line.Split('|')[21];
                    TextBoxChTovar5.Text = line.Split('|')[22];

                    TextBoxNazvanieChTovar6.Text = line.Split('|')[23];
                    TextBoxChTovar6.Text = line.Split('|')[24];

                    TextBoxNazvanieChTovar7.Text = line.Split('|')[25];
                    TextBoxChTovar7.Text = line.Split('|')[26];

                    TextBoxNazvanieChTovar8.Text = line.Split('|')[27];
                    TextBoxChTovar8.Text = line.Split('|')[28];

                    TextBoxNazvanieChTovar9.Text = line.Split('|')[29];
                    TextBoxChTovar9.Text = line.Split('|')[30];

                    TextBoxNazvanieChTovar10.Text = line.Split('|')[31];
                    TextBoxChTovar10.Text = line.Split('|')[32];

                    TextBoxNazvanieChTovar11.Text = line.Split('|')[33];
                    TextBoxChTovar11.Text = line.Split('|')[34];

                    TextBoxNazvanieChTovar12.Text = line.Split('|')[35];
                    TextBoxChTovar12.Text = line.Split('|')[36];

                    TextBoxNazvanieChTovar13.Text = line.Split('|')[37];
                    TextBoxChTovar13.Text = line.Split('|')[38];

                    TextBoxNazvanieChTovar14.Text = line.Split('|')[39];
                    TextBoxChTovar14.Text = line.Split('|')[40];

                    TextBoxNazvanieChTovar15.Text = line.Split('|')[41];
                    TextBoxChTovar15.Text = line.Split('|')[42];

                    TextBoxNazvanieChTovar16.Text = line.Split('|')[43];
                    TextBoxChTovar16.Text = line.Split('|')[44];

                    TextBoxNazvanieChTovar17.Text = line.Split('|')[45];
                    TextBoxChTovar17.Text = line.Split('|')[46];

                    TextBoxNazvanieChTovar18.Text = line.Split('|')[47];
                    TextBoxChTovar18.Text = line.Split('|')[48];

                    TextBoxNazvanieChTovar19.Text = line.Split('|')[49];
                    TextBoxChTovar19.Text = line.Split('|')[50];

                    TextBoxNazvanieChTovar20.Text = line.Split('|')[51];
                    TextBoxChTovar20.Text = line.Split('|')[52];

                    TextBoxLinkIMG1.Text = line.Split('|')[53];
                    TextBoxLinkIMG2.Text = line.Split('|')[54];
                    TextBoxLinkIMG3.Text = line.Split('|')[55];
                    TextBoxLinkIMG4.Text = line.Split('|')[56];
                    TextBoxLinkIMG5.Text = line.Split('|')[57];
                    TextBoxLinkVideo.Text = line.Split('|')[58];

                    TextBoxFTPServer.Text = line.Split('|')[59];
                    TextBoxFTPUser.Text = line.Split('|')[60];
                    TextBoxFTPPass.Password = line.Split('|')[61];

                    TextBoxNavigationLevel1.Text = line.Split('|')[62];
                    TextBoxNavigationLevel1Link.Text = line.Split('|')[63];
                    TextBoxNavigationLevel2.Text = line.Split('|')[64];
                    TextBoxNavigationLevel2Link.Text = line.Split('|')[65];
                    TextBoxNavigationLevel3.Text = line.Split('|')[66];
                    TextBoxNavigationLevel3Link.Text = line.Split('|')[67];

                    TextBoxTovarShortDescription.Text = line.Split('|')[68];
                    TextBoxFontBody.Text = line.Split('|')[69];
                    TextBoxLinkTovar.Text = line.Split('|')[70];

                    try { TextBoxCUSTOMCSS.Text = line.Split('|')[71]; }
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

        private async void SaveFileTovar_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл данных страницы \"ТОВАР\"", new List<string>() { ".tovar" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "tovar1";
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
                TextBoxKeywords.Text + "|" +
                TextBoxMetaDescription.Text + "|" +
                TextBoxFont.Text + "|" +
                TextBoxZagolovokColor.Text + "|" +
                TextBoxKategoriiTextColor.Text + "|" +
                TextBoxButtonTextColor.Text + "|" +
                TextBoxBackgroundColor.Text + "|" +
                TextBoxNavigationTextColor.Text + "|" +
                TextBoxNazvanijeTovara.Text + "|" +
                TextBoxModelTovara.Text + "|" +
                TextBoxCenaTovara.Text + "|");

                if (RadioButtonRub.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (RadioButtonDollar.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (RadioButtonEuro.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxNazvanieChTovar1.Text + "|" +
                TextBoxChTovar1.Text + "|" +

                TextBoxNazvanieChTovar2.Text + "|" +
                TextBoxChTovar2.Text + "|" +

                TextBoxNazvanieChTovar3.Text + "|" +
                TextBoxChTovar3.Text + "|" +

                TextBoxNazvanieChTovar4.Text + "|" +
                TextBoxChTovar4.Text + "|" +

                TextBoxNazvanieChTovar5.Text + "|" +
                TextBoxChTovar5.Text + "|" +

                TextBoxNazvanieChTovar6.Text + "|" +
                TextBoxChTovar6.Text + "|" +

                TextBoxNazvanieChTovar7.Text + "|" +
                TextBoxChTovar7.Text + "|" +

                TextBoxNazvanieChTovar8.Text + "|" +
                TextBoxChTovar8.Text + "|" +

                TextBoxNazvanieChTovar9.Text + "|" +
                TextBoxChTovar9.Text + "|" +

                TextBoxNazvanieChTovar10.Text + "|" +
                TextBoxChTovar10.Text + "|" +

                TextBoxNazvanieChTovar11.Text + "|" +
                TextBoxChTovar11.Text + "|" +

                TextBoxNazvanieChTovar12.Text + "|" +
                TextBoxChTovar12.Text + "|" +

                TextBoxNazvanieChTovar13.Text + "|" +
                TextBoxChTovar13.Text + "|" +

                TextBoxNazvanieChTovar14.Text + "|" +
                TextBoxChTovar14.Text + "|" +

                TextBoxNazvanieChTovar15.Text + "|" +
                TextBoxChTovar15.Text + "|" +

                TextBoxNazvanieChTovar16.Text + "|" +
                TextBoxChTovar16.Text + "|" +

                TextBoxNazvanieChTovar17.Text + "|" +
                TextBoxChTovar17.Text + "|" +

                TextBoxNazvanieChTovar18.Text + "|" +
                TextBoxChTovar18.Text + "|" +

                TextBoxNazvanieChTovar19.Text + "|" +
                TextBoxChTovar19.Text + "|" +

                TextBoxNazvanieChTovar20.Text + "|" +
                TextBoxChTovar20.Text + "|" +

                TextBoxLinkIMG1.Text + "|" +
                TextBoxLinkIMG2.Text + "|" +
                TextBoxLinkIMG3.Text + "|" +
                TextBoxLinkIMG4.Text + "|" +
                TextBoxLinkIMG5.Text + "|" +
                TextBoxLinkVideo.Text + "|" +

                TextBoxFTPServer.Text + "|" +
                TextBoxFTPUser.Text + "|" +
                TextBoxFTPPass.Password + "|" +
                TextBoxNavigationLevel1.Text + "|" +
                TextBoxNavigationLevel1Link.Text + "|" +
                TextBoxNavigationLevel2.Text + "|" +
                TextBoxNavigationLevel2Link.Text + "|" +
                TextBoxNavigationLevel3.Text + "|" +
                TextBoxNavigationLevel3Link.Text + "|" + TextBoxTovarShortDescription.Text + "|"+TextBoxFontBody.Text + "|"+ TextBoxLinkTovar.Text + "|"
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


                    this.StatusFile.Text = "Файл данных страницы \"ТОВАР\" " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл данных страницы \"ТОВАР\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных страницы \"ТОВАР\" " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных страницы \"ТОВАР\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных страницы \"ТОВАР\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла данных страницы \"ТОВАР\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }


        private async void SaveFileTovarPHP_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("PHP файл страницы \"ТОВАР\"", new List<string>() { ".php" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "tovar1";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<?php \r\n");
                await FileIO.AppendTextAsync(Myfile4, "$name=\"" + TextBoxNazvanijeTovara.Text + "\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$model=\"" + TextBoxModelTovara.Text + "\";\r\n");
                await FileIO.AppendTextAsync(Myfile4, "$price=\"" + TextBoxCenaTovara.Text + "\";\r\n?>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/header.tpl\"; ?>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<title>" + TextBoxZagolovokPage.Text + "</title>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

                if (TextBoxCUSTOMCSS.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4, "<meta name=\"keywords\" content=\""+TextBoxKeywords.Text+"\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\"></head>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<body style=\"font-family:"+TextBoxFontBody.Text+";\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/navigation.tpl\"; ?>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<!-- СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА--><?php $file1=$_SERVER['DOCUMENT_ROOT'].\"/dollar.ini\"; $fd1=fopen($file1,\"r\"); $dollar=fgets($fd1,6); fclose ($fd1); $file2=$_SERVER['DOCUMENT_ROOT'].\"/euro.ini\"; $fd2=fopen($file2,\"r\"); $euro=fgets($fd2,6); fclose ($fd2); ?>\r\n<!-- КОНЕЦ СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-->\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<!--ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><div class=\"container\" style=\"margin-top:92px;\"><p><a href=\"index.php\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">Главная</a>\r\n");
                if (TextBoxNavigationLevel1.Text.Length !=0) { await FileIO.AppendTextAsync(Myfile4, " -> <a href=\""+TextBoxNavigationLevel1Link.Text+ "\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">"+TextBoxNavigationLevel1.Text+ "</a>\r\n"); }
                if (TextBoxNavigationLevel2.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, " -> <a href=\"" + TextBoxNavigationLevel2Link.Text + "\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">" + TextBoxNavigationLevel2.Text + "</a>\r\n"); }
                if (TextBoxNavigationLevel3.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, " -> <a href=\"" + TextBoxNavigationLevel3Link.Text + "\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">" + TextBoxNavigationLevel3.Text + "</a>\r\n"); }
                await FileIO.AppendTextAsync(Myfile4, "</p><div class=\"row featurette\" style=\"margin-top:20px;\"><div class=\"col-md-7 col-md-push-5\"><h3 class=\"featurette-heading\" style=\"color:" + TextBoxZagolovokColor.Text + ";\">" + TextBoxNazvanijeTovara.Text + "<br><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit;\">" + TextBoxModelTovara.Text + "</span></h3>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<p class=\"lead\">"+TextBoxTovarShortDescription.Text+"</p>");
                await FileIO.AppendTextAsync(Myfile4, "<p class=\"lead\">Цена: <span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:bold; color:" + TextBoxButtonTextColor.Text + ";\">\r\n");
                if (RadioButtonRub.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<?php echo $price; ?></span> рублей</p>"); }
                if (RadioButtonDollar.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<?php echo ceil($price*$dollar); ?></span> рублей</p>\r\n"); }
                if (RadioButtonEuro.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<?php echo ceil($price*$euro); ?></span> рублей</p>\r\n"); }

                if (RadioButtonRub.IsChecked == false) {await FileIO.AppendTextAsync(Myfile4, "<p>Внимание! Цены на товары меняются ежедневно в зависимости от курса доллара/евро ЦБ РФ</p>\r\n"); }

                await FileIO.AppendTextAsync(Myfile4, "<hr><h4>Характеристики:</h4><br><table class=\"table table-striped\">\r\n");

                if (TextBoxNazvanieChTovar1.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar1.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar1.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar2.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar2.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar2.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar3.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar3.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar3.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar4.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar4.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar4.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar5.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar5.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar5.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar6.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar6.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar6.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar7.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar7.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar7.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar8.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar8.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar8.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar9.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar9.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar9.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar10.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar10.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar10.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar11.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar11.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar11.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar12.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar12.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar12.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar13.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar13.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar13.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar14.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar14.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar14.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar15.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar15.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar15.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar16.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar16.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar16.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar17.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar17.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar17.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar18.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar18.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar18.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar19.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar19.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar19.Text + "</span></p></td></tr>\r\n"); }
                if (TextBoxNazvanieChTovar20.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<tr><td><p>" + TextBoxNazvanieChTovar20.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar20.Text + "</span></p></td></tr>\r\n"); }

                await FileIO.AppendTextAsync(Myfile4, "</table></div><div class=\"col-md-5 col-md-pull-7\">");

                if (TextBoxLinkIMG1.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<img class=\"featurette-image img-responsive center-block\" src=\""+TextBoxLinkIMG1.Text+"\" alt=\""+TextBoxNazvanijeTovara.Text+"\"><br>\r\n"); }
                if (TextBoxLinkIMG2.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG2.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
                if (TextBoxLinkIMG3.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG3.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
                if (TextBoxLinkIMG4.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG4.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
                if (TextBoxLinkIMG5.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG5.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
                if (TextBoxLinkVideo.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<video class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkVideo.Text + "\" controls alt=\"" + TextBoxNazvanijeTovara.Text + "\"></video><br>\r\n"); }

                await FileIO.AppendTextAsync(Myfile4, "</div></div></div><!--КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><?php require $_SERVER['DOCUMENT_ROOT'].\"/footer.tpl\"; ?><?php require $_SERVER['DOCUMENT_ROOT'].\"/footerscripts.tpl\"; ?>\r\n");


                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "PHP файл страницы \"ТОВАР\" " + Myfile4.Name + " успешно экспортирован.";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");


                    FileTextBox.Text = text2;
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("PHP файл страницы \"ТОВАР\" " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить PHP-файл страницы \"ТОВАР\" " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить PHP-файл страницы \"ТОВАР\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи PHP-файла страницы \"ТОВАР\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи PHP-файла страницы \"ТОВАР\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
            Progress.IsActive = false;
        }


        private void FTPFileTovarPHP_Click(object sender, RoutedEventArgs e)
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
            savePicker4.FileTypeChoices.Add("Файл данных страницы \"ТОВАР\"", new List<string>() { ".tovar" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "tovar1";
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
                TextBoxKeywords.Text + "|" +
                TextBoxMetaDescription.Text + "|" +
                TextBoxFont.Text + "|" +
                TextBoxZagolovokColor.Text + "|" +
                TextBoxKategoriiTextColor.Text + "|" +
                TextBoxButtonTextColor.Text + "|" +
                TextBoxBackgroundColor.Text + "|" +
                TextBoxNavigationTextColor.Text + "|" +
                TextBoxNazvanijeTovara.Text + "|" +
                TextBoxModelTovara.Text + "|" +
                TextBoxCenaTovara.Text + "|");

                if (RadioButtonRub.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (RadioButtonDollar.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (RadioButtonEuro.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxNazvanieChTovar1.Text + "|" +
                TextBoxChTovar1.Text + "|" +

                TextBoxNazvanieChTovar2.Text + "|" +
                TextBoxChTovar2.Text + "|" +

                TextBoxNazvanieChTovar3.Text + "|" +
                TextBoxChTovar3.Text + "|" +

                TextBoxNazvanieChTovar4.Text + "|" +
                TextBoxChTovar4.Text + "|" +

                TextBoxNazvanieChTovar5.Text + "|" +
                TextBoxChTovar5.Text + "|" +

                TextBoxNazvanieChTovar6.Text + "|" +
                TextBoxChTovar6.Text + "|" +

                TextBoxNazvanieChTovar7.Text + "|" +
                TextBoxChTovar7.Text + "|" +

                TextBoxNazvanieChTovar8.Text + "|" +
                TextBoxChTovar8.Text + "|" +

                TextBoxNazvanieChTovar9.Text + "|" +
                TextBoxChTovar9.Text + "|" +

                TextBoxNazvanieChTovar10.Text + "|" +
                TextBoxChTovar10.Text + "|" +

                TextBoxNazvanieChTovar11.Text + "|" +
                TextBoxChTovar11.Text + "|" +

                TextBoxNazvanieChTovar12.Text + "|" +
                TextBoxChTovar12.Text + "|" +

                TextBoxNazvanieChTovar13.Text + "|" +
                TextBoxChTovar13.Text + "|" +

                TextBoxNazvanieChTovar14.Text + "|" +
                TextBoxChTovar14.Text + "|" +

                TextBoxNazvanieChTovar15.Text + "|" +
                TextBoxChTovar15.Text + "|" +

                TextBoxNazvanieChTovar16.Text + "|" +
                TextBoxChTovar16.Text + "|" +

                TextBoxNazvanieChTovar17.Text + "|" +
                TextBoxChTovar17.Text + "|" +

                TextBoxNazvanieChTovar18.Text + "|" +
                TextBoxChTovar18.Text + "|" +

                TextBoxNazvanieChTovar19.Text + "|" +
                TextBoxChTovar19.Text + "|" +

                TextBoxNazvanieChTovar20.Text + "|" +
                TextBoxChTovar20.Text + "|" +

                TextBoxLinkIMG1.Text + "|" +
                TextBoxLinkIMG2.Text + "|" +
                TextBoxLinkIMG3.Text + "|" +
                TextBoxLinkIMG4.Text + "|" +
                TextBoxLinkIMG5.Text + "|" +
                TextBoxLinkVideo.Text + "|" +

                TextBoxFTPServer.Text + "|" +
                TextBoxFTPUser.Text + "|" +
                TextBoxFTPPass.Password + "|" +
                TextBoxNavigationLevel1.Text + "|" +
                TextBoxNavigationLevel1Link.Text + "|" +
                TextBoxNavigationLevel2.Text + "|" +
                TextBoxNavigationLevel2Link.Text + "|" +
                TextBoxNavigationLevel3.Text + "|" +
                TextBoxNavigationLevel3Link.Text + "|" + TextBoxTovarShortDescription.Text + "|" + TextBoxFontBody.Text + "|" + TextBoxLinkTovar.Text + "|"
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


                    this.StatusFile.Text = "Файл данных страницы \"ТОВАР\" " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл данных страницы \"ТОВАР\" " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных страницы \"ТОВАР\" " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл данных страницы \"ТОВАР\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных страницы \"ТОВАР\" была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла данных страницы \"ТОВАР\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<?php \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$name=\"" + TextBoxNazvanijeTovara.Text + "\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$model=\"" + TextBoxModelTovara.Text + "\";\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "$price=\"" + TextBoxCenaTovara.Text + "\";\r\n?>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/header.tpl\"; ?>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<title>" + TextBoxZagolovokPage.Text + "</title>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

            if (TextBoxCUSTOMCSS.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "<meta name=\"keywords\" content=\"" + TextBoxKeywords.Text + "\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\"></head>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<body style=\"font-family:" + TextBoxFontBody.Text + ";\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/navigation.tpl\"; ?>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<!-- СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА--><?php $file1=$_SERVER['DOCUMENT_ROOT'].\"/dollar.ini\"; $fd1=fopen($file1,\"r\"); $dollar=fgets($fd1,6); fclose ($fd1); $file2=$_SERVER['DOCUMENT_ROOT'].\"/euro.ini\"; $fd2=fopen($file2,\"r\"); $euro=fgets($fd2,6); fclose ($fd2); ?>\r\n<!-- КОНЕЦ СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-->\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<!--ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><div class=\"container\" style=\"margin-top:92px;\"><p><a href=\"index.php\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">Главная</a>\r\n");
            if (TextBoxNavigationLevel1.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, " -> <a href=\"" + TextBoxNavigationLevel1Link.Text + "\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">" + TextBoxNavigationLevel1.Text + "</a>\r\n"); }
            if (TextBoxNavigationLevel2.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, " -> <a href=\"" + TextBoxNavigationLevel2Link.Text + "\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">" + TextBoxNavigationLevel2.Text + "</a>\r\n"); }
            if (TextBoxNavigationLevel3.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, " -> <a href=\"" + TextBoxNavigationLevel3Link.Text + "\" style=\"color:" + TextBoxNavigationTextColor.Text + ";\">" + TextBoxNavigationLevel3.Text + "</a>\r\n"); }
            await FileIO.AppendTextAsync(UPLOADFile, "</p><div class=\"row featurette\" style=\"margin-top:20px;\"><div class=\"col-md-7 col-md-push-5\"><h3 class=\"featurette-heading\" style=\"color:" + TextBoxZagolovokColor.Text + ";\">" + TextBoxNazvanijeTovara.Text + "<br><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit;\">" + TextBoxModelTovara.Text + "</span></h3>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"lead\">" + TextBoxTovarShortDescription.Text + "</p>");
            await FileIO.AppendTextAsync(UPLOADFile, "<p class=\"lead\">Цена: <span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:bold; color:" + TextBoxButtonTextColor.Text + ";\">\r\n");
            if (RadioButtonRub.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php echo $price; ?></span> рублей</p>"); }
            if (RadioButtonDollar.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php echo ceil($price*$dollar); ?></span> рублей</p>\r\n"); }
            if (RadioButtonEuro.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php echo ceil($price*$euro); ?></span> рублей</p>\r\n"); }

            if (RadioButtonRub.IsChecked == false) { await FileIO.AppendTextAsync(UPLOADFile, "<p>Внимание! Цены на товары меняются ежедневно в зависимости от курса доллара/евро ЦБ РФ</p>\r\n"); }

            await FileIO.AppendTextAsync(UPLOADFile, "<hr><h4>Характеристики:</h4><br><table class=\"table table-striped\">\r\n");

            if (TextBoxNazvanieChTovar1.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar1.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar1.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar2.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar2.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar2.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar3.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar3.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar3.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar4.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar4.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar4.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar5.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar5.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar5.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar6.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar6.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar6.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar7.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar7.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar7.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar8.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar8.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar8.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar9.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar9.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar9.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar10.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar10.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar10.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar11.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar11.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar11.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar12.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar12.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar12.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar13.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar13.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar13.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar14.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar14.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar14.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar15.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar15.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar15.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar16.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar16.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar16.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar17.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar17.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar17.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar18.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar18.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar18.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar19.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar19.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar19.Text + "</span></p></td></tr>\r\n"); }
            if (TextBoxNazvanieChTovar20.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<tr><td><p>" + TextBoxNazvanieChTovar20.Text + "</p></td><td><p><span style=\"font-family:" + TextBoxFont.Text + "; font-size:inherit; font-weight:normal;\">" + TextBoxChTovar20.Text + "</span></p></td></tr>\r\n"); }

            await FileIO.AppendTextAsync(UPLOADFile, "</table></div><div class=\"col-md-5 col-md-pull-7\">");

            if (TextBoxLinkIMG1.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG1.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
            if (TextBoxLinkIMG2.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG2.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
            if (TextBoxLinkIMG3.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG3.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
            if (TextBoxLinkIMG4.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG4.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
            if (TextBoxLinkIMG5.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<img class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkIMG5.Text + "\" alt=\"" + TextBoxNazvanijeTovara.Text + "\"><br>\r\n"); }
            if (TextBoxLinkVideo.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<video class=\"featurette-image img-responsive center-block\" src=\"" + TextBoxLinkVideo.Text + "\" controls alt=\"" + TextBoxNazvanijeTovara.Text + "\"></video><br>\r\n"); }

            await FileIO.AppendTextAsync(UPLOADFile, "</div></div></div><!--КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ--><?php require $_SERVER['DOCUMENT_ROOT'].\"/footer.tpl\"; ?><?php require $_SERVER['DOCUMENT_ROOT'].\"/footerscripts.tpl\"; ?>\r\n");

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
