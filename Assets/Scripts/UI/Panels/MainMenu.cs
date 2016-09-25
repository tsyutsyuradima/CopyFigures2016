using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CopyFigure2016.Game;

namespace CopyFigure2016.UI.Panels
{
    public class MainMenu : MonoBehaviour
    {
        public Button BtnStart;
        public Button BtnEditor;

        void Start()
        {
            BtnStart.onClick.AddListener(() => _OnStartClick());
            BtnEditor.onClick.AddListener(() => _OnEditorClick());
            GameManager.Instance.OnEditorClose += _OnEditorClose;
        }

        private void _OnEditorClose()
        {
            transform.localScale = Vector3.one;
        }

        void _OnEditorClick()
        {
            GameManager.Instance.OpenEditor();
            transform.localScale = Vector3.zero;
        }

        void _OnStartClick()
        {
            GameManager.Instance.OnEditorClose -= _OnEditorClose;
            GameManager.Instance.StartGame();
            GameObject.Destroy(gameObject);
        }
    }
}