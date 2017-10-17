using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxOutlet.Views.LocatePrescriptions
{
    public class LocatePrescription : TabbedPage
    {
        public LocatePrescription()
        {
            Title = "Locate Prescription";
            this.Children.Add(new PatientInfo());
            this.Children.Add(new PrescriptionLabelInfo());
            this.Children.Add(new NoPrescriptions());
        }
    }
}
