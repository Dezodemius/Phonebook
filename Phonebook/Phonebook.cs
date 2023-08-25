namespace Phonebook;

/// <summary>
/// Телефонная книга.
/// </summary>
public class Phonebook
{
  #region Поля и свойства

  /// <summary>
  /// Абоненты в книге.
  /// </summary>
  private readonly List<Subscriber> subscribers;

  #endregion

  #region Методы

  /// <summary>
  /// Получить абонента из книги.
  /// </summary>
  /// <param name="id">ИД абонента.</param>
  /// <returns>Найденный абонент в книге.</returns>
  public Subscriber GetSubscriber(Guid id)
  {
    return this.subscribers.Single(s => s.Id == id);
  }

  /// <summary>
  /// Получить всех абонентов.
  /// </summary>
  /// <returns>Список всех абонентов.</returns>
  public IEnumerable<Subscriber> GetAll()
  {
    return this.subscribers;
  }

  /// <summary>
  /// Добавить абонента в книгу.
  /// </summary>
  /// <param name="subscriber">Абонент, которого нужно добавить.</param>
  /// <exception cref="InvalidOperationException">Возникает, если абонент уже существует в книге.</exception>
  public void AddSubscriber(Subscriber subscriber)
  {
    if (this.subscribers.Contains(subscriber))
      throw new InvalidOperationException("Unable to add subscriber. Subscriber exists");

    PhoneNumberValidator.ValidateList(subscriber.PhoneNumbers);

    this.subscribers.Add(subscriber);
  }

  /// <summary>
  /// Добавить номер для абонента.
  /// </summary>
  /// <param name="subscriber">Абонент, которому нужно добавить номер.</param>
  /// <param name="number">Добавляемый номер абонента.</param>
  public void AddNumberToSubscriber(Subscriber subscriber, PhoneNumber number)
  {
    var newNumbers = new List<PhoneNumber>(subscriber.PhoneNumbers)
    {
        number
    };
    var subscriberWithNewNumber = new Subscriber(subscriber.Id, subscriber.Name, newNumbers);

    this.UpdateSubscriber(subscriber, subscriberWithNewNumber);
  }

  /// <summary>
  /// Сменить имя абонента.
  /// </summary>
  /// <param name="subscriber">Абонент, которому нужно сменить имя.</param>
  /// <param name="newName">Новое имя абонента.</param>
  public void RenameSubscriber(Subscriber subscriber, string newName)
  {
    var subscriberWithNewName = new Subscriber(subscriber.Id, newName, subscriber.PhoneNumbers);

    this.UpdateSubscriber(subscriber, subscriberWithNewName);
  }

  /// <summary>
  /// Обновить абонента в книге.
  /// </summary>
  /// <param name="oldSubscriber">Старый абонент.</param>
  /// <param name="newSubscriber">Новый абонент.</param>
  public void UpdateSubscriber(Subscriber oldSubscriber, Subscriber newSubscriber)
  {
    var foundSubscriber = this.GetSubscriber(oldSubscriber.Id);
    int foundSubscriberPlace = this.subscribers.FindIndex(s => s.Id == foundSubscriber.Id);
    this.subscribers[foundSubscriberPlace] = newSubscriber;
  }

  /// <summary>
  /// Удалить абонента в книге.
  /// </summary>
  /// <param name="subscriberToDelete">Абонент, которого нужно удалить из книги.</param>
  public void DeleteSubscriber(Subscriber subscriberToDelete)
  {
    this.subscribers.Remove(subscriberToDelete);
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  public Phonebook()
      : this(new List<Subscriber>())
  {
  }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="subscribers">Список абонентов для инициализации книги.</param>
  public Phonebook(List<Subscriber> subscribers)
  {
    this.subscribers = subscribers;
  }

  #endregion
}