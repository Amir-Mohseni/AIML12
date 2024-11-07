using UnityEngine;

public class SoccerBallController : MonoBehaviour
{
    public GameObject area;
    [HideInInspector]
    public SoccerEnvController envController;
    public string purpleGoalTag; //will be used to check if collided with purple goal
    public string blueGoalTag; //will be used to check if collided with blue goal
    public string blueAgentTag; //will be used to check if collided with blue goal
    public string purpleAgentTag; //will be used to check if collided with blue goal

    void Start()
    {
        envController = area.GetComponent<SoccerEnvController>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(purpleGoalTag)) //ball touched purple goal
        {
            envController.GoalTouched(Team.Blue);
        }
        if (col.gameObject.CompareTag(blueGoalTag)) //ball touched blue goal
        {
            envController.GoalTouched(Team.Purple);
        }
        if (col.gameObject.CompareTag(blueAgentTag))
        {
            envController.AgentTouchedBall(Team.Blue);
            //Debug.Log("touched blue agent");
        }
        if (col.gameObject.CompareTag(purpleAgentTag))
        {
            envController.AgentTouchedBall(Team.Purple);
            //Debug.Log("touched purple agent");
        }
    }
}
