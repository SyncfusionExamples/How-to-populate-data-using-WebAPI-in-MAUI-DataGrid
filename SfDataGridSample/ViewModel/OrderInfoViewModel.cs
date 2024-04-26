using SfDataGridSample.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SfDataGridSample
{
    internal class OrderInfoViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<OrderInfo>? orderInfoCollection;

        WebApiServices webApiServices;


        public ObservableCollection<OrderInfo>? OrderInfoCollection
        {
            get { return orderInfoCollection; }
            set { this.orderInfoCollection = value; this.OnPropertyChanged(nameof(OrderInfoCollection)); }
        }


        public OrderInfoViewModel()
        {
            webApiServices = new WebApiServices();
            orderInfoCollection = new ObservableCollection<OrderInfo>();
            GenerateData();
        }

        private async void GenerateData()
        {
            OrderInfoCollection = await webApiServices.ReadDataAsync()!;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
