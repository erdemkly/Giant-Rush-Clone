using Cinemachine;
using UnityEditor;
using UnityEngine;

namespace Packages.HifiveUtilities.Editor
{
    public class HifiveUtilityEditor : UnityEditor.Editor
    {
        private static GameObject _screenCapture;
        

        #region Creators

        // Call to adjust pivot of Selection.activeGameObject
        [MenuItem("Hifive Games/Utilities/Adjust Pivot")]
        static void AdjustPivot()
        {
            if (Selection.activeObject != null)
            {
                Tools.pivotMode = PivotMode.Center;
                var center = Tools.handlePosition;
                Tools.pivotMode = PivotMode.Pivot;
                var delta = center - Tools.handlePosition;

                if (Selection.activeGameObject.transform.childCount == 0)
                {
                    GameObject go = new GameObject();
                    Tools.pivotMode = PivotMode.Pivot;
                    go.transform.position = Tools.handlePosition;
                    Selection.activeGameObject.transform.position -= delta;
                    Selection.activeGameObject.transform.parent = go.transform;
                    go.name = Selection.activeGameObject.name;
                    Selection.activeGameObject = go;
                }
                else
                {

                    for (int i = 0; i < Selection.activeGameObject.transform.childCount; i++)
                    {
                        Selection.activeGameObject.transform.GetChild(i).gameObject.transform.position -= delta;
                    }
                }
            }
        }

        #endregion

    }
}