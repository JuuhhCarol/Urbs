namespace Urbs.UseCases.Login;

public record LoginPayload(
    string Login,
    string Password
);