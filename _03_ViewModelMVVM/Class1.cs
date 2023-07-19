using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _03_ViewModelMVVM;

public class Class1 : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string? _test;
    public string? Test
    {
        get => _test;
        set
        {
            _test = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
        }
    }

}