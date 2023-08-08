using System;
using System.Collections.Generic;
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
using static System.Net.Mime.MediaTypeNames;

namespace MenuItem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Додавання строчки у файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_0_Click(object sender, RoutedEventArgs e)
        {
            TextAdd.Visibility = Visibility.Visible;
            Enter.Visibility = Visibility.Visible;


        }
        /// <summary>
        /// Створення 2х файлів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем два текстовых файла
                string fileName1 = "file1.txt";
                string fileName2 = "file2.txt";

                // Проверяем, существуют ли файлы, и если да, удаляем их
                if (File.Exists(fileName1))
                {
                    File.Delete(fileName1);
                }

                if (File.Exists(fileName2))
                {
                    File.Delete(fileName2);
                }

                // Записываем информацию в первый файл
                string content1 = "Привіт це файл 1!\n Це перший рядок файлу.\n.";
                File.WriteAllText(fileName1, content1);

                // Записываем информацию во второй файл
                string content2 = "Привіт це файл 2!\n Це другий рядок  другого файлу.\n.";
                File.WriteAllText(fileName2, content2);

                MessageBox.Show("Два файла створенні і заповененні");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Виникла помилка: " + ex.Message);
            }
        }

/// <summary>
/// Створення 3х списків та сортування їх за категорією
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    private void Add_2_Click(object sender, RoutedEventArgs e)
        {
            //  3 списка з файлу

            // Задаємо шлях до файлу
            string filePath = "List_toListBox.txt";

            // Створюємо словник для зберігання категорій
            Dictionary<char, List<string>> categories = new Dictionary<char, List<string>>();

            // Читаємо дані з файлу
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                // Розбиваємо дані на категорії
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        char categoryKey = Char.ToUpper(line[0]);

                        if (categoryKey >= 'A' && categoryKey <= 'P')
                        {
                            if (!categories.ContainsKey(categoryKey))
                            {
                                categories[categoryKey] = new List<string>();
                            }

                            categories[categoryKey].Add(line);
                        }
                    }
                }


                List<string> categoryA = categories.ContainsKey('A') ? categories['A'] : new List<string>();
                List<string> categoryB = categories.ContainsKey('B') ? categories['B'] : new List<string>();
                List<string> categoryC = categories.ContainsKey('P') ? categories['P'] : new List<string>();

                ////Виводимо результати

                foreach (string item in categoryA)
                {
                    LiB1.Items.Add(item);

                }

                foreach (string item in categoryB)
                {
                    LiB2.Items.Add(item );
                }

                foreach (string item in categoryC)
                {
                    LiB3.Items.Add(item );
                }

               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = TextAdd.Text;


            // Путь к файлу
            string filePath = "File.txt";

            // Створюємо екземпляр StreamWriter в режимі додавання 
            using (StreamWriter writer = File.AppendText(filePath))
            {
                // Записуєм текст у файл
                writer.WriteLine(text);
            }

            // Повідобмлення про успшних запис 
            MessageBox.Show("Інформація успешно додана у файл.");

            TextAdd.Visibility = Visibility.Hidden;
            Enter.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Відображаємо розмір файлу зі списками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemC2_Click(object sender, RoutedEventArgs e)
        {
            lblFileSize.Visibility = Visibility.Visible;
            string filePath = "List_toListBox.txt"; // Шлях до вашого файлу

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeInBytes = fileInfo.Length;

                // Конвертуємо розмір у зручний для читання формат (наприклад, кілобайти)
                string fileSizeText = FormatFileSize(fileSizeInBytes);

                lblFileSize.Content = $"Розмір файлу: {fileSizeText}";
            }
            catch (Exception ex)
            {
                lblFileSize.Content = $"Помилка: {ex.Message}";
            }

           
        }
        private string FormatFileSize(long fileSizeInBytes)
        {
            const int scale = 1024;
            string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            int order = 0;
            double size = fileSizeInBytes;

            while (size >= scale && order < sizeSuffixes.Length - 1)
            {
                order++;
                size = size / scale;
            }

            return $"{size:0.##} {sizeSuffixes[order]}";
        }

    }
}
//MenuItem 3 tab in 3 pages