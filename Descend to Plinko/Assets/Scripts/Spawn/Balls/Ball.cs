using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Ball : MonoBehaviour
    {
        public enum Balls
        {
            BlueBall,
            GreenBall,
            OrangeBall,
            PurpleBall,
            RedBall,
            YellowBall
        }


        [SerializeField] protected int _point;
        [SerializeField] protected int _index;
        protected Balls BallColor;

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

        public Balls BallType
        {
            get { return BallColor; }
            private set { BallColor = value; }
        }
    }
}
