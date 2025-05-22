using System.ComponentModel.DataAnnotations;

namespace Moonglade.Configuration;

public partial class GeneralSettings : IBlogSettings
{
    [Display(Name = "Bings Site Verification Code")]
    public string BingSiteVerificationCode { get; set; }

    [Display(Name = "Yandex Verification Code")]
    public string YandexSiteVerificationCode { get; set; }

    [Display(Name = "Facebook App ID")]
    public string FacebookAppId { get; set; }

    [Display(Name = "Norton Save Web Site Verification Code")]
    public string NortonSaveWebVerificationCode { get; set; }

    [Display(Name = "World of Trust Verification Code")]
    public string WorldOfTrustVerificationCode { get; set; }
}
