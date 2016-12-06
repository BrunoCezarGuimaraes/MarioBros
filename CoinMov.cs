using UnityEngine;
using System.Collections;

public class CoinMov : MonoBehaviour {

    [SerializeField]
    public float CoinSpeed = 2f;
   
    private Rigidbody2D RB2D;

    [SerializeField]
    public int scoreValue = 1;

    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {

        RB2D.velocity = new Vector2(CoinSpeed, RB2D.velocity.y);
	
	}

  void OnCollisionEnter2D(Collision2D outro) {

        if (outro.gameObject.tag == "Player") {
            // game manager
            // adicionar pontos
            ScoreManager.score += scoreValue;
            Destroy(this.gameObject);
        }
  
    
    }
}
