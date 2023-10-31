using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace _2_TreeViewsAndValueConverters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        # region Constructor
        /// <summary>
        ///  Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        
        # endregion
        
        # region On Loaded
        /// <summary>
        /// Load When Window is Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Get logical drives
            foreach (var logicalDrive in Directory.GetLogicalDrives())
            {
                // create a new item for tree view
                var treeView = new TreeViewItem
                {
                    // set header and path
                    Header = logicalDrive,
                    Tag = logicalDrive
                };
                
                // add dummy item
                treeView.Items.Add(null);
               
                // listen out for item being expanded
                treeView.Expanded += Folder_Expanded;
                
                FolderView.Items.Add(treeView);
            }
        }
        
        # endregion
        
        # region Folder Expanded
        /// <summary>
        /// folder expanded event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            # region Initial Checks
            var item = (TreeViewItem) sender;
            // if item only contains dummy data
            if (item.Items.Count != 1 || item.Items[0] != null) return;
            
            // clear dummy data
            item.Items.Clear();
            
            
            // get full path
            var fullPath = (string) item.Tag;
            # endregion
            
            # region Get Folders
            // create a blank list for directories
            var directories = new List<string>();
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch
            {
                // ignored
            }

            # endregion
            
            # region Get Files
            // for each directory
            directories.ForEach(directoryPath =>
            {
                // create directory item
                var subItem = new TreeViewItem()
                {
                    // Set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    
                    // and tag as full path
                    Tag = directoryPath
                };
                
                Console.WriteLine(subItem.Header);
                // add dummy item so we can expand folder
                subItem.Items.Add(null);
                
                // handle expanding use recursion function Folder_Expanded
                subItem.Expanded += Folder_Expanded;
                
                // add this item to parent
                item.Items.Add(subItem);
            });
            # endregion
        }
        # endregion
        
        # region Get File/Folder Name
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetFileFolderName(string path)
        {
            // C:\Something\a folder
            // C:\Something\a file.png
            // a file file.png
            
            // if we have no path, return empty
            if (string.IsNullOrEmpty(path)) return string.Empty;
            
            // make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');
            
            // find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');
            
            // if we don't find a backslash, return the path itself
            if (lastIndex <= 0) return path;
            
            // return the name after the last backslash
            return path.Substring(lastIndex + 1);
        }

        # endregion
    }
}