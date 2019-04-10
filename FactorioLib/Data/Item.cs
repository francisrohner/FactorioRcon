using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Data
{
    public class Item
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public string CraftTimeBase { get; set; }
        public string Product1_Type { get; set; }

        public static int FromString(string sv_line, out Item item)
        {
            int ret = (int)ERROR_CODES.FAILURE;            
            item = null;

            if (sv_line.StartsWith("Name|")) return (int)ERROR_CODES.UNSUPPORTED;

            if (sv_line.Contains("|"))
            {
                string[] arr = sv_line.Split('|');
                item = new Item()
                {
                    Name = arr[0],
                    Category = arr[1],
                    Group = arr[2],
                    SubGroup = arr[3],
                    CraftTimeBase = arr[4],
                    Product1_Type = arr[5]
                };
                ret = (int)ERROR_CODES.SUCCESS;
            }
            return ret;
        }

        public Bitmap Icon { get;set; }
        private string _ImageNameFromName()
        {
            string ret = string.Empty;

            //Special case
            if(Name.Contains("mk2"))
            {
                //randomly the names of these images are different lol
                switch(Name)
                {
                    case "battery-mk2-equipment":
                        ret = "Personal_battery_MK2"; //special case 
                        break;
                    case "personal-roboport-mk2-equipment":
                        ret = "Personal_roboport_MK2";
                        break;
                    default:
                        ret = Name;
                        break;
                }
                return ret;
            }            
            

            string name_mod = Name.Replace("-", "_");
            for (int i = 0; i < name_mod.Length; i++)
            {
                if (i == 0)
                    ret += name_mod[i].ToString().ToUpper();
                else
                    ret += name_mod[i];
            }
            return ret;
        }
        public int FetchIcon(WebClient client, out Bitmap image)
        {

            try
            {
                if (!Directory.Exists("img"))
                    Directory.CreateDirectory("img");
            }
            catch { }

            //Ex: https://wiki.factorio.com/images/Kovarex_enrichment_process.png
            int ret = (int)ERROR_CODES.FAILURE;
            image = null;

            string imgFileName = _ImageNameFromName() + ".png";
            

            string url = "https://wiki.factorio.com/images/" + imgFileName;
            try
            {
                if (!File.Exists(@"img\" + imgFileName))
                {

                    byte[] rx = client.DownloadData(url);
                    MemoryStream ms = new MemoryStream(rx);
                    image = new Bitmap(ms);
                    ms.Close();
                    try
                    {
                        image.Save(@"img\" + imgFileName);
                    }
                    catch { }
                }
                else //load from cache
                {
                    image = new Bitmap(@"img\" + imgFileName);
                }
                
                ret = (int)ERROR_CODES.SUCCESS;
            }
            catch{}

            return ret;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
