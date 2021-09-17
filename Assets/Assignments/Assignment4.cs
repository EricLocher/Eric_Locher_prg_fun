using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    Character gubbe;
    // Start is called before the first frame update
    private void Start()
    {
        gubbe = new Character(new Vector2(3,3), 5f);
    }

    // Update is called once per frame
    private void Update()
    {
        Background(0);

        gubbe.draw();
       
    }

}

public class Character : ProcessingLite.GP21
{
    public Vector2 pos;
    private Vector2 speed;
    private float acc;

    public Character(Vector2 pos, float acc)
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
