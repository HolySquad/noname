namespace WebLayer.Models
{
    public class LogsViewModel
    {
        public LogsViewModel(string logs)
        {
            Logs = logs;
        }

        public string Logs { get; set; } 
    }
}