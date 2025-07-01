using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ControlPanelTrigger : MonoBehaviour
{
    public GameObject panelUI;
    public DynamicMoveProvider moveProvider;
    public TextMeshProUGUI promptText; // or TextMeshProUGUI
    public InputActionReference grabAction; // 그립 액션 (오른손 또는 왼손)

    private bool isPlayerNear = false;

    void OnEnable() => grabAction.action.Enable();
    void OnDisable() => grabAction.action.Disable();

    private void Start()
    {
        panelUI.SetActive(false);
    }
    void Update()
    {
        if (isPlayerNear)
        {
            Debug.Log("플레이어가 근처에 있어");
            promptText.enabled = true;

            if (grabAction.action.WasPressedThisFrame())
            {
                OpenPanel();
            }
        }
        else
        {
            promptText.enabled = false;
        }
    }

    private void OpenPanel()
    {
        panelUI.SetActive(true);
        moveProvider.enabled = false;
        promptText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
            isPlayerNear = false;
    }
}
