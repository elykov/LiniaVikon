using System.Linq;

namespace AddProductsToServer
{
    enum ProfileSystem
    {
        Null,
        OpenTeckDELUX,
        RehauEcosol60,
        RehauEcosol70,
        RehauGeneo,
        RehauSynego,
        SalamanderBluEvolution92,
        SalamanderStreamline,
        WDS5,
        WDS6
    }

    static class Helper
    {
        /// <summary>
        /// Вид окна
        /// </summary>
        /// <param name="str">construction_type</param>
        /// <returns>value for form</returns>
        public static string GetWindowType(string str) // ♥
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
        public static string GetDoubleGlazedWindow(string str) //♥
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
        public static string GetCoutry(string str) //♥
        {
            switch (str)
            {
                case "Украина": // 
                    return "26";
                case "Германия": // 
                    return "5";
                default:
                    return "";
            }

            //string producer = str.Split(' ')[0];
            //switch (producer)
            //{
            //    case "Open-Teck": // Украина
            //        return "26";
            //    case "Rehau": // Германия
            //        return "5";
            //    default:
            //        return "";
            //}
        }

        /// <summary>
        /// Камерность профиля
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetProfileChamber(string profile_cameras) //♥
        {
            /*
             3x - 91
             4x - 92
             5 - 93
             */
            switch (profile_cameras)
            {
                case "3":
                    return "91";
                case "4":
                    return "92";
                case "5":
                    return "93";
                case "6":
                    return "106";
                case "7":
                    return "107";
                case "8":
                    return "105";
                default:
                    return "";
            }

            //switch (str)
            //{
            //    case "Open-Teck DE-LUX": // 4 60
            //        return "92";
            //    case "Rehau Ecosol 60": // 3 60
            //        return "91";
            //    case "Rehau Ecosol 70": // 5 70
            //        return "93";
            //    default:
            //        return "";
            //}
        }

        public static ProfileSystem GetProfileSystem(string profile_system, string sub_system)
        {
            switch (profile_system)
            {
                case "Open-Teck":
                    {
                        switch (sub_system)
                        {
                            case "DE-LUX":
                                return ProfileSystem.OpenTeckDELUX;
                            default:
                                break;
                        }
                        break;
                    }
                case "Rehau":
                    {
                        switch (sub_system)
                        {
                            case "Ecosol 60":
                                return ProfileSystem.RehauEcosol60;
                            case "Ecosol 70":
                                return ProfileSystem.RehauEcosol70;
                            case "Geneo":
                                return ProfileSystem.RehauGeneo;
                            case "Synego":
                                return ProfileSystem.RehauSynego;
                            default:
                                break;
                        }
                        break;
                    }
                case "Salamander":
                    {
                        switch (sub_system)
                        {
                            case "BluEvolution 92":
                                return ProfileSystem.SalamanderBluEvolution92;
                            case "Streamline":
                                return ProfileSystem.SalamanderStreamline;
                            default:
                                break;
                        }
                        break;
                    }
                case "WDS":
                    {
                        switch (sub_system)
                        {
                            case "WDS 5":
                                return ProfileSystem.WDS5;
                            case "WDS 6":
                                return ProfileSystem.WDS6;
                            default:
                                break;
                        }
                        break;
                    }
            }

            return ProfileSystem.Null;
        }

        /// <summary>
        /// Системная глубина профиля
        /// </summary>
        /// <param name="str">profile_system</param>
        /// <returns></returns>
        public static string GetSystemProfileDepth(ProfileSystem ps) // ♥
        {
            /*
                WDS 5S - 60
                OpenTeck DE-LUX - 60 
                Rehau Ecosol 60 - 60
                Salamander Desing 2D - 60 

                WDS 6S - 70
                Rehau Ecosol 70 - 70 
                Rehau Brilliant Desing - 70 
                OpenTeck ELIT 70 - 70
                
                Salamander Streamline - 76
                Rehau SYNEGO - 80
                Salamander BluEvolution 92 - 82
                Rehau GENEO - 86
             */

            /*
                50 - 29 
                60 - 48
                70 - 49
                76 - 99
                80 - 111
                82 - 109
                86 - 110
             */

            switch (ps)
            {
                case ProfileSystem.WDS5:
                case ProfileSystem.OpenTeckDELUX:
                case ProfileSystem.RehauEcosol60:
                    return "48";
                case ProfileSystem.WDS6:
                case ProfileSystem.RehauEcosol70:
                    return "49";
                case ProfileSystem.SalamanderStreamline:
                    return "99";
                case ProfileSystem.RehauSynego:
                    return "111";
                case ProfileSystem.SalamanderBluEvolution92:
                    return "109";
                case ProfileSystem.RehauGeneo:
                    return "110";
                default:
                    return "";
            }

            //switch (str)
            //{
            //    case "Open-Teck DE-LUX": // 60
            //        return "48";
            //    case "Rehau Ecosol 60": // 3 60
            //        return "48";
            //    case "Rehau Ecosol 70": // 5 70
            //        return "48";
            //    default:
            //        return "";
            //}
        }

