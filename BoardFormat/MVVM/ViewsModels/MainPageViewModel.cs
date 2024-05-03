using System.Diagnostics;
using System.Windows.Input;

namespace BoardFormat.MVVM.ViewsModels;

public class MainPageViewModel : BaseViewModel
{
    int count;  

    public string TEST { get; private set; }

    public int Count 
    { 
        get => count; 
        set => SetProperty(ref count, value); 
    }

    public ICommand OnClickCommand { get; private set; }
    

    public MainPageViewModel()
	{
        OnClickCommand = new Command(OnCounterClicked);
        TEST = "dupa";
	}

    private void OnCounterClicked()
    {
        Debug.WriteLine("Button_Pressed");
        Count++;
    }    
}