using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalker : IRandomWalker
{
    public Vector2 pos;
    public Vector2 startPos;

    public RandomWalker(int playAreaWidth, int playAreaHeight)
    {
        pos = GetStartPosition(playAreaWidth, playAreaHeight);
    }

    public string GetName()
    {
        return "Eric Locher";
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        startPos = new Vector2(playAreaWidth / 2, playAreaHeight / 2);
        return startPos;
    }

    public Vector2 Movement()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                pos += Vector2.left;
                return pos;
            case 1:
                pos += Vector2.right;
                return pos;
            case 2:
                pos += Vector2.up;
                return pos;
            default:
                pos += Vector2.down;
                return pos;
        }
    }

}
