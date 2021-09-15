public class Assignment2 : ProcessingLite.GP21
{
    private float spaceBetweenLines = 0.2f;
    private ParabolicCurve test, test2;

    private void Start()
    {
        Stroke(129, 128, 128);
        test = new ParabolicCurve(-500, 500, 200);
        //test2 = new ParabolicCurve(-100, -100, 200);
    }

    // Update is called once per frame
    private void Update()
    {
        test.draw();
        //test2.draw();


       

        
        /*for (int i = 0; i < 10; i++)
        {
            if((i % 3) == 0) {
                Stroke(0, 0, 0);
            } else
            {
                Stroke(129, 128, 128);
            }

            Debug.Log(i % 3);
            Line(0, (10 - i), (0 + i), 0);
        }*/
    }


    /**
     * Uppgift 4 beskriver en function som "tvingar" ett värde att vara innuti ett givit intervall.
     * Denna funktionen är då bra i tillfällen där man vill att värden ligger inom ett visst intervall. 
     */
}

public class ParabolicCurve : ProcessingLite.GP21
{
    private float axis1, axis2;
    private int numberOfLines;

    public ParabolicCurve(float axis1, float axis2, int numberOfLines)
    {
        this.axis1 = axis1;
        this.axis2 = axis2;
        this.numberOfLines = numberOfLines;
    }

    public void draw()
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            float x = i * (axis2 / numberOfLines);
            float y = axis2 - (i * (axis1 / numberOfLines));

            Line(x, 0, 0, y);
        }
    }
}