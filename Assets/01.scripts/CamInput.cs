using UnityEngine;

public class CamInput : MonoBehaviour
{
    public string leftRightMove = "Horizontal";
    public string upDownMove = "Vertical";

    public float horizontalMove {  get; private set; }
    public float verticalMove { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis(leftRightMove);
        verticalMove = Input.GetAxis(upDownMove);
    }
}
