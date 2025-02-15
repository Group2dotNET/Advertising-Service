namespace AnnouncementsService.Host.RestfulAPI.Models;

public class HierarchyCategoryModel
{
	public required string Name { get; set; }

	public List<HierarchyCategoryModel>? ChildCategories { get; set; }
}