using UnityEngine;
using System.Collections.Generic;
using CopyFigure2016.Game;
using CopyFigure2016.Models;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CopyFigure2016.Gesture
{
    public class GestureManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public List<Vector3> _PointArr;
        bool _MouseDown;

        bool _Ready = false;
        bool _Editor = false;

        // Use this for initialization
        void Start()
        {
            _PointArr = new List<Vector3>();
            GameManager.Instance.OnEditorClose += _OnEditorClose;
            GameManager.Instance.OnEditorOpen += _OnEditorOpen;
            GameManager.Instance.OnGameStart += _OnGameStart;
            GameManager.Instance.OnGameOver += _OnGameOver;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _Ready = true;
            GameManager.Instance.WorkflowZoneEnter(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _Ready = false;
            GameManager.Instance.WorkflowZoneEnter(false);
            _PointArr.Clear();
        }

        private void _OnEditorClose()
        {
            gameObject.transform.localScale = Vector3.zero;
            _Editor = false;
        }

        private void _OnEditorOpen()
        {
            gameObject.transform.localScale = Vector3.one;
            _Editor = true;
        }

        private void _OnGameOver()
        {
            gameObject.transform.localScale = Vector3.zero;
        }

        private void _OnGameStart()
        {
            gameObject.transform.localScale = Vector3.one;
            _DrawNewGesture();
        }

        void _DrawNewGesture()
        {
            int index = Random.Range(0, GestureTemplates.Templates.Count);
            GameManager.Instance.GestureUpdate(GestureTemplates.Templates[index]);
        }

        void Update()
        {
            if (_Ready)
            {
                if (Input.GetMouseButtonDown(0))
                    _MouseDown = true;

                if (Input.GetMouseButtonUp(0))
                {
                    if (_Editor)
                    {
                        GestureRecognizer.ShowTemplate(_PointArr);
                        GameManager.Instance.GestureUpdate(new GestureObject() { Name = "", PointArray = GestureRecognizer.toShow });
                    }
                    else if (_PointArr.Count > 5)
                    {
                        if (GestureRecognizer.StartRecognizer(_PointArr))
                        {
                            GameManager.Instance.AddScore(1);
                            _DrawNewGesture();
                        }
                        else
                        {
                            List<Vector3> arr = GestureRecognizer.GetArrayToShow(_PointArr);
                            GameManager.Instance.CheckerGestureUpdate(new GestureObject() { Name = "", PointArray = arr });
                        }
                    }
                    _MouseDown = false;
                    _PointArr.Clear();
                }

                if (_MouseDown)
                {
                    Vector3 p = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
                    if (_PointArr.Count > 1)
                    {
                        if (Vector3.Distance(_PointArr[_PointArr.Count - 1], p) > 1f)
                            _PointArr.Add(p);
                    }
                    else
                        _PointArr.Add(p);
                }
            }
        }
    }
}