using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace MobileDevelopment.ViewModels
{
    public class FilePageViewModel : INotifyPropertyChanged
    {
        private readonly Page _page;

        private readonly string _fileName = "text.txt";

        private string _text = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public FilePageViewModel(Page page)
        {
            _page = page;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadText()
        {
            var file = await FileSystem.Current.LocalStorage.CreateFileAsync(_fileName,
                CreationCollisionOption.OpenIfExists);

            Text = await file.ReadAllTextAsync();
        }

        public async Task StoreText()
        {
            var file = await FileSystem.Current.LocalStorage.CreateFileAsync(_fileName,
                CreationCollisionOption.ReplaceExisting);

            await file.WriteAllTextAsync(Text);
        }
    }
}
