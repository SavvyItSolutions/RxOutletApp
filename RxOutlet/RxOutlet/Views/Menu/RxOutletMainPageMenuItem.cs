using System;

namespace RxOutlet.Views.Menu
{

    public class RxOutletMainPageMenuItem
    {
        public RxOutletMainPageMenuItem()
        {
            //TargetType = typeof(RxOutletMainPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}