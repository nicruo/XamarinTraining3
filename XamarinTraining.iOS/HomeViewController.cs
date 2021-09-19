using GalaSoft.MvvmLight.Helpers;
using UIKit;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.iOS.Services;

namespace XamarinTraining.iOS
{
    public class HomeViewController : UIViewController
    {
        private UIButton button;
        private HomeViewModel viewModel;
        private Binding binding;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            button = new UIButton(UIButtonType.System);
            button.Frame = new CoreGraphics.CGRect(0, 50, 400, 200);
            button.SetTitle("hello world", UIControlState.Normal);
            View.Add(button);

            viewModel = new HomeViewModel(new ToastService(this));
            binding = this.SetBinding(() => viewModel.ApplicationTitle).WhenSourceChanges(() => button.SetTitle(viewModel.ApplicationTitle, UIControlState.Normal));
            viewModel.ApplicationTitle = "Olá mundo2!";

            button.SetTitle("Olá mundo!", UIControlState.Normal);
            button.TouchUpInside += Button_Click;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            await viewModel.LoadApplicationTitleAsync();
        }
    }
}