namespace AnnouncementsService.Host.RestfulAPI.Models;

public class EditingCategoryModel
{
	public required string Name { get; set; }

	public string? ParentCategoryName { get; set; }

	public string? Characteristics { get; set; }

	public string? Filtres { get; set; }
}
