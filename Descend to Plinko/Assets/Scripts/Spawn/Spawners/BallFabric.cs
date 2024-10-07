using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SceneManage;
using UnityEngine;

namespace Assets.Scripts.Spawn.Spawners
{
    public class BallFabric
    {
        public Ball CreateBall(Ball.Balls ball)
        {
            return (Ball)Resources.Load($"Assets/Resources/BallsPrefabs/{ball}");
        }

        public void SpawnBall(Ball ballPrefab, Vector2 spawnPosition)
        {
            Ball.Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
