using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerInput : MonoBehaviour
{
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";

    public float horizontalMove { get; private set; }
    public float verticalMovve { get; private set; }
   

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMovve = Input.GetAxis("Vertical");
    }
}
