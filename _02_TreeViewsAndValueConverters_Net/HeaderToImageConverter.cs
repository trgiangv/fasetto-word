using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace _02_TreeViewsAndValueConverters_Net;

/// <summary>
/// Covert a fullPath to a specific image type of a drive, folder or file
/// </summary>
[ValueConversion(typeof(string), typeof(BitmapImage))]
public class HeaderToImageConverter : IValueConverter
{
    public static HeaderToImageConverter Instance = new HeaderToImageConverter();
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Get the full path
        var path = (string)value;
        
        // if path is null, ignore
        if (path == null)
            return null;
        
        // Get the name of file/folder
        var name = MainWindow.GetFileFolderName(path);
        
        // By default, we assu,e an image
        var image = "Images/file.png";

        // if the name is blank, we presume it's a drive as we cannot have blank file or folder
        if (string.IsNullOrEmpty(name))
            image = "Images/drive.png";
        else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            image = "Images/folder-closed.png";
        
        return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}