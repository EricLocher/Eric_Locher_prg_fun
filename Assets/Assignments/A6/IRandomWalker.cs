using UnityEngine;

interface IRandomWalker
{
    //returns the name of the walker, should be your name!
    string GetName();

    //returns the start position for the walker
    Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight);

    //updates the walker position
    //the walker is only allowed to take one step, left/right or up/down
    //If the walker moves diagonally or too long, it will be killed.
    Vector2 Movement();
}