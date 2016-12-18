using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCode
{
    public class Permutations
    {
        public static IEnumerable<IEnumerable<object>> Permutate(IEnumerable<object> array)
        {
            return Permutate(array, array.Count());
        }
        private static IEnumerable<IEnumerable<object>> Permutate(IEnumerable<object> array, int roundsToGo)
        {
            if (roundsToGo == 1)
	        {
		        return array.Select(o => new object[]{ o });
	        }

            return Permutate(array, roundsToGo -1)
                .SelectMany
                (t => 
                    array.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new object[] { t2 })
                );
        }
    }
}
