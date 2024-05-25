using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject Hitler_Pen_2;
    public GameObject Pen_2_Textured_2;

    private bool isPlayer1Turn = true;

    void Start()
    {
        // Enable player1Object's script and disable player2Object's script initially
        Hitler_Pen_2.GetComponent<MouseMovement>().enabled = true;
        Pen_2_Textured_2.GetComponent<MouseMovement>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Switch between player turns
            isPlayer1Turn = !isPlayer1Turn;

            // Enable/disable the corresponding player's script
            Hitler_Pen_2.GetComponent<MouseMovement>().enabled = isPlayer1Turn;
            Pen_2_Textured_2.GetComponent<MouseMovement>().enabled = !isPlayer1Turn;
        }
    }
}