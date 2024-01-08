using HotChocolate.Subscriptions;

namespace N6GraphQLab.GraphQL;

public record TimerTick(string Tick);

public class Subscription
{
  #region Server side streaming sample

  /// <summary>
  /// for: Server side streaming
  /// </summary>
  public async IAsyncEnumerable<TimerTick> OnTimerTickStream([Service] ITopicEventReceiver eventReceiver)
  {
    do
    {
      yield return new TimerTick(Tick: DateTime.Now.ToString("HH:mm:ss.fff"));
      await Task.Delay(1000);
    }
    while (true);
  }

  /// <summary>
  /// Server side streaming
  /// </summary>
  [Subscribe(With = nameof(OnTimerTickStream))]
  public TimerTick OnTimerTick([EventMessage] TimerTick timerTick)
    => timerTick;

  #endregion

  /// <summary>
  /// Subscribe mutation evnet sample
  /// </summary>
  [Subscribe]
  [Topic(nameof(Mutation.AddProdcut))]
  public ProductAddedPayload OnProductAdded([EventMessage] ProductAddedPayload message)
    => message;

}
