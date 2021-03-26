using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField]
    private bool activeOnStart = false;
    [SerializeField]
    private QuestTrigger nextQuest = null;
    [SerializeField]
    private Color color = Color.white;
    
    private bool _active;
    private Renderer _renderer;
    private PopupHandler _popup;

    private void Awake()
    {
        _renderer = GetComponentInParent<Renderer>();
        _popup = FindObjectOfType<PopupHandler>();

        if (activeOnStart)
            Activate();
        else
            DeActivate();            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_active)
            return;

        DeActivate();
        nextQuest.Activate();
        _popup.Show($"Go to {nextQuest.name} box.");
    }

    private void Activate()
    {
        _active = true;
        _renderer.material.color = color;
    }

    private void DeActivate()
    {
        _active = false;
        _renderer.material.color = Color.white;
    }
}
