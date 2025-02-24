using System;

namespace Fishwork.Localization {

  public interface ILocalizable<T> {
    public T GetLocalizedItem(string key);
    public void SetLanguage(Language language);
  }

  public class LocalizableText : ILocalizable<Language> {
    private Language _language;

    public LocalizableText(Language language) {
      _language = language;
    }
    
    public Language GetLocalizedItem(string key) {
      throw new NotImplementedException();
    }

    public void SetLanguage(Language language) {
      _language = language;
    }
  }

}
