namespace Gamestore.Api.Dtos;

public record GameDto(
    int id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
    );

public record CreateGameDto(
    int id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record UpdateGameDto(
    int id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);