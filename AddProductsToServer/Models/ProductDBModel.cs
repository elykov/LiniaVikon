using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddProductsToServer.Models
{
    class ProductModelFile
    {
        public List<ProductDBModel> data { get; set; }
    }

    class ProductDBModel
    {
        public string articul { get; set; } // Артикул
        public string construction_type { get; set; } // Вид конструкции
        public string profile_system { get; set; } // Профильная система
        public string double_glazed_window { get; set; } // Стеклопакет
        public string double_glazed_window_formula { get; set; } // Формула стеклопакета
        public string furniture { get; set; } // Фурнитура
        public string height { get; set; } // Высота  (мм)
        public string width { get; set; } // Ширина (мм)
        public string active_sashes { get; set; } // Количество активных створок
        public string color { get; set; } // Цвет
        public string price { get; set; } // Цена (грн)

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }

        public string GetResultJson(Random rnd, int order)
        {
            JObject result = new JObject();
            result["createdDate"] = DateTime.Now.ToString("yyyy-MM-dd");
            result["createdTime"] = DateTime.Now.ToString("HH:mm:ss");
            result["order"] = order;

            var con_types = this.construction_type.Split(' ');
            if (con_types[0] == "Окно")
            {
                string anotherText = string.Join(" ", con_types.Skip(1));
                result["title"] =
                    $"Окно металлопластиковое {this.profile_system} {anotherText} {this.height} x {this.width} мм";
            }
            else
            { // Лоджия
                string anotherText = string.Join(" ", con_types.Skip(1));
                result["title"] =
                    $"Лоджия {this.profile_system} {anotherText} {this.height} x {this.width} мм";
            }

            result["active"] = "1";
            result["available"] = "1";
            result["cid"] = "30";
            result["bid"] = "0";
            result["pcode"] = this.articul;
            result["srok_izgot"] = "3";
            result["calc_link"] = "/calc/";
            result["price"] = "1";

            result["related"] = "";
            result["similar"] = "";
            result["additions"] = "";
            result["arKits"] = "";
            result["meta_key"] = "";
            result["meta_descr"] = "";
            result["meta_robots"] = "";
            result["seo_title"] = "";
            result["seo_path"] = "";

            if (rnd.Next(15) == 5)
                result["isnewest"] = "1";

            if (rnd.Next(15) == 5)
                result["issalestop"] = "1";


            // Характеристики
            result["attributes[16][]"] = Helper.GetWindowType(construction_type); // Вид 
            result["attributes[7][]"] = Helper.GetDoubleGlazedWindow(double_glazed_window); // Стеклопакет  

            result["attributes[9][]"] = Helper.GetHeight(this.height); // Высота  
            result["attributes[11][]"] = Helper.GetWidth(this.width); // Ширина  

            result["attributes[2][]"] = Helper.GetCoutry(profile_system); // Страна-производитель товара 
            result["attributes[17][]"] = Helper.GetProfileChamber(profile_system); // Камерность профиля
            result["attributes[3][]"] = Helper.GetProfile(profile_system); // Профиль
            result["attributes[1][]"] = Helper.GetSystemProfileDepth(profile_system); // Системная глубина профиля  
            result["attributes[13][]"] = Helper.GetFurniture(furniture); // Фурнитура   
            result["attributes[14][]"] = Helper.GetNumberOfActiveSashes(active_sashes); // Количество активных створок  
            result["attributes[10][]"] = Helper.GetSystemRehau(profile_system); // Система Rehau  
            result["attributes[12][]"] = Helper.GetSystemOpenTeck(profile_system); // Система OPEN TECK  
            result["attributes[15][]"] = Helper.GetColor(String.Empty); // Цвет   
            result["attributes[18][]"] = Helper.GetPropertiesOfDoubleGlazedWindows(double_glazed_window); // Свойства стеклопакетов              

            return result.ToString(Formatting.None);
        }
    }
}
