using UnityEngine;
using TMPro;
public class Informations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthPointsText;
    
    public void Set(string name,int healthPoints)
    {
        nameText.text = name;
        healthPointsText.text = ""+healthPoints;
    }
}
