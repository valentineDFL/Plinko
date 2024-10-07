using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Spawn.Spawners;
using UnityEngine;

public class SpawnBallPool : MonoBehaviour
{
    public event Action BallSpawned;

    private List<Ball> _ballsPool = new List<Ball>();
    private BallFabric _ballFabric = new BallFabric();

    private void Awake()
    {
        
    }

    public void ReturnToPool(Ball ballToReturn)
    {
        _ballsPool.Add(ballToReturn);
        ballToReturn.gameObject.SetActive(false);
        ballToReturn.transform.position = this.transform.position;
    }

    public void RealizePool(Ball.Balls ballType)
    {
        if(_ballsPool.Count == 0)
            CreateNewToPool(ballType);

        _ballsPool[0].gameObject.SetActive(true);
        _ballsPool.RemoveAt(0);
    }

    private void CreateNewToPool(Ball.Balls ball)
    {
        Ball ballForSpawn = _ballFabric.CreateBall(ball);

        _ballFabric.SpawnBall(ballForSpawn, this.transform.position);
        _ballsPool.Add(ballForSpawn);
    } 
}
