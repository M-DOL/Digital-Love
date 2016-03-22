using UnityEngine;
using System.Collections;

public class PlayerContainer : MonoBehaviour {
    Player childPlayer;
    void Start()
    {
        foreach(Transform child in transform)
        {
            childPlayer = child.GetComponent<Player>();
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                childPlayer.grounded = true;
                break;
            case "Projectile":
                Destroy(coll.gameObject);
                childPlayer.health -= coll.gameObject.GetComponent<Projectile>().damage;
                break;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                childPlayer.grounded = false;
                break;
        }
    }
}
