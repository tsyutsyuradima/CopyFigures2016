using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CopyFigure2016.Game;
using CopyFigure2016.Models;
using UnityEngine.UI;

namespace CopyFigure2016.UI.Components
{
    public class GestureDrawing : MonoBehaviour
    {
        private LineRenderer DrawingElement;
        public LineRenderer CheckerDrawingElement;
        public Text ObjectName;

        void Start()
        {
            DrawingElement = gameObject.GetComponent<LineRenderer>();
            GameManager.Instance.OnGestureUpdate += _OnGestureUpdate;
            GameManager.Instance.OnCheckerGestureUpdate += _OnCheckerGestureUpdate; ;
            GameManager.Instance.OnGameOver += HideAll;
        }

        void HideAll()
        {
            ObjectName.text = "";
            DrawingElement.gameObject.SetActive(false);
            CheckerDrawingElement.gameObject.SetActive(false);
        }

        private void _OnGestureUpdate(GestureObject obj)
        {
            ObjectName.text = obj.Name;
            CheckerDrawingElement.gameObject.SetActive(false);
            if (obj.PointArray != null && obj.PointArray.Count > 5)
            {
                DrawingElement.SetVertexCount(obj.PointArray.Count);
                for (int i = 0; i < obj.PointArray.Count; i++)
                {
                    DrawingElement.SetPosition(i, obj.PointArray[i]);
                }
                DrawingElement.gameObject.SetActive(true);
            }
            else
                DrawingElement.gameObject.SetActive(false);
        }


        private void _OnCheckerGestureUpdate(GestureObject obj)
        {
            if (obj.PointArray != null && obj.PointArray.Count > 5)
            {
                CheckerDrawingElement.SetVertexCount(obj.PointArray.Count);
                for (int i = 0; i < obj.PointArray.Count; i++)
                {
                    CheckerDrawingElement.SetPosition(i, obj.PointArray[i]);
                }
                CheckerDrawingElement.gameObject.SetActive(true);
            }
            else
                CheckerDrawingElement.gameObject.SetActive(false);
        }
    }
}