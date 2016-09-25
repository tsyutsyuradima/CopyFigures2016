using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CopyFigure2016.Game;

namespace CopyFigure2016.UI.Components
{
    public class ScoreController : MonoBehaviour
    {
        public Text Score;

        void Start()
        {
            GameManager.Instance.OnGameOver += _Refresh;
            GameManager.Instance.OnGameStart += _Refresh;
            GameManager.Instance.OnScoreUpdate += _OnScoreUpdate;
        }

        private void _OnScoreUpdate(int count)
        {
            Score.text = count.ToString();
        }

        private void _Refresh()
        {
            Score.text = GameManager.Instance.GetScore().ToString();
        }
    }
}