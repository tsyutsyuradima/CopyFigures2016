using UnityEngine;
using UnityEngine.UI;
using CopyFigure2016.Game;

namespace CopyFigure2016.UI.Panels
{
    public class Restart : MonoBehaviour
    {
        public Button BtnRestart;
        public Button BtnEditor;
        public Text Score;

        void Start()
        {
            BtnRestart.onClick.AddListener(() => _OnRestartClick());
            BtnEditor.onClick.AddListener(() => _OnEditorClick());
            GameManager.Instance.OnGameOver += _OnGameOver;
        }

        private void _OnGameOver()
        {
            transform.localScale = Vector3.one;
            Score.text = GameManager.Instance.GetScore().ToString();
        }

        void _OnEditorClick()
        {
            GameManager.Instance.OpenEditor();
            GameManager.Instance.OnEditorClose += _OnEditorClose;
            transform.localScale = Vector3.zero;
        }

        private void _OnEditorClose()
        {
            GameManager.Instance.OnEditorClose -= _OnEditorClose;
            transform.localScale = Vector3.one;
        }

        void _OnRestartClick()
        {
            GameManager.Instance.StartGame();
            transform.localScale = Vector3.zero;
        }
    }
}