using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Rendering.DebugUI;


    public class ObjectSpawnedOrDestroyedEventArgs<TLogic> : EventArgs where TLogic : LogicBase
    {
        public TLogic ObjectToSpawn { get; set; }
        
        public ObjectSpawnedOrDestroyedEventArgs(TLogic objectToSpawn)
        {
            ObjectToSpawn = objectToSpawn;
        }
    }

