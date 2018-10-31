using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class task2
    {
        public enum conversations
        {
            ZERO = 0, ONE = 1, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, SIX = 6, SEVEN = 7, EIGHT = 8, NINE = 9, TEN = 10

        }
        public static string[] number2string(params int[] array)
        {
            int SIZE = array.Length;
            String[] string_ = new string[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                string_[i] = Enum.ToObject(typeof(conversations), array[i]).ToString();

            }
            return string_;

        }
    }
}
