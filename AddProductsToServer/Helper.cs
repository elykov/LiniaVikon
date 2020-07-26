using System.Linq;

namespace AddProductsToServer
{
    static class Helper
    {
        /// <summary>
        /// Вид окна
        /// </summary>
        /// <param name="str">construction_type</param>
        /// <returns>value for form</returns>
        public static string GetWindowType(string str)
        {
            switch (str)
            {
                case "Окно глухое": // Глухие одностворчатые окна
                    return "87";
                case "Окно поворотно-откидное": // Поворотно-откидные окна
                    return "98";
                case "Окно двустворчатое с поворотно-откидной створкой": // Двустворчатые окна
                    return "88";
                case "Окно трехстворчатое с поворотно-откидной створкой": // Трехтворчатые окна
                    return "89";
                case "Лоджия с двумя поворотно-откидными створками": //
                    return "88";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Стеклопакет
        /// </summary>
        /// <param name="str">double_glazed_window</param>
        /// <returns></returns>
        public static string GetDoubleGlazedWindow(string str)
        {
            switch (str)
            {
                case "Однокамерный": // Однокамерный
                    return "18";
                case "Двухкамерный": // Двухкамерный
                    return "19";
                case "Трехкамерный": // Трехкамерный
                    return "20";
                case "Двухкамерный энергосберегающий": // Двухкамерный энергосберегающий
                    return "50";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Страна производитель
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetCoutry(string str)
        {
            string producer = str.Split(' ')[0];
            switch (producer)
            {
                case "Open-Teck": // Украина
                    return "26";
                case "Rehau": // Германия
                    return "5";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Камерность профиля
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetProfileChamber(string str)
        {
            /*
             3x - 91
             4x - 92
             5 - 93
             */

            switch (str)
            {
                case "Open-Teck DE-LUX": // 4 60
                    return "92";
                case "Rehau Ecosol 60": // 3 60
                    return "91";
                case "Rehau Ecosol 70": // 5 70
                    return "93";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Профиль
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetProfile(string str)
        {
            switch (str)
            {
                case "Open-Teck DE-LUX": // OpenTeck
                    return "10";
                case "Rehau Ecosol 60": // Rehau
                    return "8";
                case "Rehau Ecosol 70": // Rehau
                    return "8";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Системная глубина профиля
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetSystemProfileDepth(string str)
        {
            /*
                50 - 29 
                60 - 48
                70 - 49
             */

            switch (str)
            {
                case "Open-Teck DE-LUX": // 60
                    return "48";
                case "Rehau Ecosol 60": // 3 60
                    return "48";
                case "Rehau Ecosol 70": // 5 70
                    return "48";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Фурнитура 
        /// </summary>
        /// <param name="str">furniture</param>
        /// <returns></returns>
        public static string GetFurniture(string str)
        {
            switch (str)
            {
                case "Vorne":
                    return "81";
                case "Maco":
                    return "82";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Количество активных створок
        /// </summary>
        /// <param name="str">active_sashes</param>
        /// <returns></returns>
        public static string GetNumberOfActiveSashes(string str)
        {
            return $"{int.Parse(str) + 83}";
        }

        /// <summary>
        /// Система Rehau
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetSystemRehau(string str)
        {
            if (str.Contains("Rehau"))
            {
                string res = string.Join(" ", str.Split(' ').Skip(1));
                switch (res)
                {
                    case "Ecosol 60":
                        return "30";
                    case "Ecosol 70":
                        return "31";
                    default:
                        break;
                }
            }
            return "";
        }

        /// <summary>
        /// Система OPEN TECK
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetSystemOpenTeck(string str)
        {
            if (str.Contains("Open-Teck"))
            {
                string res = string.Join(" ", str.Split(' ').Skip(1));
                switch (res)
                {
                    case "DE-LUX":
                        return "79";
                    case "ELIT 70":
                        return "80";
                    default:
                        break;
                }
            }
            return "";
        }

        /// <summary>
        /// Цвет
        /// </summary>
        /// <param name="str">String.Empty</param>
        /// <returns></returns>
        public static string GetColor(string str)
        {
            return "86"; // Белый
        }

        /// <summary>
        /// Свойства стеклопакетов
        /// </summary>
        /// <param name="str">double_glazed_window</param>
        /// <returns></returns>
        public static string GetPropertiesOfDoubleGlazedWindows(string str)
        {
            if (str.Contains("энергосберегающий"))
            {
                return "97";
            }
            return "";
        }

        /// <summary>
        /// ширина
        /// </summary>
        /// <param name="width">width</param>
        /// <returns></returns>
        public static string GetWidth(string width)
        {
            return $"{((int.Parse(width) - 500) / 100) + 51}";
        }

        /// <summary>
        /// высота
        /// </summary>
        /// <param name="height">height</param>
        /// <returns></returns>
        public static string GetHeight(string height)
        {
            switch (height)
            {
                case "500":
                    return "24";
                case "600":
                    return "25";
                case "700":
                    return "36";
                case "800":
                    return "37";
                case "900":
                    return "38";
                case "1000":
                    return "39";
                case "1100":
                    return "40";
                case "1200":
                    return "41";
                case "1300":
                    return "42";
                case "1400":
                    return "43";
                case "1500":
                    return "44";
                case "1600":
                    return "45";
                case "1700":
                    return "46";
                case "1800":
                    return "47";
                default:
                    return "";
            }
        }
    }
}
