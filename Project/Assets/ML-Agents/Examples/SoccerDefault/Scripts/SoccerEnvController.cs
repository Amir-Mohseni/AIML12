using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class SoccerEnvController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInfo
    {
        public AgentSoccer Agent;
        [HideInInspector]
        public Vector3 StartingPos;
        [HideInInspector]
        public Quaternion StartingRot;
        [HideInInspector]
        public Rigidbody Rb;
    }


    /// <summary>
    /// Max Academy steps before this platform resets
    /// </summary>
    /// <returns></returns>
    [Tooltip("Max Environment Steps")] public int MaxEnvironmentSteps = 25000;

    /// <summary>
    /// The area bounds.
    /// </summary>

    /// <summary>
    /// We will be changing the ground material based on success/failue
    /// </summary>

    public GameObject ball;
    [HideInInspector]
    public Rigidbody ballRb;
    Vector3 m_BallStartingPos;

    //List of Agents On Platform
    public List<PlayerInfo> AgentsList = new List<PlayerInfo>();

    private SoccerSettings m_SoccerSettings;


    private SimpleMultiAgentGroup m_BlueAgentGroup;
    private SimpleMultiAgentGroup m_PurpleAgentGroup;

    private int m_ResetTimer;
    private Sound sound;
    private ScoreTracker scoreTracker;
    private int limit;

    void Start()
    {
        sound = new Sound();
        m_SoccerSettings = FindObjectOfType<SoccerSettings>();
        limit = m_SoccerSettings.limit;
        // Initialize TeamManager
        m_BlueAgentGroup = new SimpleMultiAgentGroup();
        m_PurpleAgentGroup = new SimpleMultiAgentGroup();
        ballRb = ball.GetComponent<Rigidbody>();
        m_BallStartingPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        sound.AddObject(ballRb);
        Debug.Log("blue: " + m_SoccerSettings.modelTypeBlueTeam);
        Debug.Log("Purple: " + m_SoccerSettings.modelTypePurpleTeam);
        foreach (var item in AgentsList)
        {
            item.StartingPos = item.Agent.transform.position;
            item.StartingRot = item.Agent.transform.rotation;
            item.Rb = item.Agent.GetComponent<Rigidbody>();
            sound.AddObject(item.Rb);
            if (item.Agent.team == Team.Blue)
            {
                item.Agent.setModelType(m_SoccerSettings.modelTypeBlueTeam);
                m_BlueAgentGroup.RegisterAgent(item.Agent);
            }
            else
            {
                item.Agent.setModelType(m_SoccerSettings.modelTypePurpleTeam);
                m_PurpleAgentGroup.RegisterAgent(item.Agent);
            }
        }
        foreach (var item in AgentsList)
        {
            item.Agent.setSound(sound);
            item.Agent.initThing();
        }
        scoreTracker = ScoreTracker.GetScoreTracker(m_SoccerSettings.limit, m_SoccerSettings.modelTypeBlueTeam, m_SoccerSettings.modelTypePurpleTeam);
        ResetScene();

    }

    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            m_BlueAgentGroup.GroupEpisodeInterrupted();
            m_PurpleAgentGroup.GroupEpisodeInterrupted();
            ResetScene();
        }
    }


    public void ResetBall()
    {
        var randomPosX = Random.Range(-2.5f, 2.5f);
        var randomPosZ = Random.Range(-2.5f, 2.5f);

        ball.transform.position = m_BallStartingPos + new Vector3(randomPosX, 0f, randomPosZ);
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

    }

    public void GoalTouched(Team scoredTeam)
    {
        if (scoredTeam == Team.Blue)
        {
            m_BlueAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_PurpleAgentGroup.AddGroupReward(-1);
            scoreTracker.addScoreBlue();
        }
        else
        {
            m_PurpleAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_BlueAgentGroup.AddGroupReward(-1);
            scoreTracker.addScorePurple();
        }
        m_PurpleAgentGroup.EndGroupEpisode();
        m_BlueAgentGroup.EndGroupEpisode();
        ResetScene();

    }


    public void ResetScene()
    {
        m_ResetTimer = 0;
        scoreTracker.addMatch();
        //Reset Agents
        foreach (var item in AgentsList)
        {
            var randomPosX = Random.Range(-5f, 5f);
            var newStartPos = item.Agent.initialPos + new Vector3(randomPosX, 0f, 0f);
            var rot = item.Agent.rotSign * Random.Range(80.0f, 100.0f);
            var newRot = Quaternion.Euler(0, rot, 0);
            item.Agent.transform.SetPositionAndRotation(newStartPos, newRot);

            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
        }

        //Reset Ball
        ResetBall();
        string s = scoreTracker.checkLimit();
        if (s != ""&&limit!=0)
        {
            Debug.LogError(s);
        }else if(s==""&&limit!=0)
        {
            Debug.Log("blue won: " + scoreTracker.getBlueScore() + " purple won: " + scoreTracker.getPurpleScore());
        }
    }
}