using UnityEngine;
using System.Collections.Generic;
using CopyFigure2016.Models;
using CopyFigure2016.Game;

namespace CopyFigure2016.Gesture
{
    public class GestureRecognizer
    {
        // recognizer settings
        static int maxPoints = 40;                  // Max number of point in the gesture
        static int sizeOfScaleRect = 300;           // The size of the bounding box
        static int compareDetail = 30;              // Number of matching iterations (CPU consuming) 
        static int angleRange = 90;                 // Angle detail level of when matching with templates 

        public static List<Vector3> toShow;

        public static bool StartRecognizer(List<Vector3> pointArray)
        {
            List<Vector3> _pointArray = optimizeGesture(pointArray, maxPoints);
            _pointArray = scaleGesture(_pointArray, sizeOfScaleRect);
            _pointArray = translateGestureToOrigin(_pointArray);
            bool res = gestureMatch(_pointArray);
            toShow = _pointArray;
            return res;
        }
        public static void ShowTemplate(List<Vector3> pointArray)
        {
            toShow = new List<Vector3>();
            if (pointArray.Count > 10)
            {
                List<Vector3> _pointArray = optimizeGesture(pointArray, maxPoints);
                _pointArray = scaleGesture(_pointArray, sizeOfScaleRect);
                _pointArray = translateGestureToOrigin(_pointArray);
                toShow = _pointArray;
            }
        }
        public static List<Vector3> GetArrayToShow(List<Vector3> pointArray)
        {
            List<Vector3> res = new List<Vector3>();
            if (pointArray.Count > 10)
            {
                List<Vector3> _pointArray = optimizeGesture(pointArray, maxPoints);
                _pointArray = scaleGesture(_pointArray, sizeOfScaleRect);
                _pointArray = translateGestureToOrigin(_pointArray);
                res = _pointArray;
            }
            return res;
        }

        public static bool RecordTemplate(string name)
        {
            bool result = false;
            if (toShow.Count > 10)
            {
                GestureTemplates.Templates.Templates.Add(new GestureObject() { Name = name, PointArray = toShow });
                GestureTemplates.Read();
                result = true;
            }
            return result;
        }

        static List<Vector3> optimizeGesture(List<Vector3> pointArray, int maxPoints)
        {
            // take all the points in the gesture and finds the correct points compared with distance and the maximun value of points
            // calc the interval relative the length of the gesture drawn by the user
            float interval = calcTotalGestureLength(pointArray) / (maxPoints - 1);

            // use the same starting point in the new array from the old one. 
            List<Vector3> optimizedPoints = new List<Vector3>();
            optimizedPoints.Add(pointArray[0]);

            float tempDistance = 0.0f;
            // run through the gesture array. Start at i = 1 because we compare point two with point one)
            for (int i = 1; i < pointArray.Count; i++)
            {
                float currentDistanceBetween2Points = calcDistance(pointArray[i - 1], pointArray[i]);
                if ((tempDistance + currentDistanceBetween2Points) >= interval)
                {
                    // the calc is: old pixel + the differens of old and new pixel multiply  
                    float newX = pointArray[i - 1].x + ((interval - tempDistance) / currentDistanceBetween2Points) * (pointArray[i].x - pointArray[i - 1].x);
                    float newY = pointArray[i - 1].y + ((interval - tempDistance) / currentDistanceBetween2Points) * (pointArray[i].y - pointArray[i - 1].y);
                    // create new point
                    Vector3 newPoint = new Vector3(newX, newY);
                    // set new point into array
                    optimizedPoints.Add(newPoint);
                    tempDistance = 0.0f;
                }
                else
                {
                    // the point was too close to the last point compared with the interval,. Therefore the distance will be stored for the next point to be compared.
                    tempDistance += currentDistanceBetween2Points;
                }
            }
            // Rounding-errors might happens. Just to check if all the points are in the new array
            if (optimizedPoints.Count == maxPoints - 1)
                optimizedPoints.Add(new Vector3(pointArray[pointArray.Count - 1].x, pointArray[pointArray.Count - 1].y));

            return optimizedPoints;
        }

        static List<Vector3> rotateGesture(List<Vector3> pointArray, float radians, Vector3 center)
        {
            // loop through original array, rotate each point and return the new array
            List<Vector3> newArray = new List<Vector3>();
            float cos = Mathf.Cos(radians);
            float sin = Mathf.Sin(radians);

            for (int i = 0; i < pointArray.Count; i++)
            {
                float newX = (pointArray[i].x - center.x) * cos - (pointArray[i].y - center.y) * sin + center.x;
                float newY = (pointArray[i].x - center.x) * sin + (pointArray[i].y - center.y) * cos + center.y;
                newArray.Add(new Vector3(newX, newY));
            }
            return newArray;
        }

        static List<Vector3> scaleGesture(List<Vector3> pointArray, int size)
        {
            // equal min and max to the opposite infinity, such that every gesture size can fit the bounding box.
            float minX = Mathf.Infinity;
            float maxX = Mathf.NegativeInfinity;
            float minY = Mathf.Infinity;
            float maxY = Mathf.NegativeInfinity;

            // loop through array. Find the minimum and maximun values of x and y to be able to create the box
            for (int i = 0; i < pointArray.Count; i++)
            {
                if (pointArray[i].x < minX)
                    minX = pointArray[i].x;
                if (pointArray[i].x > maxX)
                    maxX = pointArray[i].x;
                if (pointArray[i].y < minY)
                    minY = pointArray[i].y;
                if (pointArray[i].y > maxY)
                    maxY = pointArray[i].y;
            }

            // create a rectangle surronding the gesture as a bounding box.
            Rect BoundingBox = new Rect(minX, minY, maxX - minX, maxY - minY);

            List<Vector3> newArray = new List<Vector3>();
            for (int i = 0; i < pointArray.Count; i++)
            {
                float newX = pointArray[i].x * (size / BoundingBox.width);
                float newY = pointArray[i].y * (size / BoundingBox.height);
                newArray.Add(new Vector3(newX, newY));
            }
            return newArray;
        }

