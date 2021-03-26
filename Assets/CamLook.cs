using UnityEngine;

public class CamLook : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private float moveSensitivity = 100f;

    private float _rotation;
    private bool _disableControl;

    private void Awake()
    {
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
        
        var mX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
        var mY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;

        _rotation = Mathf.Clamp(_rotation - mY, -90f, 90f);
        player.Rotate(Vector3.up * mX);
    }
}
