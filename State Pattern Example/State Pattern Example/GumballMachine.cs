using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern_Example
{
    class GumballMachine
    {
        private State soldOutState;
        private State noQuarterState;
        private State hasQuarterState;
        private State soldState;

        private State state;
        private int count = 0;

        public GumballMachine(int numberGumballs)
        {
            state = soldOutState;
            soldOutState = new SoldOutState(this);
            noQuarterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);

            this.count = numberGumballs;
            if (count > 0)
            {
                state = noQuarterState;
            }
        }

        public void InsertQuarter()
        {
            state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            state.EjectQuarter();
        }

        public void TurnCrank()
        {
            state.TurnCrank();
            state.Dispense();
        }

        public void ReleaseBall()
        {
            Console.Out.WriteLine("A gumball comes out");
            if (count != 0)
            {
                count = count - 1;
            }
        }

        public int GetCount()
        {
            return count;
        }

        public void refill(int count)
        {
            this.count = count;
            state = noQuarterState;
        }

        public void setState(State state)
        {
            this.state = state;
        }
        public State getState()
        {
            return state;
        }

        public State getSoldOutState()
        {
            return soldOutState;
        }

        public State getNoQuarterState()
        {
            return noQuarterState;
        }

        public State getHasQuarterState()
        {
            return hasQuarterState;
        }

        public State getSoldState()
        {
            return soldState;
        }

        public override string ToString()
        {
            return "Gumball Machine Mk 01\n" +
                   "Inventory: " + count + " gumballs\n" +
                   "Machine is " + state + "\n";
        }
    }
}
