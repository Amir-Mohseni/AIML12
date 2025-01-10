using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using System.Collections.Generic;

public class SensorControllerForAgents
{
    private static List<string> rayNames = new List<string> { "BlueReverseRays" , "PurpleReverseRays" , "BlueReverseRays (1)", "PurpleReverseRays (1)" };
    
/*
 this function will diable the back cast raysof the agent.
*/
private static void ManageBackCast(AgentSoccer agent, bool setActive)
{
        Transform child = null;
        foreach (string currentRayName in rayNames)
        {
            child = agent.transform.Find(currentRayName);
            if (child != null)
            {
                //Debug.Log("Child: " + child.name);
                //Debug.Log("active?: " + setActive);
                child.gameObject.SetActive(setActive);
                return;
            }
        }
    }

    public static void ManageAgentSensors(AgentSoccer agent)
    {
        //Debug.Log("OnlyForwardRaycast: " + agent.GetModelType());
        if (SoccerSettings.ModelType.OnlyForwardRaycast == agent.GetModelType())
        {
            ManageBackCast(agent, false);
            ManageSphereCollider(agent, false);
        }
        else if (SoccerSettings.ModelType.ForwardAndBackwardRaycast == agent.GetModelType())
        {
            ManageBackCast(agent, true);
            ManageSphereCollider(agent, false);
        }
        else if (SoccerSettings.ModelType.SoundAndViewRotation == agent.GetModelType())
        {
            ManageBackCast(agent, false);
            ManageSphereCollider(agent, true);
        }
    }
    public static void ManageSphereCollider(AgentSoccer agent, bool setActive)
    {
        agent.setSphereActive(setActive);
    }

}



