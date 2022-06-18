

namespace Crazy.CLuaCompiler
{
    public class Compiler
    {
        public void Compile(string DataFromFile)
        {
            Dictionary<int,Dictionary<string,string>> Instructions = new Dictionary<int,Dictionary<string,string>>();
            Functions.GetValuesFromString(DataFromFile, out Instructions);


        }
    }
}