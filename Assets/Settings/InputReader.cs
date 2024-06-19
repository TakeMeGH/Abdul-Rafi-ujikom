using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputMaping;


[CreateAssetMenu(fileName = "InputReader", menuName = "InputReader", order = 0)]
public class InputReader : ScriptableObject, IGameplayActions, IUIActions
{
    public UnityAction OnThrowFoodPerformed;
    public InputMaping InputMaping;
    public GameplayActions GameplayAction;
    // public InputAction UIMap;
    public void Init()
    {
        InputMaping = new InputMaping();
        // GameplayAction = InputMaping.GameplayAction;
        // GameplayMap = InputMaping.Gameplay;
        // GameplayMap.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnOpenPauseMenu(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnThrowFood(InputAction.CallbackContext context)
    {
        Debug.Log("SPACE");
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("PERFORMED");
        }
    }

    public void OnClosePauseMenu(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

}

