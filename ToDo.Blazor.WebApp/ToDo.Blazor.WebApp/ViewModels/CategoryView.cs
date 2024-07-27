namespace ToDo.Blazor.WebApp.ViewModels
{
    public class CategoryView
    {
        public int Id { get; set; }

        public bool IsEditing { get; set; } = false;

        public string Title { get; set; }
    }
}
