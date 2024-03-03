
class MainProgram
{
    bool startOfTurn, movesCalc, noMoves, noMorePosMoves, endOfTurn;

    public enum States {idle, calculating, action}
    public States state;

    void Main(string[] args)
    {
        //Run a state check
        StateCheck();

        //Reset variables after turn
        if (endOfTurn == true)
        {
            state = States.idle;
            startOfTurn = false;
            movesCalc = false;
            noMoves = false;
            noMorePosMoves = false;
        }
    }

    public void StateCheck()
    {
        if (startOfTurn == true && state == States.idle)
            state = States.calculating;

        if (movesCalc == true && state == States.calculating)
            state = States.action;

        if (noMoves == true || (noMorePosMoves == true && state == States.action) || endOfTurn == true)
            state = States.idle;

    }
}