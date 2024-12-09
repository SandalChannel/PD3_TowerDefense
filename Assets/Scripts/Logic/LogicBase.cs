using System.ComponentModel;
using System.Runtime.CompilerServices;

public abstract class LogicBase : INotifyPropertyChanged
{
    //event created here so we don't have to create one in every model class
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
