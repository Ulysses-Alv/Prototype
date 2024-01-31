using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 72;
    }
}