namespace AnnouncementsService.Domain.Abstractions.Dto;

/// <summary>
/// Dto для полного отображения категории
/// </summary>
/// <param name="Name">Имя категории</param>
/// <param name="ParentCategoryName">Имя родительской категории</param>
/// <param name="Characteristics">Характеристики категории</param>
/// <param name="Filtres">Фильтры категории</param>
public record FullCategoryDto(string Name, string? ParentCategoryName, string? Characteristics, string? Filtres);


public record CategoryDto(string Name, string? ParentCategoryName);