using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace _02_TreeViewsAndValueConverters_Net
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region On Loaded
        /// <summary>
        /// When the application first open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Get Every logical drive on machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // Create a new item for it
                var item = new TreeViewItem()
                {
                    // Set the header
                    Header = drive,
                    // Add the full path
                    Tag = drive
                };
                // Add a dummy item
                item.Items.Add(null);
                
                // Listen out for item being expanded
                item.Expanded += Folder_Expanded;
                
                // Add it to the main TreeView
                FolderView.Items.Add(item);
            }
        }
        #endregion

        #region Folder Expanded
        /// <summary>
        /// When a folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region initial check
            
            var item = (TreeViewItem)sender;
            
            // if the item only contains the dymmy data
            if (item.Items.Count != 1 && item.Items[0] != null)
                return;
            
            // Clear dummy data
            item.Items.Clear();
            
            // Get full path
            var fullPath = (string)item.Tag;
            
            #endregion

            #region Get Folders

            // Create a blank list for directories
            var directories = new List<String>();
            
            // Try and get directories from the folder
            // ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            // for each directory...
            directories.ForEach(directoryPath =>
            {
                // Create directory item
                var subItem = new TreeViewItem()
                {
                    // set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    // And tag as full path
                    Tag = directoryPath
                };
                // Add dummy item so we can expand folder
                subItem.Items.Add(null);
                
                // Handle Expanding
                subItem.Expanded += Folder_Expanded;
                
                // Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion

            #region Get Files

            // Create a blank list for directories
            var files = new List<String>();
            // Try and get directories from the folder
            // ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            // for each files...
            files.ForEach(filePath =>
            {
                // Create file item
                var subItem = new TreeViewItem()
                {
                    // set header as file name
                    Header = GetFileFolderName(filePath),
                    // And tag as full path
                    Tag = filePath
                };
                
                // Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion
        }
        #endregion

        #region helpers

        /// <summary>
        /// Find The file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
}
