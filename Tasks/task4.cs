using System;
using System.Collections;

/* Write a function that combines two lists by alternatingly taking elements, e.g.
[a,b,c], [1,2,3] → [a,1,b,2,c,3].
[1,2,5,8,0], [9,4,8,7,6] → [1, 9, 2, 4, 5, 8, 8, 7, 0, 6]. */
// notice that the length is similar, 
// in ArrayList1 and ArrayList2
namespace Tasks
{
    public static class func
    {
        public static ArrayList Combine(ArrayList list1, ArrayList list2)
        {
            var Length = list1.Count;
            var results = new ArrayList();
            for (int i = 0; i < Length; i++)
            {
                results.Add(list1[i]);
                results.Add(list2[i]);
            }
            return results;
        }
    }
}
