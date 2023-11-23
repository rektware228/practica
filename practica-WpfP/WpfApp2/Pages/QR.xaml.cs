
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для QR.xaml
    /// </summary>
    public partial class QR : Page
    {
        public QR()
        {
            InitializeComponent();
            CreateQr();
        }


        private void CreateQr()
        {
            string soucer_xl = "https://web.telegram.org/";     // Создание переменной библиотеки QRCoder
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();     // Присваеваем значиения
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);     // переводим в Qr
            QRCoder.QRCode code = new QRCoder.QRCode(data); Bitmap bitmap = code.GetGraphic(100);
            /// Создание картинки   
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp); 
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory; bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit(); imageQr.Source = bitmapimage;
            }
        }
    }
}
