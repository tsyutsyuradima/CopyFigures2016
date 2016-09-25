﻿using UnityEngine;
using System.Collections.Generic;

namespace CopyFigure2016.Helpers
{
    public class TronTrailSection
    {
        public Vector3 point;
        public Vector3 upDir;
        public float time;
    }

    [RequireComponent(typeof(MeshFilter))]
    public class ShadowTrail : MonoBehaviour
    {
        public float height = 2.0f;
        public float time = 2.0f;
        public bool alwaysUp = false;
        public float minDistance = 0.1f;

        public Color startColor = Color.white;
        public Color endColor = new Color(1, 1, 1, 0);

        bool _MouseDown = false;

        List<TronTrailSection> sections = new List<TronTrailSection>();

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _MouseDown = true;
            if (Input.GetMouseButtonUp(0))
            {
                _MouseDown = false;
                Mesh mesh = GetComponent<MeshFilter>().mesh;
                mesh.Clear();
                sections.Clear();
            }
            if (_MouseDown)
            {
                Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);
                curPosition.z = 10f;
                transform.position = curPosition;
            }
        }

        void OnEnable()
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            mesh.Clear();
            sections.Clear();
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);
            curPosition.z = 10f;
            transform.position = curPosition;
        }

        void OnDisable()
        {
            _MouseDown = false;
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            mesh.Clear();
            sections.Clear();
        }

        void LateUpdate()
        {
            Vector3 position = transform.position;
            float now = Time.time;

            // Remove old sections
            while (sections.Count > 0 && now > sections[sections.Count - 1].time + time)
            {
                sections.RemoveAt(sections.Count - 1);
            }
            if (_MouseDown)
            {
                // Add a new trail section
                if (sections.Count == 0 || (sections[0].point - position).sqrMagnitude > minDistance * minDistance)
                {
                    TronTrailSection section = new TronTrailSection();
                    section.point = position;
                    if (alwaysUp)
                        section.upDir = Vector3.up;
                    else
                        section.upDir = transform.TransformDirection(Vector3.up);
                    section.time = now;
                    sections.Insert(0, section);
                }
            }

            // Rebuild the mesh
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            mesh.Clear();

            // We need at least 2 sections to create the line
            if (sections.Count < 2)
            {
                return;
            }

            Vector3[] vertices = new Vector3[sections.Count * 2];
            Color[] colors = new Color[sections.Count * 2];
            Vector2[] uv = new Vector2[sections.Count * 2];

            TronTrailSection currentSection = sections[0];

            // Use matrix instead of transform.TransformPoint for performance reasons
            var localSpaceTransform = transform.worldToLocalMatrix;

            // Generate vertex, uv and colors
            for (var i = 0; i < sections.Count; i++)
            {
                currentSection = sections[i];
                // Calculate u for texture uv and color interpolation
                var u = 0.0f;
                if (i != 0)
                    u = Mathf.Clamp01((Time.time - currentSection.time) / time);

                // Calculate upwards direction
                var upDir = currentSection.upDir;

                // Generate vertices
                vertices[i * 2 + 0] = localSpaceTransform.MultiplyPoint(currentSection.point);
                vertices[i * 2 + 1] = localSpaceTransform.MultiplyPoint(currentSection.point + upDir * height);

                uv[i * 2 + 0] = new Vector2(u, 0);
                uv[i * 2 + 1] = new Vector2(u, 1);

                // fade colors out over time
                var interpolatedColor = Color.Lerp(startColor, endColor, u);
                colors[i * 2 + 0] = interpolatedColor;
                colors[i * 2 + 1] = interpolatedColor;
            }

            // Generate triangles indices
            int[] triangles = new int[(sections.Count - 1) * 2 * 3];
            for (int i = 0; i < triangles.Length / 6; i++)
            {
                triangles[i * 6 + 0] = i * 2;
                triangles[i * 6 + 1] = i * 2 + 1;
                triangles[i * 6 + 2] = i * 2 + 2;

                triangles[i * 6 + 3] = i * 2 + 2;
                triangles[i * 6 + 4] = i * 2 + 1;
                triangles[i * 6 + 5] = i * 2 + 3;
            }

            // Assign to mesh	
            mesh.vertices = vertices;
            mesh.colors = colors;
            mesh.uv = uv;
            mesh.triangles = triangles;
        }
    }
}