using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Attenderizer.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RolePage : ContentPage
    {
        //private ObservableCollection<StudentAttendance> myList;

        //ObservableCollection<StudentAttendance> MyList
        //{
        //    get { return myList; }
        //    set { myList = value; }
        //}
        public RolePage()
        {
            InitializeComponent();
            //this.BindingContext = this;

            //MyList = new ObservableCollection<StudentAttendance>();

            //for (int i = 1; i < 10; i++)
            //{
            //    MyList.Add(new StudentAttendance() { Name = "Student" + i.ToString(), Image = "usa.png", Image2 = "lk" });
            //}

            //StudentAttendenceList.ItemsSource = MyList;

        }
    }
}