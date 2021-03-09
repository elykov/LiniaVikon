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
        public string country_producer { get; set; } // Страна производитель
        public string profile_system { get; set; } // Профильная система
        public string rehau_system { get; set; } // Система Rehau
        public string salamander_system { get; set; } // Система Salamander
        public string wds_system { get; set; } // Система WDS
        public string open_teck { get; set; } // Система Open-Teck 
        public string current_system { get; set; }
        public string double_glazed_window { get; set; } // Стеклопакет
        public string double_glazed_window_formula { get; set; } // Формула стеклопакета
        public string profile_cameras { get; set; } // Камерность профиля
        public string furniture { get; set; } // Фурнитура
        public string height { get; set; } // Высота  (мм)
        public string width { get; set; } // Ширина (мм)
        public string active_sashes { get; set; } // Количество активных створок
        public string color { get; set; } // Цвет
        public string price { get; set; } // Цена (грн)
        public ProfileSystem ProfileSystem { get; set; }
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

            this.current_system = $"{ this.open_teck}{this.rehau_system}{this.salamander_system}{this.wds_system}";

            var con_types = this.construction_type.Split(' ');
            string anotherText = string.Join(" ", con_types.Skip(1));
            string result_title_text = (con_types[0] == "Окно") ? "Окно металлопластиковое" : "Лоджия";
            result["title"] = $"{result_title_text} {this.profile_system} {this.current_system} {anotherText} {this.height} x {this.width} мм";

            result["active"] = "1";
            result["available"] = "1";
            result["cid"] = "30"; // Категория
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

            this.ProfileSystem = Helper.GetProfileSystem(this.profile_system, this.current_system);
            // Характеристики
            result["attributes[16][]"] = Helper.GetWindowType(construction_type); // Вид ♥
            result["attributes[7][]"] = Helper.GetDoubleGlazedWindow(double_glazed_window); // Стеклопакет ♥

            result["attributes[9][]"] = Helper.GetHeight(this.height); // Высота ♥
            result["attributes[11][]"] = Helper.GetWidth(this.width); // Ширина ♥

            result["attributes[2][]"] = Helper.GetCoutry(this.country_producer); // Страна-производитель товара ♥
            result["attributes[17][]"] = Helper.GetProfileChamber(this.profile_cameras); // Камерность профиля ♥
            result["attributes[3][]"] = Helper.GetProfile(this.ProfileSystem); // Профиль ♥
            result["attributes[13][]"] = Helper.GetFurniture(furniture); // Фурнитура  ♥ 
            result["attributes[14][]"] = Helper.GetNumberOfActiveSashes(active_sashes); // Количество активных створок ♥ 
            result["attributes[18][]"] = Helper.GetPropertiesOfDoubleGlazedWindows(double_glazed_window); // Свойства стеклопакетов ♥             
            result["attributes[15][]"] = Helper.GetColor(String.Empty); // Цвет  ♥ 
            result["attributes[1][]"] = Helper.GetSystemProfileDepth(this.ProfileSystem); // Системная глубина профиля  ♥

            result["attributes[10][]"] = Helper.GetSystemRehau(this.ProfileSystem); // Система Rehau ♥ 
            result["attributes[12][]"] = Helper.GetSystemOpenTeck(this.ProfileSystem); // Система OPEN TECK  ♥
            result["attributes[19][]"] = Helper.GetSystemSalamander(this.ProfileSystem); // Система Salamander ♥
            result["attributes[20][]"] = Helper.GetSystemWDS(this.ProfileSystem); // Система WDS ♥

            return result.ToString(Formatting.None);
        }
    }
}
