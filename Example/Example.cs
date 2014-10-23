using System;
using BoolByte;

namespace BoolByte.Example
{
    /// <summary>
    /// BooleanByte Example
    /// </summary>
    /// <see cref="https://github.com/Cyral/BooleanByte/"/>
    public class Example
    {
        public static bool Foo
        {
            get { return data[0]; }
            set { data[0] = value; }
        }

        public static bool Bar
        {
            get { return data[1]; }
            set { data[1] = value; }
        }

        private static BooleanByte data;

        private static void Main(string[] args)
        {
            //Example
            Foo = true;
            Bar = false;

            data[3] = true;
            data.SetBit(4, false);

            //Output result
            Console.WriteLine(Foo);
            Console.WriteLine(Bar);
            Console.WriteLine(data[3]);
            Console.WriteLine(data.GetBit(4));

            Console.ReadLine();
        }
    }
}
