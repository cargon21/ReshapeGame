using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackToMain : MonoBehaviour
{
    InputMaster controls;

    void Awake()
    {
        controls = new InputMaster();
        controls.Player.Back.performed += ctx => loadMain();
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    void loadMain()
    {
        FindObjectOfType<GameManager>().MainMenu();
    }
}
