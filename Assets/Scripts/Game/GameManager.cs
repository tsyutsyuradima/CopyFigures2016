using CopyFigure2016.Helpers;
using CopyFigure2016.Models;
using UnityEngine;

public delegate void VoidDelegate();
public delegate void IntDelegate(int count);
public delegate void BoolDelegate(bool status);
public delegate void GestureObjectDelegate(GestureObject obj);

namespace CopyFigure2016.Game
{
    public class GameManager : MonoBehaviour
    {
        public GestureObject currentGesture;

        public float StartLevelTime = 200f;
        public float MinLevelTime = 50f;
        public float LevelTimeStep = 40;
        public GameObject ShadowTrailer;

        public event VoidDelegate OnGameOver;
        public event VoidDelegate OnGameStart;
        public event VoidDelegate OnEditorOpen;
        public event VoidDelegate OnEditorClose;
        public event IntDelegate OnScoreUpdate;
        public event GestureObjectDelegate OnGestureUpdate;
        public event GestureObjectDelegate OnCheckerGestureUpdate;

        private int _Score = 0;
        private float _LevelTime;

        void Awake()
        {
            // for cases when GameController is already added in scene
            if (instance == null)
                instance = this;
        }

        public void AddScore(int newScoreValue)
        {
            _LevelTime = (_LevelTime > MinLevelTime) ? _LevelTime - LevelTimeStep : _LevelTime;

            _Score += newScoreValue;
            if (OnScoreUpdate != null)
                OnScoreUpdate(_Score);
        }
        public void StartGame()
        {
            _LevelTime = StartLevelTime;
            _Score = 0;
            if (OnGameStart != null)
                OnGameStart();
            if (OnScoreUpdate != null)
                OnScoreUpdate(0);
        }
        public void GestureUpdate(GestureObject obj)
        {
            currentGesture = obj;
            if (OnGestureUpdate != null)
                OnGestureUpdate(obj);
        }
        public void CheckerGestureUpdate(GestureObject obj)
        {
            if (OnCheckerGestureUpdate != null)
                OnCheckerGestureUpdate(obj);
        }

        public void GameOver()
        {
            if (OnGameOver != null)
                OnGameOver();
        }
        public void OpenEditor()
        {
            if (OnEditorOpen != null)
                OnEditorOpen();
        }
        public void CloseEditor()
        {
            if (OnEditorClose != null)
                OnEditorClose();
        }
        public int GetScore()
        {
            return _Score;
        }
        public float GetLevelTime()
        {
            return _LevelTime;
        }
        public void WorkflowZoneEnter(bool state)
        {
            ShadowTrailer.SetActive(state);
        }

        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                return instance;
            }
        }
    }
}