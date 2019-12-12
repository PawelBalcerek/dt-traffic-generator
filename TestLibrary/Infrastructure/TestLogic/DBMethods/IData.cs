using System;
using System.Collections.Generic;
using System.Text;
using TestLibrary.BusinessObject;

namespace TestLibrary.Infrastructure.TestLogic.DBMethods
{
    interface IData
    {
        
        void AddTests(List<Test> tests);
        TestParameters GetTestParameters(long id);
        
    }
}
