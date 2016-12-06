using UnityEngine;
using System.Collections;

public class Morte : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D outro)
    {

        if (outro.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }


    }
}
