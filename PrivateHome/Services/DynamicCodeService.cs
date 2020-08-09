using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.Web.CodeGeneration;
using PrivateHome.ExtensionContracts;
using PrivateHome.Models.DynamicCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PrivateHome.Services
{
    public class DynamicCodeService
    {
        public ExtensionCompilationResult GetAssemblyFromText(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            string assemblyName = Path.GetRandomFileName();
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IExtension).Assembly.Location),
            };

            var compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var result = new ExtensionCompilationResult();
            using (var ms = new MemoryStream())
            {
                var compilerOutput = compilation.Emit(ms);

                if (!compilerOutput.Success)
                {
                    var failures = compilerOutput.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        result.CompilerErrors.Add(diagnostic.GetMessage());
                    }
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    result.Assembly = Assembly.Load(ms.ToArray());
                    result.Succeeded = true;
                }
            }
            return result;
        }

        public IExtension GetExtensionFromAssembly(Assembly assembly)
        {
            var allTypes = assembly.GetTypes();
            var entrypoint = allTypes.First(x => x.GetInterface("IExtension") != null);
            object obj = Activator.CreateInstance(entrypoint);
            return (IExtension)obj;
        }
    }
}
