using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KM_Lab_7
{
    internal class GetRequest
    {//Об'єкт запроза 
        HttpWebRequest _request;
        //Змінна для адреси
        string _address;
        //Властивість
        public string Response { get; set; }

        //конструктор класу в який передаємо адресу АПІ
        public GetRequest(string address)
        {
            _address = address;
        }
      //Функція для запуску запроса
        public void Run()
        {
            //Створення запросу по адресі
            _request = (HttpWebRequest)WebRequest.Create(_address);
           //Указуєм шо наш запрос типу Get
            _request.Method = "GET";

            try
            {
                //Об'єкт відповіді
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception)
            {

            }

        }
    }


}
