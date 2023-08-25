using System.Text.RegularExpressions;

namespace Phonebook;

/// <summary>
/// Валидатор номера телефона.
/// </summary>
public static class PhoneNumberValidator
{
  /// <summary>
  /// Валидировать номер телефона.
  /// </summary>
  /// <param name="number">Объект номера телефона.</param>
  /// <exception cref="ArgumentException">Возникает, если номер телефона не в корректном формате.</exception>
  public static void Validate(PhoneNumber number)
  {
    var regex = new Regex(@"^\+\d{1,3}\s?\(\d{3}\)\s?\d{3}-\d{4}$");
    var isValid  = regex.IsMatch(number.Number);
    if (isValid)
      throw new ArgumentException("Phone number is invalid");
  }

  /// <summary>
  /// Валидировать список номеров телефонов.
  /// </summary>
  /// <param name="phoneNumbers">Список номеров телефонов.</param>
  public static void ValidateList(List<PhoneNumber> phoneNumbers)
  {
    foreach (var phoneNumber in phoneNumbers)
    {
      Validate(phoneNumber);
    }
  }
}