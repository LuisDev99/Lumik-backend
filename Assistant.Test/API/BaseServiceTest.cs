using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Assistant.Test.API
{
    public class BaseServiceTest<T>
    { 
        public BaseServiceTest()
        {
            
        }

        [Theory]
        [InlineData(1, 1)]
        public static void Test<K>(K n1, K n2)
        {
            Assert.Equal(n1, n2);
        }
    }
}
