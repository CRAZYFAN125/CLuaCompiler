using Crazy.CLuaCompiler.Cores;

namespace Crazy.CLuaCompiler
{
    public class Compiler
    {
        /// <summary>
        /// Change data from file .cLua into process
        /// </summary>
        /// <param name="DataFromFile">All cLua file writed into string, from System.IO.File.ReadAllText()</param>
        /// <param name="values">Values what was in scripts converted to normal use</param>
        public void Compile(string DataFromFile, out Dictionary<int,Value> values )
        {

            values=GetValues.GetValueFromInstruction(Functions.GetNamesFromString(DataFromFile));


        }

        /*
        public void AddCustomMethod(object sender, string name, out object[] ReturnedDatas)
        {

        }
        */
    }
}