using System.Windows.Input;

namespace ToDoApplication.Commands
{
    public class RelayCommand : ICommand
    {
        #pragma warning disable 67
        public event EventHandler? CanExecuteChanged;
        #pragma warning restore 67

        // Action to execute
        private Action<object> _Execute { get; set; }
        // Predicate to check if execution is allowed
        private Predicate<object> _CanExecute { get; set; }

        // Constructor to initialise the command
        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {
            _Execute = executeMethod;
            _CanExecute = canExecuteMethod;
        }

        // Method to determine if the command can execute
        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        // Method to execute the command
        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}
