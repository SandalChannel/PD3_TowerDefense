using Display.Castles;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisplayBase<TLogic> : MonoBehaviour where TLogic : LogicBase //if you use a generic that implements a class, you get the class itself rather than the class it inherrits from
{
    private TLogic _logic;
    
    public TLogic Logic
    {
        get => _logic;
        set
        {
            _logic = value;
            _logic.PropertyChanged += HandlePropertyChanged;
        }
    }

    

    //reacts to the event
    protected abstract void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);

}
