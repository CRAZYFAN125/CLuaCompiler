namespace Crazy.CLuaCompiler.Cores
{

    internal class GetValues
    {
        public class Value
        {
            public string key = string.Empty;
            public string name = string.Empty;
            public object value = string.Empty;
        }



        public static Dictionary<int, Value> GetValueFromInstruction(Dictionary<int, List<string>> instructions)
        {
            Dictionary<int, Value> result = new Dictionary<int, Value>();

            for (int i = 0; i < instructions.Count; i++)
            {
                Value newValue = new();
                List<string> keyValuePairs = instructions[i];
                newValue.key = keyValuePairs[0];
                newValue.name = GetName(keyValuePairs[1]);
                object value = GetValuesToCompile(newValue.key, keyValuePairs[1]);
                if (value != null)
                {
                    newValue.value = value;
                }
            }

            return result;
        }

        private static object GetValuesToCompile(string key, string v)
        {
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            object value = null;
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.

            string[] strings = v.Split('=');
            if (strings.Length > 1)
            {
                Dictionary<int, string> keyValuePairs = new();
                foreach (char item in Datas1.indexes)
                {
                    string[] variable = strings[1].Split(item);
                    if (variable.Length > 1)
                    {
                        switch (item)
                        {
                            case '*':

                                break;
                            case '-':
                                break;
                            case '+':
                                break;
                            case '/':
                                break;
                            default:
                                break;
                        }
                    }
                }

                Datas1.CoreKey coreKey = new Datas1.CoreKey();
                List<string> avaibleKeys = Functions.Interpreters.GetKeys();

                for (int j = 0; j < avaibleKeys.Count; j++)
                {
                    if (key == avaibleKeys[j])
                    {
                        coreKey = (Datas1.CoreKey)(j + 1);
                    }
                }

                switch (coreKey)
                {
                    case Datas1.CoreKey.ints:
                        value = int.Parse(strings[2]);
                        break;
                    case Datas1.CoreKey.strings:
                        value = strings[2];
                        break;
                    case Datas1.CoreKey.bools:
                        //ToDo
                        break;
                    case Datas1.CoreKey.functions:
                        //ToDo
                        break;
                    case Datas1.CoreKey.floats:
                        value = float.Parse(strings[2]);
                        break;
                    default:
                        break;
                }



            }

#pragma warning disable CS8603 // Możliwe zwrócenie odwołania o wartości null.
            return value;
#pragma warning restore CS8603 // Możliwe zwrócenie odwołania o wartości null.
        }

        private static string GetName(string x)
        {
            string name = x;

            for (int i = 0; i < Datas1.indexes.Length; i++)
            {
                string[] strings = x.Split(Datas1.indexes[i]);
                if (strings.Length > 1)
                {
                    name = strings[0];
                }
            }

            return name;
        }
    }
}
