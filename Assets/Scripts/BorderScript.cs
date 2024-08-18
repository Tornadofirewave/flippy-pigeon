using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public LogicScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.gameOver();
            BirdScript.birdIsAlive = false;
        }
    }
}