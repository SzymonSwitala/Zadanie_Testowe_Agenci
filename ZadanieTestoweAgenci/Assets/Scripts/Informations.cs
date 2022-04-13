using UnityEngine;
using TMPro;
public class Informations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthPointsText;
    private AgentController currentSelectedAgent;
  
    public void SelectAgent(AgentController agent)
    {
        if (currentSelectedAgent != null)
        {
            currentSelectedAgent.Unselect();
        }

        currentSelectedAgent = agent;
        currentSelectedAgent.Select();
        gameObject.SetActive(true);

    }
    public void UnselectAgent()
    {
        if (currentSelectedAgent==null)
        {
            return;
        }
        currentSelectedAgent.Unselect();
        currentSelectedAgent = null;
    }
    private void SetTexts()
    {
        nameText.text = currentSelectedAgent.agentName;
        healthPointsText.text = "" + currentSelectedAgent.healthPoints;
    }
    private void Update()
    {
     

        if (currentSelectedAgent != null)
        {
            SetTexts();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
