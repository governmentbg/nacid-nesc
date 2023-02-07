namespace StudentCard.Infrastructure.DomainValidation.Enums
{
    public enum UserErrorCode
    {
        UserEmailTaken = 201,
        UserInvalidCredentials = 202,
        UserActivationTokenAlreadyUsed = 203,
        UserActivationTokenExpired = 204,
        UserChangePasswordNewPasswordsMismatch = 205,
        UserChangePasswordOldPasswordMismatch = 206,
        UserDeactivated = 207,
        UserNotFound = 208,
        UserIncorrectBirthDate = 209,
        UserInvalidEmail = 210,
        UserInvalidPassword = 211,
        UserChangeEmailNewEmailsMismatch = 212,
        NewEmailActivationTokenExpired = 213,
        NewEmailActivationTokenAlreadyUsed = 214,
        NewPasswordRecoveryTokenExpired = 215,
        NewPasswordRecoveryTokenAlreadyUsed = 216,
        RegiXConnectionFailed = 217,
        UserRegisterNotFoundWithGivenIdentificator = 218,
        UserRegisterEmailMismatch = 219,
        UserRegisterEmailNotFoundInRDPZSD = 220,
        UserAlreadyHasProfileWIthGivenUan = 221,
        UserRegisterNotActive = 222,
        EmptyRegixResponse = 223
    }
}
