using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class TexttoButton : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject buttonPrefab; // �̸� ������ ��ư ������
    public Transform buttonParent;  // ��ư���� ���� �θ� ������Ʈ

    void Start()
    {
        string original = "ȯ���մϴ�. {{Ȯ��}}�� ���� ����ϼ���. {{���}}";

        string pattern = @"\{\{(.*?)\}\}";
        var matches = Regex.Matches(original, pattern);

        string textForTMP = original;
        foreach (Match match in matches)
        {
            string label = match.Groups[1].Value;
            textForTMP = textForTMP.Replace(match.Value, "    "); // ��ư �ڸ��� ����
        }

        textComponent.text = textForTMP;

        foreach (Match match in matches)
        {
            string label = match.Groups[1].Value;

            GameObject buttonObj = Instantiate(buttonPrefab, buttonParent);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = label;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => {
                Debug.Log($"{label} ��ư Ŭ����");
            });
        }
    }
}
