using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    testChar char1;
    // Start is called before the first frame update
    private void Start()
    {
        char1 = new testChar(new Vector2(3,3), 5f);
    }

    // Update is called once per frame
    private void Update()
    {
        Background(0);

        char1.draw();
       
    }

}

public class testChar : ProcessingLite.GP21
{
    public Vector2 pos;
    private Vector2 speed;
    private float acc;

    public testChar(Vector2 pos, float acc)
    {
        this.pos = pos;
        this.acc = acc;
    }

    public void draw()
    {

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            speed.x += (acc * Input.GetAxisRaw("Horizontal")) * Time.deltaTime;
            pos.x += Time.deltaTime * speed.x;
        }
        else
        {
            if(speed.x > 0)
                speed.x -= acc * Time.deltaTime;
            else if(speed.x < 0)
                speed.x += acc * Time.deltaTime;

            pos.x += Time.deltaTime * speed.x;     
        }


        if(Input.GetAxisRaw("Vertical") != 0)
        {
            speed.y += (acc * Input.GetAxisRaw("Vertical")) * Time.deltaTime;
            pos.y += Time.deltaTime * speed.y;
        }
        else
        {
            if (speed.y > 0)
                speed.y -= acc * Time.deltaTime;
            else if (speed.y < 0)
                speed.y += acc * Time.deltaTime;

            pos.y += Time.deltaTime * speed.y;
        }


        Circle(pos.x, pos.y, 0.7f);
    }


}
