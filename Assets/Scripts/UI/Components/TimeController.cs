using CopyFigure2016.Game;
using UnityEngine;
using UnityEngine.UI;

namespace CopyFigure2016.UI.Components
{
    public class TimeController : MonoBehaviour
    {
        public Image Foreground;

        bool _Ready;
        float _AllTime;
        float _CurrentTime;

        void Start()
        {
            GameManager.Instance.OnGameStart += _Refresh;
            GameManager.Instance.OnScoreUpdate += _OnScoreUpdate;
        }

        private void _OnScoreUpdate(int count)
        {
            _Refresh();
        }

        void _Refresh()
        {
            _Ready = true;
            _CurrentTime = 0f;
            _AllTime = GameManager.Instance.GetLevelTime();
        }

        void FixedUpdate()
        {
            if (_Ready && Foreground != null)
            {
                _CurrentTime++;
                float procent = _CurrentTime / _AllTime;

                Foreground.fillAmount = procent;
                if (procent >= 1f)
                {
                    _Ready = false;
                    GameManager.Instance.GameOver();
                }
            }
        }
    }
}