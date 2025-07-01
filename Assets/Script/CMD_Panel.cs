using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ControlPanelTrigger : MonoBehaviour
{
    public GameObject panelUI;
    public DynamicMoveProvider moveProvider;
    public TextMeshProUGUI promptText; // or TextMeshProUGUI
    public InputActionReference grabAction; // �׸� �׼� (������ �Ǵ� �޼�)

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
            Debug.Log("�÷��̾ ��ó�� �־�");
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
