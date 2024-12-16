namespace LibraryManagement.Models.ViewModels
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class AssignRoleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
