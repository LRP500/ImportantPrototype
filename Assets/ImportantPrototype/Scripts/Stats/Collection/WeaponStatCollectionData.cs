using System;
using System.Collections.Generic;
using ImportantPrototype.System;
using ImportantPrototype.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;
                                    
namespace ImportantPrototype.Stats
{
    [CreateAssetMenu(menuName = ContextMenuPath.Stats + "Weapon Stat Collection")]
    public class WeaponStatCollectionData : ScriptableObject
    {
        [Serializable]
        public class StatConfig
        {
            [ReadOnly]
            [HideLabel]
            [HorizontalGroup]
            [SerializeField]
            private StatInfo _stat;
            
            [HideLabel]
            [SerializeField]
            [HorizontalGroup(Width = 200)]
            private float _value;
        
            public StatInfo Stat => _stat;
            public float Value => _value;

            public StatConfig(StatInfo stat)
            {
                _stat = stat;
            }
        }
        
        [SerializeField]
        [ListDrawerSettings(
            HideAddButton = true,
            HideRemoveButton = true,
            DraggableItems = false)]
        private List<StatConfig> _stats = new ();

        public IEnumerable<StatConfig> Stats => _stats;

        [SerializeField]
        [HideInInspector]
        private List<WeaponStatInfo> _statInfoAssets = new ();
        
        // public void OnBeforeSerialize()
        // {
        //     Populate();
        // }
        //
        // public void OnAfterDeserialize() { }
        //
        // private void Populate()
        // {
        //     var stats = FindAssetsByType<WeaponStatInfo>();
        //
        //     if (_stats.All(x => x.Stat != null) &&
        //         stats.All(x => _statInfoAssets.Contains(x)))
        //         return;
        //     
        //     _statInfoAssets = stats;
        //
        //     for (int i = 0; i < _stats.Count; i++)
        //     {
        //         if (_stats[i].Stat == null) _stats.RemoveAt(i);
        //         EditorUtility.SetDirty(this);
        //     }
        //     
        //     for (int i = 0; i < _statInfoAssets.Count; i++)
        //     {
        //         if (_stats.Any(x => ReferenceEquals(x.Stat, _statInfoAssets[i])))
        //             continue;
        //         _stats.Add(new StatConfig(_statInfoAssets[i]));
        //         EditorUtility.SetDirty(this);
        //     }
        //
        //     AssetDatabase.SaveAssetIfDirty(this);
        //     AssetDatabase.Refresh();
        // }
        //
        // private static List<T> FindAssetsByType<T>() where T : Object
        // {
        //     var assets = new List<T>();
        //     var guids = AssetDatabase.FindAssets($"t:{typeof(T)}");
        //
        //     for (int i = 0, length = guids.Length; i < length; ++i)
        //     {
        //         var assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
        //         var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
        //         if (asset != null) assets.Add(asset);
        //     }
        //
        //     return assets;
        // }
    }
}