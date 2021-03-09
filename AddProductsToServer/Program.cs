using AddProductsToServer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AddProductsToServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Console.WriteLine("Чтобы не перегрузить сервер, программа будет работать с небольшой задержкой.");

            Console.WriteLine("Укажите текущий order. Для этого зайдите на сайт, нажмите кнопку [+товар] и выполните скрипт:");
            Console.WriteLine(@"(function getValueObject() {
let sa = $('form').serializeArray()
let res = {}
sa.forEach(el => res[el.name] = el.value);
return res
})().order");
            Console.WriteLine();
            Console.Write("Order: ");
            int order = int.Parse(Console.ReadLine());

            Console.Write("Сколько продуктов загрузить?: ");
            int count = int.Parse(Console.ReadLine());

            // Считать файл
            JObject dataObject = JObject.Parse(File.ReadAllText("new_json.json"));

            ProductModelFile prodFile = dataObject.ToObject<ProductModelFile>();
            // count = prodFile.data.Count;

            using (StreamWriter file = new StreamWriter(@"newFile.txt"))
            {
                for (int i = 0; i < count; i++, order++)
                {
                    string resJSON = prodFile.data[i].GetResultJson(rnd, order);
                    file.WriteLine(resJSON);
                }
            }

            Console.WriteLine("Теперь можно закрыть программу. Нажмите любую кнопку.");
            Console.ReadKey();

            /*
             После необходимо залить на сайт с помощью этого скрипта
             
document.cookie="PHPSESSID="; // Взять сессию возле командной строки
            
let data = ``; // Сюда данные из нового файла

let jsons = data.split('\n')

setTimeout(() => {
    console.log("Program finished");
}, (jsons.length + 1) * 1000);

jsons.forEach((el, i) => { 
    setTimeout(() => {
        console.log(el);
        $.post('https://liniavikon.com.ua/admin.php?module=catalog&task=addItem', JSON.parse(el));
    }, i * 1000);
})
             */
        }

        static async Task SendAddProductAsync(string jsonProduct, string cookie)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"),
                    "https://liniavikon.com.ua/admin.php?module=catalog&task=addItem"))
                {
                    request.Content = new StringContent(jsonProduct);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                    request.Content.Headers.Add("Cookie", "PHPSESSID=" + cookie);

                    Console.WriteLine(request);
                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(response.ToString());
                    Console.WriteLine(response.Content.ToString());
                }
            }
        }
    }
}
