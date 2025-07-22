using UnityEngine;
using System.Collections.Generic;

public class Door_Button : MonoBehaviour
{
    public GameObject Door; // 문 오브젝트
    private Collider Door_collider;
    private Renderer Door_renderer;

    public List<GameObject> buttonList; // Button_ON_OFF 스크립트를 가진 오브젝트들
    public Material materialA;          // 문에 적용할 머티리얼
    public Material childMaterial;      // 자식 오브젝트에 적용할 머티리얼

    void Start()
    {
        Door_collider = Door.GetComponent<Collider>();
        Door_renderer = Door.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            bool allOn = true;

            foreach (GameObject button in buttonList)
            {
                Button_ON_OFF script = button.GetComponent<Button_ON_OFF>();
                if (script == null || !script.getter_on())
                {
                    allOn = false;
                    break;
                }
            }

            if (allOn)
            {
                Door_collider.isTrigger = true;
                Door_renderer.material = materialA;

                // 자식 오브젝트들의 머티리얼을 childMaterial로 변경
                foreach (Transform child in transform)
                {
                    Renderer r = child.GetComponent<Renderer>();
                    if (r != null)
                    {
                        r.material = childMaterial;
                    }
                }
            }
        }
    }
}
