using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Ball : MonoBehaviour
    {
        [SerializeField] protected int _point;
        [SerializeField] protected int _index;

        public int Point
        {
            get { return _point; }
            private set { _point = value; }
        }

        public int Index
        {
            get { return _index; }
            private set { _index = value; }
        }
    }
}
