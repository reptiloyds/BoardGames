using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LootLocker.Requests;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LeaderBoard _leaderBoard;
    
    private void Start()
    {
        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return LoginRoutine();
        yield return _leaderBoard.SubmitScoreRoutine(111);
    }

    private IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log($"Player was logged in by id {response.player_id}");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);
    }
}
