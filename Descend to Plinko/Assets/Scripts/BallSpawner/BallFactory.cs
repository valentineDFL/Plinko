using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BallSpawner
{
    internal class BallFactory : AbstractSpawnBall
    {
        public override GameObject CreateGreenBall()
        {
            return new GameObject();
        }

        public override GameObject CreateYellowBall()
        {
            return new GameObject();
        }

        public override GameObject CreatePurpleBall()
        {
            return new GameObject();
        }

        public override GameObject CreateBlueBall()
        {
            return new GameObject();
        }

        public override GameObject CreateRedBall()
        {
            return new GameObject();
        }

        public override GameObject CreatePinkBall()
        {
            return new GameObject();
        }
    }
}
