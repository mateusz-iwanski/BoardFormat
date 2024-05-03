using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BoardFormat.MVVM.ViewsModels;

public class BaseViewModel : INotifyPropertyChanged
{
    protected Settings settings = MauiProgram.Services.GetService<IConfiguration>()
    .GetRequiredSection("Settings").Get<Settings>();

    public BaseViewModel()
	{
	}

    public event PropertyChangedEventHandler? PropertyChanged;

	protected void RaisePropertyChanged(string propertyName) 
	{ 
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
	}

	protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyname = null)
    {
        if (EqualityComparer<T>.Default.Equals(property, value))
        {
            return false;
        }
        property = value;
        RaisePropertyChanged(propertyname);
        return true;
    }

    private bool isBusy = false;
    public bool IsBusy
    {
        get
        {
            return isBusy;
        }
        set
        {
            SetProperty(ref isBusy, value);
        }
    }

}