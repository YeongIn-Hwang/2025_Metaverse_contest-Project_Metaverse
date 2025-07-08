using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ControlPanelTrigger : MonoBehaviour
{
    public GameObject panelUI;
    public DynamicMoveProvider moveProvider;
    public TextMeshProUGUI promptText; // or TextMeshProUGUI
    public InputActionReference grabAction; // 그립 액션 (오른손 또는 왼손)
    public SnapTurnProvider SnapTurnProvider; // 회전 액션
    public Code_Text code_text;

    [TextArea]
    public string codeTemplate = "";

    private bool isPlayerNear = false;
    private bool front_of_panel = false;

    void OnEnable() => grabAction.action.Enable();
    void OnDisable() => grabAction.action.Disable();

    private void Start()
    {
        panelUI.SetActive(false);
        promptText.enabled = false;
    }
    void Update()
    {
        if (isPlayerNear)
        {
            if (grabAction.action.WasPressedThisFrame())
            {
                if (!front_of_panel)
                    OpenPanel();
                else
                    ClosePanel();
            }
        }
    }

    private void OpenPanel()
    {
        front_of_panel = true;
        code_text.promptText.text = codeTemplate;
        panelUI.SetActive(true);
        moveProvider.enabled = false;
        promptText.enabled = false;
        SnapTurnProvider.enabled = false;
    }

    private void ClosePanel()
    {
        front_of_panel = false;
        code_text.promptText.text = "";
        panelUI?.SetActive(false);
        moveProvider.enabled=true;
        promptText.enabled = true;
        SnapTurnProvider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            isPlayerNear = true;
            promptText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            isPlayerNear = false;
            promptText.enabled = false;
        }
    }
}
