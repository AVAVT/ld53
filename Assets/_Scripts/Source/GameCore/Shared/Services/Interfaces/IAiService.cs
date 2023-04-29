using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAiService
{
  public Task<string> Captcha(string question);
  public Task<TurnDecision> DoTurn(TurnStateDto state);
}