using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class TestingUnit
    {
        //
        static void Main()
        {
            //task 1  - the API {comments & posts}
            Fetch fetch = new Fetch();
            // get posts and their comments by user id


            fetch.getPostsByID(1);
            Console.WriteLine("\n \n \n ");
            Console.WriteLine("----------------------------");
            //task 2 
            //task two
            /* Q2: Write a program that accepts an array of numbers and returns an array of numbers in written form e.g.
          [1,4,6] → [“one”, “four”, “six”]
          [0,0,6,2,7] → [“zero”, “zero”, “six”,"two","seven"]
          [5,4,3,2,1,5,8] → ["five", "four", "three", "two", "one", "five","eight"]*/

            var res = task2.number2string(1, 2, 3, 4, 5);
            foreach (var item in res)
            {
                Console.Write(item+"-");
            }
            Console.WriteLine("\n \n \n -----------------------------------");

            // task 3 (Read from csv and parse for the needed objective
            Console.WriteLine("task three, with the three functionalities");
            // note that the 4th functionality (consectuive oscars) is undoable as there are many oscars holders
           // with the same amount of oscars
           // like 
           // Jimmy 2
           // Bob 2
           // etc.. 2
           // but there's no 3/4 oscars per person
            OscarFunctionality functionality = new OscarFunctionality("oscar.csv");
            Console.WriteLine("\n \n\n ---------------------------------");
            Console.WriteLine("4th task: combing lists");
            //task 4
            var list1 = new ArrayList() { 1, 2, 3 };
            var list2 = new ArrayList() { 'a', 'b', 'c' };
            var result = func.Combine(list1, list2);
            foreach (var item in result)
            {
                Console.Write(item + " - ");
            }
            Console.WriteLine("Done");
        }
    }
}

