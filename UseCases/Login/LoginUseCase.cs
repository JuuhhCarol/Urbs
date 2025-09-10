using Urbs.Services.JWT;

namespace Urbs.UseCases.Login;

public class LoginUseCase(

    IJWTService jwtService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profilesService.FindByLogin(payload.Login);

        // Se o usuário for null, retorna Fail com mensagem
        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");

        // Passa os dois valores do payload para o serviço comparar
        var passwordMatch = passwordService
            .Compare(payload.Password, user.Password);

        // Se o computador não der match, envia erro.
        if (!passwordMatch)
            return Result<LoginResponse>.Fail("Wrong Password!");

        // 
        var jwt = jwtService.CreateToken(new(
            user.ID, user.Username, user.SubscriptionID
        ));

        // Se tudo der certo, retorna o JWT
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}