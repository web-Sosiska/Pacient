
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;



namespace Pacient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            ////// Проверка заполненности полей
            //if (string.IsNullOrWhiteSpace(guna2TextBox1_name.Text))
            //{

            //    MessageBox.Show("Поле 'Имя' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(guna2TextBox2_Email.Text))
            //{

            //   MessageBox.Show("Поле 'Email' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(guna2TextBox3_password.Text))
            //{

            //    MessageBox.Show("Поле 'Пароль' не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //try
            //{
            //    // Создаем экземпляр DatabaseHelper и HospitalRepository
            //    DatabaseHelper dbHelper = new DatabaseHelper();
            //    HospitalRepository repository = new HospitalRepository(dbHelper);

            //    // Создаем объект Registration
            //    Registration registration = new Registration
            //    {
            //        Name = guna2TextBox1_name.Text.Trim(),
            //        Email = guna2TextBox2_Email.Text.Trim(),
            //        Password = guna2TextBox3_password.Text.Trim()
            //    };

            //    // Сохраняем в базу данных
            //    repository.InsertRegistration(registration);

            //    MessageBox.Show(
            //        "Регистрация успешно завершена!",
            //        "Успех",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information
            //    );

            //    // Сбрасываем цвета полей
            //    guna2TextBox1_name.FillColor = Color.White;
            //    guna2TextBox1_name.BorderColor = Color.Gray;
            //    guna2TextBox2_Email.FillColor = Color.White;
            //    guna2TextBox2_Email.BorderColor = Color.Gray;
            //    guna2TextBox3_password.FillColor = Color.White;
            //    guna2TextBox3_password.BorderColor = Color.Gray;

            //// Открываем главную форму
            Osnova patientCard = new Osnova();
            patientCard.Show();
            //    this.Hide(); // Скрываем форму регистрации
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(
            //        $"Ошибка при сохранении данных: {ex.Message}",
            //        "Ошибка базы данных",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );
            //}



        }


        private void guna2TextBox1_name_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 100;

            if (guna2TextBox1_name.Text.Length > maxLength)
            {
                guna2TextBox1_name.Text = guna2TextBox1_name.Text.Substring(0, maxLength);
                guna2TextBox1_name.SelectionStart = guna2TextBox1_name.Text.Length;

                // Подсвечиваем поле красным при превышении
                guna2TextBox1_name.FillColor = Color.LightCoral;
                guna2TextBox1_name.BorderColor = Color.Red;
            }
            else if (!string.IsNullOrWhiteSpace(guna2TextBox1_name.Text))
            {
                // Если поле заполнено и не превышает лимит - зеленый
                guna2TextBox1_name.FillColor = Color.LightGreen;
                guna2TextBox1_name.BorderColor = Color.Green;
            }
            else
            {
                // Если поле пустое - возвращаем стандартный цвет
                guna2TextBox1_name.FillColor = Color.FromArgb(255, 128, 128, 128);
                guna2TextBox1_name.BorderColor = Color.FromArgb(255, 128, 128, 128);
            }
        }

        private void guna2TextBox2_Email_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 255;

            // Ограничение по длине
            if (guna2TextBox2_Email.Text.Length > maxLength)
            {
                guna2TextBox2_Email.Text = guna2TextBox2_Email.Text.Substring(0, maxLength);
                guna2TextBox2_Email.SelectionStart = guna2TextBox2_Email.Text.Length;

                MessageBox.Show(
                    $"Email не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            // Проверка на валидный email
            if (!string.IsNullOrWhiteSpace(guna2TextBox2_Email.Text))
            {
                if (!IsValidEmail(guna2TextBox2_Email.Text))
                {
                    // Подсвечиваем поле красным, если email невалидный
                    guna2TextBox2_Email.FillColor = Color.LightCoral;
                    guna2TextBox2_Email.BorderColor = Color.Red;
                }
                else
                {
                    // Возвращаем нормальный цвет, если email валидный
                    guna2TextBox2_Email.FillColor = Color.LightGreen;
                    guna2TextBox2_Email.BorderColor = Color.Green;
                }
            }
            else
            {
                // Если поле пустое, возвращаем нормальный цвет
                guna2TextBox2_Email.FillColor = Color.FromArgb(255, 128, 128, 128);
                guna2TextBox2_Email.BorderColor = Color.FromArgb(255, 128, 128, 128);
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
        private void guna2TextBox3_password_TextChanged(object sender, EventArgs e)
        {
            const int minLength = 6;
            const int maxLength = 8;

            // Ограничение максимальной длины
            if (guna2TextBox3_password.Text.Length > maxLength)
            {
                guna2TextBox3_password.Text = guna2TextBox3_password.Text.Substring(0, maxLength);
                guna2TextBox3_password.SelectionStart = guna2TextBox3_password.Text.Length;

                MessageBox.Show(
                    $"Пароль не может превышать {maxLength} символов!",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }


            // Проверка длины пароля
            if (!string.IsNullOrWhiteSpace(guna2TextBox3_password.Text))
            {
                if (guna2TextBox3_password.Text.Length < minLength)
                {
                    // Пароль слишком короткий - подсвечиваем красным
                    guna2TextBox3_password.FillColor = Color.LightCoral;
                    guna2TextBox3_password.BorderColor = Color.Red;
                }
                else
                {
                    // Пароль соответствует требованиям - зеленый или нормальный цвет
                    guna2TextBox3_password.FillColor = Color.LightGreen;
                    guna2TextBox3_password.BorderColor = Color.Green;
                }
            }
            else
            {
                // Если поле пустое - возвращаем нормальный цвет
                guna2TextBox3_password.FillColor = Color.White;
                guna2TextBox3_password.BorderColor = Color.Gray;
            }
        }
    }
}
