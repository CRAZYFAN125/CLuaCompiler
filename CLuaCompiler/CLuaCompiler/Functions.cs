using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy.CLuaCompiler
{
    internal class Functions
    {
        class Interpreters
        {
            static List<string> KeyValues = new List< string>();
            public static List< string> GetKeys()
            {
                if (KeyValues.Count==0)
                {
                    List<string> keys = new List< string>();
                    keys.Add("int");
                    keys.Add("float");
                    keys.Add("string");
                    keys.Add("function");
                    keys.Add("bool");


                    KeyValues=keys;
                    return KeyValues;
                }
                else
                {
                    return KeyValues;
                }
            }
            public static bool IsInKeys(string toCheck, out string key)
            {
                List<string> keys = GetKeys();
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i]==toCheck)
                    {
                        key = keys[i];
                        return true;
                    }
                    if (i==keys.Count)
                    {
                        key = string.Empty;
                        return false;
                    }
                }
                key = string.Empty;
                return false;
            }
        }
        public static void GetValuesFromString(string data, out Dictionary<int,Dictionary<string,string>> instructionsToDo)
        {
            Dictionary<int, string> values = new Dictionary<int, string>();
            values = GetAllCode(data);

            Dictionary < int,Dictionary<string, string>> instructions = new Dictionary<int, Dictionary<string, string>>();
            for (int i = 0; i < values.Count; i++)
            {
                string[] strings = values[i].Split(' ');
                List<string> dat = new();
                for (int v = 0; v < strings.Length; v++)
                {
                    if (!string.IsNullOrEmpty(strings[i]))
                    {
                        dat.Add(strings[i]);
                    }
                }

                if (dat.Count>2)
                {
                    List<string> x = new();

                    foreach (string item in dat)
                    {
                        x.Add(item);
                    }
                    string z = string.Empty;
                    foreach (string item in x)
                    {
                        z += item;
                    }
                    dat.Clear();
                    dat.Add(x[0]);
                    dat.Add(z);
                }

                string key;
                if (Interpreters.IsInKeys(dat[0], out key))
                {
                    Dictionary<string, string> x = new()
                    {
                        { key, dat[1] }
                    };
                    instructions.Add(instructions.Count, x);
                }
            }

            instructionsToDo = instructions;
        }

        private static Dictionary<int, string> GetAllCode(string data)
        {
            string[] strings = data.Split(';');
            Dictionary<int , string> code = new Dictionary<int , string>();
            for (int i = 0; i < strings.Length; i++)
            {
                code.Add(i, strings[i]);
            }
            return code;
        }
    }
}
