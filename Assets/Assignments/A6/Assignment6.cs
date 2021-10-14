using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment6 : ProcessingLite.GP21
{
    [SerializeField]
    private Gradient test = new Gradient();
    private float gradientTime = 0f;
    RandomWalker walkMan;
    

    void Start()
    {
        walkMan = new RandomWalker((int)Width, (int)Height);
    }

    void Update()
    {
        gradientTime += 0.05f;
        if (gradientTime >= 1)
            gradientTime = 0;

        Stroke((int)(test.Evaluate(gradientTime).r * 255), (int)(test.Evaluate(gradientTime).g * 255), (int)(test.Evaluate(gradientTime).b * 255));



        Vector2 newPos = walkMan.Movement();

        Point((newPos.x * 0.01f) + walkMan.startPos.x, (newPos.y * 0.01f) + walkMan.startPos.y);
       
    }
}
