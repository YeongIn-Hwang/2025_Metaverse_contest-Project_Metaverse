using UnityEngine;

public class Button_ON_OFF : MonoBehaviour
{
    public Material materialB; // �浹�� ������ �� ������ ��Ƽ����

    bool on = false;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            on = true;

            // �ڽ��� ��Ƽ���� ������ �����ؼ� �ڽĿ� ����
            Color parentColor = GetComponent<Renderer>().material.color;

            foreach (Transform child in transform)
            {
                Renderer r = child.GetComponent<Renderer>();
                if (r != null)
                {
                    r.material.color = parentColor;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            on = false;

            // �ڽĵ��� ��Ƽ������ materialB�� �ٲٱ�
            foreach (Transform child in transform)
            {
                Renderer r = child.GetComponent<Renderer>();
                if (r != null)
                {
                    r.material = materialB;
                }
            }
        }
    }

    public bool getter_on()
    {
        return on;
    }
}