        static List<Vector3> translateGestureToOrigin(List<Vector3> pointArray)
        {
            Vector3 origin = new Vector3(0, 0);
            Vector3 center = calcCenterOfGesture(pointArray);
            List<Vector3> newArray = new List<Vector3>();
            for (int i = 0; i < pointArray.Count; i++)
            {
                float newX = pointArray[i].x + origin.x - center.x;
                float newY = pointArray[i].y + origin.y - center.y;
                newArray.Add(new Vector3(newX, newY));
            }
            return newArray;
        }

        // --------------------------------  		     GESTURE OPTIMIZING DONE   		--------------------------------------------------------
        // -------------------------------- 		START OF THE MATCHING PROCESS	----------------------------------------------------------------

        static bool gestureMatch(List<Vector3> pointArray)
        {
            float tempDistance = Mathf.Infinity;
            bool res = false;

            float distance = calcDistanceAtOptimalAngle(pointArray, GameManager.Instance.currentGesture.PointArray, -angleRange, angleRange);
            if (distance < tempDistance)
            {
                tempDistance = distance;
            }

            float HalfDiagonal = 0.5f * Mathf.Sqrt(Mathf.Pow(sizeOfScaleRect, 2) + Mathf.Pow(sizeOfScaleRect, 2));
            float score = 1.0f - (tempDistance / HalfDiagonal);

            if (score > 0.6)
                res = true;

            return res;
        }

        // --------------------------------  		    GESTURE RECOGNIZER DONE   		----------------------------------------------------------------
        // -------------------------------- 		START OF THE HELP CALC FUNCTIONS	----------------------------------------------------------------


        static Vector3 calcCenterOfGesture(List<Vector3> pointArray)
        {
            // finds the center of the drawn gesture
            float averageX = 0.0f;
            float averageY = 0.0f;

            for (int i = 0; i < pointArray.Count; i++)
            {
                averageX += pointArray[i].x;
                averageY += pointArray[i].y;
            }
            averageX = averageX / pointArray.Count;
            averageY = averageY / pointArray.Count;

            return new Vector3(averageX, averageY);
        }

        static float calcDistance(Vector3 point1, Vector3 point2)
        {
            // distance between two vector points.
            float dx = point2.x - point1.x;
            float dy = point2.y - point1.y;

            return Mathf.Sqrt(dx * dx + dy * dy);
        }

        static float calcTotalGestureLength(List<Vector3> pointArray)
        {
            // total length of gesture path
            float length = 0.0f;
            for (int i = 1; i < pointArray.Count; i++)
            {
                length += calcDistance(pointArray[i - 1], pointArray[i]);
            }
            return length;
        }


        static float calcDistanceAtOptimalAngle(List<Vector3> pointArray, List<Vector3> T, float negativeAngle, float positiveAngle)
        {
            // Create two temporary distances. Compare while running through the angles. 
            // Each time a lower distace between points and template points are foound store it in one of the temporary variables. 

            float radian1 = Mathf.PI * negativeAngle + (1.0f - Mathf.PI) * positiveAngle;
            float tempDistance1 = calcDistanceAtAngle(pointArray, T, radian1);

            float radian2 = (1.0f - Mathf.PI) * negativeAngle + Mathf.PI * positiveAngle;
            float tempDistance2 = calcDistanceAtAngle(pointArray, T, radian2);

            // the higher the number compareDetail is, the better recognition this system will perform. 
            for (int i = 0; i < compareDetail; i++)
            {
                if (tempDistance1 < tempDistance2)
                {
                    positiveAngle = radian2;
                    radian2 = radian1;
                    tempDistance2 = tempDistance1;
                    radian1 = Mathf.PI * negativeAngle + (1.0f - Mathf.PI) * positiveAngle;
                    tempDistance1 = calcDistanceAtAngle(pointArray, T, radian1);
                }
                else
                {
                    negativeAngle = radian1;
                    radian1 = radian2;
                    tempDistance1 = tempDistance2;
                    radian2 = (1.0f - Mathf.PI) * negativeAngle + Mathf.PI * positiveAngle;
                    tempDistance2 = calcDistanceAtAngle(pointArray, T, radian2);
                }
            }

            return Mathf.Min(tempDistance1, tempDistance2);
        }

        static float calcDistanceAtAngle(List<Vector3> pointArray, List<Vector3> T, float radians)
        {
            // calc the distance of template and user gesture at 
            Vector3 center = calcCenterOfGesture(pointArray);
            List<Vector3> newpoints = rotateGesture(pointArray, radians, center);
            return calcGestureTemplateDistance(newpoints, T);
        }

        static float calcGestureTemplateDistance(List<Vector3> newRotatedPoints, List<Vector3> templatePoints)
        {
            // calc the distance between gesture path from user and the template gesture
            float distance = 0.0f;

            int i = 0;
            foreach (Vector3 tmPos in newRotatedPoints)
            {
                if (templatePoints.Count > i)
                    distance += calcDistance(tmPos, templatePoints[i]);
                i++;
            }
            return distance / newRotatedPoints.Count;
        }
    }
}