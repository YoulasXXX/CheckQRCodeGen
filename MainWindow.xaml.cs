using CheckQRCodeGen.Models;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CheckQRCodeGen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateAndSetQRCodeImage();
        }

        public void GenerateAndSetQRCodeImage()
        {
            var users = DataBaseEntities.GetContext().Users.ToList();  // Получаем список пользователей из базы данных

            foreach (var user in users)
            {
                string dataUser = $"userId: {user.userId}, login: {user.login} etc..."; // Генерируем данные для QR-код

                QRCodeGenerator qrGenerator = new QRCodeGenerator();  // Создаем генератор QR-кода
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(dataUser, QRCodeGenerator.ECCLevel.Q);  // Генерируем данные для QR-кода
                QRCode qrCode = new QRCode(qrCodeData);  // Создаем QR-код на основе сгенерированных данных

                Bitmap qrCodeImage = qrCode.GetGraphic(20);  // Получаем изображение QR-кода

                using (MemoryStream memory = new MemoryStream())  // Сохраняем изображение QR-кода в памяти
                {
                    qrCodeImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);

                    user.userQRCODE = new BitmapImage();  // Создаем новый объект BitmapImage для хранения изображения QR-кода
                    user.userQRCODE.BeginInit();
                    user.userQRCODE.CacheOption = BitmapCacheOption.OnLoad;
                    user.userQRCODE.StreamSource = memory;  // Устанавливаем сохраненное изображение в качестве источника данных для BitmapImage
                    user.userQRCODE.EndInit();  // Завершаем инициализацию объекта BitmapImage
                }
            }

            DataBaseEntities.GetContext().SaveChanges();  // Сохраняем изменения в базе данных

            dgUsers.ItemsSource = null;  // Обнуляем источник данных для DataGrid
            dgUsers.ItemsSource = users;  // Устанавливаем список пользователей с QR-кодами в качестве нового источника данных для DataGrid
        }

    }
}
