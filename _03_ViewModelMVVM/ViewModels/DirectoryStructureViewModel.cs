using System.Collections.ObjectModel;
using System.Linq;

namespace _03_ViewModelMVVM;

/// <summary>
/// The View Model for the applications mani Directory View
/// </summary>
public class DirectoryStructureViewModel : BaseViewModel
{
    /// <summary>
    /// List of all directories on the machine
    /// </summary>
    public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

    /// <summary>
    /// Default Constructor
    /// </summary>
    public DirectoryStructureViewModel()
    {
        // get the logical drives
        var children = DirectoryStructure.GetLogicalDrives();
        
        // Create the view models from the data
        this.Items =
            new ObservableCollection<DirectoryItemViewModel>(children.Select(drive =>
                new DirectoryItemViewModel(drive.FullPath, drive.Type)));
    }

}