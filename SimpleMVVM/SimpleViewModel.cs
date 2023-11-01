using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;

namespace SimpleMVVM
{
    public class SimpleVM : BindableBase
    {
        #region  properties
 
        //So Thu 1
        private int _soThu1;
        public int SoThu1
        {
            get => this._soThu1;
            set
            {
                SetProperty(ref this._soThu1, value);
                SubmitCommand.RaiseCanExecuteChanged();
            }
        }
 
        //So Thu 2
        private int _soThu2;
        public int SoThu2
        {
            get => _soThu2;
            set
            {
                SetProperty( ref this._soThu2, value);
                SubmitCommand.RaiseCanExecuteChanged();
            }
        }
 
        //Tong
        private int _tong;
        public int Tong
        {
            get => this._tong;
            set => SetProperty(ref this._tong, value);
        }
 
 
        //Danh sách Tổng, để binding lên DataGrid
        private ObservableCollection<SimpleClass> _lstTong;
        public ObservableCollection<SimpleClass> lstTong
        {
            get => this._lstTong;
            set => SetProperty(ref this._lstTong, value);
        }
      
        #endregion
        
        #region commmand
 
 
        public DelegateCommand SubmitCommand { get; private set; }
 
        private void OnSubmit()
        {
            ///implement xử lý ở đây
            Tong = SoThu1 + SoThu2;
            // add vào danh sách history, để cập nhật lên view
            lstTong.Add(new SimpleClass { SoA = SoThu1, SoB = SoThu2, TongAB = Tong });
        }
        private bool CanSubmit()
        {
            // chỉ được click khi nhập 2 số thứ 1 và số thứ 2
            if (SoThu1 != 0 && SoThu2 != 0)
                return true;
            else
                return false;
        }
        #endregion
 
        /// <summary>
        /// SimpleVM constructor
        /// </summary>
        public SimpleVM()
        {
            this.SubmitCommand = new DelegateCommand(this.OnSubmit, this.CanSubmit);
            // khởi tạo dữ liệu ban đầu cho datagrid
            SimpleClass temp = new SimpleClass();
            lstTong = new ObservableCollection<SimpleClass>(temp.khoiTaoDuLieu());
        }
    }
}