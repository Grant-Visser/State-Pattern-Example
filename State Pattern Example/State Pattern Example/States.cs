using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern_Example
{
    class SoldOutState:State
    {
        GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.Out.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void EjectQuarter()
        {
            Console.Out.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void TurnCrank()
        {
            Console.Out.WriteLine("You turned, but there are no gumballs");
        }

        public void Dispense()
        {
            Console.Out.WriteLine("No gumball dispensed");
        }

        public override String ToString()
        {
            return "sold out";
        }
    }

    class NoQuarterState : State
    {
        private GumballMachine gumballMachine;
        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void InsertQuarter()
        {
            Console.Out.WriteLine("You inserted a quarter");
            gumballMachine.setState(gumballMachine.getHasQuarterState());
        }

        public void EjectQuarter()
        {
            Console.Out.WriteLine("You haven't inserted a quarter");
        }

        public void TurnCrank()
        {
            Console.Out.WriteLine("You turned, but there's no quarter");
        }

        public void Dispense()
        {
            Console.Out.WriteLine("You need to pay first");
        }

        public override String ToString()
        {
            return "waiting for quarter";
        }
    }

    class HasQuarterState : State
    {
        GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.Out.WriteLine("You can't insert another quarter");
        }

        public void EjectQuarter()
        {
            Console.Out.WriteLine("Quarter returned");
            gumballMachine.setState(gumballMachine.getNoQuarterState());
        }

        public void TurnCrank()
        {
            Console.Out.WriteLine("You turned...");
            gumballMachine.setState(gumballMachine.getSoldState());
        }

        public void Dispense()
        {
            Console.Out.WriteLine("No gumball dispensed");
        }

        public override String ToString()
        {
            return "waiting for turn of crank";
        }
    }

    class SoldState : State
    {
        GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.Out.WriteLine("Please wait, we're already giving you a gumball");
        }

        public void EjectQuarter()
        {
            Console.Out.WriteLine("Sorry, you already turned the crank");
        }

        public void TurnCrank()
        {
            Console.Out.WriteLine("Turning twice doesn't get you another gumball!");
        }

        public void Dispense()
        {
            gumballMachine.ReleaseBall();
            if (gumballMachine.GetCount() > 0)
            {
                gumballMachine.setState(gumballMachine.getNoQuarterState());
            }
            else
            {
                Console.Out.WriteLine("Oops, out of gumballs!");
                gumballMachine.setState(gumballMachine.getSoldOutState());
            }
        }

        public override String ToString()
        {
            return "dispensing a gumball";
        }
    }
}
