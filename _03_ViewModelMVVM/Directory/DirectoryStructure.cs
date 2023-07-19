using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_ViewModelMVVM;
/// <summary>
/// A helper class to query information about directories
/// </summary>
public class DirectoryStructure
{
    /// <summary>
    /// Get all logical drive on the machine
    /// </summary>
    /// <returns></returns>
    public static List<DirectoryItem> GetLogicalDrives()
    {
        // Get Every logical drive on the machine
        return Directory.GetLogicalDrives()
            .Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
    }

    public static List<DirectoryItem> GetDirectoryContents(string fullPath)
    {
        
        // Create a blank list for directories
        var items = new List<DirectoryItem>();
        
        #region Get Folders

        // Try and get directories from the folder
        // ignoring any issues doing so
        try
        {
            var dirs = Directory.GetDirectories(fullPath);
            if (dirs.Length > 0)
                items.AddRange(dirs.Select(dir => new DirectoryItem {FullPath = dir, Type = DirectoryItemType.Folder}));
        }
        catch { }
        
        #endregion
        
        #region Get Files
        
        // Try and get directories from the folder
        // ignoring any issues doing so
        try
        {
            var fs = Directory.GetDirectories(fullPath);
            if (fs.Length > 0)
                items.AddRange(fs.Select(dir => new DirectoryItem {FullPath = dir, Type = DirectoryItemType.Folder}));
        }
        catch { }
        
        #endregion

        return items;
        
    }
    
    #region Helpers

    /// <summary>
    /// Find The file or folder name from a full path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetFileFolderName(string path)
    {
        // if has no path, return empty
        if (string.IsNullOrEmpty(path))
            return string.Empty;
        // make all slashed back slashes
        var normalizePath = path.Replace('/', '\\');
        //Find the last backslash in the path
        var lastIndex = normalizePath.LastIndexOf('\\');
        // if we don't find a backslash, return the path itself
        if (lastIndex <= 0)
            return path;

        // Return the name after the last back slash
        return path.Substring(lastIndex + 1);

    }

    #endregion
    
}