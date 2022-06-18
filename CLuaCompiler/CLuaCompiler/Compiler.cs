using Crazy.CLuaCompiler.Cores;

namespace Crazy.CLuaCompiler
{
    public class Compiler
    {
        public void Compile(string DataFromFile)
        {
            GetValues.GetValueFromInstruction(Functions.GetNamesFromString(DataFromFile));


        }
    }
}