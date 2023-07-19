namespace _03_ViewModelMVVM;

/// <summary>
/// Information a bout a directory item such
/// </summary>
public class DirectoryItem
{
    /// <summary>
    /// The type of this item
    /// </summary>
    public DirectoryItemType Type { get; set; }
    
    /// <summary>
    /// The absolutre path to this item
    /// </summary>
    public string FullPath { get; set; }
    
    /// <summary>
    /// The name of this directory item
    /// </summary>
    public string Name
    {
        get { return this.Type == DirectoryItemType.Drive? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); }
    }
}

