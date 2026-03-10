using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputService : MonoBehaviour ,IInputService
{
    public bool IsJumpPressed()
    {
        return Input.GetMouseButtonDown(0);
    }
}
