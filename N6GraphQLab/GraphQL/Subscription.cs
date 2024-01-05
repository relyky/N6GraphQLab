using HotChocolate.Subscriptions;

namespace N6GraphQLab.GraphQL;

public record TimerTick(string Tick);

public class Subscription
{
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
}
