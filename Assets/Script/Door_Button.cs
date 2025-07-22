using UnityEngine;
using System.Collections.Generic;

public class Door_Button : MonoBehaviour
{
    public GameObject Door; // �� ������Ʈ
    private Collider Door_collider;
    private Renderer Door_renderer;

    public List<GameObject> buttonList; // Button_ON_OFF ��ũ��Ʈ�� ���� ������Ʈ��
    public Material materialA;          // ���� ������ ��Ƽ����
    public Material childMaterial;      // �ڽ� ������Ʈ�� ������ ��Ƽ����

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

                // �ڽ� ������Ʈ���� ��Ƽ������ childMaterial�� ����
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
