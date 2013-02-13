using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services.Description;
using System.Reflection;

namespace QuickMon
{
    public class SoapWebServiceRunner
    {
        public string LastError { get; set; }
        public object WebServiceInstance { get; set; }
        public bool SetWebServiceInstance(string webServiceAsmxUrl, string serviceName)
        {
            bool success = false;
            string lastStep = "";
            try
            {
                LastError = "";
                lastStep = "Getting web service description/specification";
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(webServiceAsmxUrl + "?wsdl");
                ServiceDescription description = ServiceDescription.Read(stream);
                ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
                importer.ProtocolName = "Soap12";
                importer.AddServiceDescription(description, null, null);
                importer.Style = ServiceDescriptionImportStyle.Client;
                importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
                CodeNamespace nmspace = new CodeNamespace();
                CodeCompileUnit unit1 = new CodeCompileUnit();
                unit1.Namespaces.Add(nmspace);
                ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1);

                if (warning == 0)
                {
                    CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp");
                    string[] assemblyReferences = new string[] {"System.dll", 
                    "System.Web.Services.dll", "System.Web.dll", 
                    "System.Xml.dll", "System.Data.dll"};
                    CompilerParameters parms = new CompilerParameters(assemblyReferences);
                    parms.GenerateInMemory = true;
                    CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1);

                    if (results.Errors.Count > 0)
                    {
                        foreach (CompilerError oops in results.Errors)
                        {
                            System.Diagnostics.Debug.WriteLine("========Compiler error============");
                            System.Diagnostics.Debug.WriteLine(oops.ErrorText);
                        }
                        throw new System.Exception("Compile Error Occurred calling webservice.");
                    }

                    lastStep = "Creating instance of web service client";
                    WebServiceInstance = results.CompiledAssembly.CreateInstance(serviceName);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                LastError = string.Format("Last step: {0}\r\n{1}", lastStep, ex.ToString());
            }
            return success;
        }
        public object RunWSMethod(string methodName, object[] args)
        {
            string lastStep = "";
            object returnValue = null;
            try
            {
                LastError = "";
                if (WebServiceInstance != null)
                {
                    lastStep = "Specifying method name";
                    MethodInfo mi = WebServiceInstance.GetType().GetMethod(methodName);
                    lastStep = "Invoking method";
                    returnValue = mi.Invoke(WebServiceInstance, args);
                }
                else
                {
                    throw new Exception("Web Service instance not set!");
                }
            }
            catch (System.Reflection.TargetInvocationException tex)
            {
                if (tex.InnerException != null)
                    throw  new Exception(string.Format("Last step: {0}\r\n{1}", lastStep, tex.InnerException.Message));
                else
                    throw new Exception(string.Format("Last step: {0}\r\n{1}", lastStep, tex.ToString()));
            }
            return returnValue;
        }
    }
}
