
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace _3_TreeViewsSimpleViewModel
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        private DirectoryItemType _type;
        private string _fullPath;
        private ObservableCollection<DirectoryItemViewModel> _children;
        private RelayCommand _expandCommand;
        private bool _isExpanded;
        
        public DirectoryItemType Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ImageName => Type == DirectoryItemType.Drive ? "drive" : (Type == DirectoryItemType.File ? "file" : (IsExpanded ? "folder-open" : "folder-closed"));
        
        public string FullPath
        {
            get => _fullPath;
            set
            {
                if (_fullPath != value)
                {
                    _fullPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name => Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);

        public ObservableCollection<DirectoryItemViewModel> Children
        {
            get => _children;
            set
            {
                _children = value;
                OnPropertyChanged();
            }
        }

        public bool IsExpanded
        {
            get => Children?.Count(x=>x != null) > 0;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;

                    // Update the image name based on the expanded state
                    OnPropertyChanged(nameof(ImageName));
                }
                if (value)
                {
                    Expand();
                }
                else
                {
                    ClearChildren();
                }
            }
        }

        public ICommand ExpandCommand
        {
            set
            {
                _expandCommand = value as RelayCommand;
                OnPropertyChanged();
            }
        }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);
            FullPath = fullPath;
            Type = type;
            ClearChildren();
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();
            if (Type != DirectoryItemType.File)
            {
                Children.Add(null);
            }
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
            {
                return;
            }

            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type))
            );
        }
    }

}