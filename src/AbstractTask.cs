namespace CustomTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public abstract class AbstractTask : Microsoft.Build.Utilities.Task
    {

        /// <summary>site url</summary>
        protected const string SITE_URL = "https://github.com/yasu-s/MsBuild-CustomTask";


        protected void WriteHeaderInfo(string taskNm)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyCopyrightAttribute asmcpy = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            Console.WriteLine("{0} [Version {1}]", asm.GetName().Name, asm.GetName().Version);
            Console.WriteLine(asmcpy.Copyright);
            Console.WriteLine("URL: {0}", SITE_URL);
            Console.WriteLine("Run Task: {0}", taskNm);
            Console.WriteLine();
        }
    }
}
