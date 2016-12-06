using UnityEngine;
using System.Collections;

public class InimMov : MonoBehaviour {

    public LayerMask inimigoMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
    }

    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, inimigoMask);
        
        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
    void OnCollisionEnter2D(Collision2D outro)
    {

        if (outro.gameObject.tag == "Player")
        {
            Application.LoadLevel("Menu");
        }
    }
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "cabeca")
            Destroy(gameObject);
    }
}
