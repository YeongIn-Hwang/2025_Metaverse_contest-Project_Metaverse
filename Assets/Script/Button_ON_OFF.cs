using UnityEngine;

public class Button_ON_OFF : MonoBehaviour
{
    public Material materialB; // 충돌이 끝났을 때 적용할 머티리얼

    bool on = false;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            on = true;

            // 자신의 머티리얼 색상을 추출해서 자식에 적용
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

            // 자식들의 머티리얼을 materialB로 바꾸기
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
