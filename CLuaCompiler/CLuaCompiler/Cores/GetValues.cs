namespace Crazy.CLuaCompiler.Cores
{

    internal class GetValues
    {
        


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
                Datas1.CoreKey coreKey = new Datas1.CoreKey();
                List<string> avaibleKeys = Functions.Interpreters.GetKeys();

                for (int j = 0; j < avaibleKeys.Count; j++)
                {
                    if (key == avaibleKeys[j])
                    {
                        coreKey = (Datas1.CoreKey)(j + 1);
                    }
                }

                object keyValuePairs = Calculate(strings[1], coreKey);





                if (keyValuePairs == null)
                {
                    switch (coreKey)
                    {
                        case Datas1.CoreKey.ints:
                            value = int.Parse(strings[1]);
                            break;
                        case Datas1.CoreKey.strings:
                            value = strings[1];
                            break;
                        case Datas1.CoreKey.bools:
                            //ToDo
                            break;
                        case Datas1.CoreKey.functions:
                            //ToDo
                            break;
                        case Datas1.CoreKey.floats:
                            value = float.Parse(strings[1]);
                            break;
                        default:
                            break;
                    }
                }



            }

#pragma warning disable CS8603 // Możliwe zwrócenie odwołania o wartości null.
            return value;
#pragma warning restore CS8603 // Możliwe zwrócenie odwołania o wartości null.
        }

        /// <summary>
        /// Get, convert and calculate all numbers in string
        /// </summary>
        /// <param name="v">String with data to convert</param>
        /// <param name="key">Key used by line when reads</param>
        /// <returns>Specific data</returns>
        private static object Calculate(string v, Datas1.CoreKey key)
        {
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            object data = null;
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.


            char[] chars = v.ToCharArray();
            int fromLastSymbol = 0;

            if (key == Datas1.CoreKey.floats)
            {
                float lastNumbers = -354.4035093625f;
                char lastSymbol =' ';
                for (int i = 0; i < chars.Length; i++)
                {
                    string xx = string.Empty;
                    for (int b = 0; b < fromLastSymbol; b++)
                    {
                        xx += chars[b];
                    }
                    switch (chars[i])
                    {
                        case '*':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '*';
                            break;
                        case '/':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '/';
                            break;
                        case '+':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '+';
                            break;
                        case '-':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '-';
                            break;
                        default:
                            break;
                    }
                    fromLastSymbol++;

                }
                if (lastNumbers!= -354.4035093625f)
                {
                    data = lastNumbers;
                }
            }
            else if (key == Datas1.CoreKey.ints)
            {
                float lastNumbers = -354.4035093625f;
                char lastSymbol = ' ';
                for (int i = 0; i < chars.Length; i++)
                {
                    string xx = string.Empty;
                    for (int b = 0; b < fromLastSymbol; b++)
                    {
                        xx += chars[b];
                    }
                    switch (chars[i])
                    {
                        case '*':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '*';
                            break;
                        case '/':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '/';
                            break;
                        case '+':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '+';
                            break;
                        case '-':
                            if (lastNumbers != -354.4035093625f)
                            {
                                switch (lastSymbol)
                                {
                                    case '*':
                                        lastNumbers = lastNumbers * float.Parse(xx);
                                        break;
                                    case '/':
                                        lastNumbers = lastNumbers / float.Parse(xx);
                                        break;
                                    case '+':
                                        lastNumbers = lastNumbers + float.Parse(xx);
                                        break;
                                    case '-':
                                        lastNumbers = lastNumbers - float.Parse(xx);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            lastNumbers = float.Parse(xx);
                            lastSymbol = '-';
                            break;
                        default:
                            break;
                    }
                    fromLastSymbol++;

                }
                if (lastNumbers != -354.4035093625f)
                {
                    data = int.Parse(MathF.Floor( lastNumbers).ToString());
                }
            }
            else if (key == Datas1.CoreKey.strings)
            {
                string x = string.Empty;
                for (int i = 0; i < chars.Length; i++)
                {
                    x+=chars[i];
                }
                data = x;
            }

            return data;
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
