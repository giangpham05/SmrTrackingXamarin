using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SMR.Tracking.Platforms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : Shell
    {
        public Page1()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}