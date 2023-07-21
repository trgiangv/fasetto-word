using System;
using System.Windows.Input;

namespace _03_ViewModelMVVM;

/// <summary>
/// A basic command that runs an Action
/// </summary>
public class RelayCommand : ICommand

{
    #region Private member
    /// <summary>
    /// The action to run
    /// </summary>
    private Action mAction;

    #endregion
    
    #region public events

    /// <summary>
    /// The event thats wass fired the <see cref="CanExecute(Object)"/>
    /// </summary>
    public EventHandler CanExcuteChanegd = (sender, e) => { };

    #endregion


    #region Constuctor

    /// <summary>
    /// Default Constuctor
    /// </summary>
    public RelayCommand(Action action)
    {
        mAction = action;
    }

    #endregion
    
    #region Command methods

    /// <summary>
    /// A Relay command can always execute
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    
    /// <summary>
    /// Execute the command action
    /// </summary>
    /// <param name="parameter"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Execute(object? parameter)
    {
        mAction();
    }

    public event EventHandler? CanExecuteChanged;

    #endregion
    
}