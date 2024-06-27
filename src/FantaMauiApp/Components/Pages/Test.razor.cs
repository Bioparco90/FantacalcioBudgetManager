namespace FantaMauiApp.Components.Pages
{
    public partial class Test
    {
        public string? TeamName { get; set; } = "";
        public bool ChangePhoto {  get; set; }

        public async Task AddTeam()
        {
            if (string.IsNullOrWhiteSpace(TeamName))
            {
                return;
            }
            await TeamRepository.InsertAsync(new() { Name = TeamName });
        }
    }
}
