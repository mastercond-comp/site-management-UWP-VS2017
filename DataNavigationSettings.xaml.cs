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
    public sealed partial class DataNavigationSettings : Page
    {
        public DataNavigationSettings()
        {
            this.InitializeComponent();
        }

        private async void LoadFileMain_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ///picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".main");
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
                    TextBoxName.Text = line.Split('|')[0];
                    TextBoxSlogan.Text = line.Split('|')[1];
                    TextBoxLogo.Text = line.Split('|')[2];
                    TextBoxTel.Text = line.Split('|')[3];
                    TextBoxGorod.Text = line.Split('|')[4];


                    TextBoxMenuRazdel1.Text = line.Split('|')[5];
                    TextBoxMenuRazdel12.Text = line.Split('|')[6];

                    TextBoxMenuRazdel1Punkt1.Text = line.Split('|')[7];
                    TextBoxMenuRazdel1Punkt1Hiperlink.Text = line.Split('|')[8];
                    TextBoxMenuRazdel1Punkt2.Text = line.Split('|')[9];
                    TextBoxMenuRazdel1Punkt2Hiperlink.Text = line.Split('|')[10];
                    TextBoxMenuRazdel1Punkt3.Text = line.Split('|')[11];
                    TextBoxMenuRazdel1Punkt3Hiperlink.Text = line.Split('|')[12];
                    TextBoxMenuRazdel1Punkt4.Text = line.Split('|')[13];
                    TextBoxMenuRazdel1Punkt4Hiperlink.Text = line.Split('|')[14];
                    TextBoxMenuRazdel1Punkt5.Text = line.Split('|')[15];
                    TextBoxMenuRazdel1Punkt5Hiperlink.Text = line.Split('|')[16];
                    TextBoxMenuRazdel1Punkt6.Text = line.Split('|')[17];
                    TextBoxMenuRazdel1Punkt6Hiperlink.Text = line.Split('|')[18];
                    TextBoxMenuRazdel1Punkt7.Text = line.Split('|')[19];
                    TextBoxMenuRazdel1Punkt7Hiperlink.Text = line.Split('|')[20];
                    TextBoxMenuRazdel1Punkt8.Text = line.Split('|')[21];
                    TextBoxMenuRazdel1Punkt8Hiperlink.Text = line.Split('|')[22];
                    TextBoxMenuRazdel1Punkt9.Text = line.Split('|')[23];
                    TextBoxMenuRazdel1Punkt9Hiperlink.Text = line.Split('|')[24];
                    TextBoxMenuRazdel1Punkt10.Text = line.Split('|')[25];
                    TextBoxMenuRazdel1Punkt10Hiperlink.Text = line.Split('|')[26];
                    TextBoxMenuRazdel1Punkt11.Text = line.Split('|')[27];
                    TextBoxMenuRazdel1Punkt11Hiperlink.Text = line.Split('|')[28];
                    TextBoxMenuRazdel1Punkt12.Text = line.Split('|')[29];
                    TextBoxMenuRazdel1Punkt12Hiperlink.Text = line.Split('|')[30];
                    TextBoxMenuRazdel1Punkt13.Text = line.Split('|')[31];
                    TextBoxMenuRazdel1Punkt13Hiperlink.Text = line.Split('|')[32];
                    TextBoxMenuRazdel1Punkt14.Text = line.Split('|')[33];
                    TextBoxMenuRazdel1Punkt14Hiperlink.Text = line.Split('|')[34];
                    TextBoxMenuRazdel1Punkt15.Text = line.Split('|')[35];
                    TextBoxMenuRazdel1Punkt15Hiperlink.Text = line.Split('|')[36];
                    TextBoxMenuRazdel1Punkt16.Text = line.Split('|')[37];
                    TextBoxMenuRazdel1Punkt16Hiperlink.Text = line.Split('|')[38];
                    TextBoxMenuRazdel1Punkt17.Text = line.Split('|')[39];
                    TextBoxMenuRazdel1Punkt17Hiperlink.Text = line.Split('|')[40];
                    TextBoxMenuRazdel1Punkt18.Text = line.Split('|')[41];
                    TextBoxMenuRazdel1Punkt18Hiperlink.Text = line.Split('|')[42];
                    TextBoxMenuRazdel1Punkt19.Text = line.Split('|')[43];
                    TextBoxMenuRazdel1Punkt19Hiperlink.Text = line.Split('|')[44];
                    TextBoxMenuRazdel1Punkt20.Text = line.Split('|')[45];
                    TextBoxMenuRazdel1Punkt20Hiperlink.Text = line.Split('|')[46];
                    TextBoxMenuRazdel1Punkt21.Text = line.Split('|')[47];
                    TextBoxMenuRazdel1Punkt21Hiperlink.Text = line.Split('|')[48];
                    TextBoxMenuRazdel1Punkt22.Text = line.Split('|')[49];
                    TextBoxMenuRazdel1Punkt22Hiperlink.Text = line.Split('|')[50];
                    TextBoxMenuRazdel1Punkt23.Text = line.Split('|')[51];
                    TextBoxMenuRazdel1Punkt23Hiperlink.Text = line.Split('|')[52];
                    TextBoxMenuRazdel1Punkt24.Text = line.Split('|')[53];
                    TextBoxMenuRazdel1Punkt24Hiperlink.Text = line.Split('|')[54];
                    TextBoxMenuRazdel1Punkt25.Text = line.Split('|')[55];
                    TextBoxMenuRazdel1Punkt25Hiperlink.Text = line.Split('|')[56];




                    TextBoxMenuRazdel2.Text = line.Split('|')[57];
                    TextBoxMenuRazdel22.Text = line.Split('|')[58];

                    TextBoxMenuRazdel2Punkt1.Text = line.Split('|')[59];
                    TextBoxMenuRazdel2Punkt1Hiperlink.Text = line.Split('|')[60];
                    TextBoxMenuRazdel2Punkt2.Text = line.Split('|')[61];
                    TextBoxMenuRazdel2Punkt2Hiperlink.Text = line.Split('|')[62];
                    TextBoxMenuRazdel2Punkt3.Text = line.Split('|')[63];
                    TextBoxMenuRazdel2Punkt3Hiperlink.Text = line.Split('|')[64];
                    TextBoxMenuRazdel2Punkt4.Text = line.Split('|')[65];
                    TextBoxMenuRazdel2Punkt4Hiperlink.Text = line.Split('|')[66];
                    TextBoxMenuRazdel2Punkt5.Text = line.Split('|')[67];
                    TextBoxMenuRazdel2Punkt5Hiperlink.Text = line.Split('|')[68];
                    TextBoxMenuRazdel2Punkt6.Text = line.Split('|')[69];
                    TextBoxMenuRazdel2Punkt6Hiperlink.Text = line.Split('|')[70];
                    TextBoxMenuRazdel2Punkt7.Text = line.Split('|')[71];
                    TextBoxMenuRazdel2Punkt7Hiperlink.Text = line.Split('|')[72];
                    TextBoxMenuRazdel2Punkt8.Text = line.Split('|')[73];
                    TextBoxMenuRazdel2Punkt8Hiperlink.Text = line.Split('|')[74];
                    TextBoxMenuRazdel2Punkt9.Text = line.Split('|')[75];
                    TextBoxMenuRazdel2Punkt9Hiperlink.Text = line.Split('|')[76];
                    TextBoxMenuRazdel2Punkt10.Text = line.Split('|')[77];
                    TextBoxMenuRazdel2Punkt10Hiperlink.Text = line.Split('|')[78];
                    TextBoxMenuRazdel2Punkt11.Text = line.Split('|')[79];
                    TextBoxMenuRazdel2Punkt11Hiperlink.Text = line.Split('|')[80];
                    TextBoxMenuRazdel2Punkt12.Text = line.Split('|')[81];
                    TextBoxMenuRazdel2Punkt12Hiperlink.Text = line.Split('|')[82];
                    TextBoxMenuRazdel2Punkt13.Text = line.Split('|')[83];
                    TextBoxMenuRazdel2Punkt13Hiperlink.Text = line.Split('|')[84];
                    TextBoxMenuRazdel2Punkt14.Text = line.Split('|')[85];
                    TextBoxMenuRazdel2Punkt14Hiperlink.Text = line.Split('|')[86];
                    TextBoxMenuRazdel2Punkt15.Text = line.Split('|')[87];
                    TextBoxMenuRazdel2Punkt15Hiperlink.Text = line.Split('|')[88];
                    TextBoxMenuRazdel2Punkt16.Text = line.Split('|')[89];
                    TextBoxMenuRazdel2Punkt16Hiperlink.Text = line.Split('|')[90];
                    TextBoxMenuRazdel2Punkt17.Text = line.Split('|')[91];
                    TextBoxMenuRazdel2Punkt17Hiperlink.Text = line.Split('|')[92];
                    TextBoxMenuRazdel2Punkt18.Text = line.Split('|')[93];
                    TextBoxMenuRazdel2Punkt18Hiperlink.Text = line.Split('|')[94];
                    TextBoxMenuRazdel2Punkt19.Text = line.Split('|')[95];
                    TextBoxMenuRazdel2Punkt19Hiperlink.Text = line.Split('|')[96];
                    TextBoxMenuRazdel2Punkt20.Text = line.Split('|')[97];
                    TextBoxMenuRazdel2Punkt20Hiperlink.Text = line.Split('|')[98];
                    TextBoxMenuRazdel2Punkt21.Text = line.Split('|')[99];
                    TextBoxMenuRazdel2Punkt21Hiperlink.Text = line.Split('|')[100];
                    TextBoxMenuRazdel2Punkt22.Text = line.Split('|')[101];
                    TextBoxMenuRazdel2Punkt22Hiperlink.Text = line.Split('|')[102];
                    TextBoxMenuRazdel2Punkt23.Text = line.Split('|')[103];
                    TextBoxMenuRazdel2Punkt23Hiperlink.Text = line.Split('|')[104];
                    TextBoxMenuRazdel2Punkt24.Text = line.Split('|')[105];
                    TextBoxMenuRazdel2Punkt24Hiperlink.Text = line.Split('|')[106];
                    TextBoxMenuRazdel2Punkt25.Text = line.Split('|')[107];
                    TextBoxMenuRazdel2Punkt25Hiperlink.Text = line.Split('|')[108];


                    TextBoxMenuRazdel3.Text = line.Split('|')[109];
                    TextBoxMenuRazdel32.Text = line.Split('|')[110];

                    TextBoxMenuRazdel3Punkt1.Text = line.Split('|')[111];
                    TextBoxMenuRazdel3Punkt1Hiperlink.Text = line.Split('|')[112];
                    TextBoxMenuRazdel3Punkt2.Text = line.Split('|')[113];
                    TextBoxMenuRazdel3Punkt2Hiperlink.Text = line.Split('|')[114];
                    TextBoxMenuRazdel3Punkt3.Text = line.Split('|')[115];
                    TextBoxMenuRazdel3Punkt3Hiperlink.Text = line.Split('|')[116];
                    TextBoxMenuRazdel3Punkt4.Text = line.Split('|')[117];
                    TextBoxMenuRazdel3Punkt4Hiperlink.Text = line.Split('|')[118];
                    TextBoxMenuRazdel3Punkt5.Text = line.Split('|')[119];
                    TextBoxMenuRazdel3Punkt5Hiperlink.Text = line.Split('|')[120];
                    TextBoxMenuRazdel3Punkt6.Text = line.Split('|')[121];
                    TextBoxMenuRazdel3Punkt6Hiperlink.Text = line.Split('|')[122];
                    TextBoxMenuRazdel3Punkt7.Text = line.Split('|')[123];
                    TextBoxMenuRazdel3Punkt7Hiperlink.Text = line.Split('|')[124];
                    TextBoxMenuRazdel3Punkt8.Text = line.Split('|')[125];
                    TextBoxMenuRazdel3Punkt8Hiperlink.Text = line.Split('|')[126];
                    TextBoxMenuRazdel3Punkt9.Text = line.Split('|')[127];
                    TextBoxMenuRazdel3Punkt9Hiperlink.Text = line.Split('|')[128];
                    TextBoxMenuRazdel3Punkt10.Text = line.Split('|')[129];
                    TextBoxMenuRazdel3Punkt10Hiperlink.Text = line.Split('|')[130];
                    TextBoxMenuRazdel3Punkt11.Text = line.Split('|')[131];
                    TextBoxMenuRazdel3Punkt11Hiperlink.Text = line.Split('|')[132];
                    TextBoxMenuRazdel3Punkt12.Text = line.Split('|')[133];
                    TextBoxMenuRazdel3Punkt12Hiperlink.Text = line.Split('|')[134];
                    TextBoxMenuRazdel3Punkt13.Text = line.Split('|')[135];
                    TextBoxMenuRazdel3Punkt13Hiperlink.Text = line.Split('|')[136];
                    TextBoxMenuRazdel3Punkt14.Text = line.Split('|')[137];
                    TextBoxMenuRazdel3Punkt14Hiperlink.Text = line.Split('|')[138];
                    TextBoxMenuRazdel3Punkt15.Text = line.Split('|')[139];
                    TextBoxMenuRazdel3Punkt15Hiperlink.Text = line.Split('|')[140];
                    TextBoxMenuRazdel3Punkt16.Text = line.Split('|')[141];
                    TextBoxMenuRazdel3Punkt16Hiperlink.Text = line.Split('|')[142];
                    TextBoxMenuRazdel3Punkt17.Text = line.Split('|')[143];
                    TextBoxMenuRazdel3Punkt17Hiperlink.Text = line.Split('|')[144];
                    TextBoxMenuRazdel3Punkt18.Text = line.Split('|')[145];
                    TextBoxMenuRazdel3Punkt18Hiperlink.Text = line.Split('|')[146];
                    TextBoxMenuRazdel3Punkt19.Text = line.Split('|')[147];
                    TextBoxMenuRazdel3Punkt19Hiperlink.Text = line.Split('|')[148];
                    TextBoxMenuRazdel3Punkt20.Text = line.Split('|')[149];
                    TextBoxMenuRazdel3Punkt20Hiperlink.Text = line.Split('|')[150];
                    TextBoxMenuRazdel3Punkt21.Text = line.Split('|')[151];
                    TextBoxMenuRazdel3Punkt21Hiperlink.Text = line.Split('|')[152];
                    TextBoxMenuRazdel3Punkt22.Text = line.Split('|')[153];
                    TextBoxMenuRazdel3Punkt22Hiperlink.Text = line.Split('|')[154];
                    TextBoxMenuRazdel3Punkt23.Text = line.Split('|')[155];
                    TextBoxMenuRazdel3Punkt23Hiperlink.Text = line.Split('|')[156];
                    TextBoxMenuRazdel3Punkt24.Text = line.Split('|')[157];
                    TextBoxMenuRazdel3Punkt24Hiperlink.Text = line.Split('|')[158];
                    TextBoxMenuRazdel3Punkt25.Text = line.Split('|')[159];
                    TextBoxMenuRazdel3Punkt25Hiperlink.Text = line.Split('|')[160];



                    TextBoxMenuRazdel4.Text = line.Split('|')[161];
                    TextBoxMenuRazdel42.Text = line.Split('|')[162];

                    TextBoxMenuRazdel4Punkt1.Text = line.Split('|')[163];
                    TextBoxMenuRazdel4Punkt1Hiperlink.Text = line.Split('|')[164];
                    TextBoxMenuRazdel4Punkt2.Text = line.Split('|')[165];
                    TextBoxMenuRazdel4Punkt2Hiperlink.Text = line.Split('|')[166];
                    TextBoxMenuRazdel4Punkt3.Text = line.Split('|')[167];
                    TextBoxMenuRazdel4Punkt3Hiperlink.Text = line.Split('|')[168];
                    TextBoxMenuRazdel4Punkt4.Text = line.Split('|')[169];
                    TextBoxMenuRazdel4Punkt4Hiperlink.Text = line.Split('|')[170];
                    TextBoxMenuRazdel4Punkt5.Text = line.Split('|')[171];
                    TextBoxMenuRazdel4Punkt5Hiperlink.Text = line.Split('|')[172];
                    TextBoxMenuRazdel4Punkt6.Text = line.Split('|')[173];
                    TextBoxMenuRazdel4Punkt6Hiperlink.Text = line.Split('|')[174];
                    TextBoxMenuRazdel4Punkt7.Text = line.Split('|')[175];
                    TextBoxMenuRazdel4Punkt7Hiperlink.Text = line.Split('|')[176];
                    TextBoxMenuRazdel4Punkt8.Text = line.Split('|')[177];
                    TextBoxMenuRazdel4Punkt8Hiperlink.Text = line.Split('|')[178];
                    TextBoxMenuRazdel4Punkt9.Text = line.Split('|')[179];
                    TextBoxMenuRazdel4Punkt9Hiperlink.Text = line.Split('|')[180];
                    TextBoxMenuRazdel4Punkt10.Text = line.Split('|')[181];
                    TextBoxMenuRazdel4Punkt10Hiperlink.Text = line.Split('|')[182];
                    TextBoxMenuRazdel4Punkt11.Text = line.Split('|')[183];
                    TextBoxMenuRazdel4Punkt11Hiperlink.Text = line.Split('|')[184];
                    TextBoxMenuRazdel4Punkt12.Text = line.Split('|')[185];
                    TextBoxMenuRazdel4Punkt12Hiperlink.Text = line.Split('|')[186];
                    TextBoxMenuRazdel4Punkt13.Text = line.Split('|')[187];
                    TextBoxMenuRazdel4Punkt13Hiperlink.Text = line.Split('|')[188];
                    TextBoxMenuRazdel4Punkt14.Text = line.Split('|')[189];
                    TextBoxMenuRazdel4Punkt14Hiperlink.Text = line.Split('|')[190];
                    TextBoxMenuRazdel4Punkt15.Text = line.Split('|')[191];
                    TextBoxMenuRazdel4Punkt15Hiperlink.Text = line.Split('|')[192];
                    TextBoxMenuRazdel4Punkt16.Text = line.Split('|')[193];
                    TextBoxMenuRazdel4Punkt16Hiperlink.Text = line.Split('|')[194];
                    TextBoxMenuRazdel4Punkt17.Text = line.Split('|')[195];
                    TextBoxMenuRazdel4Punkt17Hiperlink.Text = line.Split('|')[196];
                    TextBoxMenuRazdel4Punkt18.Text = line.Split('|')[197];
                    TextBoxMenuRazdel4Punkt18Hiperlink.Text = line.Split('|')[198];
                    TextBoxMenuRazdel4Punkt19.Text = line.Split('|')[199];
                    TextBoxMenuRazdel4Punkt19Hiperlink.Text = line.Split('|')[200];
                    TextBoxMenuRazdel4Punkt20.Text = line.Split('|')[201];
                    TextBoxMenuRazdel4Punkt20Hiperlink.Text = line.Split('|')[202];
                    TextBoxMenuRazdel4Punkt21.Text = line.Split('|')[203];
                    TextBoxMenuRazdel4Punkt21Hiperlink.Text = line.Split('|')[204];
                    TextBoxMenuRazdel4Punkt22.Text = line.Split('|')[205];
                    TextBoxMenuRazdel4Punkt22Hiperlink.Text = line.Split('|')[206];
                    TextBoxMenuRazdel4Punkt23.Text = line.Split('|')[207];
                    TextBoxMenuRazdel4Punkt23Hiperlink.Text = line.Split('|')[208];
                    TextBoxMenuRazdel4Punkt24.Text = line.Split('|')[209];
                    TextBoxMenuRazdel4Punkt24Hiperlink.Text = line.Split('|')[210];
                    TextBoxMenuRazdel4Punkt25.Text = line.Split('|')[211];
                    TextBoxMenuRazdel4Punkt25Hiperlink.Text = line.Split('|')[212];



                    TextBoxMenuRazdel5.Text = line.Split('|')[213];
                    TextBoxMenuRazdel52.Text = line.Split('|')[214];

                    TextBoxMenuRazdel5Punkt1.Text = line.Split('|')[215];
                    TextBoxMenuRazdel5Punkt1Hiperlink.Text = line.Split('|')[216];
                    TextBoxMenuRazdel5Punkt2.Text = line.Split('|')[217];
                    TextBoxMenuRazdel5Punkt2Hiperlink.Text = line.Split('|')[218];
                    TextBoxMenuRazdel5Punkt3.Text = line.Split('|')[219];
                    TextBoxMenuRazdel5Punkt3Hiperlink.Text = line.Split('|')[220];
                    TextBoxMenuRazdel5Punkt4.Text = line.Split('|')[221];
                    TextBoxMenuRazdel5Punkt4Hiperlink.Text = line.Split('|')[222];
                    TextBoxMenuRazdel5Punkt5.Text = line.Split('|')[223];
                    TextBoxMenuRazdel5Punkt5Hiperlink.Text = line.Split('|')[224];
                    TextBoxMenuRazdel5Punkt6.Text = line.Split('|')[225];
                    TextBoxMenuRazdel5Punkt6Hiperlink.Text = line.Split('|')[226];
                    TextBoxMenuRazdel5Punkt7.Text = line.Split('|')[227];
                    TextBoxMenuRazdel5Punkt7Hiperlink.Text = line.Split('|')[228];
                    TextBoxMenuRazdel5Punkt8.Text = line.Split('|')[229];
                    TextBoxMenuRazdel5Punkt8Hiperlink.Text = line.Split('|')[230];
                    TextBoxMenuRazdel5Punkt9.Text = line.Split('|')[231];
                    TextBoxMenuRazdel5Punkt9Hiperlink.Text = line.Split('|')[232];
                    TextBoxMenuRazdel5Punkt10.Text = line.Split('|')[233];
                    TextBoxMenuRazdel5Punkt10Hiperlink.Text = line.Split('|')[234];
                    TextBoxMenuRazdel5Punkt11.Text = line.Split('|')[235];
                    TextBoxMenuRazdel5Punkt11Hiperlink.Text = line.Split('|')[236];
                    TextBoxMenuRazdel5Punkt12.Text = line.Split('|')[237];
                    TextBoxMenuRazdel5Punkt12Hiperlink.Text = line.Split('|')[238];
                    TextBoxMenuRazdel5Punkt13.Text = line.Split('|')[239];
                    TextBoxMenuRazdel5Punkt13Hiperlink.Text = line.Split('|')[240];
                    TextBoxMenuRazdel5Punkt14.Text = line.Split('|')[241];
                    TextBoxMenuRazdel5Punkt14Hiperlink.Text = line.Split('|')[242];
                    TextBoxMenuRazdel5Punkt15.Text = line.Split('|')[243];
                    TextBoxMenuRazdel5Punkt15Hiperlink.Text = line.Split('|')[244];
                    TextBoxMenuRazdel5Punkt16.Text = line.Split('|')[245];
                    TextBoxMenuRazdel5Punkt16Hiperlink.Text = line.Split('|')[246];
                    TextBoxMenuRazdel5Punkt17.Text = line.Split('|')[247];
                    TextBoxMenuRazdel5Punkt17Hiperlink.Text = line.Split('|')[248];
                    TextBoxMenuRazdel5Punkt18.Text = line.Split('|')[249];
                    TextBoxMenuRazdel5Punkt18Hiperlink.Text = line.Split('|')[250];
                    TextBoxMenuRazdel5Punkt19.Text = line.Split('|')[251];
                    TextBoxMenuRazdel5Punkt19Hiperlink.Text = line.Split('|')[252];
                    TextBoxMenuRazdel5Punkt20.Text = line.Split('|')[253];
                    TextBoxMenuRazdel5Punkt20Hiperlink.Text = line.Split('|')[254];
                    TextBoxMenuRazdel5Punkt21.Text = line.Split('|')[255];
                    TextBoxMenuRazdel5Punkt21Hiperlink.Text = line.Split('|')[256];
                    TextBoxMenuRazdel5Punkt22.Text = line.Split('|')[257];
                    TextBoxMenuRazdel5Punkt22Hiperlink.Text = line.Split('|')[258];
                    TextBoxMenuRazdel5Punkt23.Text = line.Split('|')[259];
                    TextBoxMenuRazdel5Punkt23Hiperlink.Text = line.Split('|')[260];
                    TextBoxMenuRazdel5Punkt24.Text = line.Split('|')[261];
                    TextBoxMenuRazdel5Punkt24Hiperlink.Text = line.Split('|')[262];
                    TextBoxMenuRazdel5Punkt25.Text = line.Split('|')[263];
                    TextBoxMenuRazdel5Punkt25Hiperlink.Text = line.Split('|')[264];
                    TextBoxBackgroundColor.Text = line.Split('|')[265];
                    TextBoxShrift.Text= line.Split('|')[266];
                    TextBoxShriftTel.Text = line.Split('|')[267];

                    TextBoxFTPServer.Text = line.Split('|')[268];
                    TextBoxFTPUser.Text = line.Split('|')[269];
                    TextBoxFTPPass.Password = line.Split('|')[270];

                    try { TextBoxSTYLENavigation.Text = line.Split('|')[271]; }
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

        private async void SaveFileMain_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            var savePicker4 = new Windows.Storage.Pickers.FileSavePicker();
            savePicker4.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Поле выбора типа файла в диалоге
            savePicker4.FileTypeChoices.Add("Файл навигационного меню", new List<string>() { ".main" });
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





                await FileIO.WriteTextAsync(Myfile4, TextBoxName.Text+"|"+
                    TextBoxSlogan.Text + "|" +TextBoxLogo.Text + "|" 
                    +TextBoxTel.Text + "|" +
                TextBoxGorod.Text + "|" +
                TextBoxMenuRazdel1.Text +"|"+
                TextBoxMenuRazdel12.Text +"|"+

                TextBoxMenuRazdel1Punkt1.Text +"|"+
                TextBoxMenuRazdel1Punkt1Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt2.Text +"|"+
                TextBoxMenuRazdel1Punkt2Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt3.Text +"|"+
                TextBoxMenuRazdel1Punkt3Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt4.Text +"|"+
                TextBoxMenuRazdel1Punkt4Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt5.Text +"|"+
                TextBoxMenuRazdel1Punkt5Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt6.Text +"|"+
                TextBoxMenuRazdel1Punkt6Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt7.Text +"|"+
                TextBoxMenuRazdel1Punkt7Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt8.Text +"|"+
                TextBoxMenuRazdel1Punkt8Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt9.Text +"|"+
                TextBoxMenuRazdel1Punkt9Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt10.Text +"|"+
                TextBoxMenuRazdel1Punkt10Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt11.Text +"|"+
                TextBoxMenuRazdel1Punkt11Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt12.Text +"|"+
                TextBoxMenuRazdel1Punkt12Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt13.Text +"|"+
                TextBoxMenuRazdel1Punkt13Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt14.Text +"|"+
                TextBoxMenuRazdel1Punkt14Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt15.Text +"|"+
                TextBoxMenuRazdel1Punkt15Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt16.Text +"|"+
                TextBoxMenuRazdel1Punkt16Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt17.Text +"|"+
                TextBoxMenuRazdel1Punkt17Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt18.Text +"|"+
                TextBoxMenuRazdel1Punkt18Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt19.Text +"|"+
                TextBoxMenuRazdel1Punkt19Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt20.Text +"|"+
                TextBoxMenuRazdel1Punkt20Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt21.Text +"|"+
                TextBoxMenuRazdel1Punkt21Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt22.Text +"|"+
                TextBoxMenuRazdel1Punkt22Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt23.Text +"|"+
                TextBoxMenuRazdel1Punkt23Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt24.Text +"|"+
                TextBoxMenuRazdel1Punkt24Hiperlink.Text +"|"+
                TextBoxMenuRazdel1Punkt25.Text +"|"+
                TextBoxMenuRazdel1Punkt25Hiperlink.Text +"|"+




                TextBoxMenuRazdel2.Text +"|"+
                TextBoxMenuRazdel22.Text +"|"+

                TextBoxMenuRazdel2Punkt1.Text +"|"+
                TextBoxMenuRazdel2Punkt1Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt2.Text +"|"+
                TextBoxMenuRazdel2Punkt2Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt3.Text +"|"+
                TextBoxMenuRazdel2Punkt3Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt4.Text +"|"+
                TextBoxMenuRazdel2Punkt4Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt5.Text +"|"+
                TextBoxMenuRazdel2Punkt5Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt6.Text +"|"+
                TextBoxMenuRazdel2Punkt6Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt7.Text +"|"+
                TextBoxMenuRazdel2Punkt7Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt8.Text +"|"+
                TextBoxMenuRazdel2Punkt8Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt9.Text +"|"+
                TextBoxMenuRazdel2Punkt9Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt10.Text +"|"+
                TextBoxMenuRazdel2Punkt10Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt11.Text +"|"+
                TextBoxMenuRazdel2Punkt11Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt12.Text +"|"+
                TextBoxMenuRazdel2Punkt12Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt13.Text +"|"+
                TextBoxMenuRazdel2Punkt13Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt14.Text +"|"+
                TextBoxMenuRazdel2Punkt14Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt15.Text +"|"+
                TextBoxMenuRazdel2Punkt15Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt16.Text +"|"+
                TextBoxMenuRazdel2Punkt16Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt17.Text +"|"+
                TextBoxMenuRazdel2Punkt17Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt18.Text +"|"+
                TextBoxMenuRazdel2Punkt18Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt19.Text +"|"+
                TextBoxMenuRazdel2Punkt19Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt20.Text +"|"+
                TextBoxMenuRazdel2Punkt20Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt21.Text +"|"+
                TextBoxMenuRazdel2Punkt21Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt22.Text +"|"+
                TextBoxMenuRazdel2Punkt22Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt23.Text +"|"+
                TextBoxMenuRazdel2Punkt23Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt24.Text +"|"+
                TextBoxMenuRazdel2Punkt24Hiperlink.Text +"|"+
                TextBoxMenuRazdel2Punkt25.Text +"|"+
                TextBoxMenuRazdel2Punkt25Hiperlink.Text +"|"+


                TextBoxMenuRazdel3.Text +"|"+
                TextBoxMenuRazdel32.Text +"|"+

                TextBoxMenuRazdel3Punkt1.Text +"|"+
                TextBoxMenuRazdel3Punkt1Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt2.Text +"|"+
                TextBoxMenuRazdel3Punkt2Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt3.Text +"|"+
                TextBoxMenuRazdel3Punkt3Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt4.Text +"|"+
                TextBoxMenuRazdel3Punkt4Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt5.Text +"|"+
                TextBoxMenuRazdel3Punkt5Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt6.Text +"|"+
                TextBoxMenuRazdel3Punkt6Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt7.Text +"|"+
                TextBoxMenuRazdel3Punkt7Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt8.Text +"|"+
                TextBoxMenuRazdel3Punkt8Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt9.Text +"|"+
                TextBoxMenuRazdel3Punkt9Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt10.Text +"|"+
                TextBoxMenuRazdel3Punkt10Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt11.Text +"|"+
                TextBoxMenuRazdel3Punkt11Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt12.Text +"|"+
                TextBoxMenuRazdel3Punkt12Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt13.Text +"|"+
                TextBoxMenuRazdel3Punkt13Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt14.Text +"|"+
                TextBoxMenuRazdel3Punkt14Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt15.Text +"|"+
                TextBoxMenuRazdel3Punkt15Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt16.Text +"|"+
                TextBoxMenuRazdel3Punkt16Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt17.Text +"|"+
                TextBoxMenuRazdel3Punkt17Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt18.Text +"|"+
                TextBoxMenuRazdel3Punkt18Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt19.Text +"|"+
                TextBoxMenuRazdel3Punkt19Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt20.Text +"|"+
                TextBoxMenuRazdel3Punkt20Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt21.Text +"|"+
                TextBoxMenuRazdel3Punkt21Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt22.Text +"|"+
                TextBoxMenuRazdel3Punkt22Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt23.Text +"|"+
                TextBoxMenuRazdel3Punkt23Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt24.Text +"|"+
                TextBoxMenuRazdel3Punkt24Hiperlink.Text +"|"+
                TextBoxMenuRazdel3Punkt25.Text +"|"+
                TextBoxMenuRazdel3Punkt25Hiperlink.Text +"|"+



                TextBoxMenuRazdel4.Text +"|"+
                TextBoxMenuRazdel42.Text +"|"+

                TextBoxMenuRazdel4Punkt1.Text +"|"+
                TextBoxMenuRazdel4Punkt1Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt2.Text +"|"+
                TextBoxMenuRazdel4Punkt2Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt3.Text +"|"+
                TextBoxMenuRazdel4Punkt3Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt4.Text +"|"+
                TextBoxMenuRazdel4Punkt4Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt5.Text +"|"+
                TextBoxMenuRazdel4Punkt5Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt6.Text +"|"+
                TextBoxMenuRazdel4Punkt6Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt7.Text +"|"+
                TextBoxMenuRazdel4Punkt7Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt8.Text +"|"+
                TextBoxMenuRazdel4Punkt8Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt9.Text +"|"+
                TextBoxMenuRazdel4Punkt9Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt10.Text +"|"+
                TextBoxMenuRazdel4Punkt10Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt11.Text +"|"+
                TextBoxMenuRazdel4Punkt11Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt12.Text +"|"+
                TextBoxMenuRazdel4Punkt12Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt13.Text +"|"+
                TextBoxMenuRazdel4Punkt13Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt14.Text +"|"+
                TextBoxMenuRazdel4Punkt14Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt15.Text +"|"+
                TextBoxMenuRazdel4Punkt15Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt16.Text +"|"+
                TextBoxMenuRazdel4Punkt16Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt17.Text +"|"+
                TextBoxMenuRazdel4Punkt17Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt18.Text +"|"+
                TextBoxMenuRazdel4Punkt18Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt19.Text +"|"+
                TextBoxMenuRazdel4Punkt19Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt20.Text +"|"+
                TextBoxMenuRazdel4Punkt20Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt21.Text +"|"+
                TextBoxMenuRazdel4Punkt21Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt22.Text +"|"+
                TextBoxMenuRazdel4Punkt22Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt23.Text +"|"+
                TextBoxMenuRazdel4Punkt23Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt24.Text +"|"+
                TextBoxMenuRazdel4Punkt24Hiperlink.Text +"|"+
                TextBoxMenuRazdel4Punkt25.Text +"|"+
                TextBoxMenuRazdel4Punkt25Hiperlink.Text +"|"+



                TextBoxMenuRazdel5.Text +"|"+
                TextBoxMenuRazdel52.Text +"|"+

                TextBoxMenuRazdel5Punkt1.Text +"|"+
                TextBoxMenuRazdel5Punkt1Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt2.Text +"|"+
                TextBoxMenuRazdel5Punkt2Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt3.Text +"|"+
                TextBoxMenuRazdel5Punkt3Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt4.Text +"|"+
                TextBoxMenuRazdel5Punkt4Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt5.Text +"|"+
                TextBoxMenuRazdel5Punkt5Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt6.Text +"|"+
                TextBoxMenuRazdel5Punkt6Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt7.Text +"|"+
                TextBoxMenuRazdel5Punkt7Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt8.Text +"|"+
                TextBoxMenuRazdel5Punkt8Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt9.Text +"|"+
                TextBoxMenuRazdel5Punkt9Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt10.Text +"|"+
                TextBoxMenuRazdel5Punkt10Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt11.Text +"|"+
                TextBoxMenuRazdel5Punkt11Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt12.Text +"|"+
                TextBoxMenuRazdel5Punkt12Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt13.Text +"|"+
                TextBoxMenuRazdel5Punkt13Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt14.Text +"|"+
                TextBoxMenuRazdel5Punkt14Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt15.Text +"|"+
                TextBoxMenuRazdel5Punkt15Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt16.Text +"|"+
                TextBoxMenuRazdel5Punkt16Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt17.Text +"|"+
                TextBoxMenuRazdel5Punkt17Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt18.Text +"|"+
                TextBoxMenuRazdel5Punkt18Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt19.Text +"|"+
                TextBoxMenuRazdel5Punkt19Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt20.Text +"|"+
                TextBoxMenuRazdel5Punkt20Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt21.Text +"|"+
                TextBoxMenuRazdel5Punkt21Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt22.Text +"|"+
                TextBoxMenuRazdel5Punkt22Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt23.Text +"|"+
                TextBoxMenuRazdel5Punkt23Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt24.Text +"|"+
                TextBoxMenuRazdel5Punkt24Hiperlink.Text +"|"+
                TextBoxMenuRazdel5Punkt25.Text +"|"+
                TextBoxMenuRazdel5Punkt25Hiperlink.Text +"|"+
                TextBoxBackgroundColor.Text+"|"+
                TextBoxShrift.Text+"|"+
                TextBoxShriftTel.Text+"|"+
                
                TextBoxFTPServer.Text+"|"+
                TextBoxFTPUser.Text + "|" +
                TextBoxFTPPass.Password + "|"+TextBoxSTYLENavigation.Text+"|");






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

                    this.StatusFile.Text = "Файл навигационного меню " + Myfile4.Name + " успешно сохранен.";
                    Progress.IsActive = false;

                    var messagedialogFile = new MessageDialog("Файл навигационного меню " + Myfile4.Name + " успешно сохранен.");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл навигационного меню " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialogFile = new MessageDialog("Не удалось сохранить файл навигационного меню " + Myfile4.Name + ".");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла навигационного меню была прервана.";
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
            savePicker4.FileTypeChoices.Add("TPL файл навигационного меню", new List<string>() { ".tpl" });
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

                await FileIO.WriteTextAsync(Myfile4, "< !-- ================================= НАЧАЛО КОДА ФИКСИРОВАННОГО НАВИГАЦИОННОГО МЕНЮ ========================================= --> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<nav class=\"navbar navbar-default navbar-fixed-top\" style=\"background:"+TextBoxBackgroundColor.Text+ ";" + TextBoxSTYLENavigation.Text + "\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"container\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div class=\"navbar-header\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<button type= \"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar\" aria-expanded=\"false\" aria-controls=\"navbar\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"sr-only\">Переключатель навигации</span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"icon-bar\"></span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"icon-bar\"></span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<span class=\"icon-bar\"></span> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "</button> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<a href = \"index.php\"><img class=\"navbar-brand\" src=\"" + TextBoxLogo.Text + "\" style=\"width:70px; height:65px; text-align:left;\"></a><p class=\"navbar-brand\" style=\"font-family: "+TextBoxShrift.Text+"; font-size:21px; line-height:18px; text-align:left;\">" + TextBoxName.Text + "<br><span style=\"font-size:12px;\"> " + TextBoxSlogan.Text + "</span></p> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "</div> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<div id = \"navbar\" class=\"navbar-collapse collapse\" style=\"font-family: "+TextBoxShrift.Text+";\"> \r\n");
                await FileIO.AppendTextAsync(Myfile4, "<ul class=\"nav navbar-nav\"> \r\n");

                //////////////////////РАЗДЕЛ 1/////////////////////////////////////////////////////
                if (TextBoxMenuRazdel1.Text.Length != 0) 
                {
                    if (TextBoxMenuRazdel12.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel1.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                        //////////////////////Подразделы меню////////////////////////////////////////////
                        if (TextBoxMenuRazdel1Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt1.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt1.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n");  } else { if (TextBoxMenuRazdel1Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\""+TextBoxMenuRazdel1Punkt1Hiperlink.Text+"\">"+TextBoxMenuRazdel1Punkt1.Text+"</a></li> \r\n"); } else {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt1.Text + "</li> \r\n");} }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt2.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt2.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt2.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt2.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt3.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt3.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt3.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt3.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt4.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt4.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt4.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt4.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt5.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt5.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt5.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt5.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt6.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt6.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt6.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt6.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt7.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt7.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt7.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt7.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt8.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt8.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt8.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt8.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt9.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt9.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt9.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt9.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt10.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt10.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt10.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt10.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt11.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt11.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt11.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt11.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt12.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt12.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt12.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt12.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt13.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt13.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt13.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt13.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt14.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt14.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt14.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt14.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt15.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt15.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt15.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt15.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt16.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt16.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt16.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt16.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt17.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt17.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt17.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt17.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel1Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt18.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt18.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt18.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt18.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt19.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt19.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt19.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt19.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt20.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt20.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt20.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt20.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt21.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt21.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt21.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt21.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel1Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt22.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt22.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt22.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt22.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel1Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt23.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt23.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt23.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt23.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt24.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt24.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt24.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt24.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel1Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt25.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel1Punkt25.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel1Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel1Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt25.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt25.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                        await FileIO.AppendTextAsync(Myfile4, "</ul> \r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel12.Text + "\">" + TextBoxMenuRazdel1.Text + "</a></li>\r\n"); }
                }
                await FileIO.AppendTextAsync(Myfile4, "</li> \r\n");
                //////////////////////КОНЕЦ РАЗДЕЛ 1/////////////////////////////////////////////////////


                //////////////////////РАЗДЕЛ 2/////////////////////////////////////////////////////
                if (TextBoxMenuRazdel2.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel22.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel2.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                        //////////////////////Подразделы меню////////////////////////////////////////////
                        if (TextBoxMenuRazdel2Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt1.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt1.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt1.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt1.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt2.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt2.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt2.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt2.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt3.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt3.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt3.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt3.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt4.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt4.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt4.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt4.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt5.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt5.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt5.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt5.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt6.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt6.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt6.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt6.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt7.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt7.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt7.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt7.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt8.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt8.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt8.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt8.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt9.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt9.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt9.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt9.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt10.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt10.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt10.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt10.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt11.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt11.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt11.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt11.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt12.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt12.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt12.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt12.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt13.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt13.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt13.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt13.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt14.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt14.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt14.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt14.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt15.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt15.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt15.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt15.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt16.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt16.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt16.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt16.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt17.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt17.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt17.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt17.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel2Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt18.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt18.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt18.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt18.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt19.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt19.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt19.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt19.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt20.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt20.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt20.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt20.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt21.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt21.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt21.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt21.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel2Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt22.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt22.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt22.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt22.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel2Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt23.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt23.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt23.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt23.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt24.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt24.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt24.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt24.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel2Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt25.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel2Punkt25.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel2Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel2Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt25.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt25.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                        await FileIO.AppendTextAsync(Myfile4, "</ul> \r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel22.Text + "\">" + TextBoxMenuRazdel2.Text + "</a></li>\r\n"); }
                }
                await FileIO.AppendTextAsync(Myfile4, "</li> \r\n");
                //////////////////////КОНЕЦ РАЗДЕЛ 2/////////////////////////////////////////////////////



                //////////////////////РАЗДЕЛ 3/////////////////////////////////////////////////////
                if (TextBoxMenuRazdel3.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel32.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel3.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                        //////////////////////Подразделы меню////////////////////////////////////////////
                        if (TextBoxMenuRazdel3Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt1.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt1.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt1.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt1.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt2.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt2.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt2.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt2.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt3.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt3.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt3.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt3.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt4.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt4.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt4.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt4.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt5.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt5.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt5.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt5.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt6.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt6.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt6.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt6.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt7.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt7.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt7.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt7.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt8.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt8.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt8.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt8.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt9.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt9.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt9.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt9.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt10.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt10.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt10.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt10.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt11.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt11.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt11.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt11.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt12.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt12.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt12.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt12.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt13.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt13.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt13.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt13.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt14.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt14.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt14.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt14.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt15.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt15.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt15.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt15.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt16.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt16.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt16.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt16.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt17.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt17.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt17.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt17.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel3Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt18.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt18.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt18.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt18.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt19.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt19.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt19.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt19.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt20.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt20.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt20.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt20.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt21.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt21.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt21.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt21.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel3Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt22.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt22.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt22.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt22.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel3Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt23.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt23.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt23.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt23.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt24.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt24.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt24.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt24.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel3Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt25.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel3Punkt25.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel3Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel3Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt25.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt25.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                        await FileIO.AppendTextAsync(Myfile4, "</ul> \r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel32.Text + "\">" + TextBoxMenuRazdel3.Text + "</a></li>\r\n"); }
                }
                await FileIO.AppendTextAsync(Myfile4, "</li> \r\n");
                //////////////////////КОНЕЦ РАЗДЕЛ 3/////////////////////////////////////////////////////



                //////////////////////РАЗДЕЛ 4/////////////////////////////////////////////////////
                if (TextBoxMenuRazdel4.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel42.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel4.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                        //////////////////////Подразделы меню////////////////////////////////////////////
                        if (TextBoxMenuRazdel4Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt1.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt1.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt1.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt1.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt2.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt2.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt2.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt2.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt3.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt3.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt3.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt3.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt4.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt4.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt4.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt4.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt5.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt5.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt5.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt5.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt6.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt6.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt6.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt6.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt7.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt7.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt7.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt7.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt8.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt8.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt8.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt8.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt9.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt9.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt9.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt9.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt10.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt10.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt10.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt10.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt11.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt11.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt11.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt11.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt12.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt12.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt12.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt12.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt13.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt13.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt13.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt13.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt14.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt14.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt14.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt14.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt15.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt15.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt15.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt15.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt16.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt16.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt16.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt16.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt17.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt17.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt17.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt17.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel4Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt18.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt18.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt18.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt18.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt19.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt19.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt19.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt19.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt20.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt20.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt20.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt20.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt21.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt21.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt21.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt21.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel4Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt22.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt22.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt22.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt22.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel4Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt23.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt23.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt23.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt23.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt24.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt24.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt24.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt24.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel4Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt25.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel4Punkt25.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel4Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel4Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt25.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt25.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                        await FileIO.AppendTextAsync(Myfile4, "</ul> \r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel42.Text + "\">" + TextBoxMenuRazdel4.Text + "</a></li>\r\n"); }
                }
                await FileIO.AppendTextAsync(Myfile4, "</li> \r\n");
                //////////////////////КОНЕЦ РАЗДЕЛ 4/////////////////////////////////////////////////////



                //////////////////////РАЗДЕЛ 5/////////////////////////////////////////////////////
                if (TextBoxMenuRazdel5.Text.Length != 0)
                {
                    if (TextBoxMenuRazdel52.Text.Length == 0)
                    {
                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel5.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                        //////////////////////Подразделы меню////////////////////////////////////////////
                        if (TextBoxMenuRazdel5Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt1.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt1.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt1.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt1.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt2.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt2.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt2.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt2.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt3.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt3.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt3.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt3.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt4.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt4.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt4.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt4.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt5.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt5.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt5.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt5.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt6.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt6.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt6.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt6.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt7.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt7.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt7.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt7.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt8.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt8.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt8.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt8.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt9.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt9.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt9.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt9.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt10.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt10.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt10.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt10.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt11.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt11.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt11.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt11.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt12.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt12.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt12.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt12.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt13.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt13.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt13.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt13.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt14.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt14.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt14.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt14.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt15.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt15.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt15.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt15.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt16.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt16.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt16.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt16.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt17.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt17.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt17.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt17.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel5Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt18.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt18.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt18.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt18.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt19.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt19.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt19.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt19.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt20.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt20.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt20.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt20.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt21.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt21.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt21.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt21.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }


                        if (TextBoxMenuRazdel5Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt22.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt22.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt22.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt22.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }



                        if (TextBoxMenuRazdel5Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt23.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt23.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt23.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt23.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt24.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt24.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt24.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt24.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        if (TextBoxMenuRazdel5Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt25.Text.Length != 0)
                            {
                                if (TextBoxMenuRazdel5Punkt25.Text == "#") { await FileIO.AppendTextAsync(Myfile4, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                                else
                                {
                                    if (TextBoxMenuRazdel5Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(Myfile4, "<li><a href=\"" + TextBoxMenuRazdel5Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt25.Text + "</a></li> \r\n"); }
                                    else
                                    {
                                        await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt25.Text + "</li> \r\n");
                                    }
                                }
                            }
                        }

                        //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                        await FileIO.AppendTextAsync(Myfile4, "</ul> \r\n");
                    }
                    else { await FileIO.AppendTextAsync(Myfile4, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel52.Text + "\">" + TextBoxMenuRazdel5.Text + "</a></li>\r\n"); }
                }
                await FileIO.AppendTextAsync(Myfile4, "</li> \r\n");
                //////////////////////КОНЕЦ РАЗДЕЛ 5/////////////////////////////////////////////////////



                await FileIO.AppendTextAsync(Myfile4, "</ul><ul class=\"nav navbar-nav navbar-right\"><li><p style=\"font-family:"+TextBoxShriftTel.Text+",Helvetica Neue,Arial,sans-serif; font-size:18px; line-height:18px; text-align:right;\" class=\"navbar-brand\" id=\"tel\">" + TextBoxTel.Text + "<br><span style=\"font-size:12px; font-family:"+TextBoxShrift.Text+"; text-align:right;\" > " + TextBoxGorod.Text + "</span></p></li></ul></div><!--/.nav-collapse --></div></nav>\r\n <!-- ================================КОНЕЦ КОДА НАВИГАЦИОННОГО МЕНЮ================================== --!>");







                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
        Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(Myfile4);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    this.StatusFile.Text = "TPL файл навигационного меню " + Myfile4.Name + " успешно экспортирован.";

                    FileTextBox.Text = "";


                    string text1 = await Windows.Storage.FileIO.ReadTextAsync(Myfile4);
                    string text02 = text1.Replace("\r\n", "  "); string text002 = text02.Replace("\n", "  "); string text2 = text002.Replace("\r", "  ");

                    FileTextBox.Text = text2;

                    Progress.IsActive = false;

                    var messagedialogFile = new MessageDialog("TPL файл навигационного меню " + Myfile4.Name + " успешно экспортирован.");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить TPL-файл навигационного меню " + Myfile4.Name + ".";
                    Progress.IsActive = false;

                    var messagedialogFile = new MessageDialog("Не удалось сохранить TPL-файл навигационного меню " + Myfile4.Name + ".");
                    messagedialogFile.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи TPL-файла навигационного меню была прервана.";
                Progress.IsActive = false;
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

                var messagedialogFile1 = new MessageDialog("Файл успешно выгружен на FTP сервер.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }

            catch 
            {
                StatusFile.Text = "Невозможно соединиться с сервером FTP: неправильное имя пользователя или пароль, либо сервер недоступен.";
                Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Невозможно соединиться с сервером FTP: неправильное имя пользователя или пароль, либо сервер недоступен.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
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
            savePicker4.FileTypeChoices.Add("Файл навигационного меню", new List<string>() { ".main" });
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





                await FileIO.WriteTextAsync(Myfile4, TextBoxName.Text + "|" +
                    TextBoxSlogan.Text + "|" + TextBoxLogo.Text + "|"
                    + TextBoxTel.Text + "|" +
                TextBoxGorod.Text + "|" +
                TextBoxMenuRazdel1.Text + "|" +
                TextBoxMenuRazdel12.Text + "|" +

                TextBoxMenuRazdel1Punkt1.Text + "|" +
                TextBoxMenuRazdel1Punkt1Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt2.Text + "|" +
                TextBoxMenuRazdel1Punkt2Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt3.Text + "|" +
                TextBoxMenuRazdel1Punkt3Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt4.Text + "|" +
                TextBoxMenuRazdel1Punkt4Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt5.Text + "|" +
                TextBoxMenuRazdel1Punkt5Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt6.Text + "|" +
                TextBoxMenuRazdel1Punkt6Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt7.Text + "|" +
                TextBoxMenuRazdel1Punkt7Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt8.Text + "|" +
                TextBoxMenuRazdel1Punkt8Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt9.Text + "|" +
                TextBoxMenuRazdel1Punkt9Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt10.Text + "|" +
                TextBoxMenuRazdel1Punkt10Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt11.Text + "|" +
                TextBoxMenuRazdel1Punkt11Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt12.Text + "|" +
                TextBoxMenuRazdel1Punkt12Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt13.Text + "|" +
                TextBoxMenuRazdel1Punkt13Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt14.Text + "|" +
                TextBoxMenuRazdel1Punkt14Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt15.Text + "|" +
                TextBoxMenuRazdel1Punkt15Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt16.Text + "|" +
                TextBoxMenuRazdel1Punkt16Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt17.Text + "|" +
                TextBoxMenuRazdel1Punkt17Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt18.Text + "|" +
                TextBoxMenuRazdel1Punkt18Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt19.Text + "|" +
                TextBoxMenuRazdel1Punkt19Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt20.Text + "|" +
                TextBoxMenuRazdel1Punkt20Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt21.Text + "|" +
                TextBoxMenuRazdel1Punkt21Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt22.Text + "|" +
                TextBoxMenuRazdel1Punkt22Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt23.Text + "|" +
                TextBoxMenuRazdel1Punkt23Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt24.Text + "|" +
                TextBoxMenuRazdel1Punkt24Hiperlink.Text + "|" +
                TextBoxMenuRazdel1Punkt25.Text + "|" +
                TextBoxMenuRazdel1Punkt25Hiperlink.Text + "|" +




                TextBoxMenuRazdel2.Text + "|" +
                TextBoxMenuRazdel22.Text + "|" +

                TextBoxMenuRazdel2Punkt1.Text + "|" +
                TextBoxMenuRazdel2Punkt1Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt2.Text + "|" +
                TextBoxMenuRazdel2Punkt2Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt3.Text + "|" +
                TextBoxMenuRazdel2Punkt3Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt4.Text + "|" +
                TextBoxMenuRazdel2Punkt4Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt5.Text + "|" +
                TextBoxMenuRazdel2Punkt5Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt6.Text + "|" +
                TextBoxMenuRazdel2Punkt6Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt7.Text + "|" +
                TextBoxMenuRazdel2Punkt7Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt8.Text + "|" +
                TextBoxMenuRazdel2Punkt8Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt9.Text + "|" +
                TextBoxMenuRazdel2Punkt9Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt10.Text + "|" +
                TextBoxMenuRazdel2Punkt10Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt11.Text + "|" +
                TextBoxMenuRazdel2Punkt11Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt12.Text + "|" +
                TextBoxMenuRazdel2Punkt12Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt13.Text + "|" +
                TextBoxMenuRazdel2Punkt13Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt14.Text + "|" +
                TextBoxMenuRazdel2Punkt14Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt15.Text + "|" +
                TextBoxMenuRazdel2Punkt15Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt16.Text + "|" +
                TextBoxMenuRazdel2Punkt16Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt17.Text + "|" +
                TextBoxMenuRazdel2Punkt17Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt18.Text + "|" +
                TextBoxMenuRazdel2Punkt18Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt19.Text + "|" +
                TextBoxMenuRazdel2Punkt19Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt20.Text + "|" +
                TextBoxMenuRazdel2Punkt20Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt21.Text + "|" +
                TextBoxMenuRazdel2Punkt21Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt22.Text + "|" +
                TextBoxMenuRazdel2Punkt22Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt23.Text + "|" +
                TextBoxMenuRazdel2Punkt23Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt24.Text + "|" +
                TextBoxMenuRazdel2Punkt24Hiperlink.Text + "|" +
                TextBoxMenuRazdel2Punkt25.Text + "|" +
                TextBoxMenuRazdel2Punkt25Hiperlink.Text + "|" +


                TextBoxMenuRazdel3.Text + "|" +
                TextBoxMenuRazdel32.Text + "|" +

                TextBoxMenuRazdel3Punkt1.Text + "|" +
                TextBoxMenuRazdel3Punkt1Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt2.Text + "|" +
                TextBoxMenuRazdel3Punkt2Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt3.Text + "|" +
                TextBoxMenuRazdel3Punkt3Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt4.Text + "|" +
                TextBoxMenuRazdel3Punkt4Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt5.Text + "|" +
                TextBoxMenuRazdel3Punkt5Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt6.Text + "|" +
                TextBoxMenuRazdel3Punkt6Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt7.Text + "|" +
                TextBoxMenuRazdel3Punkt7Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt8.Text + "|" +
                TextBoxMenuRazdel3Punkt8Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt9.Text + "|" +
                TextBoxMenuRazdel3Punkt9Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt10.Text + "|" +
                TextBoxMenuRazdel3Punkt10Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt11.Text + "|" +
                TextBoxMenuRazdel3Punkt11Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt12.Text + "|" +
                TextBoxMenuRazdel3Punkt12Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt13.Text + "|" +
                TextBoxMenuRazdel3Punkt13Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt14.Text + "|" +
                TextBoxMenuRazdel3Punkt14Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt15.Text + "|" +
                TextBoxMenuRazdel3Punkt15Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt16.Text + "|" +
                TextBoxMenuRazdel3Punkt16Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt17.Text + "|" +
                TextBoxMenuRazdel3Punkt17Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt18.Text + "|" +
                TextBoxMenuRazdel3Punkt18Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt19.Text + "|" +
                TextBoxMenuRazdel3Punkt19Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt20.Text + "|" +
                TextBoxMenuRazdel3Punkt20Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt21.Text + "|" +
                TextBoxMenuRazdel3Punkt21Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt22.Text + "|" +
                TextBoxMenuRazdel3Punkt22Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt23.Text + "|" +
                TextBoxMenuRazdel3Punkt23Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt24.Text + "|" +
                TextBoxMenuRazdel3Punkt24Hiperlink.Text + "|" +
                TextBoxMenuRazdel3Punkt25.Text + "|" +
                TextBoxMenuRazdel3Punkt25Hiperlink.Text + "|" +



                TextBoxMenuRazdel4.Text + "|" +
                TextBoxMenuRazdel42.Text + "|" +

                TextBoxMenuRazdel4Punkt1.Text + "|" +
                TextBoxMenuRazdel4Punkt1Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt2.Text + "|" +
                TextBoxMenuRazdel4Punkt2Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt3.Text + "|" +
                TextBoxMenuRazdel4Punkt3Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt4.Text + "|" +
                TextBoxMenuRazdel4Punkt4Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt5.Text + "|" +
                TextBoxMenuRazdel4Punkt5Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt6.Text + "|" +
                TextBoxMenuRazdel4Punkt6Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt7.Text + "|" +
                TextBoxMenuRazdel4Punkt7Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt8.Text + "|" +
                TextBoxMenuRazdel4Punkt8Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt9.Text + "|" +
                TextBoxMenuRazdel4Punkt9Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt10.Text + "|" +
                TextBoxMenuRazdel4Punkt10Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt11.Text + "|" +
                TextBoxMenuRazdel4Punkt11Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt12.Text + "|" +
                TextBoxMenuRazdel4Punkt12Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt13.Text + "|" +
                TextBoxMenuRazdel4Punkt13Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt14.Text + "|" +
                TextBoxMenuRazdel4Punkt14Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt15.Text + "|" +
                TextBoxMenuRazdel4Punkt15Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt16.Text + "|" +
                TextBoxMenuRazdel4Punkt16Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt17.Text + "|" +
                TextBoxMenuRazdel4Punkt17Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt18.Text + "|" +
                TextBoxMenuRazdel4Punkt18Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt19.Text + "|" +
                TextBoxMenuRazdel4Punkt19Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt20.Text + "|" +
                TextBoxMenuRazdel4Punkt20Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt21.Text + "|" +
                TextBoxMenuRazdel4Punkt21Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt22.Text + "|" +
                TextBoxMenuRazdel4Punkt22Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt23.Text + "|" +
                TextBoxMenuRazdel4Punkt23Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt24.Text + "|" +
                TextBoxMenuRazdel4Punkt24Hiperlink.Text + "|" +
                TextBoxMenuRazdel4Punkt25.Text + "|" +
                TextBoxMenuRazdel4Punkt25Hiperlink.Text + "|" +



                TextBoxMenuRazdel5.Text + "|" +
                TextBoxMenuRazdel52.Text + "|" +

                TextBoxMenuRazdel5Punkt1.Text + "|" +
                TextBoxMenuRazdel5Punkt1Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt2.Text + "|" +
                TextBoxMenuRazdel5Punkt2Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt3.Text + "|" +
                TextBoxMenuRazdel5Punkt3Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt4.Text + "|" +
                TextBoxMenuRazdel5Punkt4Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt5.Text + "|" +
                TextBoxMenuRazdel5Punkt5Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt6.Text + "|" +
                TextBoxMenuRazdel5Punkt6Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt7.Text + "|" +
                TextBoxMenuRazdel5Punkt7Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt8.Text + "|" +
                TextBoxMenuRazdel5Punkt8Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt9.Text + "|" +
                TextBoxMenuRazdel5Punkt9Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt10.Text + "|" +
                TextBoxMenuRazdel5Punkt10Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt11.Text + "|" +
                TextBoxMenuRazdel5Punkt11Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt12.Text + "|" +
                TextBoxMenuRazdel5Punkt12Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt13.Text + "|" +
                TextBoxMenuRazdel5Punkt13Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt14.Text + "|" +
                TextBoxMenuRazdel5Punkt14Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt15.Text + "|" +
                TextBoxMenuRazdel5Punkt15Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt16.Text + "|" +
                TextBoxMenuRazdel5Punkt16Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt17.Text + "|" +
                TextBoxMenuRazdel5Punkt17Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt18.Text + "|" +
                TextBoxMenuRazdel5Punkt18Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt19.Text + "|" +
                TextBoxMenuRazdel5Punkt19Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt20.Text + "|" +
                TextBoxMenuRazdel5Punkt20Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt21.Text + "|" +
                TextBoxMenuRazdel5Punkt21Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt22.Text + "|" +
                TextBoxMenuRazdel5Punkt22Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt23.Text + "|" +
                TextBoxMenuRazdel5Punkt23Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt24.Text + "|" +
                TextBoxMenuRazdel5Punkt24Hiperlink.Text + "|" +
                TextBoxMenuRazdel5Punkt25.Text + "|" +
                TextBoxMenuRazdel5Punkt25Hiperlink.Text + "|" +
                TextBoxBackgroundColor.Text + "|" +
                TextBoxShrift.Text + "|" +
                TextBoxShriftTel.Text + "|" +

                TextBoxFTPServer.Text + "|" +
                TextBoxFTPUser.Text + "|" +
                TextBoxFTPPass.Password + "|" + TextBoxSTYLENavigation.Text + "|");






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

                    this.StatusFile.Text = "Файл навигационного меню " + Myfile4.Name + " успешно сохранен.";

                    var messagedialogFile1 = new MessageDialog("Файл навигационного меню " + Myfile4.Name + " успешно сохранен.");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
                else
                {
                    this.StatusFile.Text = "Не удалось сохранить файл навигационного меню " + Myfile4.Name + ".";

                    var messagedialogFile1 = new MessageDialog("Не удалось сохранить файл навигационного меню " + Myfile4.Name + ".");
                    messagedialogFile1.Commands.Add(new UICommand("Ok"));
                    await messagedialogFile1.ShowAsync();
                }
            }
            else
            {
                this.StatusFile.Text = "Операция записи файла навигационного меню была прервана.";

                var messagedialogFile1 = new MessageDialog("Операция записи файла навигационного меню была прервана.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();
            }

            ///////////////////////////////////////////////////////////////////////////////

            StorageFolder localFolderUPLOAD = ApplicationData.Current.LocalFolder;
            StorageFile UPLOADFile = await localFolderUPLOAD.CreateFileAsync("upload.txt", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(UPLOADFile, "< !-- ================================= НАЧАЛО КОДА ФИКСИРОВАННОГО НАВИГАЦИОННОГО МЕНЮ ========================================= --> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<nav class=\"navbar navbar-default navbar-fixed-top\" style=\"background:" + TextBoxBackgroundColor.Text + ";"+TextBoxSTYLENavigation.Text+"\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"container\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div class=\"navbar-header\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<button type= \"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar\" aria-expanded=\"false\" aria-controls=\"navbar\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"sr-only\">Переключатель навигации</span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"icon-bar\"></span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"icon-bar\"></span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<span class=\"icon-bar\"></span> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</button> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<a href = \"index.php\"><img class=\"navbar-brand\" src=\"" + TextBoxLogo.Text + "\" style=\"width:70px; height:65px; text-align:left;\"></a><p class=\"navbar-brand\" style=\"font-family: " + TextBoxShrift.Text + "; font-size:21px; line-height:18px; text-align:left;\">" + TextBoxName.Text + "<br><span style=\"font-size:12px;\"> " + TextBoxSlogan.Text + "</span></p> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "</div> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<div id = \"navbar\" class=\"navbar-collapse collapse\" style=\"font-family: " + TextBoxShrift.Text + ";\"> \r\n");
            await FileIO.AppendTextAsync(UPLOADFile, "<ul class=\"nav navbar-nav\"> \r\n");

            //////////////////////РАЗДЕЛ 1/////////////////////////////////////////////////////
            if (TextBoxMenuRazdel1.Text.Length != 0)
            {
                if (TextBoxMenuRazdel12.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel1.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                    //////////////////////Подразделы меню////////////////////////////////////////////
                    if (TextBoxMenuRazdel1Punkt1.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt1.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt1.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt1.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt2.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt2.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt2.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt2.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt3.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt3.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt3.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt3.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt4.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt4.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt4.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt4.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt5.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt5.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt5.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt5.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt6.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt6.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt6.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt6.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt7.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt7.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt7.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt7.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt8.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt8.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt8.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt8.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt9.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt9.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt9.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt9.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt10.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt10.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt10.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt10.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt11.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt11.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt11.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt11.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt12.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt12.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt12.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt12.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt13.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt13.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt13.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt13.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt14.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt14.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt14.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt14.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt15.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt15.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt15.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt15.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt16.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt16.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt16.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt16.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt17.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt17.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt17.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt17.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel1Punkt18.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt18.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt18.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt18.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt19.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt19.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt19.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt19.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt20.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt20.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt20.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt20.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt21.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt21.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt21.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt21.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel1Punkt22.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt22.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt22.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt22.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel1Punkt23.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt23.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt23.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt23.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt24.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt24.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt24.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt24.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel1Punkt25.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel1Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel1Punkt25.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel1Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel1Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel1Punkt25.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel1Punkt25.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                    await FileIO.AppendTextAsync(UPLOADFile, "</ul> \r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel12.Text + "\">" + TextBoxMenuRazdel1.Text + "</a></li>\r\n"); }
            }
            await FileIO.AppendTextAsync(UPLOADFile, "</li> \r\n");
            //////////////////////КОНЕЦ РАЗДЕЛ 1/////////////////////////////////////////////////////


            //////////////////////РАЗДЕЛ 2/////////////////////////////////////////////////////
            if (TextBoxMenuRazdel2.Text.Length != 0)
            {
                if (TextBoxMenuRazdel22.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel2.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                    //////////////////////Подразделы меню////////////////////////////////////////////
                    if (TextBoxMenuRazdel2Punkt1.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt1.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt1.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt1.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt2.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt2.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt2.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt2.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt3.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt3.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt3.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt3.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt4.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt4.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt4.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt4.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt5.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt5.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt5.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt5.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt6.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt6.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt6.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt6.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt7.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt7.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt7.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt7.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt8.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt8.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt8.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt8.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt9.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt9.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt9.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt9.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt10.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt10.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt10.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt10.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt11.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt11.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt11.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt11.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt12.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt12.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt12.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt12.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt13.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt13.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt13.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt13.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt14.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt14.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt14.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt14.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt15.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt15.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt15.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt15.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt16.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt16.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt16.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt16.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt17.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt17.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt17.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt17.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel2Punkt18.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt18.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt18.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt18.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt19.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt19.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt19.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt19.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt20.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt20.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt20.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt20.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt21.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt21.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt21.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt21.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel2Punkt22.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt22.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt22.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt22.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel2Punkt23.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt23.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt23.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt23.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt24.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt24.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt24.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt24.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel2Punkt25.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel2Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel2Punkt25.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel2Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel2Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel2Punkt25.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel2Punkt25.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                    await FileIO.AppendTextAsync(UPLOADFile, "</ul> \r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel22.Text + "\">" + TextBoxMenuRazdel2.Text + "</a></li>\r\n"); }
            }
            await FileIO.AppendTextAsync(UPLOADFile, "</li> \r\n");
            //////////////////////КОНЕЦ РАЗДЕЛ 2/////////////////////////////////////////////////////



            //////////////////////РАЗДЕЛ 3/////////////////////////////////////////////////////
            if (TextBoxMenuRazdel3.Text.Length != 0)
            {
                if (TextBoxMenuRazdel32.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel3.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                    //////////////////////Подразделы меню////////////////////////////////////////////
                    if (TextBoxMenuRazdel3Punkt1.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt1.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt1.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt1.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt2.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt2.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt2.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt2.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt3.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt3.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt3.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt3.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt4.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt4.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt4.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt4.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt5.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt5.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt5.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt5.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt6.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt6.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt6.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt6.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt7.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt7.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt7.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt7.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt8.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt8.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt8.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt8.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt9.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt9.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt9.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt9.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt10.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt10.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt10.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt10.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt11.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt11.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt11.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt11.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt12.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt12.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt12.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt12.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt13.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt13.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt13.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt13.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt14.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt14.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt14.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt14.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt15.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt15.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt15.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt15.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt16.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt16.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt16.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt16.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt17.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt17.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt17.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt17.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel3Punkt18.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt18.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt18.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt18.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt19.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt19.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt19.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt19.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt20.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt20.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt20.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt20.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt21.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt21.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt21.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt21.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel3Punkt22.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt22.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt22.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt22.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel3Punkt23.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt23.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt23.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt23.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt24.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt24.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt24.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt24.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel3Punkt25.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel3Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel3Punkt25.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel3Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel3Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel3Punkt25.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel3Punkt25.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                    await FileIO.AppendTextAsync(UPLOADFile, "</ul> \r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel32.Text + "\">" + TextBoxMenuRazdel3.Text + "</a></li>\r\n"); }
            }
            await FileIO.AppendTextAsync(UPLOADFile, "</li> \r\n");
            //////////////////////КОНЕЦ РАЗДЕЛ 3/////////////////////////////////////////////////////



            //////////////////////РАЗДЕЛ 4/////////////////////////////////////////////////////
            if (TextBoxMenuRazdel4.Text.Length != 0)
            {
                if (TextBoxMenuRazdel42.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel4.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                    //////////////////////Подразделы меню////////////////////////////////////////////
                    if (TextBoxMenuRazdel4Punkt1.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt1.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt1.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt1.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt2.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt2.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt2.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt2.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt3.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt3.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt3.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt3.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt4.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt4.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt4.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt4.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt5.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt5.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt5.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt5.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt6.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt6.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt6.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt6.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt7.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt7.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt7.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt7.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt8.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt8.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt8.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt8.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt9.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt9.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt9.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt9.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt10.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt10.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt10.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt10.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt11.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt11.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt11.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt11.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt12.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt12.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt12.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt12.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt13.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt13.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt13.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt13.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt14.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt14.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt14.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt14.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt15.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt15.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt15.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt15.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt16.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt16.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt16.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt16.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt17.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt17.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt17.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt17.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel4Punkt18.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt18.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt18.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt18.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt19.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt19.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt19.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt19.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt20.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt20.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt20.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt20.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt21.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt21.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt21.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt21.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel4Punkt22.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt22.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt22.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt22.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel4Punkt23.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt23.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt23.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt23.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt24.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt24.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt24.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt24.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel4Punkt25.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel4Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel4Punkt25.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel4Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel4Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel4Punkt25.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel4Punkt25.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                    await FileIO.AppendTextAsync(UPLOADFile, "</ul> \r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel42.Text + "\">" + TextBoxMenuRazdel4.Text + "</a></li>\r\n"); }
            }
            await FileIO.AppendTextAsync(UPLOADFile, "</li> \r\n");
            //////////////////////КОНЕЦ РАЗДЕЛ 4/////////////////////////////////////////////////////



            //////////////////////РАЗДЕЛ 5/////////////////////////////////////////////////////
            if (TextBoxMenuRazdel5.Text.Length != 0)
            {
                if (TextBoxMenuRazdel52.Text.Length == 0)
                {
                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href =\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-haspopup=\"true\" aria-expanded=\"false\">" + TextBoxMenuRazdel5.Text + "<span class=\"caret\"></span></a><ul class=\"dropdown-menu\">\r\n");


                    //////////////////////Подразделы меню////////////////////////////////////////////
                    if (TextBoxMenuRazdel5Punkt1.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt1.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt1.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt1Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt1Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt1.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt1.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt2.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt2.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt2.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt2Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt2Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt2.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt2.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt3.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt3.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt3.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt3Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt3Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt3.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt3.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt4.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt4.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt4.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt4Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt4Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt4.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt4.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt5.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt5.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt5.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt5Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt5Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt5.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt5.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt6.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt6.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt6.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt6Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt6Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt6.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt6.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt7.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt7.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt7.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt7Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt7Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt7.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt7.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt8.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt8.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt8.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt8Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt8Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt8.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt8.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt9.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt9.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt9.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt9Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt9Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt9.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt9.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt10.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt10.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt10.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt10Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt10Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt10.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt10.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt11.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt11.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt11.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt11Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt11Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt11.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt11.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt12.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt12.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt12.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt12Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt12Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt12.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt12.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt13.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt13.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt13.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt13Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt13Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt13.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt13.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt14.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt14.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt14.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt14Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt14Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt14.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt14.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt15.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt15.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt15.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt15Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt15Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt15.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt15.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt16.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt16.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt16.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt16Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt16Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt16.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt16.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt17.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt17.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt17.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt17Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt17Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt17.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt17.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel5Punkt18.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt18.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt18.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt18Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt18Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt18.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt18.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt19.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt19.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt19.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt19Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt19Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt19.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt19.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt20.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt20.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt20.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt20Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt20Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt20.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt20.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt21.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt21.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt21.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt21Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt21Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt21.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt21.Text + "</li> \r\n");
                                }
                            }
                        }
                    }


                    if (TextBoxMenuRazdel5Punkt22.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt22.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt22.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt22Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt22Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt22.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt22.Text + "</li> \r\n");
                                }
                            }
                        }
                    }



                    if (TextBoxMenuRazdel5Punkt23.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt23.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt23.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt23Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt23Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt23.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt23.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt24.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt24.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt24.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt24Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt24Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt24.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt24.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    if (TextBoxMenuRazdel5Punkt25.Text.Length != 0)
                    {
                        if (TextBoxMenuRazdel5Punkt25.Text.Length != 0)
                        {
                            if (TextBoxMenuRazdel5Punkt25.Text == "#") { await FileIO.AppendTextAsync(UPLOADFile, "<li role=\"separator\" class=\"divider\"></li> \r\n"); }
                            else
                            {
                                if (TextBoxMenuRazdel5Punkt25Hiperlink.Text.Length != 0) { await FileIO.AppendTextAsync(UPLOADFile, "<li><a href=\"" + TextBoxMenuRazdel5Punkt25Hiperlink.Text + "\">" + TextBoxMenuRazdel5Punkt25.Text + "</a></li> \r\n"); }
                                else
                                {
                                    await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown-header\">" + TextBoxMenuRazdel5Punkt25.Text + "</li> \r\n");
                                }
                            }
                        }
                    }

                    //////////////////////КОНЕЦ Подразделы меню////////////////////////////////////////////
                    await FileIO.AppendTextAsync(UPLOADFile, "</ul> \r\n");
                }
                else { await FileIO.AppendTextAsync(UPLOADFile, "<li class=\"dropdown\"><a href = \"" + TextBoxMenuRazdel52.Text + "\">" + TextBoxMenuRazdel5.Text + "</a></li>\r\n"); }
            }
            await FileIO.AppendTextAsync(UPLOADFile, "</li> \r\n");
            //////////////////////КОНЕЦ РАЗДЕЛ 5/////////////////////////////////////////////////////



            await FileIO.AppendTextAsync(UPLOADFile, "</ul><ul class=\"nav navbar-nav navbar-right\"><li><p style=\"font-family:" + TextBoxShriftTel.Text + ",Helvetica Neue,Arial,sans-serif; font-size:18px; line-height:18px; text-align:right;\" class=\"navbar-brand\" id=\"tel\">" + TextBoxTel.Text + "<br><span style=\"font-size:12px; font-family:" + TextBoxShrift.Text + "; text-align:right;\" > " + TextBoxGorod.Text + "</span></p></li></ul></div><!--/.nav-collapse --></div></nav>\r\n <!-- ================================КОНЕЦ КОДА НАВИГАЦИОННОГО МЕНЮ================================== --!>");



            ///////////////////////////////////////////////////////////////////////////////

            string text11 = await Windows.Storage.FileIO.ReadTextAsync(UPLOADFile);
            string text102 = text11.Replace("\r\n", "  "); string text1002 = text102.Replace("\n", "  "); string text12 = text1002.Replace("\r", "  ");

            FileTextBox.Text = text12;

            ///////////////////////////////////////////////////////////////////////////////

            if (TextBoxFTPServer.Text != "")
            {
                DoDownloadOrUpload(false); ////см.проект kiewic ftp client 
            }

            else { StatusFile.Text = "Ошибка. Введите адрес FTP сервера.";
                Progress.IsActive = false;

                var messagedialogFile1 = new MessageDialog("Ошибка. Введите адрес FTP сервера.");
                messagedialogFile1.Commands.Add(new UICommand("Ok"));
                await messagedialogFile1.ShowAsync();

            }

            Progress.IsActive = false;
        }

        private void ButtonOpenCloseRazdel1_Click(object sender, RoutedEventArgs e)
        {
            string ButtonStatus = ButtonOpenCloseRazdel1.Content.ToString();


            if (ButtonStatus == "+")
            {
                StackPanelRazdel1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ButtonOpenCloseRazdel1.Content = "-";
            }

            if (ButtonStatus == "-")
            {
                StackPanelRazdel1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ButtonOpenCloseRazdel1.Content = "+";
            }
        }

        private void ButtonOpenCloseRazdel2_Click(object sender, RoutedEventArgs e)
        {
            string ButtonStatus = ButtonOpenCloseRazdel2.Content.ToString();


            if (ButtonStatus == "+")
            {
                StackPanelRazdel2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ButtonOpenCloseRazdel2.Content = "-";
            }

            if (ButtonStatus == "-")
            {
                StackPanelRazdel2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ButtonOpenCloseRazdel2.Content = "+";
            }
        }

        private void ButtonOpenCloseRazdel3_Click(object sender, RoutedEventArgs e)
        {
            string ButtonStatus = ButtonOpenCloseRazdel3.Content.ToString();


            if (ButtonStatus == "+")
            {
                StackPanelRazdel3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ButtonOpenCloseRazdel3.Content = "-";
            }

            if (ButtonStatus == "-")
            {
                StackPanelRazdel3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ButtonOpenCloseRazdel3.Content = "+";
            }
        }

        private void ButtonOpenCloseRazdel5_Click(object sender, RoutedEventArgs e)
        {
            string ButtonStatus = ButtonOpenCloseRazdel5.Content.ToString();


            if (ButtonStatus == "+")
            {
                StackPanelRazdel5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ButtonOpenCloseRazdel5.Content = "-";
            }

            if (ButtonStatus == "-")
            {
                StackPanelRazdel5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ButtonOpenCloseRazdel5.Content = "+";
            }
        }

        private void ButtonOpenCloseRazdel4_Click(object sender, RoutedEventArgs e)
        {
            string ButtonStatus = ButtonOpenCloseRazdel4.Content.ToString();


            if (ButtonStatus == "+")
            {
                StackPanelRazdel4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ButtonOpenCloseRazdel4.Content = "-";
            }

            if (ButtonStatus == "-")
            {
                StackPanelRazdel4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ButtonOpenCloseRazdel4.Content = "+";
            }
        }
    }
    }


