using System;
using System.Collections;
using System.Collections.Generic;

namespace Vector
{   
    internal class tst : ISorter {
      void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer) {
        
        String val = "Hello!";
        Console.WriteLine(val);

      }
    }
}