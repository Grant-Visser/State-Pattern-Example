using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            GumballMachine gumballMachine = new GumballMachine(5);

            Console.Out.WriteLine(gumballMachine.ToString());

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.Out.WriteLine(gumballMachine.ToString());

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.Out.WriteLine(gumballMachine.ToString());

            Console.Out.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
