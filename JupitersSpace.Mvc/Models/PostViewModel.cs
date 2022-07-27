using JupitersSpace.Shared;

namespace JupitersSpace.Mvc.Models;

public record PostViewModel(
    string Title,
    string Subtitle,
    string PostText
);