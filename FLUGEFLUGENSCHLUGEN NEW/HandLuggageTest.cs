using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTluggage;

namespace FLUGEFLUGENSCHLUGEN_NEW
{
    [TestClass]
    public class HandLuggageTest
    {
        [TestMethod] 
        public void TestWeightOfHandLuggage() 
        { 
            HandLuggage h = new HandLuggage("meme","number",9);
            Assert.AreEqual(5, h.Weight);
        }

    }
}
