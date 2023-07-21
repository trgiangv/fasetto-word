using System;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Linq;
using System.Windows.Input;

namespace _03_ViewModelMVVM;

/// <summary>
/// A ViewModel for each directory item
/// </summary>
public class DirectoryItemViewModel : BaseViewModel
{
    #region public properties

    private string _FullPath;
    private string _Name;
    private DirectoryItemType _Type;
    private bool _CanExpand;
    
    public string FullPath
    {
        get => _FullPath;
        set
        {
            FullPath = value;
            OnPropertyChanged(FullPath);
        }
    }

    public DirectoryItemType Type { get; set; }
    
    
    
    public string Name
    {
        get { return this.Type == DirectoryItemType.Drive? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); }
        set
        {
            Name = value;
            OnPropertyChanged(Name);
        }
    }
    
    public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

    public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

    /// <summary>
    /// Indicates if the current item is expanded or not
    /// </summary>
    public bool IsExpanded
    {
        get
        {
            return this.Children?.Count(f => f != null) > 0;
        }
        set
        {
            if (value == true)
                Expand();
            else
                this.ClearChildren();
        }
    }

    #endregion
    

    #region helpers methods

    /// <summary>
    /// Remove all children from the list, adding a dummy item to show the expand icon if required
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void ClearChildren()
    {
        this.Children = new ObservableCollection<DirectoryItemViewModel>();

        if (this.Type != DirectoryItemType.File)
            this.Children.Add(null);
    }
    
    #endregion

    
    /// <summary>
    /// The command to expand this item
    /// </summary>
    public ICommand ExpandCommand { get; set; }

    #region Constructor
    /// <summary>
    /// Default Constructor
    /// </summary>
    public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
    {
        // Create the command
        this.ExpandCommand = new RelayCommand(Expand);
        
        // set path and type
        this.FullPath = fullPath;
        this.Type = type;
    }    

    #endregion

    
    /// <summary>
    /// expand this directory and finds all children
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void Expand()
    {
        // we cannot expand a file
        if (this.Type == DirectoryItemType.File)
            return;
        
        // Find all children 
        var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
        this.Children = new ObservableCollection<DirectoryItemViewModel>(children
            .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
    }

    
    
}