        /// <summary>
        /// Фурнитура 
        /// </summary>
        /// <param name="str">furniture</param>
        /// <returns></returns>
        public static string GetFurniture(string str) // ♥
        {
            switch (str)
            {
                case "Vorne":
                    return "81";
                case "Maco":
                    return "82";
                case "Axor K-3":
                    return "108";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Количество активных створок
        /// </summary>
        /// <param name="str">active_sashes</param>
        /// <returns></returns>
        public static string GetNumberOfActiveSashes(string str) // ♥
        {
            return $"{int.Parse(str) + 83}";
        }

        /// <summary>
        /// Цвет
        /// </summary>
        /// <param name="str">String.Empty</param>
        /// <returns></returns>
        public static string GetColor(string str) // ♥
        {
            return "86"; // Белый
        }

        /// <summary>
        /// Свойства стеклопакетов
        /// </summary>
        /// <param name="str">double_glazed_window</param>
        /// <returns></returns>
        public static string GetPropertiesOfDoubleGlazedWindows(string double_glazed_window) // ♥
        {
            if (double_glazed_window.Contains("энергосберегающий"))
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
        public static string GetHeight(string height) //♥
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

        /// <summary>
        /// Профиль
        /// </summary>
        /// <param name="ps">profile_system</param>
        /// <returns></returns>
        public static string GetProfile(ProfileSystem ps) // ♥
        {
            switch (ps)
            {
                case ProfileSystem.OpenTeckDELUX: // OpenTeck
                    return "10";
                // Rehau
                case ProfileSystem.RehauEcosol60:
                case ProfileSystem.RehauEcosol70:
                case ProfileSystem.RehauGeneo:
                case ProfileSystem.RehauSynego:
                    return "8";
                case ProfileSystem.SalamanderBluEvolution92:
                case ProfileSystem.SalamanderStreamline:
                    return "9";
                case ProfileSystem.WDS5:
                case ProfileSystem.WDS6:
                    return "11";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Система Rehau
        /// </summary>
        /// <param name="ps">profile_system</param>
        /// <returns></returns>
        public static string GetSystemRehau(ProfileSystem ps) // ♥
        {
            switch (ps)
            {
                // Rehau
                case ProfileSystem.RehauEcosol60:
                    return "30";
                case ProfileSystem.RehauEcosol70:
                    return "31";
                case ProfileSystem.RehauSynego:
                    return "33";
                case ProfileSystem.RehauGeneo:
                    return "34";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Система OPEN TECK
        /// </summary>
        /// <param name="ps">profile_system</param>
        /// <returns></returns>
        public static string GetSystemOpenTeck(ProfileSystem ps)
        {
            switch (ps)
            {
                case ProfileSystem.OpenTeckDELUX: // OpenTeck
                    return "79";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Система Salamander
        /// </summary>
        /// <param name="ps">ProfileSystem</param>
        /// <returns></returns>
        public static string GetSystemSalamander(ProfileSystem ps) // ♥
        {
            switch (ps)
            {
                case ProfileSystem.SalamanderBluEvolution92:
                    return "101";
                case ProfileSystem.SalamanderStreamline:
                    return "102";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Система WDS
        /// </summary>
        /// <param name="ps">ProfileSystem</param>
        /// <returns></returns>
        public static string GetSystemWDS(ProfileSystem ps) // ♥
        {
            switch (ps)
            {
                case ProfileSystem.WDS5:
                    return "104";
                case ProfileSystem.WDS6:
                    return "103";
                default:
                    return "";
            }
        }
    }
}
