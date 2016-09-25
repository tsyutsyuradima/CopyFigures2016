using UnityEngine;
using System.Collections;
using CopyFigure2016.Game;
using UnityEngine.UI;

namespace CopyFigure2016.UI.Panels
{
    public class Game : MonoBehaviour
    {
        Image background;

        void Start()
        {
            background = gameObject.GetComponent<Image>();
            GameManager.Instance.OnGameOver += _OnGameOver;
            GameManager.Instance.OnGameStart += _OnGameStart;
            GameManager.Instance.OnScoreUpdate += _OnScoreUpdate;
        }

        private void _OnScoreUpdate(int count)
        {
            background.color = new Color(Random.value, Random.value, Random.value, 0.2f);
        }

        private void _OnGameOver()
        {
            transform.localScale = Vector3.zero;
        }

        private void _OnGameStart()
        {
            transform.localScale = Vector3.one;
        }
    }
}