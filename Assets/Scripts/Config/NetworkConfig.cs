using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NetworkConfig", order = 1)]
public class NetworkConfig : ScriptableObject
{
    public string host;
    public int port;
    public string ip;
}