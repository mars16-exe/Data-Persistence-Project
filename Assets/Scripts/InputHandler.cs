using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public InputField input;
    // Start is called before the first frame update
    
    public void AssignName()
    {
        GameManager.Instance.Username = input.textComponent.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
