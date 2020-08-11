using System;
using PrivateHome.ExtensionContracts;

namespace PrivateHome.DefaultExtensions 
{ 
    public class HelloWorld : IExtension 
    { 
        public string GetSummary() 
        { 
            return "Hello, world!"; 
        } 
    } 
}