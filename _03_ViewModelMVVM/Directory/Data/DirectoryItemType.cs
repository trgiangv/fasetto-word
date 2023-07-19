using System.IO;

namespace _03_ViewModelMVVM;

/// <summary>
/// The type of a directory item
/// </summary>
public enum DirectoryItemType
{
    /// <summary>
    /// A logical Drive
    /// </summary>
    Drive,
    
    /// <summary>
    /// A physical file
    /// </summary>
    File,
    
    /// <summary>
    /// A folder
    /// </summary>
    Folder
}