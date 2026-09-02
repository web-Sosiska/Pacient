using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pacient
{
    public partial class Application2 : Form
    {
        public Application2()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Удаляем все нецифровые символы
            string digits = new string(guna2TextBox1.Text.Where(char.IsDigit).ToArray());

            // Ограничиваем длину (8 цифр для ДД.ММ.ГГГГ)
            if (digits.Length > 8)
            {
                digits = digits.Substring(0, 8);
            }

            // Форматируем дату с точками
            string formattedDate = "";
            if (digits.Length >= 1)
            {
                formattedDate = digits.Substring(0, Math.Min(2, digits.Length));
                if (digits.Length >= 2)
                {
                    formattedDate += ".";
                    if (digits.Length >= 4)
                    {
                        formattedDate += digits.Substring(2, Math.Min(2, digits.Length - 2));
                        if (digits.Length >= 4)
                        {
                            formattedDate += ".";
                            if (digits.Length >= 8)
                            {
                                formattedDate += digits.Substring(4, Math.Min(4, digits.Length - 4));
                            }
                            else if (digits.Length > 4)
                            {
                                formattedDate += digits.Substring(4, digits.Length - 4);
                            }
                        }
                    }
                    else if (digits.Length > 2)
                    {
                        formattedDate += digits.Substring(2, digits.Length - 2);
                    }
                }
            }

            // Обновляем текст, если он изменился
            if (guna2TextBox1.Text != formattedDate)
            {
                guna2TextBox1.Text = formattedDate;
                guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
                return;
            }

            // Валидация даты
            if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                if (guna2TextBox1.Text.Length == 10) // ДД.ММ.ГГГГ
                {
                    if (IsValidDate(guna2TextBox1.Text))
                    {
                        // Дата валидная - зеленый
                        guna2TextBox1.FillColor = Color.LightGreen;
                        guna2TextBox1.BorderColor = Color.Green;
                    }
                    else
                    {
                        // Дата невалидная - красный
                        guna2TextBox1.FillColor = Color.LightCoral;
                        guna2TextBox1.BorderColor = Color.Red;
                    }
                }
                else
                {
                    // Дата неполная - желтый
                    guna2TextBox1.FillColor = Color.LightYellow;
                    guna2TextBox1.BorderColor = Color.Orange;
                }
            }
            else
            {
                // Поле пустое - стандартный цвет
                guna2TextBox1.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox1.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidDate(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.ParseExact(date, "dd.MM.yyyy", null);

                // Проверяем, что дата не в будущем
                if (parsedDate > DateTime.Now)
                {
                    return false;
                }

                // Проверяем, что год не слишком старый (например, не раньше 1900)
                if (parsedDate.Year < 1900)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 1000;

            // Ограничение по длине
            if (guna2TextBox2.Text.Length > maxLength)
            {
                guna2TextBox2.Text = guna2TextBox2.Text.Substring(0, maxLength);
                guna2TextBox2.SelectionStart = guna2TextBox2.Text.Length;

                MessageBox.Show(
                    $"Описание не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на заполненность
            if (!string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                // Если поле заполнено - зеленый
                guna2TextBox2.FillColor = Color.LightGreen;
                guna2TextBox2.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox2.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox2.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Поле 'Дата подачи' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                MessageBox.Show("Поле 'Описание проблемы' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox2.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Поле 'Выбор врача' не выбрано!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            // Проверка загрузки PDF файла
            if (string.IsNullOrWhiteSpace(uploadedFilePath))
            {
                MessageBox.Show("PDF файл не загружен! Добавьте файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка загрузки изображения
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Изображение не загружено! Добавьте фото.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Получаем ID текущего пациента
                int patientId = GetCurrentPatientId();
                if (patientId == -1)
                {
                    MessageBox.Show(
                        "Сначала необходимо создать карточку пациента!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Читаем PDF файл в byte[]
                byte[] pdfBytes = File.ReadAllBytes(uploadedFilePath);

                // Конвертируем изображение в byte[]
                byte[] photoBytes = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        photoBytes = ms.ToArray();
                    }
                }

                // Создаем экземпляр DatabaseHelper и HospitalRepository
                DatabaseHelper dbHelper = new DatabaseHelper();
                HospitalRepository repository = new HospitalRepository(dbHelper);

                // Создаем объект Application
                Application application = new Application
                {
                    FK_IDCardpatient = patientId,
                    FailCard = pdfBytes,
                    Picture = photoBytes,
                    Description = guna2TextBox2.Text.Trim(),
                    Doctor_Name = comboBox1.SelectedItem.ToString()
                };

                // Сохраняем в базу данных
                repository.InsertApplication(application);

                MessageBox.Show(
                    $"Заявка успешно подана к выбранному врачу!\nВрач: {comboBox1.SelectedItem.ToString()}",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Очищаем поля после успешной отправки
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                uploadedFilePath = "";
                ClearPdfPanel();
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при сохранении заявки: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private int GetCurrentPatientId()
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                HospitalRepository repository = new HospitalRepository(dbHelper);
                var patients = repository.GetAllCardpatients();
                if (patients.Count > 0)
                {
                    return patients.Last().ID;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настройка фильтра для PDF файлов
                openFileDialog.Filter = "PDF файлы|*.pdf|Все файлы|*.*";
                openFileDialog.Title = "Выберите PDF файл";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Очищаем панель от предыдущих контролов (если есть)
                        guna2CustomGradientPanel5.Controls.Clear();

                        // Создаем PictureBox для отображения иконки PDF
                        PictureBox pdfPictureBox = new PictureBox
                        {
                            Size = new Size(64, 64),
                            Location = new Point(10, 10),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Image = GetPdfIcon()
                        };

                        // Создаем Label для отображения имени файла
                        Label pdfLabel = new Label
                        {
                            Text = Path.GetFileName(openFileDialog.FileName),
                            Location = new Point(80, 20),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            ForeColor = Color.DarkSlateGray
                        };

                        // Создаем Label для отображения размера файла
                        Label sizeLabel = new Label
                        {
                            Text = GetFileSize(openFileDialog.FileName),
                            Location = new Point(80, 45),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 8, FontStyle.Regular),
                            ForeColor = Color.Gray
                        };

                        // Создаем кнопку для открытия PDF
                        Guna.UI2.WinForms.Guna2Button openButton = new Guna.UI2.WinForms.Guna2Button
                        {
                            Text = "Открыть PDF",
                            Location = new Point(80, 65),
                            Size = new Size(100, 30),
                            FillColor = Color.DarkSlateGray,
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            Cursor = Cursors.Hand
                        };
                        openButton.Click += (s, args) => OpenPdfFile(openFileDialog.FileName);

                        // Создаем кнопку для удаления файла
                        Guna.UI2.WinForms.Guna2Button deleteButton = new Guna.UI2.WinForms.Guna2Button
                        {
                            Text = "✕",
                            Location = new Point(guna2CustomGradientPanel5.Width - 40, 5),
                            Size = new Size(30, 30),
                            FillColor = Color.Transparent,
                            ForeColor = Color.Red,
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            Cursor = Cursors.Hand
                        };
                        deleteButton.Click += (s, args) => ClearPdfPanel();

                        // Добавляем все контролы в панель
                        guna2CustomGradientPanel5.Controls.Add(pdfPictureBox);
                        guna2CustomGradientPanel5.Controls.Add(pdfLabel);
                        guna2CustomGradientPanel5.Controls.Add(sizeLabel);
                        guna2CustomGradientPanel5.Controls.Add(openButton);
                        guna2CustomGradientPanel5.Controls.Add(deleteButton);

                        // Сохраняем путь к файлу (можно использовать переменную класса)
                        uploadedFilePath = openFileDialog.FileName;

                        MessageBox.Show(
                            $"PDF файл успешно загружен!\nИмя: {Path.GetFileName(openFileDialog.FileName)}",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Ошибка при загрузке PDF: {ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
        private Image GetPdfIcon()
        {
            try
            {
                // Попытка получить иконку из системных ресурсов
                Icon pdfIcon = Icon.ExtractAssociatedIcon(Path.Combine(Environment.SystemDirectory, "shell32.dll"));
                if (pdfIcon != null)
                {
                    return pdfIcon.ToBitmap();
                }
            }
            catch
            {
                // Если не удалось получить системную иконку, создаем свою
            }

            // Создаем простую иконку PDF
            Bitmap bitmap = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                // Рисуем красный прямоугольник (как PDF)
                using (Brush brush = new SolidBrush(Color.FromArgb(255, 220, 50, 50)))
                {
                    g.FillRectangle(brush, 10, 10, 44, 54);
                }

                // Рисуем белую полоску
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, 10, 10, 44, 8);
                }

                // Рисуем текст "PDF"
                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.DrawString("PDF", font, brush, 12, 28);
                }
            }
            return bitmap;
        }

        // Метод для форматирования размера файла
        private string GetFileSize(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            long size = fileInfo.Length;

            string[] sizes = { "Б", "КБ", "МБ", "ГБ" };
            double len = size;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        // Метод для открытия PDF файла
        private void OpenPdfFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии PDF: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для очистки панели
        private void ClearPdfPanel()
        {
            guna2CustomGradientPanel5.Controls.Clear();
            uploadedFilePath = "";
        }

        // Переменная для хранения пути к загруженному файлу
        private string uploadedFilePath = "";

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настройка фильтра для изображений
                openFileDialog.Filter = "Изображения|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.ico;*.svg|Все файлы|*.*";
                openFileDialog.Title = "Выберите изображение";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Загружаем изображение в PictureBox
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        MessageBox.Show(
                            "Изображение успешно загружено!",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Ошибка при загрузке изображения: {ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
    }
}
