using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uglyfy.App_Start
{
    using NUglify;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Optimization;
    using Uglyfy.Utility;

    public class NuglyfyJsTransform : IItemTransform
    {
        public string MinifyJavaScript(string inputFilePath, string jsFileText)
        {
            //string input = File.ReadAllText(inputFilePath);
            UglifyResult result = Uglify.Js(jsFileText);

            if (result.HasErrors)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("Erro de minificação: " + error.Message);
                }
            }
            else
            {
                var dir = inputFilePath.Split('/').ToList();
                dir.RemoveAt(dir.Count-1);
                
                var directoryPath = dir.Aggregate("", (agg, next) => $"{agg}/{next}").Remove(0 , 1);
                directoryPath=directoryPath.Replace(MyConfiguration.JavascriptRootPath, MyConfiguration.JavascriptMinPath);
                directoryPath=directoryPath.Replace("~/", "");
                directoryPath = "C:/Users/walte/source/repos/WorkUglyfy/Uglyfy/Scripts/Bundles/Home";
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                File.WriteAllText(directoryInfo.FullName+"/"+inputFilePath.Split('/').Last(), result.ToString());
                Console.WriteLine("Arquivo JavaScript minificado com sucesso.");
            }
            return "result".ToString();
        }

        public string Process(string includedVirtualPath, string jsFileText) => MinifyJavaScript(includedVirtualPath, jsFileText);

    }

}