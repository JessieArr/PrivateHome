using System;
using PrivateHome.ExtensionContracts;

namespace PrivateHome.DefaultExtensions.HelloWorld
{ 
    public class HelloWorld : IExtension 
    { 
        public string GetSummary() 
        { 
            return "Hello, world!"; 
        } 
    } 
}