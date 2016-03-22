using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    public static UI S;
    //Whether or not the players are together
    public bool together;
    public float lastTopHealth, lastBottomHealth, lastFullHealth, fullHealth, fullMaxHealth;
    public GameObject FullHealth;
    public GameObject TopHealth;
    public GameObject BottomHealth;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    void Start ()
    {
        lastTopHealth = Top.S.health;
        lastBottomHealth = Top.S.health;
        lastFullHealth = Top.S.health;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(together)
        {
            if (Top.S.health != lastTopHealth)
            {
                Vector2 topSize = TopHealth.GetComponent<RectTransform>().sizeDelta;
                topSize.x = Top.S.health / Top.S.maxHealth * 150f;
                TopHealth.GetComponent<RectTransform>().sizeDelta = topSize;
            }
            if (Bottom.S.health != lastBottomHealth)
            {
                Vector2 bottomSize = BottomHealth.GetComponent<RectTransform>().sizeDelta;
                bottomSize.x = Bottom.S.health / Bottom.S.maxHealth * 150f;
                BottomHealth.GetComponent<RectTransform>().sizeDelta = bottomSize;
            }
        }
        else
        {
            if (fullHealth != lastFullHealth)
            {
                Vector2 fullSize = FullHealth.GetComponent<RectTransform>().sizeDelta;
                fullSize.x = fullHealth / fullMaxHealth * 150f;
                FullHealth.GetComponent<RectTransform>().sizeDelta = fullSize;
            }
        }
    }
    public void Switch()
    {
        together = !together;
        if (together)
        {
            fullHealth = Mathf.Max(Top.S.health / Top.S.maxHealth, Bottom.S.health / Bottom.S.maxHealth) * fullMaxHealth;
            lastFullHealth = fullHealth;
            FullHealth.SetActive(true);
            TopHealth.SetActive(false);
            BottomHealth.SetActive(false);
        }
        else
        {
            lastBottomHealth = lastTopHealth = Bottom.S.health = Top.S.health = fullHealth / 2f;
            FullHealth.SetActive(false);
            TopHealth.SetActive(true);
            BottomHealth.SetActive(true);
        }
    }
}
