using System;
using System.Collections.Generic;

namespace Ice1
{
    public enum State { idle, calculating, action }
    public enum Command { begin, end, transition }

    public class Process
    {
        class StateTransition
        {
            State activeState;
            Command command;

            public StateTransition (State ActiveState, Command Command)
            {
                activeState = ActiveState;
                command = Command;
            }
        }

        Dictionary<StateTransition, State> transitions;
        public State activeState { get; private set; }

        public Process()
        {
            activeState = State.idle;
            transitions = new Dictionary<StateTransition, State>
            {
                {new StateTransition(State.idle, Command.begin), State.calculating},
                {new StateTransition(State.calculating, Command.transition), State.action},
                {new StateTransition(State.action, Command.end), State.idle},
                {new StateTransition(State.calculating, Command.end), State.idle}
            };
        }

        public State StateNext(Command command)
        {
            StateTransition transition = new StateTransition(activeState, command);
            State nextState;

            if (!transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid command" + activeState + " --> " + command);

            return nextState;
        }

        public State MoveNext(Command command)
        {
            activeState = StateNext(command);
            return activeState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();

            Console.WriteLine("Current State: " + p.activeState);

        }
    }
}