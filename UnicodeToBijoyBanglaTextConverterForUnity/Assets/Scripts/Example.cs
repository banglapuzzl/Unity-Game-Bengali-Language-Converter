using TMPro;
using UnicodeToBijoyBanglaTextConverter;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI InputText = null;
    
    [SerializeField]
    public TextMeshProUGUI OutputText = null;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string input = this.InputText.text;

        string output = ConverterTools.GetAsciiBengaliFromUnicodeText(input);

        this.OutputText.text = output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
