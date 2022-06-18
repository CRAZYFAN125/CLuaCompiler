﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy.CLuaCompiler.Cores
{
    internal class Datas1
    {
        public enum CoreKey:short
        {
            ints =1,
            strings,
            bools,
            functions,
            floats
        }
        public static char[] indexes = {  '*', '-', '+', '/','=' };

    }
    public class Value
    {
        public string key = string.Empty;
        public string name = string.Empty;
        public object value = string.Empty;
    }
}
