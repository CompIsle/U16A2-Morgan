using System.Windows;
using ToDoApplication.ViewModels;

namespace ToDoApplication.Views
{
    public partial class CreateTaskView : Window
    {
        // Constructor to initialise the view and set its data context
        public CreateTaskView()
        {
            InitializeComponent();
            CreateTaskViewModel createTaskViewModel = new CreateTaskViewModel();
            this.DataContext = createTaskViewModel;

        }
    }
}
