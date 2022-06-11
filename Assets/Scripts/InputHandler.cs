using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputField>();
    }
    
    public void AssignName()
    {
        GameManager.Instance.Username = input.textComponent.text;
    }
}
