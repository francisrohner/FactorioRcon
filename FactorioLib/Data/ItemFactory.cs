using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Data
{
    public class ItemFactory
    {
        private List<Item> _items;
        public List<Item> Items { get { return _items; } }
        public ItemFactory()
        {
            _items = new List<Item>();
        }
        public int Load(string filePath)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            try
            {
                StreamReader reader = new StreamReader(filePath);
                while(!reader.EndOfStream)
                {
                    if(Item.FromString(reader.ReadLine(), out Item item) > 0)
                    {
                        _items.Add(item);
                    }
                }
                reader.Close();
                ret = (int)ERROR_CODES.SUCCESS;
            }
            catch { }

            return ret;
        }

    }
}
