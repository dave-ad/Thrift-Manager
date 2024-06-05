namespace ThriftManager.Web.Models;

public class CreateMemberViewModel
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(50)]
    public string OtherNames { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    [Phone]
    public string MobileNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string NIN { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string AccountName { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string AccountNumber { get; set; } = string.Empty;

    [Required]
    public int BankId { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string BVN { get; set; } = string.Empty;

    public bool IsSuccessful { get; set; }
    public string Error { get; set; }
}
