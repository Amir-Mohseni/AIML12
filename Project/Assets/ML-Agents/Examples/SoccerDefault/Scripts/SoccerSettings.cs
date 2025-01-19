using UnityEngine;

public class SoccerSettings : MonoBehaviour
{
    public Material purpleMaterial;
    public Material blueMaterial;
    public bool randomizePlayersTeamForTraining = false;
    public float agentRunSpeed;

    public enum ModelType
    {
        ForwardAndBackwardRaycast,
        SoundAndViewRotation,
        OnlyForwardRaycast
    }
    public ModelType modelTypeBlueTeam;
    public ModelType modelTypePurpleTeam;
}
