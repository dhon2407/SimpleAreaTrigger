using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 15;
    
    private CharacterController _controller;
    private bool _disableControl;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        var popup = FindObjectOfType<PopupHandler>();
        if (popup)
            popup.OnPopupChange += OnPopupAction;
    }

    private void OnPopupAction(bool active)
    {
        _disableControl = active;
    }

    private void Update()
    {
        if (_disableControl)
            return;
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var moveDirection = transform.right * x + transform.forward * z;
        _controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
