using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public abstract class LogicBase : INotifyPropertyChanged
{
    //this dictionary contains a list of every instance of every type that inherits from LogicBase
    private static readonly Dictionary<Type, List<LogicBase>> _allInstances = new();

    private protected LogicBase()
    {
        Type type = GetType();
        if (!_allInstances.ContainsKey(type)) //if there is no key of that type yet in the dictionary, make one
        {
            _allInstances[type] = new();
        }
        _allInstances[type].Add(this); //if there is, add it to that key
    }

    public static List<T> GetAllInstancesOfType<T>() where T : LogicBase
    {
        List<T> instances = new();
        //check if the dictionary has a list for the type that T has
        if (_allInstances.ContainsKey(typeof(T)))
        {
            //get the list and convert its items to type T
            var baseModelList = _allInstances[typeof(T)];
            foreach (var obj in baseModelList)
            {
                instances.Add((T)obj); //cast each item to the type of T
            }
        }
        return instances;
    }


    //event created here so we don't have to create one in every model class
    public event PropertyChangedEventHandler PropertyChanged;

    public event Action ObjectDestroyed;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual void OnObjectDestroyed()
    {
        Type type = GetType();
        if (_allInstances.ContainsKey(type)) //remove this item from the key if that type already has a key
        {
            _allInstances[type].Remove(this);
        }

        ObjectDestroyed?.Invoke();
    }
}
