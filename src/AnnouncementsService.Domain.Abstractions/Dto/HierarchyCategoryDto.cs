namespace AnnouncementsService.Domain.Abstractions.Dto;

public record HierarchyCategoryDto(string Name, List<HierarchyCategoryDto> Subcategories);
