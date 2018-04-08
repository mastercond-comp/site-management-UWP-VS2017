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
    public sealed partial class RootTovarPage : Page
    {
        public RootTovarPage()
        {
            this.InitializeComponent();
        }

        private async void LoadFileIndexTovari_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".indextovar");
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
                    TextBoxTovariTextColor.Text = line.Split('|')[1];
                    TextBoxTovariShrift.Text = line.Split('|')[2];

                    TextBoxNaimenovanieTovara1.Text = line.Split('|')[3];
                    TextBoxImageTovara1.Text = line.Split('|')[4];
                    TextBoxNaimenovanieModeli1.Text = line.Split('|')[5];
                    TextBoxOpisanieModeli1.Text = line.Split('|')[6];
                    TextBoxCenaModeli1.Text = line.Split('|')[7];
                    string valutaTovar1 = line.Split('|')[8];
                    if (valutaTovar1 == "0") { radioButtonTovar1RUB.IsChecked = true; }
                    if (valutaTovar1 == "1") { radioButtonTovar1DOLLAR.IsChecked = true; }
                    if (valutaTovar1 == "2") { radioButtonTovar1EURO.IsChecked = true; }
                    TextBoxLinkTovar1.Text = line.Split('|')[9];



                    TextBoxNaimenovanieTovar2.Text = line.Split('|')[10];
                    TextBoxImageTovar2.Text = line.Split('|')[11];
                    TextBoxNaimenovanieModeliTovar2.Text = line.Split('|')[12];
                    TextBoxOpisanieModeliTovar2.Text = line.Split('|')[13];
                    TextBoxCenaModeliTovar2.Text = line.Split('|')[14];
                    string valutaTovar2 = line.Split('|')[15];
                    if (valutaTovar2 == "0") { radioButtonTovar2RUB.IsChecked = true; }
                    if (valutaTovar2 == "1") { radioButtonTovar2DOLLAR.IsChecked = true; }
                    if (valutaTovar2 == "2") { radioButtonTovar2EURO.IsChecked = true; }
                    TextBoxLinkTovar2.Text = line.Split('|')[16];

                    TextBoxNaimenovanieTovar3.Text = line.Split('|')[17];
                    TextBoxImageTovar3.Text = line.Split('|')[18];
                    TextBoxNaimenovanieModeliTovar3.Text = line.Split('|')[19];
                    TextBoxOpisanieModeliTovar3.Text = line.Split('|')[20];
                    TextBoxCenaModeliTovar3.Text = line.Split('|')[21];
                    string valutaTovar3 = line.Split('|')[22];
                    if (valutaTovar3 == "0") { radioButtonTovar3RUB.IsChecked = true; }
                    if (valutaTovar3 == "1") { radioButtonTovar3DOLLAR.IsChecked = true; }
                    if (valutaTovar3 == "2") { radioButtonTovar3EURO.IsChecked = true; }
                    TextBoxLinkTovar3.Text = line.Split('|')[23];

                    TextBoxNaimenovanieTovar4.Text = line.Split('|')[24];
                    TextBoxImageTovar4.Text = line.Split('|')[25];
                    TextBoxNaimenovanieModeliTovar4.Text = line.Split('|')[26];
                    TextBoxOpisanieModeliTovar4.Text = line.Split('|')[27];
                    TextBoxCenaModeliTovar4.Text = line.Split('|')[28];
                    string valutaTovar4 = line.Split('|')[29];
                    if (valutaTovar4 == "0") { radioButtonTovar4RUB.IsChecked = true; }
                    if (valutaTovar4 == "1") { radioButtonTovar4DOLLAR.IsChecked = true; }
                    if (valutaTovar4 == "2") { radioButtonTovar4EURO.IsChecked = true; }
                    TextBoxLinkTovar4.Text = line.Split('|')[30];

                    TextBoxNaimenovanieTovar5.Text = line.Split('|')[31];
                    TextBoxImageTovar5.Text = line.Split('|')[32];
                    TextBoxNaimenovanieModeliTovar5.Text = line.Split('|')[33];
                    TextBoxOpisanieModeliTovar5.Text = line.Split('|')[34];
                    TextBoxCenaModeliTovar5.Text = line.Split('|')[35];
                    string valutaTovar5 = line.Split('|')[36];
                    if (valutaTovar5 == "0") { radioButtonTovar5RUB.IsChecked = true; }
                    if (valutaTovar5 == "1") { radioButtonTovar5DOLLAR.IsChecked = true; }
                    if (valutaTovar5 == "2") { radioButtonTovar5EURO.IsChecked = true; }
                    TextBoxLinkTovar5.Text = line.Split('|')[37];


                    TextBoxNaimenovanieTovar6.Text = line.Split('|')[38];
                    TextBoxImageTovar6.Text = line.Split('|')[39];
                    TextBoxNaimenovanieModeliTovar6.Text = line.Split('|')[40];
                    TextBoxOpisanieModeliTovar6.Text = line.Split('|')[41];
                    TextBoxCenaModeliTovar6.Text = line.Split('|')[42];
                    string valutaTovar6 = line.Split('|')[43];
                    if (valutaTovar6 == "0") { radioButtonTovar6RUB.IsChecked = true; }
                    if (valutaTovar6 == "1") { radioButtonTovar6DOLLAR.IsChecked = true; }
                    if (valutaTovar6 == "2") { radioButtonTovar6EURO.IsChecked = true; }
                    TextBoxLinkTovar6.Text = line.Split('|')[44];

                    TextBoxNaimenovanieTovar7.Text = line.Split('|')[45];
                    TextBoxImageTovar7.Text = line.Split('|')[46];
                    TextBoxNaimenovanieModeliTovar7.Text = line.Split('|')[47];
                    TextBoxOpisanieModeliTovar7.Text = line.Split('|')[48];
                    TextBoxCenaModeliTovar7.Text = line.Split('|')[49];
                    string valutaTovar7 = line.Split('|')[50];
                    if (valutaTovar7 == "0") { radioButtonTovar7RUB.IsChecked = true; }
                    if (valutaTovar7 == "1") { radioButtonTovar7DOLLAR.IsChecked = true; }
                    if (valutaTovar7 == "2") { radioButtonTovar7EURO.IsChecked = true; }
                    TextBoxLinkTovar7.Text = line.Split('|')[51];

                    TextBoxNaimenovanieTovar8.Text = line.Split('|')[52];
                    TextBoxImageTovar8.Text = line.Split('|')[53];
                    TextBoxNaimenovanieModeliTovar8.Text = line.Split('|')[54];
                    TextBoxOpisanieModeliTovar8.Text = line.Split('|')[55];
                    TextBoxCenaModeliTovar8.Text = line.Split('|')[56];
                    string valutaTovar8 = line.Split('|')[57];
                    if (valutaTovar8 == "0") { radioButtonTovar8RUB.IsChecked = true; }
                    if (valutaTovar8 == "1") { radioButtonTovar8DOLLAR.IsChecked = true; }
                    if (valutaTovar8 == "2") { radioButtonTovar8EURO.IsChecked = true; }
                    TextBoxLinkTovar8.Text = line.Split('|')[58];

                    TextBoxFTPServer.Text = line.Split('|')[59];
                    TextBoxFTPUser.Text = line.Split('|')[60];
                    TextBoxFTPPass.Password = line.Split('|')[61];

                    TextBoxModelCenaShrift.Text = line.Split('|')[62];

                    try { TextBoxSTYLEButton.Text = line.Split('|')[63]; }
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

        private async void SaveFileIndexTovari_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл модуля Товары на главной странице", new List<string>() { ".indextovar" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "tovari_index";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, TextBoxZagolovokColor.Text + "|" + TextBoxTovariTextColor.Text + "|" +
                                TextBoxTovariShrift.Text + "|" +
                                
                                TextBoxNaimenovanieTovara1.Text + "|" +
                                TextBoxImageTovara1.Text + "|" +
                                TextBoxNaimenovanieModeli1.Text + "|" +
                                TextBoxOpisanieModeli1.Text + "|" +
                                TextBoxCenaModeli1.Text + "|");
                                if (radioButtonTovar1RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar1DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar1EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar1.Text + "|" +
                                
                                TextBoxNaimenovanieTovar2.Text + "|" +
                                TextBoxImageTovar2.Text + "|" +
                                TextBoxNaimenovanieModeliTovar2.Text + "|" +
                                TextBoxOpisanieModeliTovar2.Text + "|" +
                                TextBoxCenaModeliTovar2.Text + "|");
                                 if (radioButtonTovar2RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                 if (radioButtonTovar2DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                 if (radioButtonTovar2EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar2.Text + "|" +
                                
                                TextBoxNaimenovanieTovar3.Text + "|" +
                                TextBoxImageTovar3.Text + "|" +
                                TextBoxNaimenovanieModeliTovar3.Text + "|" +
                                TextBoxOpisanieModeliTovar3.Text + "|" +
                                TextBoxCenaModeliTovar3.Text + "|");
                                if (radioButtonTovar3RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar3DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar3EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar3.Text + "|" + TextBoxNaimenovanieTovar4.Text + "|" +
                                TextBoxImageTovar4.Text + "|" +
                                TextBoxNaimenovanieModeliTovar4.Text + "|" +
                                TextBoxOpisanieModeliTovar4.Text + "|" +
                                TextBoxCenaModeliTovar4.Text + "|");
                                if (radioButtonTovar4RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar4DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar4EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar4.Text + "|" + TextBoxNaimenovanieTovar5.Text + "|" +
                                TextBoxImageTovar5.Text + "|" +
                                TextBoxNaimenovanieModeliTovar5.Text + "|" +
                                TextBoxOpisanieModeliTovar5.Text + "|" +
                                TextBoxCenaModeliTovar5.Text + "|");
                                if (radioButtonTovar5RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar5DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar5EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar5.Text + "|" + TextBoxNaimenovanieTovar6.Text + "|" +
                               TextBoxImageTovar6.Text + "|" +
                               TextBoxNaimenovanieModeliTovar6.Text + "|" +
                               TextBoxOpisanieModeliTovar6.Text + "|" +
                               TextBoxCenaModeliTovar6.Text + "|");
                                if (radioButtonTovar6RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar6DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar6EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar6.Text + "|" + TextBoxNaimenovanieTovar7.Text + "|" +
                               TextBoxImageTovar7.Text + "|" +
                               TextBoxNaimenovanieModeliTovar7.Text + "|" +
                               TextBoxOpisanieModeliTovar7.Text + "|" +
                               TextBoxCenaModeliTovar7.Text + "|");
                                if (radioButtonTovar7RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar7DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar7EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar7.Text + "|" + TextBoxNaimenovanieTovar8.Text + "|" +
                              TextBoxImageTovar8.Text + "|" +
                              TextBoxNaimenovanieModeliTovar8.Text + "|" +
                              TextBoxOpisanieModeliTovar8.Text + "|" +
                              TextBoxCenaModeliTovar8.Text + "|");
                                if (radioButtonTovar8RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                                if (radioButtonTovar8DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                                if (radioButtonTovar8EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar8.Text + "|" +
                                TextBoxFTPServer.Text + "|" +
                                TextBoxFTPUser.Text + "|" +
                                TextBoxFTPPass.Password + "|"+TextBoxModelCenaShrift.Text + "|" + TextBoxSTYLEButton.Text + "|");

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

                    this.StatusFile.Text = "Файл модуля товаров на главной " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Файл модуля товаров на главной " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл модуля товаров на главной " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить файл модуля товаров на главной " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла модуля товаров была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи файла модуля товаров была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            Progress.IsActive = false;

        }

        private async void SaveFileIndexTovariTPL_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("TPL файл модуля \"ТОВАРЫ НА ГЛАВНОЙ\" ", new List<string>() { ".tpl" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "tovari_index";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, "<!--====================================== МОДУЛЬ ТОВАРЫ ========================================================--><!--СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-- ><?php $file1=\"dollar.ini\";$fd1=fopen($file1,\"r\");$dollar=fgets($fd1,6);fclose($fd1);$file2=\"euro.ini\";$fd2=fopen($file2,\"r\");$euro=fgets($fd2,6);fclose($fd2);?><!--КОНЕЦ СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-->\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\"><h3 style=\"color: "+TextBoxZagolovokColor.Text+ "\">ПОПУЛЯРНЫЕ ТОВАРЫ</h3><div class=\"row\" style=\"margin-top:20px;\">\r\n");

                if (TextBoxNaimenovanieTovara1.Text.Length != 0)
                {
                    if (radioButtonTovar1DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovara1.Text + "\" alt=\"" + TextBoxNaimenovanieTovara1.Text + " " + TextBoxNaimenovanieModeli1.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovara1.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeli1.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeli1.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeli1.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar1.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar1EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovara1.Text + "\" alt=\"" + TextBoxNaimenovanieTovara1.Text + " " + TextBoxNaimenovanieModeli1.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovara1.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeli1.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeli1.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeli1.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar1.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar1RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovara1.Text + "\" alt=\"" + TextBoxNaimenovanieTovara1.Text + " " + TextBoxNaimenovanieModeli1.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovara1.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeli1.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeli1.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeli1.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar1.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                }

                if (TextBoxNaimenovanieTovar2.Text.Length != 0)
                {
                    if (radioButtonTovar2DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar2.Text + "\" alt=\"" + TextBoxNaimenovanieTovar2.Text + " " + TextBoxNaimenovanieModeliTovar2.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar2.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar2.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar2.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar2.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar2.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar2EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar2.Text + "\" alt=\"" + TextBoxNaimenovanieTovar2.Text + " " + TextBoxNaimenovanieModeliTovar2.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar2.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar2.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar2.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar2.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar2.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar2RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar2.Text + "\" alt=\"" + TextBoxNaimenovanieTovar2.Text + " " + TextBoxNaimenovanieModeliTovar2.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar2.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar2.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar2.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar2.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar2.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }

                }

                if (TextBoxNaimenovanieTovar3.Text.Length != 0)
                {
                    if (radioButtonTovar3DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar3.Text + "\" alt=\"" + TextBoxNaimenovanieTovar3.Text + " " + TextBoxNaimenovanieModeliTovar3.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar3.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar3.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar3.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar3.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar3.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar3EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar3.Text + "\" alt=\"" + TextBoxNaimenovanieTovar3.Text + " " + TextBoxNaimenovanieModeliTovar3.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar3.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar3.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar3.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar3.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar3.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar3RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar3.Text + "\" alt=\"" + TextBoxNaimenovanieTovar3.Text + " " + TextBoxNaimenovanieModeliTovar3.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar3.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar3.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar3.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar3.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar3.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                }

                if (TextBoxNaimenovanieTovar4.Text.Length != 0)
                {
                    if (radioButtonTovar4DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar4.Text + "\" alt=\"" + TextBoxNaimenovanieTovar4.Text + " " + TextBoxNaimenovanieModeliTovar4.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar4.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar4.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar4.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar4.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar4.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar4EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar4.Text + "\" alt=\"" + TextBoxNaimenovanieTovar4.Text + " " + TextBoxNaimenovanieModeliTovar4.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar4.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar4.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar4.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar4.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar4.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar4RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar4.Text + "\" alt=\"" + TextBoxNaimenovanieTovar4.Text + " " + TextBoxNaimenovanieModeliTovar4.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar4.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar4.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar4.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar4.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar4.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                }


                await FileIO.AppendTextAsync(Myfile4, "</div><!-- /.row-->");



                if (TextBoxNaimenovanieTovar5.Text.Length != 0 | TextBoxNaimenovanieTovar6.Text.Length != 0 | TextBoxNaimenovanieTovar7.Text.Length != 0 | TextBoxNaimenovanieTovar8.Text.Length != 0)
                    {
                    await FileIO.AppendTextAsync(Myfile4, "<div class=\"row\" style=\"margin-top:20px;\">\r\n");

                    if (TextBoxNaimenovanieTovar5.Text.Length != 0)
                    {
                        if (radioButtonTovar5DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar5.Text + "\" alt=\"" + TextBoxNaimenovanieTovar5.Text + " " + TextBoxNaimenovanieModeliTovar5.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar5.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar5.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar5.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar5.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar5.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar5EURO.IsChecked == true)  { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar5.Text + "\" alt=\"" + TextBoxNaimenovanieTovar5.Text + " " + TextBoxNaimenovanieModeliTovar5.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar5.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar5.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar5.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar5.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar5.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar5RUB.IsChecked == true)  { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar5.Text + "\" alt=\"" + TextBoxNaimenovanieTovar5.Text + " " + TextBoxNaimenovanieModeliTovar5.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar5.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar5.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar5.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar5.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar5.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    }

                    if (TextBoxNaimenovanieTovar6.Text.Length != 0)
                    {
                        if (radioButtonTovar6DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar6.Text + "\" alt=\"" + TextBoxNaimenovanieTovar6.Text + " " + TextBoxNaimenovanieModeliTovar6.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar6.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar6.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar6.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar6.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar6.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar6EURO.IsChecked == true)  { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar6.Text + "\" alt=\"" + TextBoxNaimenovanieTovar6.Text + " " + TextBoxNaimenovanieModeliTovar6.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar6.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar6.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar6.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar6.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar6.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar6RUB.IsChecked == true)  { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar6.Text + "\" alt=\"" + TextBoxNaimenovanieTovar6.Text + " " + TextBoxNaimenovanieModeliTovar6.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar6.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar6.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar6.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar6.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar6.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    }

                    if (TextBoxNaimenovanieTovar7.Text.Length != 0)
                    {
                        if (radioButtonTovar7DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar7.Text + "\" alt=\"" + TextBoxNaimenovanieTovar7.Text + " " + TextBoxNaimenovanieModeliTovar7.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar7.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar7.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar7.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar7.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar7.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar7EURO.IsChecked == true)  { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar7.Text + "\" alt=\"" + TextBoxNaimenovanieTovar7.Text + " " + TextBoxNaimenovanieModeliTovar7.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar7.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar7.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar7.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar7.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar7.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar7RUB.IsChecked == true)  { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar7.Text + "\" alt=\"" + TextBoxNaimenovanieTovar7.Text + " " + TextBoxNaimenovanieModeliTovar7.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar7.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar7.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar7.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar7.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar7.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    }

                    if (TextBoxNaimenovanieTovar8.Text.Length != 0)
                    {
                        if (radioButtonTovar8DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar8.Text + "\" alt=\"" + TextBoxNaimenovanieTovar8.Text + " " + TextBoxNaimenovanieModeliTovar8.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar8.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar8.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar8.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar8.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar8.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar8EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar8.Text + "\" alt=\"" + TextBoxNaimenovanieTovar8.Text + " " + TextBoxNaimenovanieModeliTovar8.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar8.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar8.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar8.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar8.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar8.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                        if (radioButtonTovar8RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar8.Text + "\" alt=\"" + TextBoxNaimenovanieTovar8.Text + " " + TextBoxNaimenovanieModeliTovar8.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar8.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar8.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar8.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar8.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar8.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }

                    }


                    await FileIO.AppendTextAsync(Myfile4, "</div><!-- /.row-->");

                }
                await FileIO.AppendTextAsync(Myfile4, "</div><!-- /.container marketing--><!-- ====================================== КОНЕЦ МОДУЛЬ ТОВАРЫ======================================================== -->");

                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "TPL-файл модуля \"ТОВАРЫ НА ГЛАВНОЙ\" " + Myfile4.Name + " успешно экспортирован.";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;


                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("TPL-файл модуля \"ТОВАРЫ НА ГЛАВНОЙ\" " + Myfile4.Name + " успешно экспортирован.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();

                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл модуля \"ТОВАРЫ НА ГЛАВНОЙ\" " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialog = new MessageDialog("Не удалось сохранить TPL-файл модуля \"ТОВАРЫ НА ГЛАВНОЙ\" " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла модуля \"ТОВАРЫ НА ГЛАВНОЙ\" была прервана.";
                Progress.IsActive = false;

                var messagedialog = new MessageDialog("Операция записи TPL-файла модуля \"ТОВАРЫ НА ГЛАВНОЙ\" была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }
        }



        private void FTPFileIndexTovariTPL_Click(object sender, RoutedEventArgs e)
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


        private async void ButtonAddTovar1_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovara1.Text= line.Split('|')[9];
                    TextBoxNaimenovanieModeli1.Text= line.Split('|')[10];
                    TextBoxCenaModeli1.Text= line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar1RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar1DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar1EURO.IsChecked = true; }

                    TextBoxImageTovara1.Text= line.Split('|')[53];
                    TextBoxOpisanieModeli1.Text = line.Split('|')[68];
                    TextBoxLinkTovar1.Text= line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar2_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar2.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar2.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar2.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar2RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar2DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar2EURO.IsChecked = true; }

                    TextBoxImageTovar2.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar2.Text = line.Split('|')[68];
                    TextBoxLinkTovar2.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar3_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar3.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar3.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar3.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar3RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar3DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar3EURO.IsChecked = true; }

                    TextBoxImageTovar3.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar3.Text = line.Split('|')[68];
                    TextBoxLinkTovar3.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar4_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar4.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar4.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar4.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar4RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar4DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar4EURO.IsChecked = true; }

                    TextBoxImageTovar4.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar4.Text = line.Split('|')[68];
                    TextBoxLinkTovar4.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar5_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar5.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar5.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar5.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar5RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar5DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar5EURO.IsChecked = true; }

                    TextBoxImageTovar5.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar5.Text = line.Split('|')[68];
                    TextBoxLinkTovar5.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar6_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar6.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar6.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar6.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar6RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar6DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar6EURO.IsChecked = true; }

                    TextBoxImageTovar6.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar6.Text = line.Split('|')[68];
                    TextBoxLinkTovar6.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar7_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar7.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar7.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar7.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar7RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar7DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar7EURO.IsChecked = true; }

                    TextBoxImageTovar7.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar7.Text = line.Split('|')[68];
                    TextBoxLinkTovar7.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void ButtonAddTovar8_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".tovar");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.StatusFile.Text = "Загружены данные из файла: " + file.Name;
                ///здесь далее код на чтение данных из файла построчно
                var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
                foreach (var line in readFile) ///перебор всех элементов первой строки
                {
                    TextBoxNaimenovanieTovar8.Text = line.Split('|')[9];
                    TextBoxNaimenovanieModeliTovar8.Text = line.Split('|')[10];
                    TextBoxCenaModeliTovar8.Text = line.Split('|')[11];

                    string t = line.Split('|')[12];
                    if (t == "0") { radioButtonTovar8RUB.IsChecked = true; }
                    if (t == "1") { radioButtonTovar8DOLLAR.IsChecked = true; }
                    if (t == "2") { radioButtonTovar8EURO.IsChecked = true; }

                    TextBoxImageTovar8.Text = line.Split('|')[53];
                    TextBoxOpisanieModeliTovar8.Text = line.Split('|')[68];
                    TextBoxLinkTovar8.Text = line.Split('|')[70];
                }
            }
            else
            {
                this.StatusFile.Text = "Операция загрузки данных прервана.";
            }
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileTextBox.Text = "";
            Progress.IsActive = true;
            ///////////////////////////////////////////////////////////////////////////////

            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл модуля Товары на главной странице", new List<string>() { ".indextovar" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "tovari_index";
            //
            Windows.Storage.StorageFile Myfile4 = await savePicker4.PickSaveFileAsync();
            if (Myfile4 != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(Myfile4);
                // write to file
                //await Windows.Storage.FileIO.WriteTextAsync(file, file.Name); //запись в файл имени

                await FileIO.WriteTextAsync(Myfile4, TextBoxZagolovokColor.Text + "|" + TextBoxTovariTextColor.Text + "|" +
                                TextBoxTovariShrift.Text + "|" +

                                TextBoxNaimenovanieTovara1.Text + "|" +
                                TextBoxImageTovara1.Text + "|" +
                                TextBoxNaimenovanieModeli1.Text + "|" +
                                TextBoxOpisanieModeli1.Text + "|" +
                                TextBoxCenaModeli1.Text + "|");
                if (radioButtonTovar1RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar1DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar1EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar1.Text + "|" +

                                TextBoxNaimenovanieTovar2.Text + "|" +
                                TextBoxImageTovar2.Text + "|" +
                                TextBoxNaimenovanieModeliTovar2.Text + "|" +
                                TextBoxOpisanieModeliTovar2.Text + "|" +
                                TextBoxCenaModeliTovar2.Text + "|");
                if (radioButtonTovar2RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar2DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar2EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar2.Text + "|" +

                                TextBoxNaimenovanieTovar3.Text + "|" +
                                TextBoxImageTovar3.Text + "|" +
                                TextBoxNaimenovanieModeliTovar3.Text + "|" +
                                TextBoxOpisanieModeliTovar3.Text + "|" +
                                TextBoxCenaModeliTovar3.Text + "|");
                if (radioButtonTovar3RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar3DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar3EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar3.Text + "|" + TextBoxNaimenovanieTovar4.Text + "|" +
                                TextBoxImageTovar4.Text + "|" +
                                TextBoxNaimenovanieModeliTovar4.Text + "|" +
                                TextBoxOpisanieModeliTovar4.Text + "|" +
                                TextBoxCenaModeliTovar4.Text + "|");
                if (radioButtonTovar4RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar4DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar4EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar4.Text + "|" + TextBoxNaimenovanieTovar5.Text + "|" +
                                TextBoxImageTovar5.Text + "|" +
                                TextBoxNaimenovanieModeliTovar5.Text + "|" +
                                TextBoxOpisanieModeliTovar5.Text + "|" +
                                TextBoxCenaModeliTovar5.Text + "|");
                if (radioButtonTovar5RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar5DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar5EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar5.Text + "|" + TextBoxNaimenovanieTovar6.Text + "|" +
                               TextBoxImageTovar6.Text + "|" +
                               TextBoxNaimenovanieModeliTovar6.Text + "|" +
                               TextBoxOpisanieModeliTovar6.Text + "|" +
                               TextBoxCenaModeliTovar6.Text + "|");
                if (radioButtonTovar6RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar6DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar6EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar6.Text + "|" + TextBoxNaimenovanieTovar7.Text + "|" +
                               TextBoxImageTovar7.Text + "|" +
                               TextBoxNaimenovanieModeliTovar7.Text + "|" +
                               TextBoxOpisanieModeliTovar7.Text + "|" +
                               TextBoxCenaModeliTovar7.Text + "|");
                if (radioButtonTovar7RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar7DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar7EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }


                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar7.Text + "|" + TextBoxNaimenovanieTovar8.Text + "|" +
                              TextBoxImageTovar8.Text + "|" +
                              TextBoxNaimenovanieModeliTovar8.Text + "|" +
                              TextBoxOpisanieModeliTovar8.Text + "|" +
                              TextBoxCenaModeliTovar8.Text + "|");
                if (radioButtonTovar8RUB.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "0|"); }
                if (radioButtonTovar8DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (radioButtonTovar8EURO.IsChecked == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxLinkTovar8.Text + "|" +
                                TextBoxFTPServer.Text + "|" +
                                TextBoxFTPUser.Text + "|" +
                                TextBoxFTPPass.Password + "|" + TextBoxModelCenaShrift.Text + "|"+TextBoxSTYLEButton.Text+"|");

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

                    this.StatusFile.Text = "Файл модуля товаров на главной " + Myfile4.Name + " успешно сохранен.";

                    var messagedialog = new MessageDialog("Файл модуля товаров на главной " + Myfile4.Name + " успешно сохранен.");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл модуля товаров на главной " + Myfile4.Name + ".";

                    var messagedialog = new MessageDialog("Не удалось сохранить файл модуля товаров на главной " + Myfile4.Name + ".");
                    messagedialog.Commands.Add(new UICommand("Ok"));
                    await messagedialog.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла модуля товаров была прервана.";

                var messagedialog = new MessageDialog("Операция записи файла модуля товаров была прервана.");
                messagedialog.Commands.Add(new UICommand("Ok"));
                await messagedialog.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<!--====================================== МОДУЛЬ ТОВАРЫ ========================================================--><!--СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-- ><?php $file1=\"dollar.ini\";$fd1=fopen($file1,\"r\");$dollar=fgets($fd1,6);fclose($fd1);$file2=\"euro.ini\";$fd2=fopen($file2,\"r\");$euro=fgets($fd2,6);fclose($fd2);?><!--КОНЕЦ СКРИПТ ЧТЕНИЯ КУРСА ДОЛЛАРА-->\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\"><h3 style=\"color: " + TextBoxZagolovokColor.Text + "\">ПОПУЛЯРНЫЕ ТОВАРЫ</h3><div class=\"row\" style=\"margin-top:20px;\">\r\n");

            if (TextBoxNaimenovanieTovara1.Text.Length != 0)
            {
                if (radioButtonTovar1DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovara1.Text + "\" alt=\"" + TextBoxNaimenovanieTovara1.Text + " " + TextBoxNaimenovanieModeli1.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovara1.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeli1.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeli1.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeli1.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar1.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar1EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovara1.Text + "\" alt=\"" + TextBoxNaimenovanieTovara1.Text + " " + TextBoxNaimenovanieModeli1.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovara1.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeli1.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeli1.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeli1.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar1.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar1RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovara1.Text + "\" alt=\"" + TextBoxNaimenovanieTovara1.Text + " " + TextBoxNaimenovanieModeli1.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovara1.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeli1.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeli1.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeli1.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar1.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
            }

            if (TextBoxNaimenovanieTovar2.Text.Length != 0)
            {
                if (radioButtonTovar2DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar2.Text + "\" alt=\"" + TextBoxNaimenovanieTovar2.Text + " " + TextBoxNaimenovanieModeliTovar2.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar2.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar2.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar2.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar2.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar2.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar2EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar2.Text + "\" alt=\"" + TextBoxNaimenovanieTovar2.Text + " " + TextBoxNaimenovanieModeliTovar2.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar2.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar2.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar2.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar2.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar2.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar2RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar2.Text + "\" alt=\"" + TextBoxNaimenovanieTovar2.Text + " " + TextBoxNaimenovanieModeliTovar2.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar2.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar2.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar2.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar2.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar2.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }

            }

            if (TextBoxNaimenovanieTovar3.Text.Length != 0)
            {
                if (radioButtonTovar3DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar3.Text + "\" alt=\"" + TextBoxNaimenovanieTovar3.Text + " " + TextBoxNaimenovanieModeliTovar3.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar3.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar3.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar3.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar3.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar3.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar3EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar3.Text + "\" alt=\"" + TextBoxNaimenovanieTovar3.Text + " " + TextBoxNaimenovanieModeliTovar3.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar3.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar3.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar3.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar3.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar3.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar3RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar3.Text + "\" alt=\"" + TextBoxNaimenovanieTovar3.Text + " " + TextBoxNaimenovanieModeliTovar3.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar3.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar3.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar3.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar3.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar3.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
            }

            if (TextBoxNaimenovanieTovar4.Text.Length != 0)
            {
                if (radioButtonTovar4DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar4.Text + "\" alt=\"" + TextBoxNaimenovanieTovar4.Text + " " + TextBoxNaimenovanieModeliTovar4.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar4.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar4.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar4.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar4.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar4.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar4EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar4.Text + "\" alt=\"" + TextBoxNaimenovanieTovar4.Text + " " + TextBoxNaimenovanieModeliTovar4.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar4.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar4.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar4.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar4.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar4.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                if (radioButtonTovar4RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar4.Text + "\" alt=\"" + TextBoxNaimenovanieTovar4.Text + " " + TextBoxNaimenovanieModeliTovar4.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar4.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar4.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar4.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar4.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar4.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
            }


            await FileIO.AppendTextAsync(UPLOADFile, "</div><!-- /.row-->");



            if (TextBoxNaimenovanieTovar5.Text.Length != 0 | TextBoxNaimenovanieTovar6.Text.Length != 0 | TextBoxNaimenovanieTovar7.Text.Length != 0 | TextBoxNaimenovanieTovar8.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"row\" style=\"margin-top:20px;\">\r\n");

                if (TextBoxNaimenovanieTovar5.Text.Length != 0)
                {
                    if (radioButtonTovar5DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar5.Text + "\" alt=\"" + TextBoxNaimenovanieTovar5.Text + " " + TextBoxNaimenovanieModeliTovar5.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar5.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar5.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar5.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar5.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar5.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar5EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar5.Text + "\" alt=\"" + TextBoxNaimenovanieTovar5.Text + " " + TextBoxNaimenovanieModeliTovar5.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar5.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar5.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar5.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar5.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar5.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar5RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar5.Text + "\" alt=\"" + TextBoxNaimenovanieTovar5.Text + " " + TextBoxNaimenovanieModeliTovar5.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar5.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar5.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar5.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar5.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar5.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                }

                if (TextBoxNaimenovanieTovar6.Text.Length != 0)
                {
                    if (radioButtonTovar6DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar6.Text + "\" alt=\"" + TextBoxNaimenovanieTovar6.Text + " " + TextBoxNaimenovanieModeliTovar6.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar6.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar6.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar6.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar6.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar6.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar6EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar6.Text + "\" alt=\"" + TextBoxNaimenovanieTovar6.Text + " " + TextBoxNaimenovanieModeliTovar6.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar6.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar6.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar6.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar6.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar6.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar6RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar6.Text + "\" alt=\"" + TextBoxNaimenovanieTovar6.Text + " " + TextBoxNaimenovanieModeliTovar6.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar6.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar6.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar6.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar6.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar6.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                }

                if (TextBoxNaimenovanieTovar7.Text.Length != 0)
                {
                    if (radioButtonTovar7DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar7.Text + "\" alt=\"" + TextBoxNaimenovanieTovar7.Text + " " + TextBoxNaimenovanieModeliTovar7.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar7.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar7.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar7.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar7.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar7.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar7EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar7.Text + "\" alt=\"" + TextBoxNaimenovanieTovar7.Text + " " + TextBoxNaimenovanieModeliTovar7.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar7.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar7.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar7.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar7.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar7.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar7RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar7.Text + "\" alt=\"" + TextBoxNaimenovanieTovar7.Text + " " + TextBoxNaimenovanieModeliTovar7.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar7.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar7.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar7.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar7.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar7.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                }

                if (TextBoxNaimenovanieTovar8.Text.Length != 0)
                {
                    if (radioButtonTovar8DOLLAR.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar8.Text + "\" alt=\"" + TextBoxNaimenovanieTovar8.Text + " " + TextBoxNaimenovanieModeliTovar8.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar8.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar8.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar8.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar8.Text + "*$dollar);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar8.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar8EURO.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar8.Text + "\" alt=\"" + TextBoxNaimenovanieTovar8.Text + " " + TextBoxNaimenovanieModeliTovar8.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar8.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar8.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar8.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\"><?php echo ceil(" + TextBoxCenaModeliTovar8.Text + "*$euro);?></span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar8.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }
                    if (radioButtonTovar8RUB.IsChecked == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"col-xs-6 col-md-3\"><div class=\"tovar-image\"><img class=\"img-responsive\" src=\"" + TextBoxImageTovar8.Text + "\" alt=\"" + TextBoxNaimenovanieTovar8.Text + " " + TextBoxNaimenovanieModeliTovar8.Text + "\"></div><div class=\"tovar-text\"><h4 class=\"tovar\">" + TextBoxNaimenovanieTovar8.Text + "<br><span style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;\">" + TextBoxNaimenovanieModeliTovar8.Text + "</span></h4><p class=\"tovar\">" + TextBoxOpisanieModeliTovar8.Text + "</p><p class=\"cenatovar\">Цена: <span class=\"cenatovar\" style=\"font-family:" + TextBoxModelCenaShrift.Text + "; font-size:inherit;font-weight:bold;\">" + TextBoxCenaModeliTovar8.Text + "</span> рублей</p><p><a class=\"btn btn-default\" style=\""+TextBoxSTYLEButton.Text+"\" href=\"" + TextBoxLinkTovar8.Text + "\" role=\"button\">Характеристики товара &raquo;</a></p></div></div><!-- /.col-lg-4 -->\r\n"); }

                }


                await FileIO.AppendTextAsync(UPLOADFile, "</div><!-- /.row-->");

            }
            await FileIO.AppendTextAsync(UPLOADFile, "</div><!-- /.container marketing--><!-- ====================================== КОНЕЦ МОДУЛЬ ТОВАРЫ======================================================== -->");

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
