namespace Phonebook;

/// <summary>
/// Абонент справочника.
/// </summary>
public class Subscriber
{
  #region Поля и свойства

  /// <summary>
  /// ИД абонента.
  /// </summary>
  public Guid Id { get; }

  /// <summary>
  /// Имя абонента.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// Номера телефонов абонента.
  /// </summary>
  public List<PhoneNumber> PhoneNumbers { get; }

  #endregion

  #region Базовый класс

  public override bool Equals(object? obj)
  {
    if (obj is Subscriber subscriber)
      return subscriber.Id == this.Id;
    return false;
  }

  public override int GetHashCode()
  {
    return this.Id.GetHashCode();
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="name">Имя абонента.</param>
  /// <param name="numbers">Номера телефона абонента.</param>
  public Subscriber(string name, List<PhoneNumber> numbers)
      : this(Guid.NewGuid(), name, numbers)
  {
  }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="id">ИД абонента.</param>
  /// <param name="name">Имя абонента.</param>
  /// <param name="numberses">Номера телефона абонента.</param>
  public Subscriber(Guid id, string name, List<PhoneNumber> numberses)
  {
    this.Name = name;
    this.PhoneNumbers = numberses;
    this.Id = id;
  }

  #endregion
}