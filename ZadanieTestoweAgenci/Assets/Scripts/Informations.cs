using UnityEngine;
using TMPro;
public class Informations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthPointsText;
    private AgentController currentSelectedAgent;
    public void SetNewAgent(AgentController agent)
    {
        if (currentSelectedAgent != null)
        {
            currentSelectedAgent.Unselect();
        }

        currentSelectedAgent = agent;
        currentSelectedAgent.Select();
        gameObject.SetActive(true);

    }
    void Set()
    {
        nameText.text = currentSelectedAgent.agentName;
        healthPointsText.text = "" + currentSelectedAgent.healthPoints;
    }
    private void Update()
    {
        if (currentSelectedAgent != null)
        {        
            Set();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
