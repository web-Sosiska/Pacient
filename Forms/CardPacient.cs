using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pacient
{
    public partial class CardPacient : Form
    {
        public CardPacient()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------------------
        //Information User
        //---------------------------------------------------------------------------------------------------------------------
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 100;

            if (guna2TextBox1.Text.Length > maxLength)
            {
                guna2TextBox1.Text = guna2TextBox1.Text.Substring(0, maxLength);
                guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;

                // Подсвечиваем поле красным при превышении
                guna2TextBox1.FillColor = Color.LightCoral;
                guna2TextBox1.BorderColor = Color.Red;

                MessageBox.Show(
                    $"Имя не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else if (!string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                // Если поле заполнено и не превышает лимит - зеленый
                guna2TextBox1.FillColor = Color.LightGreen;
                guna2TextBox1.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - возвращаем стандартный цвет
                guna2TextBox1.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox1.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 100;

            if (guna2TextBox2.Text.Length > maxLength)
            {
                guna2TextBox2.Text = guna2TextBox2.Text.Substring(0, maxLength);
                guna2TextBox2.SelectionStart = guna2TextBox2.Text.Length;

                // Подсвечиваем поле красным при превышении
                guna2TextBox2.FillColor = Color.LightCoral;
                guna2TextBox2.BorderColor = Color.Red;

                MessageBox.Show(
                    $"Имя не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else if (!string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                // Если поле заполнено и не превышает лимит - зеленый
                guna2TextBox2.FillColor = Color.LightGreen;
                guna2TextBox2.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - возвращаем стандартный цвет
                guna2TextBox2.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox2.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 150;

            if (guna2TextBox3.Text.Length > maxLength)
            {
                guna2TextBox3.Text = guna2TextBox3.Text.Substring(0, maxLength);
                guna2TextBox3.SelectionStart = guna2TextBox3.Text.Length;

                // Подсвечиваем поле красным при превышении
                guna2TextBox3.FillColor = Color.LightCoral;
                guna2TextBox3.BorderColor = Color.Red;

                MessageBox.Show(
                    $"Имя не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else if (!string.IsNullOrWhiteSpace(guna2TextBox3.Text))
            {
                // Если поле заполнено и не превышает лимит - зеленый
                guna2TextBox3.FillColor = Color.LightGreen;
                guna2TextBox3.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - возвращаем стандартный цвет
                guna2TextBox3.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox3.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 255;

            // Ограничение по длине
            if (guna2TextBox4.Text.Length > maxLength)
            {
                guna2TextBox4.Text = guna2TextBox4.Text.Substring(0, maxLength);
                guna2TextBox4.SelectionStart = guna2TextBox4.Text.Length;

                MessageBox.Show(
                    $"Email не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на валидный email
            if (!string.IsNullOrWhiteSpace(guna2TextBox4.Text))
            {
                if (!IsValidEmail(guna2TextBox4.Text))
                {
                    // Подсвечиваем поле красным, если email невалидный
                    guna2TextBox4.FillColor = Color.LightCoral;
                    guna2TextBox4.BorderColor = Color.Red;
                }
                else
                {
                    // Возвращаем нормальный цвет, если email валидный
                    guna2TextBox4.FillColor = Color.LightGreen;
                    guna2TextBox4.BorderColor = Color.Green;
                }
            }
            else
            {
                // Если поле пустое, возвращаем нормальный цвет
                guna2TextBox4.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox4.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 11;

            // Ограничение по длине
            if (guna2TextBox5.Text.Length > maxLength)
            {
                guna2TextBox5.Text = guna2TextBox5.Text.Substring(0, maxLength);
                guna2TextBox5.SelectionStart = guna2TextBox5.Text.Length;

                MessageBox.Show(
                    $"Номер телефона не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на валидный номер телефона (только цифры)
            if (!string.IsNullOrWhiteSpace(guna2TextBox5.Text))
            {
                if (!IsValidPhoneNumber(guna2TextBox5.Text))
                {
                    // Подсвечиваем поле красным, если номер невалидный
                    guna2TextBox5.FillColor = Color.LightCoral;
                    guna2TextBox5.BorderColor = Color.Red;
                }
                else
                {
                    // Возвращаем нормальный цвет, если номер валидный
                    guna2TextBox5.FillColor = Color.LightGreen;
                    guna2TextBox5.BorderColor = Color.Green;
                }
            }
            else
            {
                // Если поле пустое, возвращаем нормальный цвет
                guna2TextBox5.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox5.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Проверяем, что строка состоит только из цифр
            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настройка фильтра для изображений
                openFileDialog.Filter = "Изображения|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.ico|SVG|*.svg|Все файлы|*.*";
                openFileDialog.Title = "Выберите аватарку";
                openFileDialog.FilterIndex = 1; // По умолчанию PNG/JPG
                openFileDialog.RestoreDirectory = true;

                // Показываем диалог и проверяем, выбрал ли пользователь файл
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Загружаем изображение в PictureBox
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                        // Опционально: растягиваем изображение в PictureBox
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        // Или можно использовать Zoom для сохранения пропорций
                        // pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        MessageBox.Show(
                            "Аватарка успешно загружена!",
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
        //---------------------------------------------------------------------------------------------------------------------
        //Passport
        //---------------------------------------------------------------------------------------------------------------------
        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 4;

            // Ограничение по длине
            if (guna2TextBox10.Text.Length > maxLength)
            {
                guna2TextBox10.Text = guna2TextBox10.Text.Substring(0, maxLength);
                guna2TextBox10.SelectionStart = guna2TextBox10.Text.Length;

                MessageBox.Show(
                    $"Серия паспорта должна содержать {maxLength} символа!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на валидную серию (только цифры)
            if (!string.IsNullOrWhiteSpace(guna2TextBox10.Text))
            {
                if (!IsValidPassportSeries(guna2TextBox10.Text))
                {
                    // Подсвечиваем поле красным, если серия невалидная
                    guna2TextBox10.FillColor = Color.LightCoral;
                    guna2TextBox10.BorderColor = Color.Red;
                }
                else if (guna2TextBox10.Text.Length == maxLength)
                {
                    // Если серия полная (4 символа) - зеленый
                    guna2TextBox10.FillColor = Color.LightGreen;
                    guna2TextBox10.BorderColor = Color.Green;
                }
                else
                {
                    // Если серия неполная, но валидная - желтый (предупреждение)
                    guna2TextBox10.FillColor = Color.LightYellow;
                    guna2TextBox10.BorderColor = Color.Orange;
                }
            }
            else
            {
                // Если поле пустое, возвращаем стандартный цвет
                guna2TextBox10.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox10.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidPassportSeries(string series)
        {
            // Проверяем, что строка состоит только из цифр
            foreach (char c in series)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 6;

            // Ограничение по длине
            if (guna2TextBox9.Text.Length > maxLength)
            {
                guna2TextBox9.Text = guna2TextBox9.Text.Substring(0, maxLength);
                guna2TextBox9.SelectionStart = guna2TextBox9.Text.Length;

                MessageBox.Show(
                    $"Номер паспорта должен содержать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на валидный номер (только цифры)
            if (!string.IsNullOrWhiteSpace(guna2TextBox9.Text))
            {
                if (!IsValidPassportNumber(guna2TextBox9.Text))
                {
                    // Подсвечиваем поле красным, если номер невалидный
                    guna2TextBox9.FillColor = Color.LightCoral;
                    guna2TextBox9.BorderColor = Color.Red;
                }
                else if (guna2TextBox9.Text.Length == maxLength)
                {
                    // Если номер полный (6 символов) - зеленый
                    guna2TextBox9.FillColor = Color.LightGreen;
                    guna2TextBox9.BorderColor = Color.Green;
                }
                else
                {
                    // Если номер неполный, но валидный - желтый (предупреждение)
                    guna2TextBox9.FillColor = Color.LightYellow;
                    guna2TextBox9.BorderColor = Color.Orange;
                }
            }
            else
            {
                // Если поле пустое, возвращаем стандартный цвет
                guna2TextBox9.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox9.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidPassportNumber(string number)
        {
            // Проверяем, что строка состоит только из цифр
            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 255;

            // Ограничение по длине
            if (guna2TextBox8.Text.Length > maxLength)
            {
                guna2TextBox8.Text = guna2TextBox8.Text.Substring(0, maxLength);
                guna2TextBox8.SelectionStart = guna2TextBox8.Text.Length;

                MessageBox.Show(
                    $"Название организации не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на заполненность и валидные символы
            if (!string.IsNullOrWhiteSpace(guna2TextBox8.Text))
            {
                if (!IsValidOrganizationName(guna2TextBox8.Text))
                {
                    // Подсвечиваем красным, если есть недопустимые символы
                    guna2TextBox8.FillColor = Color.LightCoral;
                    guna2TextBox8.BorderColor = Color.Red;
                }
                else
                {
                    // Если все валидно - зеленый
                    guna2TextBox8.FillColor = Color.LightGreen;
                    guna2TextBox8.BorderColor = Color.Green;
                }
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox8.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox8.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidOrganizationName(string name)
        {
            // Разрешаем: буквы, цифры, пробелы, точки, запятые, дефисы, кавычки, скобки
            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c) &&
                    c != ' ' && c != '.' && c != ',' && c != '-' &&
                    c != '\'' && c != '"' && c != '(' && c != ')' &&
                    c != '№' && c != '/' && c != '\\')
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            string digits = new string(guna2TextBox7.Text.Where(char.IsDigit).ToArray());

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
            if (guna2TextBox7.Text != formattedDate)
            {
                guna2TextBox7.Text = formattedDate;
                guna2TextBox7.SelectionStart = guna2TextBox7.Text.Length;
                return;
            }

            // Проверка валидности даты
            if (!string.IsNullOrWhiteSpace(guna2TextBox7.Text))
            {
                if (guna2TextBox7.Text.Length == 10) // ДД.ММ.ГГГГ
                {
                    if (IsValidDate(guna2TextBox7.Text))
                    {
                        guna2TextBox7.FillColor = Color.LightGreen;
                        guna2TextBox7.BorderColor = Color.Green;
                    }
                    else
                    {
                        guna2TextBox7.FillColor = Color.LightCoral;
                        guna2TextBox7.BorderColor = Color.Red;
                    }
                }
                else
                {
                    // Если дата неполная - желтый
                    guna2TextBox7.FillColor = Color.LightYellow;
                    guna2TextBox7.BorderColor = Color.Orange;
                }
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox7.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox7.BorderColor = Color.FromArgb(192, 192, 192);
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

                // Проверяем, что дата не слишком старая (например, не раньше 1900 года)
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
        //---------------------------------------------------------------------------------------------------------------------
        //Addres
        //---------------------------------------------------------------------------------------------------------------------
        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 6;

            // Ограничение по длине
            if (guna2TextBox13.Text.Length > maxLength)
            {
                guna2TextBox13.Text = guna2TextBox13.Text.Substring(0, maxLength);
                guna2TextBox13.SelectionStart = guna2TextBox13.Text.Length;

                MessageBox.Show(
                    $"Почтовый индекс должен содержать {maxLength} цифр!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на валидный почтовый индекс (только цифры)
            if (!string.IsNullOrWhiteSpace(guna2TextBox13.Text))
            {
                if (!IsValidPostalCode(guna2TextBox13.Text))
                {
                    // Подсвечиваем поле красным, если индекс невалидный
                    guna2TextBox13.FillColor = Color.LightCoral;
                    guna2TextBox13.BorderColor = Color.Red;
                }
                else if (guna2TextBox13.Text.Length == maxLength)
                {
                    // Если индекс полный (6 символов) - зеленый
                    guna2TextBox13.FillColor = Color.LightGreen;
                    guna2TextBox13.BorderColor = Color.Green;
                }
                else
                {
                    // Если индекс неполный, но валидный - желтый (предупреждение)
                    guna2TextBox13.FillColor = Color.LightYellow;
                    guna2TextBox13.BorderColor = Color.Orange;
                }
            }
            else
            {
                // Если поле пустое, возвращаем стандартный цвет
                guna2TextBox13.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox13.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidPostalCode(string postalCode)
        {
            // Проверяем, что строка состоит только из цифр
            foreach (char c in postalCode)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 150;

            // Ограничение по длине
            if (guna2TextBox12.Text.Length > maxLength)
            {
                guna2TextBox12.Text = guna2TextBox12.Text.Substring(0, maxLength);
                guna2TextBox12.SelectionStart = guna2TextBox12.Text.Length;

                MessageBox.Show(
                    $"Название региона не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на заполненность
            if (!string.IsNullOrWhiteSpace(guna2TextBox12.Text))
            {
                // Если поле заполнено - зеленый
                guna2TextBox12.FillColor = Color.LightGreen;
                guna2TextBox12.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox12.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox12.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 150;

            // Ограничение по длине
            if (guna2TextBox11.Text.Length > maxLength)
            {
                guna2TextBox11.Text = guna2TextBox11.Text.Substring(0, maxLength);
                guna2TextBox11.SelectionStart = guna2TextBox11.Text.Length;

                MessageBox.Show(
                    $"Название города не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на заполненность
            if (!string.IsNullOrWhiteSpace(guna2TextBox11.Text))
            {
                // Если поле заполнено - зеленый
                guna2TextBox11.FillColor = Color.LightGreen;
                guna2TextBox11.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox11.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox11.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 150;

            // Ограничение по длине
            if (guna2TextBox6.Text.Length > maxLength)
            {
                guna2TextBox6.Text = guna2TextBox6.Text.Substring(0, maxLength);
                guna2TextBox6.SelectionStart = guna2TextBox6.Text.Length;

                MessageBox.Show(
                    $"Название улицы не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на заполненность
            if (!string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                // Если поле заполнено - зеленый
                guna2TextBox6.FillColor = Color.LightGreen;
                guna2TextBox6.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox6.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox6.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 10;

            // Ограничение по длине
            if (guna2TextBox14.Text.Length > maxLength)
            {
                guna2TextBox14.Text = guna2TextBox14.Text.Substring(0, maxLength);
                guna2TextBox14.SelectionStart = guna2TextBox14.Text.Length;

                MessageBox.Show(
                    $"Номер дома не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Проверка на заполненность и валидные символы
            if (!string.IsNullOrWhiteSpace(guna2TextBox14.Text))
            {
                if (!IsValidHouseNumber(guna2TextBox14.Text))
                {
                    // Подсвечиваем красным, если есть недопустимые символы
                    guna2TextBox14.FillColor = Color.LightCoral;
                    guna2TextBox14.BorderColor = Color.Red;
                }
                else
                {
                    // Если все валидно - зеленый
                    guna2TextBox14.FillColor = Color.LightGreen;
                    guna2TextBox14.BorderColor = Color.Green;
                }
            }
            else
            {
                // Если поле пустое - стандартный цвет
                guna2TextBox14.FillColor = Color.FromArgb(192, 192, 192);
                guna2TextBox14.BorderColor = Color.FromArgb(192, 192, 192);
            }
        }
        private bool IsValidHouseNumber(string houseNumber)
        {
            // Разрешаем: цифры, буквы, дефис, слэш, пробел
            foreach (char c in houseNumber)
            {
                if (!char.IsLetterOrDigit(c) && c != '-' && c != '/' && c != ' ' && c != '\\')
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Поле 'Имя' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                MessageBox.Show("Поле 'Фамилия' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox3.Text))
            {
                MessageBox.Show("Поле 'Отчество' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox3.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox4.Text))
            {
                MessageBox.Show("Поле 'Email' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox4.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox5.Text))
            {
                MessageBox.Show("Поле 'Номер телефона' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox5.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox6.Text))
            {
                MessageBox.Show("Поле 'Улица' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox6.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox7.Text))
            {
                MessageBox.Show("Поле 'Дата выдачи паспорта' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox7.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox8.Text))
            {
                MessageBox.Show("Поле 'Организация выдавшая паспорт' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox8.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox9.Text))
            {
                MessageBox.Show("Поле 'Номер паспорта' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox9.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox10.Text))
            {
                MessageBox.Show("Поле 'Серия паспорта' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox10.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox11.Text))
            {
                MessageBox.Show("Поле 'Город' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox11.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox12.Text))
            {
                MessageBox.Show("Поле 'Регион' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox12.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox13.Text))
            {
                MessageBox.Show("Поле 'Почтовый индекс' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox13.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox14.Text))
            {
                MessageBox.Show("Поле 'Номер дома' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox14.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Поле 'Возраст' не выбрано!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Фотография не загружена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                HospitalRepository repository = new HospitalRepository(dbHelper);

                // 1. Сохраняем регион
                Region region = new Region
                {
                    Region_name = guna2TextBox12.Text.Trim()
                };
                repository.InsertRegion(region);

                // 2. Сохраняем город
                City city = new City
                {
                    City_Name = guna2TextBox11.Text.Trim()
                };
                repository.InsertCity(city);

                // 3. Сохраняем улицу
                Street street = new Street
                {
                    Street_Name = guna2TextBox6.Text.Trim()
                };
                repository.InsertStreet(street);

                // 4. Сохраняем дом
                House house = new House
                {
                    House_Number = guna2TextBox14.Text.Trim()
                };
                repository.InsertHouse(house);

                // 5. Сохраняем адрес (связываем регион, город, улицу, дом)
                Addres addres = new Addres
                {
                    FK_IDRegion = region.ID,
                    FK_IDCity = city.ID,
                    FK_IDStreet = street.ID,
                    FK_IDHouse = house.ID,
                    Postal_Code = guna2TextBox13.Text.Trim()
                };
                repository.InsertAddres(addres);

                // 6. Сохраняем паспорт
                Passport passport = new Passport
                {
                    Series = guna2TextBox10.Text.Trim(),
                    Number = guna2TextBox9.Text.Trim(),
                    Issued_By = guna2TextBox8.Text.Trim(),
                    Issue_Date = DateTime.ParseExact(guna2TextBox7.Text.Trim(), "dd.MM.yyyy", null)
                };
                repository.InsertPassport(passport);

                // 7. Сохраняем карту пациента (связываем адрес и паспорт)
                Cardpatient cardpatient = new Cardpatient
                {
                    FK_IDAdres = addres.ID,
                    FK_IDPassport = passport.ID,
                    Surname = guna2TextBox2.Text.Trim(),
                    Patronomik = guna2TextBox3.Text.Trim(),
                    Name = guna2TextBox1.Text.Trim(),
                    Email = guna2TextBox4.Text.Trim(),
                    PhoneNumber = guna2TextBox5.Text.Trim(),
                    Age = Convert.ToInt32(comboBox1.SelectedItem)
                };
                repository.InsertCardpatient(cardpatient);

                MessageBox.Show(
                    "Данные пациента успешно сохранены в базу данных!",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Сохраняем PDF карточку
                SaveCardToPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при сохранении данных: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            SaveCardToPDF();
        }

        private void SaveCardToPDF()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF file|*.pdf";
                saveFileDialog.Title = "Save patient card as PDF";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "Patient_card.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Convert photo to byte[]
                        byte[] photoBytes = null;
                        if (pictureBox1.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                photoBytes = ms.ToArray();
                            }
                        }

                        // Create PDF
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            iTextSharp.text.Document doc = new iTextSharp.text.Document();
                            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            // Title
                            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL);

                            // Document title
                            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Patient card", titleFont);
                            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                            doc.Add(title);
                            doc.Add(new iTextSharp.text.Paragraph(" "));

                            // Photo
                            if (photoBytes != null)
                            {
                                iTextSharp.text.Image photo = iTextSharp.text.Image.GetInstance(photoBytes);
                                photo.ScaleToFit(150, 150);
                                photo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                                doc.Add(photo);
                                doc.Add(new iTextSharp.text.Paragraph(" "));
                            }

                            // Personal information
                            doc.Add(new iTextSharp.text.Paragraph("PERSONAL INFORMATION", headerFont));
                            doc.Add(new iTextSharp.text.Paragraph(" "));
                            doc.Add(new iTextSharp.text.Paragraph($"Name: {guna2TextBox1.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Surname: {guna2TextBox2.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Patronymic: {guna2TextBox3.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Email: {guna2TextBox4.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Phone: {guna2TextBox5.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Age: {comboBox1.SelectedItem}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph(" "));

                            // Passport data
                            doc.Add(new iTextSharp.text.Paragraph("PASSPORT DATA", headerFont));
                            doc.Add(new iTextSharp.text.Paragraph(" "));
                            doc.Add(new iTextSharp.text.Paragraph($"Series: {guna2TextBox10.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Number: {guna2TextBox9.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Issued by: {guna2TextBox8.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Issue date: {guna2TextBox7.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph(" "));

                            // Address
                            doc.Add(new iTextSharp.text.Paragraph("ADDRESS", headerFont));
                            doc.Add(new iTextSharp.text.Paragraph(" "));
                            doc.Add(new iTextSharp.text.Paragraph($"Region: {guna2TextBox12.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"City: {guna2TextBox11.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Street: {guna2TextBox6.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"House: {guna2TextBox14.Text}", normalFont));
                            doc.Add(new iTextSharp.text.Paragraph($"Postal code: {guna2TextBox13.Text}", normalFont));

                            doc.Close();
                        }

                        MessageBox.Show(
                            $"Patient card successfully saved to PDF!\nPath: {saveFileDialog.FileName}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Error saving: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
    }
}
