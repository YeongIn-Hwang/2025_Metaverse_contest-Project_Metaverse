using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class TexttoButton : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject buttonPrefab; // 미리 만들어둔 버튼 프리팹
    public Transform buttonParent;  // 버튼들을 넣을 부모 오브젝트

    void Start()
    {
        string original = "환영합니다. {{확인}}을 눌러 계속하세요. {{취소}}";

        string pattern = @"\{\{(.*?)\}\}";
        var matches = Regex.Matches(original, pattern);

        string textForTMP = original;
        foreach (Match match in matches)
        {
            string label = match.Groups[1].Value;
            textForTMP = textForTMP.Replace(match.Value, "    "); // 버튼 자리에 공백
        }

        textComponent.text = textForTMP;

        foreach (Match match in matches)
        {
            string label = match.Groups[1].Value;

            GameObject buttonObj = Instantiate(buttonPrefab, buttonParent);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = label;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => {
                Debug.Log($"{label} 버튼 클릭됨");
            });
        }
    }
}
