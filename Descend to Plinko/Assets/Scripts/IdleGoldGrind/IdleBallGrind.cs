﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.IdleGoldGrind
{
    internal class IdleBallGrind : BallSpawnGrind
    {
        public override event Action<long> BallInTimeAdded;

        private void OnEnable()
        {
            PlayerPrefs.SetString(Keys.OnEnterApplicateTimeCode, DateTime.Now.ToString());
            print("startTimeStr: " + PlayerPrefs.GetString(Keys.OnEnterApplicateTimeCode));
        }

        private void OnDisable()
        {
            PlayerPrefs.SetString(Keys.OnExitApplicateTimeCode, DateTime.Now.ToString());
            print("exitTimeStr: " + PlayerPrefs.GetString(Keys.OnExitApplicateTimeCode));
        }

        protected override void BallSpawn()
        {
            bool startBool = DateTime.TryParse(PlayerPrefs.GetString(Keys.OnEnterApplicateTimeCode), out DateTime start);
            bool exitBool = DateTime.TryParse(PlayerPrefs.GetString(Keys.OnExitApplicateTimeCode), out DateTime exit);

            long sec = (long)(start - exit).TotalSeconds;
            print("exitTime: " + exit + " startTime: " + start + " sec: " + sec);

            long ballToInvent = (long)(sec / BallCreationTime);
            BallInTimeAdded?.Invoke(ballToInvent);
            
        }

        private void Start()
        {
            BallSpawn();
        }
    }
}
