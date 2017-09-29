using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RxOutlet.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RxOutletMainPageMaster : ContentPage
    {
        public ListView ListView;

        public RxOutletMainPageMaster()
        {
            InitializeComponent();

            BindingContext = new RxOutletMainPageMasterViewModel();
            ListView = MenuItemsListView;
        }        
    }
}