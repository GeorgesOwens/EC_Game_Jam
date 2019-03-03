using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    #region Singleton
    private static CheckpointManager _instance;

    public static CheckpointManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        ActiveCheckpoint = StartingCheckpoint = _StartingCheckpoint;
    }
    #endregion

    public Checkpoint _StartingCheckpoint;

    public static Checkpoint ActiveCheckpoint { get; set; }
    public static Checkpoint StartingCheckpoint { get; set; }

    public static void MoveToActiveCheckpoint( Transform target )
    {
        if ( ActiveCheckpoint == null )
        {
            target.position = Vector3.zero;
            return;
        }

        target.position = ActiveCheckpoint.respawnLocation.position;
    }
}
