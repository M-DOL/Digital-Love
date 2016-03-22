using UnityEngine;
using System.Collections;

public class Whole : MonoBehaviour {
    public static Whole S;
    public Rigidbody2D rigid;
    void Awake()
    {
        S = this;
        rigid = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                Bottom.S.grounded = true;
                break;
            case "Projectile":
                Destroy(coll.gameObject);
                UI.S.fullHealth -= coll.gameObject.GetComponent<Projectile>().damage;
                break;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                Bottom.S.grounded = false;
                break;
        }
    }
}
