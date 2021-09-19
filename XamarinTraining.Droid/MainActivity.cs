using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using GalaSoft.MvvmLight.Helpers;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.Droid.Services;

namespace XamarinTraining.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button;
        private HomeViewModel viewModel;
        private Binding binding;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            button = FindViewById<Button>(Resource.Id.button);

            viewModel = new HomeViewModel(new ToastService(this));
            binding = this.SetBinding(() => viewModel.ApplicationTitle, () => button.Text);
            viewModel.ApplicationTitle = "Olá mundo2!";
            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            await viewModel.LoadApplicationTitleAsync();
        }
    }
}