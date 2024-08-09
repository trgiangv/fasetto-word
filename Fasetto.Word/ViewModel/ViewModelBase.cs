using System.ComponentModel;
using PropertyChanged;

namespace Fasetto.Word.ViewModel;

[AddINotifyPropertyChangedInterface]
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}