using System;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace EComponent
{
    public class DrawPropertyAttribute : Attribute
    {
        public DrawPropertyAttribute()
        {
        }
    }
    
    public class ComponentView : MonoBehaviour
    {
        public List<Component> componts = new List<Component>();
    
        private GUIStyle labelField;
        private GUIStyle helpBox;
        
        [OnInspectorGUI]
        private void OnInspectGUI()
        {
            labelField = new GUIStyle("LabelField");
            labelField.fontStyle = FontStyle.Bold;
            
            helpBox = new GUIStyle("HelpBox");
            
            for (int i = 0; i < componts.Count; i++)
            {
                var component = componts[i];
                var type = component.GetType();
                
                EditorGUILayout.BeginVertical(helpBox);
                EditorGUILayout.LabelField(type.Name, labelField);

                // Go组件展示其Entity的属性，其他组件展示自身的属性
                if (type == typeof(GameObjectComponent))
                {
                    var entityType = component.Entity.GetType();
                    if (entityType.GetCustomAttribute<DrawPropertyAttribute>() != null) 
                    {
                        var str = component.Entity.ToString();
                        if (!string.IsNullOrEmpty(str))
                        {
                            EditorGUILayout.TextArea(str);
                        }
                    }
                }
                else
                {
                    if (type.GetCustomAttribute<DrawPropertyAttribute>() != null)
                    {
                        var str = component.ToString();
                        if (!string.IsNullOrEmpty(str))
                        {
                            EditorGUILayout.TextArea(str);
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space(5);
            }

        }
    }
}