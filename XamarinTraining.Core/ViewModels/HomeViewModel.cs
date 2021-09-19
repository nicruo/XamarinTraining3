using GalaSoft.MvvmLight;
using System.Threading.Tasks;
using XamarinTraining.Core.Domain;
using XamarinTraining.Core.Services;

namespace XamarinTraining.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private DataService dataService;
        private IToastService toastService;
        private int counter;

        private string applicationTitle;
        public string ApplicationTitle
        {
            get => applicationTitle;
            set => Set(nameof(ApplicationTitle), ref applicationTitle, value);
        }

        public HomeViewModel(IToastService toastService)
        {
            dataService = new DataService();
            this.toastService = toastService;
        }

        public async Task LoadApplicationTitleAsync()
        {
            toastService.ShowToast("button clicked");
            await Task.Delay(1000);
            ApplicationTitle = counter++ + " volta(s)";
            Character result = await dataService.GetCharacterAsync(2);
            ApplicationTitle = "Result = " + result;
        }
    }
}