using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPI_Ribbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API Training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITraining\";

            var panel = application.CreateRibbonPanel(tabName, "Приложения");

            var button1 = new PushButtonData("Задание 5.1", "Создание кнопок",
                Path.Combine(utilsFolderPath, "RevitAPI_task5.dll"), /*отдельно не сохранил это задание, поэтому тут  "Задание 5.2"*/
                "RevitAPI_task5.Main");

            var button2 = new PushButtonData("Задание 5.2", "Изменение типов стен",
                Path.Combine(utilsFolderPath, "RevitAPI_task5.dll"), 
                "RevitAPI_task5.Main");

            Uri uriImage1 = new Uri(@"C:\Program Files\RevitAPITraining\Images\RevitAPITrainingUI_32_2.png", UriKind.Absolute);
            BitmapImage LargeImage1 = new BitmapImage(uriImage1);
            button1.LargeImage = LargeImage1;

            Uri uriImage2 = new Uri(@"C:\Program Files\RevitAPITraining\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage LargeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = LargeImage2;

            panel.AddItem(button1);
            panel.AddItem(button2);

            return Result.Succeeded;
        }
    }
}
