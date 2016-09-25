using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CopyFigure2016.Game;
using CopyFigure2016.Gesture;
using CopyFigure2016.Models;

namespace CopyFigure2016.UI.Panels
{
    public class Editor : MonoBehaviour
    {
        public Button BtnExit;
        public Button BtnSave;
        public InputField InputName;
        public Text Status;

        void Start()
        {
            GameManager.Instance.OnEditorOpen += _OnEditorOpen;

            BtnSave.onClick.AddListener(() => _OnSaveClick());
            BtnExit.onClick.AddListener(() => _OnExitClick());
        }

        private void _OnEditorOpen()
        {
            transform.localScale = Vector3.one;
        }

        void _OnSaveClick()
        {
            if (GestureRecognizer.RecordTemplate(InputName.text))
            {
                Status.color = Color.green;
                Status.text = "SAVED";
            }
            else
            {
                Status.color = Color.red;
                Status.text = "ERROR";
                InputName.text = "";
                //hide gesture;  
                GameManager.Instance.GestureUpdate(new GestureObject() { Name = "", PointArray = new System.Collections.Generic.List<Vector3>() });
            }
            Status.gameObject.SetActive(true);
            Invoke("HideStatus", 1f);
        }

        void _OnExitClick()
        {
            GameManager.Instance.CloseEditor();
            transform.localScale = Vector3.zero;
            Status.gameObject.SetActive(false);
            GameManager.Instance.GestureUpdate(new GestureObject() { Name = "", PointArray = new System.Collections.Generic.List<Vector3>() });
        }

        void HideStatus()
        {
            Status.gameObject.SetActive(false);
        }
    }
}