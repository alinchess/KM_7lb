using Newtonsoft.Json.Linq;
using System;

using System.Drawing;
using System.IO;

using System.Net;

using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace KM_Lab_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //При написканні на кнопку розпочинається виконання запросу
        private void button1_Click(object sender, EventArgs e)
        {
            //Змінна для коду криптовалюти в неї записуується те що вводиться в поле вводу
            var coin_name = textBox1.Text;
            //Створити обєкт класу запросу і передаємо в нього адресу
            var request = new GetRequest("https://api.coinpaprika.com/v1/coins/" + coin_name);
            //Виконуємо функцію
            request.Run();
            //Змінна для відповіді
            var response = request.Response;


            //Якщо відповідь є то
            if (response != null)
            {
                //Створюємо JSon об'єкт та парсимо відповідь
                JObject j_obj = JObject.Parse(response);
                //Створюємо змінні для виводу інформації та звертаємося до JSon об'єкту
                string _coin_name = j_obj["name"].ToString();
                string coin_symbol = j_obj["symbol"].ToString();
                string coin_description = j_obj["description"].ToString();
                string imageUrl = j_obj["logo"].ToString();
                //Виводимо отриману інформацію а саме...
                label1.Text =
                    "Назва: " + _coin_name + "\n" +
                    "Символ: " + coin_symbol + "\n";

                description.Text = "Опис: " + coin_description;

                //Створюємо новий запрос для отримання іконки валюти
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                Bitmap bitmap = new Bitmap(stream);
                //Виводимо іконку валюти
                FlagIMG.BackgroundImage = bitmap;
                FlagIMG.BackgroundImageLayout = ImageLayout.Stretch;

            }
            else//Якщо відповіді ми не отримуємо то...
            {
                //Виводимо помилку
                label1.Text = "Помилка:\n" +
                    "- Не вірний код валюти";
                FlagIMG.Image = null;
            }







        }
    }
}
