using UnityEngine;
using TMPro;
public class DividedNumbers: MonoBehaviour
{
   
    [SerializeField] private GameObject table;
    private TextMeshProUGUI text;
    private void Start()
    {
        text=table.GetComponentInChildren<TextMeshProUGUI>();
        table.SetActive(false);
    }
    public void ShowNumbers()
    {
        table.SetActive(true);
        text.text = "";
        for (int i = 1; i <= 100; i++)
        {
            
            if (i % 3 == 0&& i % 5==0)
            {
                text.text += "MarcoPolo";
            }
            else  if (i % 3 == 0)
            {
                text.text += "Marco";
            }
            else if (i % 5 == 0)
            {
                text.text += "Polo";
            }
            else
            {
                text.text +=i;
            }
            text.text += ",";
        }
    }
    public void Clear()
    {
        table.SetActive(false);
        text.text="";
    }
}
