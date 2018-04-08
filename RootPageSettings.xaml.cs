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
    public sealed partial class RootPageSettings : Page
    {
        public RootPageSettings()
        {
            this.InitializeComponent();
            ComboBoxModule1.SelectedItem = Combo011;
            ComboBoxModule2.SelectedItem = Combo021;
            ComboBoxModule3.SelectedItem = Combo031;
            ComboBoxModule4.SelectedItem = Combo041;
            ComboBoxModule5.SelectedItem = Combo051;
            ComboBoxModule6.SelectedItem = Combo061;
            ComboBoxModule7.SelectedItem = Combo071;
            ComboBoxModule8.SelectedItem = Combo081;
            ComboBoxModule9.SelectedItem = Combo091;
            ComboBoxModule10.SelectedItem = Combo0101;

        }

        private async void LoadFilePage_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".indexpage");
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
                    TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                    ComboBoxModule1.SelectedItem = Combo011;
                    ComboBoxModule2.SelectedItem = Combo021;
                    ComboBoxModule3.SelectedItem = Combo031;
                    ComboBoxModule4.SelectedItem = Combo041;
                    ComboBoxModule5.SelectedItem = Combo051;
                    ComboBoxModule6.SelectedItem = Combo061;
                    ComboBoxModule7.SelectedItem = Combo071;
                    ComboBoxModule8.SelectedItem = Combo081;
                    ComboBoxModule9.SelectedItem = Combo091;
                    ComboBoxModule10.SelectedItem = Combo0101;

                    TextBoxZagolovokPage.Text = line.Split('|')[0];
                    TextBoxKeywords.Text = line.Split('|')[1];
                    TextBoxMetaDescription.Text = line.Split('|')[2];
                    TextBoxFontBody.Text = line.Split('|')[3];
                    TextBoxFont.Text = line.Split('|')[4];

                    TextBoxZagolovokColor.Text = line.Split('|')[5];
                    TextBoxKategoriiTextColor.Text = line.Split('|')[6];
                    TextBoxBackgroundColor.Text = line.Split('|')[7];

                    string t1 = line.Split('|')[8];
                    if (t1 == "1") { ComboBoxModule1.SelectedItem = Combo11; }
                    if (t1 == "2") { ComboBoxModule1.SelectedItem = Combo12; }
                    if (t1 == "3") { ComboBoxModule1.SelectedItem = Combo13; }
                    if (t1 == "4") { ComboBoxModule1.SelectedItem = Combo14; }
                    if (t1 == "5") { ComboBoxModule1.SelectedItem = Combo15; }
                    if (t1 == "6") { TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; ComboBoxModule1.SelectedItem = Combo16; }
                    if (t1 == "7" || t1 == "") { ComboBoxModule1.SelectedItem = Combo011; }


                    string t2 = line.Split('|')[9];
                    if (t2 == "1") { ComboBoxModule2.SelectedItem = Combo21; }
                    if (t2 == "2") { ComboBoxModule2.SelectedItem = Combo22; }
                    if (t2 == "3") { ComboBoxModule2.SelectedItem = Combo23; }
                    if (t2 == "4") { ComboBoxModule2.SelectedItem = Combo24; }
                    if (t2 == "5") { ComboBoxModule2.SelectedItem = Combo25; }
                    if (t2 == "6") { ComboBoxModule2.SelectedItem = Combo26; TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t2 == "7" || t2 == "") { ComboBoxModule2.SelectedItem = Combo021; }

                    string t3 = line.Split('|')[10];
                    if (t3 == "1") { ComboBoxModule3.SelectedItem = Combo31; }
                    if (t3 == "2") { ComboBoxModule3.SelectedItem = Combo32; }
                    if (t3 == "3") { ComboBoxModule3.SelectedItem = Combo33; }
                    if (t3 == "4") { ComboBoxModule3.SelectedItem = Combo34; }
                    if (t3 == "5") { ComboBoxModule3.SelectedItem = Combo35; }
                    if (t3 == "6") { ComboBoxModule3.SelectedItem = Combo36; TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t3 == "7" || t3 == "") { ComboBoxModule3.SelectedItem = Combo031; }

                    string t4 = line.Split('|')[11];
                    if (t4 == "1") { ComboBoxModule4.SelectedItem = Combo41; }
                    if (t4 == "2") { ComboBoxModule4.SelectedItem = Combo42; }
                    if (t4 == "3") { ComboBoxModule4.SelectedItem = Combo43; }
                    if (t4 == "4") { ComboBoxModule4.SelectedItem = Combo44; }
                    if (t4 == "5") { ComboBoxModule4.SelectedItem = Combo45; }
                    if (t4 == "6") { ComboBoxModule4.SelectedItem = Combo46; TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t4 == "7" || t4 == "") { ComboBoxModule4.SelectedItem = Combo041; }

                    string t5 = line.Split('|')[12];
                    if (t5 == "1") { ComboBoxModule5.SelectedItem =Combo51; }
                    if (t5 == "2") { ComboBoxModule5.SelectedItem = Combo52; }
                    if (t5 == "3") { ComboBoxModule5.SelectedItem = Combo53; }
                    if (t5 == "4") { ComboBoxModule5.SelectedItem = Combo54; }
                    if (t5 == "5") { ComboBoxModule5.SelectedItem = Combo55; }
                    if (t5 == "6") { ComboBoxModule5.SelectedItem = Combo56; TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t5 == "7" || t5 == "") { ComboBoxModule5.SelectedItem = Combo051; }

                    string t6 = line.Split('|')[13];
                    if (t6 == "1") { ComboBoxModule6.SelectedItem = Combo61; }
                    if (t6 == "2") { ComboBoxModule6.SelectedItem = Combo62; }
                    if (t6 == "3") { ComboBoxModule6.SelectedItem = Combo63; }
                    if (t6 == "4") { ComboBoxModule6.SelectedItem = Combo64; }
                    if (t6 == "5") { ComboBoxModule6.SelectedItem = Combo65; }
                    if (t6 == "6") { TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; ComboBoxModule6.SelectedItem = Combo66; }
                    if (t6 == "7" || t6 == "") { ComboBoxModule6.SelectedItem = Combo061; }

                    string t7 = line.Split('|')[14];
                    if (t7 == "1") { ComboBoxModule7.SelectedItem = Combo71; }
                    if (t7 == "2") { ComboBoxModule7.SelectedItem = Combo72; }
                    if (t7 == "3") { ComboBoxModule7.SelectedItem = Combo73; }
                    if (t7 == "4") { ComboBoxModule7.SelectedItem = Combo74; }
                    if (t7 == "5") { ComboBoxModule7.SelectedItem = Combo75; }
                    if (t7 == "6") { ComboBoxModule7.SelectedItem = Combo76; TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t7 == "7" || t7 == "") { ComboBoxModule7.SelectedItem = Combo071; }

                    string t8 = line.Split('|')[15];
                    if (t8 == "1") { ComboBoxModule8.SelectedItem = Combo81; }
                    if (t8 == "2") { ComboBoxModule8.SelectedItem = Combo82; }
                    if (t8 == "3") { ComboBoxModule8.SelectedItem = Combo83; }
                    if (t8 == "4") { ComboBoxModule8.SelectedItem = Combo84; }
                    if (t8 == "5") { ComboBoxModule8.SelectedItem = Combo85; }
                    if (t8 == "6") { ComboBoxModule8.SelectedItem = Combo86; TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t8 == "7" || t8 == "") { ComboBoxModule8.SelectedItem = Combo081; }

                    string t9 = line.Split('|')[16];
                    if (t9 == "1") { ComboBoxModule9.SelectedItem = Combo91; }
                    if (t9 == "2") { ComboBoxModule9.SelectedItem = Combo92; }
                    if (t9 == "3") { ComboBoxModule9.SelectedItem = Combo93; }
                    if (t9 == "4") { ComboBoxModule9.SelectedItem = Combo94; }
                    if (t9 == "5") { ComboBoxModule9.SelectedItem = Combo95; }
                    if (t9 == "6") { ComboBoxModule9.SelectedItem = Combo96; TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t9 == "7" || t9 == "") { ComboBoxModule9.SelectedItem = Combo091; }

                    string t10 = line.Split('|')[17];
                    if (t10 == "1") { ComboBoxModule10.SelectedItem = Combo101; }
                    if (t10 == "2") { ComboBoxModule10.SelectedItem = Combo102; }
                    if (t10 == "3") { ComboBoxModule10.SelectedItem = Combo103; }
                    if (t10 == "4") { ComboBoxModule10.SelectedItem = Combo104; }
                    if (t10 == "5") { ComboBoxModule10.SelectedItem = Combo105; }
                    if (t10 == "6") { ComboBoxModule10.SelectedItem = Combo106; TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Visible; }
                    if (t10 == "7" || t10=="") { ComboBoxModule10.SelectedItem = Combo0101; }

                    TextBoxModule1HTML.Text = line.Split('|')[18];
                    TextBoxModule2HTML.Text = line.Split('|')[19];
                    TextBoxModule3HTML.Text = line.Split('|')[20];
                    TextBoxModule4HTML.Text = line.Split('|')[21];
                    TextBoxModule5HTML.Text = line.Split('|')[22];
                    TextBoxModule6HTML.Text = line.Split('|')[23];
                    TextBoxModule7HTML.Text = line.Split('|')[24];
                    TextBoxModule8HTML.Text = line.Split('|')[25];
                    TextBoxModule9HTML.Text = line.Split('|')[26];
                    TextBoxModule10HTML.Text = line.Split('|')[27];

                    TextBoxFTPServer.Text = line.Split('|')[28];
                    TextBoxFTPUser.Text = line.Split('|')[29];
                    TextBoxFTPPass.Password = line.Split('|')[30];

                    try { TextBoxSTYLE.Text = line.Split('|')[31]; TextBoxCUSTOMCSS.Text = line.Split('|')[32]; }
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

    private async void SaveFileTovar_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл данных главной страницы ", new List<string>() { ".indexpage" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "index";
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
                TextBoxBackgroundColor.Text + "|");

                if (ComboBoxModule1.SelectedItem.Equals(Combo11) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo12) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo13) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo14) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo15) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo16) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo011) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule2.SelectedItem.Equals(Combo21) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo22) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo23) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo24) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo25) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo26) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo021) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule3.SelectedItem.Equals(Combo31) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo32) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo33) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo34) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo35) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo36) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo031) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule4.SelectedItem.Equals(Combo41) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo42) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo43) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo44) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo45) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo46) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo041) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }
            
                if (ComboBoxModule5.SelectedItem.Equals(Combo51) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo52) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo53) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo54) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo55) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo56) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo051) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule6.SelectedItem.Equals(Combo61) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo62) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo63) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo64) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo65) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo66) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo061) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }
            
                if (ComboBoxModule7.SelectedItem.Equals(Combo71) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo72) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo73) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo74) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo75) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo76) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo071) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule8.SelectedItem.Equals(Combo81) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo82) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo83) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo84) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo85) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo86) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo081) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule9.SelectedItem.Equals(Combo91) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo92) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo93) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo94) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo95) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo96) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo091) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }
            
                if (ComboBoxModule10.SelectedItem.Equals(Combo101) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo102) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo103) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo104) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo105) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo106) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo0101) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxModule1HTML.Text + "|" + TextBoxModule2HTML.Text + "|" + TextBoxModule3HTML.Text + "|" + TextBoxModule4HTML.Text + "|" + TextBoxModule5HTML.Text + "|" + TextBoxModule6HTML.Text + "|" + TextBoxModule7HTML.Text + "|" + TextBoxModule8HTML.Text + "|" + TextBoxModule9HTML.Text + "|" + TextBoxModule10HTML.Text + "|" + TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|"+TextBoxSTYLE.Text+"|"+TextBoxCUSTOMCSS.Text+"|");

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

                    this.StatusFile.Text = "Файл данных главной страницы " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("Файл данных главной страницы " + Myfile4.Name + " успешно сохранен.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных главной страницы " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("Не удалось сохранить файл данных главной страницы " + Myfile4.Name + ".");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных главной страницы была прервана.";
                Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Операция записи файла данных главной страницы была прервана.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private async void SaveFileTovarPHP_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("PHP файл главной страницы ", new List<string>() { ".php" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "index";
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
                await FileIO.AppendTextAsync(Myfile4, "<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

                if (TextBoxCUSTOMCSS.Text.Length != 0)
                {
                    await FileIO.AppendTextAsync(Myfile4, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
                }

                await FileIO.AppendTextAsync(Myfile4, "<style>\r\n" + TextBoxSTYLE.Text + "</style>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "</head>\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<body style=\"font-family:" + TextBoxFontBody.Text + "; background:" + TextBoxBackgroundColor.Text + "; color:" + TextBoxKategoriiTextColor.Text + "\">\r\n");
                await FileIO.AppendTextAsync(Myfile4, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/navigation.tpl\"; ?>\r\n");
                


                if (ComboBoxModule1.SelectedItem.Equals(Combo11) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo12) == true) { await FileIO.AppendTextAsync(Myfile4, "<div style=\"margin-top:80px;\"></div><?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo13) == true) { await FileIO.AppendTextAsync(Myfile4, "<div style=\"margin-top:80px;\"></div><?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo14) == true) { await FileIO.AppendTextAsync(Myfile4, "<div style=\"margin-top:80px;\"></div><?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo15) == true) { await FileIO.AppendTextAsync(Myfile4, "<div style=\"margin-top:80px;\"></div><?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo16) == true) { await FileIO.AppendTextAsync(Myfile4, "<div style=\"margin-top:80px;\"></div>" + TextBoxModule1HTML.Text + "\r\n"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo011) == true) { }

                if (ComboBoxModule2.SelectedItem.Equals(Combo21) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo22) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo23) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo24) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo25) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo26) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule2HTML.Text + "\r\n"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo021) == true) { }

                if (ComboBoxModule3.SelectedItem.Equals(Combo31) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo32) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo33) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo34) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo35) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo36) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule3HTML.Text + "\r\n"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo031) == true) { }

                if (ComboBoxModule4.SelectedItem.Equals(Combo41) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo42) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo43) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo44) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo45) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo46) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule4HTML.Text + "\r\n"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo041) == true) { }

                if (ComboBoxModule5.SelectedItem.Equals(Combo51) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo52) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo53) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo54) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo55) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo56) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule5HTML.Text + "\r\n"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo051) == true) { }

                if (ComboBoxModule6.SelectedItem.Equals(Combo61) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo62) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo63) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo64) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo65) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo66) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule6HTML.Text + "\r\n"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo061) == true) { }

                if (ComboBoxModule7.SelectedItem.Equals(Combo71) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo72) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo73) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo74) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo75) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo76) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule7HTML.Text + "\r\n"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo071) == true) { }

                if (ComboBoxModule8.SelectedItem.Equals(Combo81) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo82) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo83) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo84) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo85) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo86) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule8HTML.Text + "\r\n"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo081) == true) { }

                if (ComboBoxModule9.SelectedItem.Equals(Combo91) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo92) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo93) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo94) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo95) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo96) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule9HTML.Text + "\r\n"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo091) == true) { }

                if (ComboBoxModule10.SelectedItem.Equals(Combo101) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('slider.tpl'); ?>\r\n"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo102) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('tovari_index.tpl'); ?>\r\n"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo103) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('news.tpl'); ?>\r\n"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo104) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('clients.tpl'); ?>\r\n"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo105) == true) { await FileIO.AppendTextAsync(Myfile4, "<?php require('works.tpl'); ?>\r\n"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo106) == true) { await FileIO.AppendTextAsync(Myfile4, TextBoxModule10HTML.Text + "\r\n"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo0101) == true) { }

                await FileIO.AppendTextAsync(Myfile4, "\r\n<!-- КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ -->\r\n<?php require $_SERVER['DOCUMENT_ROOT'].\"/footer.tpl\"; ?>\r\n<?php require $_SERVER['DOCUMENT_ROOT'].\"/footerscripts.tpl\"; ?>\r\n\r\n</body>\r\n</html>");



                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "PHP файл главной страницы " + Myfile4.Name + " успешно экспортирован.";

                    FileTextBox.Text = "";
                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;

                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("PHP файл главной страницы " + Myfile4.Name + " успешно экспортирован.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить PHP-файл главной страницы " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("Не удалось сохранить PHP-файл главной страницы " + Myfile4.Name + ".");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи PHP-файла главной страницы была прервана.";
                Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Операция записи PHP-файла главной страницы была прервана.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }
            Progress.IsActive = false;
        }

        private void FTPFileTovarPHP_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            if (TextBoxFTPServer.Text != "")
            {
                DoDownloadOrUpload(false); ////см.проект kiewic ftp client 
                Progress.IsActive = false;
            }

            else { StatusFile.Text = "Ошибка. Введите адрес FTP сервера."; Progress.IsActive = false; }
            Progress.IsActive = false;
        }

        private void Combo16_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo26_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo36_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo46_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo56_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo66_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo76_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo86_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo96_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void Combo106_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Visible;
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

        private void Combo091_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo91_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo92_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo93_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo94_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo95_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule9HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo0101_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo101_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo102_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo103_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo104_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo105_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule10HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo011_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo11_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo12_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo13_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo14_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo15_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule1HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo021_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo21_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo22_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo23_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo24_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo25_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule2HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo031_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo31_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo32_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo33_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo34_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo35_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule3HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo041_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo41_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo42_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo43_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo44_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo45_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule4HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo051_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo51_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo52_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo53_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo54_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo55_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule5HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo061_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo61_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo62_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo63_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo64_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo65_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule6HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo071_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo71_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo72_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo73_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo74_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo75_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule7HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo081_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo81_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo82_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo83_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo84_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Combo85_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBoxModule8HTML.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileTextBox.Text = "";
            Progress.IsActive = true;
            ///////////////////////////////////////////////////////////////////////////////

            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл данных главной страницы ", new List<string>() { ".indexpage" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker4.SuggestedFileName = "index";
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
                TextBoxBackgroundColor.Text + "|");

                if (ComboBoxModule1.SelectedItem.Equals(Combo11) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo12) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo13) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo14) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo15) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo16) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule1.SelectedItem.Equals(Combo011) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule2.SelectedItem.Equals(Combo21) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo22) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo23) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo24) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo25) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo26) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule2.SelectedItem.Equals(Combo021) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule3.SelectedItem.Equals(Combo31) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo32) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo33) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo34) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo35) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo36) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule3.SelectedItem.Equals(Combo031) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule4.SelectedItem.Equals(Combo41) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo42) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo43) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo44) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo45) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo46) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule4.SelectedItem.Equals(Combo041) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule5.SelectedItem.Equals(Combo51) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo52) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo53) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo54) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo55) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo56) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule5.SelectedItem.Equals(Combo051) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule6.SelectedItem.Equals(Combo61) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo62) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo63) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo64) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo65) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo66) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule6.SelectedItem.Equals(Combo061) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule7.SelectedItem.Equals(Combo71) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo72) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo73) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo74) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo75) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo76) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule7.SelectedItem.Equals(Combo071) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule8.SelectedItem.Equals(Combo81) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo82) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo83) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo84) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo85) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo86) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule8.SelectedItem.Equals(Combo081) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule9.SelectedItem.Equals(Combo91) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo92) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo93) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo94) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo95) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo96) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule9.SelectedItem.Equals(Combo091) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                if (ComboBoxModule10.SelectedItem.Equals(Combo101) == true) { await FileIO.AppendTextAsync(Myfile4, "1|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo102) == true) { await FileIO.AppendTextAsync(Myfile4, "2|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo103) == true) { await FileIO.AppendTextAsync(Myfile4, "3|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo104) == true) { await FileIO.AppendTextAsync(Myfile4, "4|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo105) == true) { await FileIO.AppendTextAsync(Myfile4, "5|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo106) == true) { await FileIO.AppendTextAsync(Myfile4, "6|"); }
                if (ComboBoxModule10.SelectedItem.Equals(Combo0101) == true) { await FileIO.AppendTextAsync(Myfile4, "7|"); }

                await FileIO.AppendTextAsync(Myfile4, TextBoxModule1HTML.Text + "|" + TextBoxModule2HTML.Text + "|" + TextBoxModule3HTML.Text + "|" + TextBoxModule4HTML.Text + "|" + TextBoxModule5HTML.Text + "|" + TextBoxModule6HTML.Text + "|" + TextBoxModule7HTML.Text + "|" + TextBoxModule8HTML.Text + "|" + TextBoxModule9HTML.Text + "|" + TextBoxModule10HTML.Text + "|" + TextBoxFTPServer.Text + "|" + TextBoxFTPUser.Text + "|" + TextBoxFTPPass.Password + "|" + TextBoxSTYLE.Text + "|"+TextBoxCUSTOMCSS.Text+"|");

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

                    this.StatusFile.Text = "Файл данных главной страницы " + Myfile4.Name + " успешно сохранен.";

                    var messagedialogFile1 = new MessageDialog("Файл данных главной страницы " + Myfile4.Name + " успешно сохранен.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл данных главной страницы " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialogFile1 = new MessageDialog("Не удалось сохранить файл данных главной страницы " + Myfile4.Name + ".");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла данных главной страницы была прервана.";
                Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Операция записи файла данных главной страницы была прервана.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/header.tpl\"; ?>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<title>" + TextBoxZagolovokPage.Text + "</title>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<meta name=\"keywords\" content=\"" + TextBoxKeywords.Text + "\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<meta name=\"description\" content=\"" + TextBoxMetaDescription.Text + "\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"/css/customstyle.css\" rel=\"stylesheet\">\r\n");

            if (TextBoxCUSTOMCSS.Text.Length != 0)
            {
                await FileIO.AppendTextAsync(UPLOADFile, "<link href=\"" + TextBoxCUSTOMCSS.Text + "\" rel=\"stylesheet\">\r\n");
            }

            await FileIO.AppendTextAsync(UPLOADFile, "<style>\r\n" + TextBoxSTYLE.Text + "</style>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</head>\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<body style=\"font-family:" + TextBoxFontBody.Text + "; background:" + TextBoxBackgroundColor.Text + "; color:"+TextBoxKategoriiTextColor.Text+";\">\r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<?php require $_SERVER['DOCUMENT_ROOT'].\"/navigation.tpl\"; ?>\r\n");

            if (ComboBoxModule1.SelectedItem.Equals(Combo11) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule1.SelectedItem.Equals(Combo12) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div style=\"margin-top:80px;\"></div><?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule1.SelectedItem.Equals(Combo13) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div style=\"margin-top:80px;\"></div><?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule1.SelectedItem.Equals(Combo14) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div style=\"margin-top:80px;\"></div><?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule1.SelectedItem.Equals(Combo15) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div style=\"margin-top:80px;\"></div><?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule1.SelectedItem.Equals(Combo16) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<div style=\"margin-top:80px;\"></div>" + TextBoxModule1HTML.Text + "\r\n"); }
            if (ComboBoxModule1.SelectedItem.Equals(Combo011) == true) { }

            if (ComboBoxModule2.SelectedItem.Equals(Combo21) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule2.SelectedItem.Equals(Combo22) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule2.SelectedItem.Equals(Combo23) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule2.SelectedItem.Equals(Combo24) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule2.SelectedItem.Equals(Combo25) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule2.SelectedItem.Equals(Combo26) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule2HTML.Text + "\r\n"); }
            if (ComboBoxModule2.SelectedItem.Equals(Combo021) == true) { }

            if (ComboBoxModule3.SelectedItem.Equals(Combo31) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule3.SelectedItem.Equals(Combo32) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule3.SelectedItem.Equals(Combo33) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule3.SelectedItem.Equals(Combo34) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule3.SelectedItem.Equals(Combo35) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule3.SelectedItem.Equals(Combo36) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule3HTML.Text + "\r\n"); }
            if (ComboBoxModule3.SelectedItem.Equals(Combo031) == true) { }

            if (ComboBoxModule4.SelectedItem.Equals(Combo41) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule4.SelectedItem.Equals(Combo42) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule4.SelectedItem.Equals(Combo43) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule4.SelectedItem.Equals(Combo44) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule4.SelectedItem.Equals(Combo45) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule4.SelectedItem.Equals(Combo46) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule4HTML.Text + "\r\n"); }
            if (ComboBoxModule4.SelectedItem.Equals(Combo041) == true) { }

            if (ComboBoxModule5.SelectedItem.Equals(Combo51) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule5.SelectedItem.Equals(Combo52) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule5.SelectedItem.Equals(Combo53) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule5.SelectedItem.Equals(Combo54) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule5.SelectedItem.Equals(Combo55) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule5.SelectedItem.Equals(Combo56) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule5HTML.Text + "\r\n"); }
            if (ComboBoxModule5.SelectedItem.Equals(Combo051) == true) { }

            if (ComboBoxModule6.SelectedItem.Equals(Combo61) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule6.SelectedItem.Equals(Combo62) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule6.SelectedItem.Equals(Combo63) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule6.SelectedItem.Equals(Combo64) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule6.SelectedItem.Equals(Combo65) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule6.SelectedItem.Equals(Combo66) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule6HTML.Text + "\r\n"); }
            if (ComboBoxModule6.SelectedItem.Equals(Combo061) == true) { }

            if (ComboBoxModule7.SelectedItem.Equals(Combo71) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule7.SelectedItem.Equals(Combo72) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule7.SelectedItem.Equals(Combo73) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule7.SelectedItem.Equals(Combo74) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule7.SelectedItem.Equals(Combo75) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule7.SelectedItem.Equals(Combo76) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule7HTML.Text + "\r\n"); }
            if (ComboBoxModule7.SelectedItem.Equals(Combo071) == true) { }

            if (ComboBoxModule8.SelectedItem.Equals(Combo81) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule8.SelectedItem.Equals(Combo82) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule8.SelectedItem.Equals(Combo83) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule8.SelectedItem.Equals(Combo84) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule8.SelectedItem.Equals(Combo85) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule8.SelectedItem.Equals(Combo86) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule8HTML.Text + "\r\n"); }
            if (ComboBoxModule8.SelectedItem.Equals(Combo081) == true) { }

            if (ComboBoxModule9.SelectedItem.Equals(Combo91) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule9.SelectedItem.Equals(Combo92) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule9.SelectedItem.Equals(Combo93) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule9.SelectedItem.Equals(Combo94) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule9.SelectedItem.Equals(Combo95) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule9.SelectedItem.Equals(Combo96) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule9HTML.Text + "\r\n"); }
            if (ComboBoxModule9.SelectedItem.Equals(Combo091) == true) { }

            if (ComboBoxModule10.SelectedItem.Equals(Combo101) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('slider.tpl'); ?>\r\n"); }
            if (ComboBoxModule10.SelectedItem.Equals(Combo102) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('tovari_index.tpl'); ?>\r\n"); }
            if (ComboBoxModule10.SelectedItem.Equals(Combo103) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('news.tpl'); ?>\r\n"); }
            if (ComboBoxModule10.SelectedItem.Equals(Combo104) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('clients.tpl'); ?>\r\n"); }
            if (ComboBoxModule10.SelectedItem.Equals(Combo105) == true) { await FileIO.AppendTextAsync(UPLOADFile, "<?php require('works.tpl'); ?>\r\n"); }
            if (ComboBoxModule10.SelectedItem.Equals(Combo106) == true) { await FileIO.AppendTextAsync(UPLOADFile, TextBoxModule10HTML.Text + "\r\n"); }
            if (ComboBoxModule10.SelectedItem.Equals(Combo0101) == true) { }

            await FileIO.AppendTextAsync(UPLOADFile, "\r\n<!-- КОНЕЦ ОСНОВНОЙ КОНТЕНТ СТРАНИЦЫ -->\r\n<?php require $_SERVER['DOCUMENT_ROOT'].\"/footer.tpl\"; ?>\r\n<?php require $_SERVER['DOCUMENT_ROOT'].\"/footerscripts.tpl\"; ?>\r\n\r\n</body>\r\n</html>");


            ///////////////////////////////////////////////////////////////////////////////

            string text11 = await Windows.Storage.FileIO.ReadTextAsync(UPLOADFile);
            string text102 = text11.Replace("\r\n", "  "); string text1002 = text102.Replace("\n", "  "); string text12 = text1002.Replace("\r", "  ");

            FileTextBox.Text = text12;

            ///////////////////////////////////////////////////////////////////////////////

            if (TextBoxFTPServer.Text != "")
            {
                Progress.IsActive = true;
                DoDownloadOrUpload(false); ////см.проект kiewic ftp client 
                Progress.IsActive = false;
            }

            else
            {
                StatusFile.Text = "Ошибка. Введите адрес FTP сервера."; Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Ошибка. Введите адрес FTP сервера.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }

            Progress.IsActive = false;


        }
    }
}
