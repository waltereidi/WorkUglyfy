using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uglyfy.App_Start
{
    using NUglify;
    using System;
    using System.IO;
    using System.Web.Optimization;

    public class MinifyHelper : IItemTransform
    {
        public string MinifyJavaScript(string inputFilePath, string outputFilePath)
        {
            //string input = File.ReadAllText(inputFilePath);
            UglifyResult result = Uglify.Js(outputFilePath);

            if (result.HasErrors)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("Erro de minificação: " + error.Message);
                }
            }
            else
            {
                File.WriteAllText(outputFilePath, result.ToString());
                Console.WriteLine("Arquivo JavaScript minificado com sucesso.");
            }
            return File.ReadAllText(outputFilePath);
        }

        public static void MinifyCss(string inputFilePath, string outputFilePath)
        {
            string input = File.ReadAllText(inputFilePath);
            UglifyResult result = Uglify.Css(input);

            if (result.HasErrors)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("Erro de minificação: " + error.Message);
                }
            }
            else
            {
                File.WriteAllText(outputFilePath, result.ToString());
                Console.WriteLine("Arquivo CSS minificado com sucesso.");
            }
        }

        public string Process(string includedVirtualPath, string input) => MinifyJavaScript(includedVirtualPath, input);

    }

}