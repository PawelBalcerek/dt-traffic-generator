using System;
using TestLibrary.Infrastructure.RunTest.Concrete;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //TODO tutaj powinien byc jedynie kod rozruchowy (ewentualnie pobieranie parametrów z konsoli)
            //TODO w tym projekcie "ConsoleApplication" nie powinno być żadnej logiki działąnia testów, 
            // natomiast powinna być wywoływana logika testów za pomocą metody "RunTest"
            // przykład uruchomienia poniżej
            TestRunner testRunner = new TestRunner();
            testRunner.RunTest(1);
        }
    }
}
