using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SceneManage
{
    internal static class CameraSize
    {
        private static Camera _camera => Camera.main;
        public static float Height => 2f * _camera.orthographicSize;
        public static float Width => Height * _camera.aspect;

    }
}
